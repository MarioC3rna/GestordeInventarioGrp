using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;

namespace Proyecto_Base_de_Datos
{
    public partial class ActualizarForm : Form
    {
        private int productoIdActual = -1;
        private string codigoProductoActual = "";
        private string rutaImagenAnterior = "";

        // ✅ IDs actuales de las tablas relacionadas
        private int unidadMedidaIdActual = -1;
        private int proveedorIdActual = -1;
        private int servicioBienIdActual = -1;
        private int categoriaIdActual = -1;

        public ActualizarForm()
        {
            InitializeComponent();
            // ✅ Hacer el campo de tipo servicio/bien de solo lectura
            textBoxTipoServicioTipo.ReadOnly = true;
            textBoxTipoServicioTipo.BackColor = SystemColors.Control;
        }

        private void ActualizarForm_Load(object sender, EventArgs e)
        {
            // ✅ Cargar categorías disponibles
            CargarCategorias();
            // ✅ Cargar proveedores disponibles
            CargarProveedores();
            DeshabilitarCampos();
        }

        private void CargarCategorias()
        {
            try
            {
                using (var connection = DatabaseConnection.CreateConnection())
                {
                    string query = @"
    SELECT Categoria_Id, Categoria_Nombre
     FROM Invt.Tb_Categorias
     ORDER BY Categoria_Nombre";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        comboBoxCategoria.DataSource = data;
                        comboBoxCategoria.DisplayMember = "Categoria_Nombre";
                        comboBoxCategoria.ValueMember = "Categoria_Id";
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No hay categorías disponibles.", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProveedores()
        {
            try
            {
                using (var connection = DatabaseConnection.CreateConnection())
                {
                    string query = @"
    SELECT Proveedor_Id, Proveedor_Nombre
      FROM Invt.Tb_Proveedores
    ORDER BY Proveedor_Nombre";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        comboBoxProveedor.DataSource = data;
                        comboBoxProveedor.DisplayMember = "Proveedor_Nombre";
                        comboBoxProveedor.ValueMember = "Proveedor_Id";
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No hay proveedores disponibles.", "Advertencia",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeshabilitarCampos()
        {
            txtBoxCodigoProducto.Enabled = false;
            txtBoxNombreProducto.Enabled = false;
            textBoxDescripcion.Enabled = false;
            textBoxCostoUnitario.Enabled = false;
            textBoxDescuento.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBoxUnidadMedida.Enabled = false;
            textBoxAbrevLongitud.Enabled = false;
            textBoxPeso.Enabled = false;
            textBoxAbrevPeso.Enabled = false;
            comboBoxProveedor.Enabled = false;
            textBoxTipoServicioTipo.Enabled = false;
            comboBoxCategoria.Enabled = false;
            buttonImagen.Enabled = false;
            textBoxStock.Enabled = false;
            btnACTUALIZAR.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtBoxCodigoProducto.Enabled = true;
            txtBoxNombreProducto.Enabled = true;
            textBoxDescripcion.Enabled = true;
            textBoxCostoUnitario.Enabled = true;
            textBoxDescuento.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBoxUnidadMedida.Enabled = true;
            textBoxAbrevLongitud.Enabled = true;
            textBoxPeso.Enabled = true;
            textBoxAbrevPeso.Enabled = true;
            comboBoxProveedor.Enabled = true;
            // ✅ El tipo de servicio/bien NO se puede editar
            textBoxTipoServicioTipo.Enabled = false;
            comboBoxCategoria.Enabled = true;
            buttonImagen.Enabled = true;
    
 // ✅ Stock se habilita solo si NO es servicio
         VerificarTipoYHabilitarStock();
          
    btnACTUALIZAR.Enabled = true;
        }

   // ✅ Método para verificar el tipo y habilitar/deshabilitar stock
        private void VerificarTipoYHabilitarStock()
        {
  string tipoServicioBien = textBoxTipoServicioTipo.Text.Trim();
     
    if (tipoServicioBien.Equals("Servicio", StringComparison.OrdinalIgnoreCase))
            {
        textBoxStock.Enabled = false;
       textBoxStock.Text = "0";
    textBoxStock.BackColor = SystemColors.Control;
        }
       else
            {
              textBoxStock.Enabled = true;
     textBoxStock.BackColor = SystemColors.Window;
     }
      }

  private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string codigoProducto = txtBoxCodigoProductoB.Text.Trim();
            string nombreProducto = textBoxNombreProductoBU.Text.Trim();

            if (string.IsNullOrEmpty(codigoProducto) && string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Por favor ingresa el código o nombre del producto.", "Advertencia",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LimpiarCamposResultados();

            // ✅ Consulta extendida con datos de unidad de medida completa
            string query = @"
     SELECT 
   P.Producto_Id,
 P.Producto_Codigo,
    P.Producto_Nombre,
P.Producto_Descripcion,
       P.Producto_CostoUnitario,
     P.Producto_Descuento,
        P.Producto_FechaIngreso,
        P.UnidadMedida_Id,
  P.Proveedor_Id,
         P.ServicioBien_Id,
       P.Categoria_Id,
      P.Producto_ImagenRuta,
UM.UnidadMedida_Longitud,
      UM.UnidadMedida_AbrevLongitud,
         UM.UnidadMedida_Peso,
                UM.UnidadMedida_AbrevPeso,
PR.Proveedor_Nombre,
SB.ServicioBien_Tipo,
      C.Categoria_Nombre,
             ISNULL(SUM(I.Cantidad_Disponible), 0) AS Stock_Total
FROM Invt.Tb_Productos P
            INNER JOIN Invt.Tb_UnidadMedidas UM ON P.UnidadMedida_Id = UM.UnidadMedida_Id
     INNER JOIN Invt.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
      INNER JOIN Invt.Tb_ServiciosBienes SB ON P.ServicioBien_Id = SB.ServicioBien_Id
       INNER JOIN Invt.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
      LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
     WHERE (P.Producto_Codigo = @Codigo OR P.Producto_Nombre = @Nombre)
GROUP BY 
  P.Producto_Id, P.Producto_Codigo, P.Producto_Nombre,
   P.Producto_Descripcion, P.Producto_CostoUnitario,
 P.Producto_Descuento, P.Producto_FechaIngreso,
     P.UnidadMedida_Id, P.Proveedor_Id, P.ServicioBien_Id,
                P.Categoria_Id, P.Producto_ImagenRuta,
  UM.UnidadMedida_Longitud, UM.UnidadMedida_AbrevLongitud,
         UM.UnidadMedida_Peso, UM.UnidadMedida_AbrevPeso,
       PR.Proveedor_Nombre, SB.ServicioBien_Tipo, C.Categoria_Nombre";

            using (var connection = DatabaseConnection.CreateConnection())
    using (var command = new SqlCommand(query, connection))
            {
 command.Parameters.AddWithValue("@Codigo", codigoProducto);
      command.Parameters.AddWithValue("@Nombre", nombreProducto);

            try
  {
        connection.Open();
        var reader = command.ExecuteReader();

 if (reader.Read())
           {
  productoIdActual = Convert.ToInt32(reader["Producto_Id"]);
        codigoProductoActual = reader["Producto_Codigo"].ToString();

        // ✅ Guardar IDs actuales
            unidadMedidaIdActual = Convert.ToInt32(reader["UnidadMedida_Id"]);
       proveedorIdActual = Convert.ToInt32(reader["Proveedor_Id"]);
           servicioBienIdActual = Convert.ToInt32(reader["ServicioBien_Id"]);
              categoriaIdActual = Convert.ToInt32(reader["Categoria_Id"]);

         // ✅ Llenar campos básicos
           txtBoxCodigoProducto.Text = reader["Producto_Codigo"].ToString();
                txtBoxNombreProducto.Text = reader["Producto_Nombre"].ToString();
              textBoxDescripcion.Text = reader["Producto_Descripcion"].ToString();
    textBoxCostoUnitario.Text = reader["Producto_CostoUnitario"].ToString();
       textBoxDescuento.Text = reader["Producto_Descuento"].ToString();
        dateTimePicker1.Value = Convert.ToDateTime(reader["Producto_FechaIngreso"]);
    textBoxStock.Text = reader["Stock_Total"].ToString();

        // ✅ Llenar campos de UNIDAD DE MEDIDA
         textBoxUnidadMedida.Text = reader["UnidadMedida_Longitud"].ToString();
              textBoxAbrevLongitud.Text = reader["UnidadMedida_AbrevLongitud"].ToString();
textBoxPeso.Text = reader["UnidadMedida_Peso"].ToString();
     textBoxAbrevPeso.Text = reader["UnidadMedida_AbrevPeso"].ToString();

             // ✅ Seleccionar PROVEEDOR en el ComboBox
         string proveedorNombre = reader["Proveedor_Nombre"].ToString();
       for (int i = 0; i < comboBoxProveedor.Items.Count; i++)
   {
      DataRowView row = (DataRowView)comboBoxProveedor.Items[i];
  if (row["Proveedor_Nombre"].ToString() == proveedorNombre)
   {
      comboBoxProveedor.SelectedIndex = i;
        break;
     }
     }

              // ✅ Llenar TIPO SERVICIO/BIEN (solo lectura)
   textBoxTipoServicioTipo.Text = reader["ServicioBien_Tipo"].ToString();

        // ✅ Seleccionar CATEGORÍA en el ComboBox
 string categoriaNombre = reader["Categoria_Nombre"].ToString();
             for (int i = 0; i < comboBoxCategoria.Items.Count; i++)
         {
   DataRowView row = (DataRowView)comboBoxCategoria.Items[i];
             if (row["Categoria_Nombre"].ToString() == categoriaNombre)
          {
     comboBoxCategoria.SelectedIndex = i;
          break;
             }
       }

    // ✅ Cargar imagen
   rutaImagenAnterior = "";
    if (reader["Producto_ImagenRuta"] != DBNull.Value)
     {
    string rutaImagen = reader["Producto_ImagenRuta"].ToString();
     if (!string.IsNullOrEmpty(rutaImagen))
       {
      rutaImagenAnterior = rutaImagen;
            Image imagen = ImageHelper.LoadProductImage(rutaImagen);
    if (imagen != null)
              {
     pictureBoxImagen.Image = imagen;
     pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
    }
              else
           {
            pictureBoxImagen.Image = null;
       }
             }
        else
     {
            pictureBoxImagen.Image = null;
    }
         }
             else
   {
          pictureBoxImagen.Image = null;
         }

    MessageBox.Show("✅ Producto encontrado. Puedes modificar los datos.", "Resultado",
MessageBoxButtons.OK, MessageBoxIcon.Information);

            HabilitarCampos();
          }
          else
   {
          MessageBox.Show("❌ No se encontró ningún producto con ese criterio.",
  "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
       DeshabilitarCampos();
          }

   reader.Close();
         }
                catch (Exception ex)
      {
       MessageBox.Show("Error al buscar el producto: " + ex.Message,
      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     }
       }
        }

        private void btnACTUALIZAR_Click(object sender, EventArgs e)
        {
       if (productoIdActual == -1)
 {
     MessageBox.Show("⚠️ Primero debes buscar un producto.", "Advertencia",
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
            }

       // ✅ Validar campos vacíos (excluyendo stock si es servicio)
       var cajasRequeridas = new List<TextBox> {
         txtBoxCodigoProducto, txtBoxNombreProducto, textBoxDescripcion,
     textBoxCostoUnitario, textBoxDescuento,
     textBoxUnidadMedida, textBoxAbrevLongitud, textBoxPeso, textBoxAbrevPeso
    };

         // ✅ Solo validar stock si NO es servicio
      string tipoServicioBien = textBoxTipoServicioTipo.Text.Trim();
    if (!tipoServicioBien.Equals("Servicio", StringComparison.OrdinalIgnoreCase))
            {
                cajasRequeridas.Add(textBoxStock);
       }

   var cajasVacias = cajasRequeridas.Where(tb => string.IsNullOrWhiteSpace(tb.Text)).ToList();

      if (cajasVacias.Any())
        {
             MessageBox.Show("⚠️ Todos los campos son obligatorios.", "Advertencia",
          MessageBoxButtons.OK, MessageBoxIcon.Warning);
             return;
            }

            // ✅ Validar que se haya seleccionado una categoría
            if (comboBoxCategoria.SelectedValue == null)
            {
   MessageBox.Show("⚠️ Debes seleccionar una categoría.", "Validación",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
            }

      // ✅ Validar que se haya seleccionado un proveedor
     if (comboBoxProveedor.SelectedValue == null)
            {
           MessageBox.Show("⚠️ Debes seleccionar un proveedor.", "Validación",
  MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
            }

       decimal peso = Convert.ToDecimal(textBoxPeso.Text);
     string abrevPeso = textBoxAbrevPeso.Text.Trim();

            int proveedorId = Convert.ToInt32(comboBoxProveedor.SelectedValue);
            string servicioTipo = textBoxTipoServicioTipo.Text.Trim();
    int categoriaId = Convert.ToInt32(comboBoxCategoria.SelectedValue);

            // ✅ Actualizar producto usando procedimientos almacenados
     try
         {
             using (var connection = DatabaseConnection.CreateConnection())
      {
        connection.Open();
   using (var transaction = connection.BeginTransaction())
       {
     try
       {
     // Datos capturados
         string codigoProducto = txtBoxCodigoProducto.Text.Trim();
 string nombreProducto = txtBoxNombreProducto.Text.Trim();
         string descripcion = textBoxDescripcion.Text.Trim();
      decimal costoUnitario = Convert.ToDecimal(textBoxCostoUnitario.Text);
   decimal descuento = Convert.ToDecimal(textBoxDescuento.Text);
   
    // ✅ Si es servicio, stock es 0
           int stockDisponible = tipoServicioBien.Equals("Servicio", StringComparison.OrdinalIgnoreCase) 
         ? 0 
   : Convert.ToInt32(textBoxStock.Text);
      
         DateTime fechaIngreso = dateTimePicker1.Value;

          // Actualizar datos básicos del producto
         string cmdText = @"
    UPDATE Invt.Tb_Productos
  SET 
      Producto_Codigo = @Codigo,
  Producto_Nombre = @Nombre,
      Producto_Descripcion = @Descripcion,
      Producto_CostoUnitario = @CostoUnitario,
   Producto_Descuento = @Descuento,
  Producto_FechaIngreso = @FechaIngreso,
      UnidadMedida_Id = @UnidadMedidaId,
   Proveedor_Id = @ProveedorId,
      ServicioBien_Id = @ServicioBienId,
      Categoria_Id = @CategoriaId,
    Producto_ImagenRuta = @ImagenRuta
    WHERE Producto_Id = @ProductoId";

       using (var cmd = new SqlCommand(cmdText, connection, transaction))
     {
       cmd.Parameters.AddWithValue("@Codigo", codigoProducto);
          cmd.Parameters.AddWithValue("@Nombre", nombreProducto);
       cmd.Parameters.AddWithValue("@Descripcion", descripcion);
         cmd.Parameters.AddWithValue("@CostoUnitario", costoUnitario);
 cmd.Parameters.AddWithValue("@Descuento", descuento);
    cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
   cmd.Parameters.AddWithValue("@UnidadMedidaId", unidadMedidaIdActual);
        cmd.Parameters.AddWithValue("@ProveedorId", proveedorId);
    cmd.Parameters.AddWithValue("@ServicioBienId", servicioBienIdActual);
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
         cmd.Parameters.AddWithValue("@ImagenRuta", (object)rutaImagenAnterior ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ProductoId", productoIdActual);

       cmd.ExecuteNonQuery();
       }

         transaction.Commit();

                MessageBox.Show("✅ Producto actualizado con éxito.", "Éxito",
    MessageBoxButtons.OK, MessageBoxIcon.Information);

     // Limpiar campos y deshabilitar edición
                LimpiarTodosCampos();
           DeshabilitarCampos();
             }
    catch (Exception ex)
     {
      transaction.Rollback();
        MessageBox.Show("Error al actualizar el producto: " + ex.Message,
          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
    }
}
            }
          catch (Exception ex)
{
                MessageBox.Show("Error al establecer conexión: " + ex.Message,
  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    }

        private void LimpiarTodosCampos()
        {
            txtBoxCodigoProductoB.Clear();
            textBoxNombreProductoBU.Clear();
            LimpiarCamposResultados();
        }

        private void LimpiarCamposResultados()
        {
            productoIdActual = -1;
            codigoProductoActual = "";
            rutaImagenAnterior = "";
            unidadMedidaIdActual = -1;
            proveedorIdActual = -1;
            servicioBienIdActual = -1;
            categoriaIdActual = -1;

            txtBoxCodigoProducto.Clear();
            txtBoxNombreProducto.Clear();
            textBoxDescripcion.Clear();
            textBoxCostoUnitario.Clear();
            textBoxDescuento.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBoxUnidadMedida.Clear();
            textBoxAbrevLongitud.Clear();
            textBoxPeso.Clear();
            textBoxAbrevPeso.Clear();
            textBoxTipoServicioTipo.Clear();
            textBoxStock.Clear();
            pictureBoxImagen.Image = null;

            if (comboBoxProveedor.Items.Count > 0)
                comboBoxProveedor.SelectedIndex = 0;

            if (comboBoxCategoria.Items.Count > 0)
                comboBoxCategoria.SelectedIndex = 0;
        }

        private void buttonAtras_Click(object sender, EventArgs e)
     {
  // ✅ Volver al formulario de opciones sin cerrar la aplicación
            OpcionesForm opcionesForm = new OpcionesForm();
            opcionesForm.Show();
       this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Evento vacío para el label del título
        }

        private void buttonImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Seleccionar imagen del producto";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Cargar la imagen en el PictureBox
                        Image imagen = Image.FromFile(openFileDialog.FileName);
                        pictureBoxImagen.Image = imagen;
                        pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;

                        // Guardar la ruta de la imagen
                        rutaImagenAnterior = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message,
          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBoxCodigoProductoB_TextChanged(object sender, EventArgs e)
        {
            // Evento para cuando cambia el texto del código de búsqueda
        }

    }
}