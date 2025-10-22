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

        private string connectionString = "Data Source=192.168.116.129\\MYISTANCE;Initial Catalog=Db_EmpresaDev;User ID=admin_inventario;Password=Adm!n2025$;Encrypt=True;TrustServerCertificate=True;";
        private int productoIdActual = -1;

   public ActualizarForm()
        {
            InitializeComponent();
        }

        private void ActualizarForm_Load(object sender, EventArgs e)
        {
     // Cargar ComboBox
            CargarComboBox(comboBoxUnidadMedida, "Invt.Tb_UnidadMedidas", "UnidadMedida_Id", "UnidadMedida_Longitud");
            CargarComboBox(comboBoxProveedor, "Invt.Tb_Proveedores", "Proveedor_Id", "Proveedor_Nombre");
        CargarComboBox(comboBoxTipoServicioProducto, "Invt.Tb_ServiciosBienes", "ServicioBien_Id", "ServicioBien_Nombre");
            CargarComboBox(comboBoxCategoria, "Invt.Tb_Categorias", "Categoria_Id", "Categoria_Nombre");

  comboBoxUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
   comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBoxTipoServicioProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

      DeshabilitarCampos();
        }

        private void CargarComboBox(ComboBox combo, string tabla, string idCol, string nombreCol)
        {
            try
   {
using (SqlConnection connection = new SqlConnection(connectionString))
      {
         string query = $"SELECT {idCol}, {nombreCol} FROM {tabla}";
    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
             DataTable data = new DataTable();
   adapter.Fill(data);

   combo.DataSource = data;
        combo.DisplayMember = nombreCol;
     combo.ValueMember = idCol;
                    combo.SelectedIndex = -1;
   }
  }
            catch (Exception ex)
            {
 MessageBox.Show("❌ Error al cargar datos: " + ex.Message);
            }
        }

 private void DeshabilitarCampos()
        {
            txtBoxNombreProducto.Enabled = false;
    textBoxDescripcion.Enabled = false;
            textBoxCostoUnitario.Enabled = false;
            textBoxDescuento.Enabled = false;
            dateTimePicker1.Enabled = false;
     comboBoxUnidadMedida.Enabled = false;
            comboBoxProveedor.Enabled = false;
        comboBoxTipoServicioProducto.Enabled = false;
            comboBoxCategoria.Enabled = false;
            buttonImagen.Enabled = false;
   textBoxStock.Enabled = false; // ✅ Agregar control del stock
   btnACTUALIZAR.Enabled = false;
        }

    private void HabilitarCampos()
        {
txtBoxNombreProducto.Enabled = true;
            textBoxDescripcion.Enabled = true;
      textBoxCostoUnitario.Enabled = true;
    textBoxDescuento.Enabled = true;
            dateTimePicker1.Enabled = true;
     comboBoxUnidadMedida.Enabled = true;
    comboBoxProveedor.Enabled = true;
   comboBoxTipoServicioProducto.Enabled = true;
        comboBoxCategoria.Enabled = true;
  buttonImagen.Enabled = true;
    textBoxStock.Enabled = true; // ✅ Habilitar edición del stock
 btnACTUALIZAR.Enabled = true;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
  // 🔹 Obtener criterios de búsqueda de los campos CORRECTOS
            string codigoProducto = txtBoxCodigoProductoB.Text.Trim();
            string nombreProducto = textBoxNombreProductoBU.Text.Trim(); // ✅ AHORA ES CORRECTO
            string categoriaProducto = textBoxCategoriaProductoBU.Text.Trim();

            // 🔹 Validar que al menos haya algo escrito
  if (string.IsNullOrEmpty(codigoProducto) && string.IsNullOrEmpty(nombreProducto) && string.IsNullOrEmpty(categoriaProducto))
            {
       MessageBox.Show("Por favor ingresa el código, nombre o categoría del producto.", "Advertencia",
              MessageBoxButtons.OK, MessageBoxIcon.Warning);
         return;
            }

 // 🔹 Limpiar campos de resultados
            LimpiarCamposResultados();

  // 🔹 Consulta SQL - CORREGIDA para ser consistente con BuscarForm
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
       P.Producto_Imagen,
    UM.UnidadMedida_Longitud AS UnidadMedida,
    PR.Proveedor_Nombre AS Proveedor,
    SB.ServicioBien_Nombre AS ServicioBien,
   C.Categoria_Nombre AS Categoria,
            ISNULL(SUM(I.Cantidad_Disponible), 0) AS Stock_Total
     FROM Invt.Tb_Productos P
      INNER JOIN Invt.Tb_UnidadMedidas UM ON P.UnidadMedida_Id = UM.UnidadMedida_Id
        INNER JOIN Invt.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
        INNER JOIN Invt.Tb_ServiciosBienes SB ON P.ServicioBien_Id = SB.ServicioBien_Id
        INNER JOIN Invt.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
        LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
      WHERE (P.Producto_Codigo = @Codigo 
               OR P.Producto_Nombre = @Nombre 
  OR C.Categoria_Nombre = @Categoria)
        GROUP BY 
 P.Producto_Id, P.Producto_Codigo, P.Producto_Nombre,
 P.Producto_Descripcion, P.Producto_CostoUnitario,
            P.Producto_Descuento, P.Producto_FechaIngreso,
   P.UnidadMedida_Id, P.Proveedor_Id, P.ServicioBien_Id,
            P.Categoria_Id, P.Producto_Imagen, UM.UnidadMedida_Longitud,
        PR.Proveedor_Nombre, SB.ServicioBien_Nombre, C.Categoria_Nombre";

    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        command.Parameters.AddWithValue("@Codigo", codigoProducto);
    command.Parameters.AddWithValue("@Nombre", nombreProducto);
 command.Parameters.AddWithValue("@Categoria", categoriaProducto);

        try
        {
     connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
      {
       // ✅ Almacenar ID del producto para actualización
                productoIdActual = Convert.ToInt32(reader["Producto_Id"]);

                // ✅ Llenar campos con datos encontrados
         txtBoxNombreProducto.Text = reader["Producto_Nombre"].ToString();
      textBoxDescripcion.Text = reader["Producto_Descripcion"].ToString();
                textBoxCostoUnitario.Text = reader["Producto_CostoUnitario"].ToString();
     textBoxDescuento.Text = reader["Producto_Descuento"].ToString();
         dateTimePicker1.Value = Convert.ToDateTime(reader["Producto_FechaIngreso"]);

  // ✅ Mostrar stock disponible
     textBoxStock.Text = reader["Stock_Total"].ToString();

                // ✅ Seleccionar valores en ComboBoxes
    comboBoxUnidadMedida.SelectedValue = reader["UnidadMedida_Id"];
    comboBoxProveedor.SelectedValue = reader["Proveedor_Id"];
     comboBoxTipoServicioProducto.SelectedValue = reader["ServicioBien_Id"];
         comboBoxCategoria.SelectedValue = reader["Categoria_Id"];

    // ✅ Cargar imagen si existe
      if (reader["Producto_Imagen"] != DBNull.Value)
    {
        byte[] imagenBytes = (byte[])reader["Producto_Imagen"];
       using (MemoryStream ms = new MemoryStream(imagenBytes))
        {
            pictureBoxImagen.Image = Image.FromStream(ms);
      pictureBoxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
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

    // 🔹 Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtBoxNombreProducto.Text) ||
     string.IsNullOrWhiteSpace(textBoxDescripcion.Text) ||
   string.IsNullOrWhiteSpace(textBoxCostoUnitario.Text) ||
             string.IsNullOrWhiteSpace(textBoxDescuento.Text) ||
             string.IsNullOrWhiteSpace(textBoxStock.Text) || // ✅ Validar stock
   comboBoxUnidadMedida.SelectedIndex == -1 ||
   comboBoxProveedor.SelectedIndex == -1 ||
         comboBoxTipoServicioProducto.SelectedIndex == -1 ||
        comboBoxCategoria.SelectedIndex == -1)
            {
       MessageBox.Show("⚠️ Todos los campos son obligatorios.", "Advertencia",
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
       }

         try
            {
     // 🔹 Capturar datos para actualización
    string nombreProducto = txtBoxNombreProducto.Text.Trim();
        string descripcion = textBoxDescripcion.Text.Trim();
        decimal costoUnitario = Convert.ToDecimal(textBoxCostoUnitario.Text);
      decimal descuento = Convert.ToDecimal(textBoxDescuento.Text);
        int stockDisponible = Convert.ToInt32(textBoxStock.Text); // ✅ Capturar stock
     DateTime fechaIngreso = dateTimePicker1.Value;
       int unidadMedidaId = Convert.ToInt32(comboBoxUnidadMedida.SelectedValue);
   int proveedorId = Convert.ToInt32(comboBoxProveedor.SelectedValue);
 int servicioBienId = Convert.ToInt32(comboBoxTipoServicioProducto.SelectedValue);
          int categoriaId = Convert.ToInt32(comboBoxCategoria.SelectedValue);

 // 🔹 Convertir imagen a bytes
 byte[] imagenBytes = null;
  if (pictureBoxImagen.Image != null)
  {
  using (MemoryStream ms = new MemoryStream())
            {
         pictureBoxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
       imagenBytes = ms.ToArray();
        }
         }

    // 🔹 Actualizar en base de datos usando transacción
     using (SqlConnection connection = new SqlConnection(connectionString))
  {
    connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
   {
    try
          {
                 // ✅ 1. Actualizar tabla de productos
            string queryProducto = @"
    UPDATE Invt.Tb_Productos 
      SET Producto_Nombre = @Nombre,
            Producto_Descripcion = @Descripcion,
      Producto_CostoUnitario = @Costo,
          Producto_Descuento = @Descuento,
          Producto_FechaIngreso = @Fecha,
      UnidadMedida_Id = @Unidad,
 Proveedor_Id = @Proveedor,
    ServicioBien_Id = @Servicio,
    Categoria_Id = @Categoria,
     Producto_Imagen = @Imagen
          WHERE Producto_Id = @Id";

           using (SqlCommand commandProducto = new SqlCommand(queryProducto, connection, transaction))
           {
      commandProducto.Parameters.AddWithValue("@Nombre", nombreProducto);
        commandProducto.Parameters.AddWithValue("@Descripcion", descripcion);
        commandProducto.Parameters.AddWithValue("@Costo", costoUnitario);
   commandProducto.Parameters.AddWithValue("@Descuento", descuento);
            commandProducto.Parameters.AddWithValue("@Fecha", fechaIngreso);
            commandProducto.Parameters.AddWithValue("@Unidad", unidadMedidaId);
           commandProducto.Parameters.AddWithValue("@Proveedor", proveedorId);
      commandProducto.Parameters.AddWithValue("@Servicio", servicioBienId);
       commandProducto.Parameters.AddWithValue("@Categoria", categoriaId);
  commandProducto.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value = (object)imagenBytes ?? DBNull.Value;
               commandProducto.Parameters.AddWithValue("@Id", productoIdActual);

        commandProducto.ExecuteNonQuery();
      }

  // ✅ 2. Actualizar o insertar en tabla de inventario
       string queryInventarioCheck = @"
    SELECT COUNT(*) FROM Invt.Tb_Inventario 
    WHERE Producto_Id = @ProductoId";

 using (SqlCommand commandCheck = new SqlCommand(queryInventarioCheck, connection, transaction))
{
    commandCheck.Parameters.AddWithValue("@ProductoId", productoIdActual);
  int existeInventario = (int)commandCheck.ExecuteScalar();

    if (existeInventario > 0)
    {
        // Actualizar registro existente
        string queryUpdateInventario = @"
        UPDATE Invt.Tb_Inventario 
      SET Cantidad_Disponible = @Stock,
     Fecha_de_Actualizacion = GETDATE()
      WHERE Producto_Id = @ProductoId";

        using (SqlCommand commandUpdate = new SqlCommand(queryUpdateInventario, connection, transaction))
        {
            commandUpdate.Parameters.AddWithValue("@Stock", stockDisponible);
     commandUpdate.Parameters.AddWithValue("@ProductoId", productoIdActual);
            commandUpdate.ExecuteNonQuery();
        }
    }
    else
    {
   // ✅ Insertar nuevo registro con todos los campos requeridos
   // Primero obtenemos una estantería disponible (usaremos la primera disponible)
        string queryEstanteria = @"
    SELECT TOP 1 Estanteria_Id 
   FROM Invt.Tb_Estanterias 
            WHERE EstadoBodega_Id IN (SELECT EstadoBodega_Id FROM Invt.Tb_EstadoBodegas WHERE EstadoBodega_Estado = 'Activo')
    ORDER BY Estanteria_Id";

        int estanteriaId = 1; // Valor por defecto en caso de no encontrar estantería
        
 using (SqlCommand commandEstanteria = new SqlCommand(queryEstanteria, connection, transaction))
        {
   var result = commandEstanteria.ExecuteScalar();
   if (result != null)
    {
       estanteriaId = Convert.ToInt32(result);
            }
        }

  // Calcular precio de venta (costo + 30% de margen como ejemplo)
      decimal precioVenta = costoUnitario * 1.30m;

        string queryInsertInventario = @"
     INSERT INTO Invt.Tb_Inventario 
    (Estanteria_Id, Producto_Id, Cantidad_Disponible, Fecha_de_Actualizacion, Precio_Venta)
    VALUES (@EstanteriaId, @ProductoId, @Stock, GETDATE(), @PrecioVenta)";

        using (SqlCommand commandInsert = new SqlCommand(queryInsertInventario, connection, transaction))
        {
        commandInsert.Parameters.AddWithValue("@EstanteriaId", estanteriaId);
            commandInsert.Parameters.AddWithValue("@ProductoId", productoIdActual);
     commandInsert.Parameters.AddWithValue("@Stock", stockDisponible);
            commandInsert.Parameters.AddWithValue("@PrecioVenta", precioVenta);
       commandInsert.ExecuteNonQuery();
        }
    }
}
     // ✅ Confirmar transacción
     transaction.Commit();

     MessageBox.Show("✅ Producto y stock actualizados exitosamente.", "Éxito",
             MessageBoxButtons.OK, MessageBoxIcon.Information);

       LimpiarTodosCampos();
          DeshabilitarCampos();
        productoIdActual = -1;
    }
             catch (Exception ex)
 {
        // ❌ Revertir transacción en caso de error
            transaction.Rollback();
         throw new Exception("Error en la transacción: " + ex.Message);
              }
  }
        }
    }
    catch (FormatException)
    {
        MessageBox.Show("⚠️ Por favor verifica que los campos numéricos tengan valores válidos.", "Error de formato",
           MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    catch (Exception ex)
  {
        MessageBox.Show("❌ Error al actualizar: " + ex.Message, "Error",
      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void buttonImagen_Click(object sender, EventArgs e)
      {
            OpenFileDialog openFileDialog = new OpenFileDialog();
     openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.png;*.jpeg;*.bmp";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
           pictureBoxImagen.Image = Image.FromFile(openFileDialog.FileName);
      pictureBoxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
    }
        }

      private void LimpiarCamposResultados()
        {
            txtBoxNombreProducto.Clear();
    textBoxDescripcion.Clear();
 textBoxCostoUnitario.Clear();
            textBoxDescuento.Clear();
       textBoxStock.Clear();
      comboBoxUnidadMedida.SelectedIndex = -1;
     comboBoxProveedor.SelectedIndex = -1;
            comboBoxTipoServicioProducto.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
            pictureBoxImagen.Image = null;
        productoIdActual = -1;
     }

        private void LimpiarTodosCampos()
      {
     txtBoxCodigoProductoB.Clear();
   textBoxNombreProductoBU.Clear(); // ✅ Limpiar campo de búsqueda por nombre
            textBoxCategoriaProductoBU.Clear();
        LimpiarCamposResultados();
        }

 private void buttonAtras_Click(object sender, EventArgs e)
     {
     OpcionesForm opcionesForm = new OpcionesForm();
    opcionesForm.Show();
      this.Hide();
        }

        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    private void lblNombreProducto_Click(object sender, EventArgs e) { }
     private void label1_Click_1(object sender, EventArgs e) { }
        private void txtBoxCodigoProductoB_TextChanged(object sender, EventArgs e) { }
        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
