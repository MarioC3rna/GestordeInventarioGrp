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
  }

   private void ActualizarForm_Load(object sender, EventArgs e)
        {
       // ✅ Ya no necesitamos cargar ComboBox
      DeshabilitarCampos();
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
            textBoxProveedorNombre.Enabled = false;
      textBoxTipoServicioTipo.Enabled = false;
  textBoxCategoria.Enabled = false;
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
       textBoxProveedorNombre.Enabled = true;
textBoxTipoServicioTipo.Enabled = true;
  textBoxCategoria.Enabled = true;
        buttonImagen.Enabled = true;
     textBoxStock.Enabled = true;
    btnACTUALIZAR.Enabled = true;
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

          // ✅ Llenar PROVEEDOR
      textBoxProveedorNombre.Text = reader["Proveedor_Nombre"].ToString();

     // ✅ Llenar TIPO SERVICIO/BIEN
                  textBoxTipoServicioTipo.Text = reader["ServicioBien_Tipo"].ToString();

// ✅ Llenar CATEGORÍA
    textBoxCategoria.Text = reader["Categoria_Nombre"].ToString();

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

// ✅ Validar campos vacíos
 var cajasVacias = new[] {
     txtBoxCodigoProducto, txtBoxNombreProducto, textBoxDescripcion,
     textBoxCostoUnitario, textBoxDescuento, textBoxStock,
     textBoxUnidadMedida, textBoxAbrevLongitud, textBoxPeso, textBoxAbrevPeso,
  textBoxProveedorNombre, textBoxTipoServicioTipo, textBoxCategoria
  }.Where(tb => string.IsNullOrWhiteSpace(tb.Text)).ToList();

    if (cajasVacias.Any())
            {
                MessageBox.Show("⚠️ Todos los campos son obligatorios.", "Advertencia",
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
            }

  try
        {
            // 🔹 Capturar datos
       string codigoProducto = txtBoxCodigoProducto.Text.Trim();
                string nombreProducto = txtBoxNombreProducto.Text.Trim();
        string descripcion = textBoxDescripcion.Text.Trim();
      decimal costoUnitario = Convert.ToDecimal(textBoxCostoUnitario.Text);
    decimal descuento = Convert.ToDecimal(textBoxDescuento.Text);
       int stockDisponible = Convert.ToInt32(textBoxStock.Text);
       DateTime fechaIngreso = dateTimePicker1.Value;

     decimal longitud = Convert.ToDecimal(textBoxUnidadMedida.Text);
        string abrevLongitud = textBoxAbrevLongitud.Text.Trim();
       decimal peso = Convert.ToDecimal(textBoxPeso.Text);
             string abrevPeso = textBoxAbrevPeso.Text.Trim();

            string proveedorNombre = textBoxProveedorNombre.Text.Trim();
       string servicioTipo = textBoxTipoServicioTipo.Text.Trim();
     string categoriaNombre = textBoxCategoria.Text.Trim();

     // ✅ Validar tipo
            if (servicioTipo != "Servicio" && servicioTipo != "Bien")
     {
                    MessageBox.Show("⚠️ El Tipo debe ser 'Servicio' o 'Bien'", "Validación",
           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

    // ✅ Manejar actualización de imagen
  string rutaImagenFinal = rutaImagenAnterior;
   if (pictureBoxImagen.Image != null && string.IsNullOrEmpty(rutaImagenAnterior))
       {
          rutaImagenFinal = ImageHelper.SaveProductImage(pictureBoxImagen.Image, codigoProducto);
    }
        else if (pictureBoxImagen.Image != null && !string.IsNullOrEmpty(rutaImagenAnterior))
       {
          Image imagenAnterior = ImageHelper.LoadProductImage(rutaImagenAnterior);
       if (imagenAnterior == null || !ImagenesIguales(pictureBoxImagen.Image, imagenAnterior))
  {
rutaImagenFinal = ImageHelper.UpdateProductImage(pictureBoxImagen.Image, codigoProducto, rutaImagenAnterior);
        }
    }

       using (var connection = DatabaseConnection.CreateConnection())
 {
           connection.Open();
         using (var transaction = connection.BeginTransaction())
       {
           try
      {
       // ✅ 1. ACTUALIZAR O OBTENER UNIDAD DE MEDIDA
     int unidadMedidaId = ObtenerOCrearUnidadMedida(connection, transaction, longitud, abrevLongitud, peso, abrevPeso);

       // ✅ 2. ACTUALIZAR O OBTENER PROVEEDOR
                int proveedorId = ObtenerOCrearProveedor(connection, transaction, proveedorNombre);

          // ✅ 3. ACTUALIZAR O OBTENER SERVICIO/BIEN
       int servicioBienId = ObtenerOCrearServicioBien(connection, transaction, servicioTipo, codigoProducto);

       // ✅ 4. ACTUALIZAR O OBTENER CATEGORÍA
         int categoriaId = ObtenerOCrearCategoria(connection, transaction, categoriaNombre);

 // ✅ 5. ACTUALIZAR PRODUCTO
  string queryProducto = @"
           UPDATE Invt.Tb_Productos 
 SET Producto_Codigo = @Codigo,
            Producto_Nombre = @Nombre,
               Producto_Descripcion = @Descripcion,
      Producto_CostoUnitario = @Costo,
         Producto_Descuento = @Descuento,
Producto_FechaIngreso = @Fecha,
        UnidadMedida_Id = @Unidad,
       Proveedor_Id = @Proveedor,
             ServicioBien_Id = @Servicio,
      Categoria_Id = @Categoria,
        Producto_ImagenRuta = @ImagenRuta
       WHERE Producto_Id = @Id";

          using (var commandProducto = new SqlCommand(queryProducto, connection, transaction))
         {
commandProducto.Parameters.AddWithValue("@Codigo", codigoProducto);
      commandProducto.Parameters.AddWithValue("@Nombre", nombreProducto);
commandProducto.Parameters.AddWithValue("@Descripcion", descripcion);
        commandProducto.Parameters.AddWithValue("@Costo", costoUnitario);
       commandProducto.Parameters.AddWithValue("@Descuento", descuento);
       commandProducto.Parameters.AddWithValue("@Fecha", fechaIngreso);
         commandProducto.Parameters.AddWithValue("@Unidad", unidadMedidaId);
      commandProducto.Parameters.AddWithValue("@Proveedor", proveedorId);
           commandProducto.Parameters.AddWithValue("@Servicio", servicioBienId);
         commandProducto.Parameters.AddWithValue("@Categoria", categoriaId);
       commandProducto.Parameters.AddWithValue("@ImagenRuta", (object)rutaImagenFinal ?? DBNull.Value);
    commandProducto.Parameters.AddWithValue("@Id", productoIdActual);

        commandProducto.ExecuteNonQuery();
      }

       // ✅ 6. ACTUALIZAR INVENTARIO
   ActualizarInventario(connection, transaction, productoIdActual, stockDisponible, costoUnitario);

 transaction.Commit();

    MessageBox.Show("✅ Producto actualizado exitosamente.", "Éxito",
         MessageBoxButtons.OK, MessageBoxIcon.Information);

        LimpiarTodosCampos();
   DeshabilitarCampos();
        productoIdActual = -1;
         rutaImagenAnterior = "";
   codigoProductoActual = "";
             }
    catch (Exception ex)
       {
       transaction.Rollback();
    throw new Exception("Error en la transacción: " + ex.Message);
          }
   }
            }
  }
            catch (FormatException)
     {
         MessageBox.Show("⚠️ Verifica que los campos numéricos tengan valores válidos.", "Error de formato",
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    catch (Exception ex)
            {
       MessageBox.Show("❌ Error al actualizar: " + ex.Message, "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   // ✅ MÉTODOS AUXILIARES PARA OBTENER/CREAR REGISTROS
        private int ObtenerOCrearUnidadMedida(SqlConnection conn, SqlTransaction trans, decimal longitud, string abrevLong, decimal peso, string abrevPeso)
 {
       string queryCheck = @"SELECT UnidadMedida_Id FROM Invt.Tb_UnidadMedidas
           WHERE UnidadMedida_Longitud = @Longitud AND UnidadMedida_AbrevLongitud = @AbrevLong
           AND UnidadMedida_Peso = @Peso AND UnidadMedida_AbrevPeso = @AbrevPeso";

            using (var cmd = new SqlCommand(queryCheck, conn, trans))
     {
  cmd.Parameters.AddWithValue("@Longitud", longitud);
     cmd.Parameters.AddWithValue("@AbrevLong", abrevLong);
                cmd.Parameters.AddWithValue("@Peso", peso);
  cmd.Parameters.AddWithValue("@AbrevPeso", abrevPeso);

  var result = cmd.ExecuteScalar();
     if (result != null) return Convert.ToInt32(result);
         }

       string queryInsert = @"INSERT INTO Invt.Tb_UnidadMedidas 
         (UnidadMedida_Longitud, UnidadMedida_AbrevLongitud, UnidadMedida_AbrevPeso, UnidadMedida_Peso)
       OUTPUT INSERTED.UnidadMedida_Id
  VALUES (@Longitud, @AbrevLong, @AbrevPeso, @Peso)";

      using (var cmd = new SqlCommand(queryInsert, conn, trans))
            {
 cmd.Parameters.AddWithValue("@Longitud", longitud);
                cmd.Parameters.AddWithValue("@AbrevLong", abrevLong);
       cmd.Parameters.AddWithValue("@Peso", peso);
     cmd.Parameters.AddWithValue("@AbrevPeso", abrevPeso);
      return (int)cmd.ExecuteScalar();
}
        }

        private int ObtenerOCrearProveedor(SqlConnection conn, SqlTransaction trans, string nombre)
 {
     string queryCheck = "SELECT Proveedor_Id FROM Invt.Tb_Proveedores WHERE Proveedor_Nombre = @Nombre";

      using (var cmd = new SqlCommand(queryCheck, conn, trans))
         {
      cmd.Parameters.AddWithValue("@Nombre", nombre);
  var result = cmd.ExecuteScalar();
 if (result != null) return Convert.ToInt32(result);
       }

       // ✅ Generar NIT automático de MÁXIMO 9 caracteres
    string nitAutomatico = DateTime.Now.ToString("yyMMddHHmmss").Substring(0, 9); // ✅ CORREGIDO
    string queryInsert = @"INSERT INTO Invt.Tb_Proveedores (Proveedor_NIT, Proveedor_Nombre, Municipio_Id)
        OUTPUT INSERTED.Proveedor_Id VALUES (@NIT, @Nombre, 1)";

       using (var cmd = new SqlCommand(queryInsert, conn, trans))
   {
      cmd.Parameters.AddWithValue("@NIT", nitAutomatico);
   cmd.Parameters.AddWithValue("@Nombre", nombre);
    return (int)cmd.ExecuteScalar();
}
        }

    private int ObtenerOCrearServicioBien(SqlConnection conn, SqlTransaction trans, string tipo, string codigo)
        {
       string nombre = $"{tipo} - {codigo}";
   string queryCheck = "SELECT ServicioBien_Id FROM Invt.Tb_ServiciosBienes WHERE ServicioBien_Tipo = @Tipo AND ServicioBien_Nombre = @Nombre";

 using (var cmd = new SqlCommand(queryCheck, conn, trans))
   {
  cmd.Parameters.AddWithValue("@Tipo", tipo);
        cmd.Parameters.AddWithValue("@Nombre", nombre);
      var result = cmd.ExecuteScalar();
     if (result != null) return Convert.ToInt32(result);
  }

  string queryInsert = @"INSERT INTO Invt.Tb_ServiciosBienes (ServicioBien_Nombre, ServicioBien_Tipo)
            OUTPUT INSERTED.ServicioBien_Id VALUES (@Nombre, @Tipo)";

            using (var cmd = new SqlCommand(queryInsert, conn, trans))
        {
            cmd.Parameters.AddWithValue("@Nombre", nombre);
cmd.Parameters.AddWithValue("@Tipo", tipo);
   return (int)cmd.ExecuteScalar();
          }
 }

        private int ObtenerOCrearCategoria(SqlConnection conn, SqlTransaction trans, string nombre)
        {
            string queryCheck = "SELECT Categoria_Id FROM Invt.Tb_Categorias WHERE Categoria_Nombre = @Nombre";

            using (var cmd = new SqlCommand(queryCheck, conn, trans))
         {
     cmd.Parameters.AddWithValue("@Nombre", nombre);
       var result = cmd.ExecuteScalar();
      if (result != null) return Convert.ToInt32(result);
    }

          string queryInsert = @"INSERT INTO Invt.Tb_Categorias (Categoria_Nombre)
         OUTPUT INSERTED.Categoria_Id VALUES (@Nombre)";

  using (var cmd = new SqlCommand(queryInsert, conn, trans))
 {
   cmd.Parameters.AddWithValue("@Nombre", nombre);
  return (int)cmd.ExecuteScalar();
            }
        }

  private void ActualizarInventario(SqlConnection conn, SqlTransaction trans, int productoId, int stock, decimal costo)
        {
       string queryCheck = "SELECT COUNT(*) FROM Invt.Tb_Inventario WHERE Producto_Id = @ProductoId";

      using (var cmd = new SqlCommand(queryCheck, conn, trans))
  {
     cmd.Parameters.AddWithValue("@ProductoId", productoId);
        int existe = (int)cmd.ExecuteScalar();

            if (existe > 0)
    {
    string queryUpdate = @"UPDATE Invt.Tb_Inventario SET Cantidad_Disponible = @Stock,
            Fecha_de_Actualizacion = GETDATE() WHERE Producto_Id = @ProductoId";

      using (var cmdUpdate = new SqlCommand(queryUpdate, conn, trans))
          {
            cmdUpdate.Parameters.AddWithValue("@Stock", stock);
       cmdUpdate.Parameters.AddWithValue("@ProductoId", productoId);
  cmdUpdate.ExecuteNonQuery();
            }
                }
       else
{
           int estanteriaId = 1;
               decimal precioVenta = costo * 1.30m;

 string queryInsert = @"INSERT INTO Invt.Tb_Inventario 
 (Estanteria_Id, Producto_Id, Cantidad_Disponible, Fecha_de_Actualizacion, Precio_Venta)
        VALUES (@EstanteriaId, @ProductoId, @Stock, GETDATE(), @PrecioVenta)";

  using (var cmdInsert = new SqlCommand(queryInsert, conn, trans))
   {
  cmdInsert.Parameters.AddWithValue("@EstanteriaId", estanteriaId);
 cmdInsert.Parameters.AddWithValue("@ProductoId", productoId);
  cmdInsert.Parameters.AddWithValue("@Stock", stock);
     cmdInsert.Parameters.AddWithValue("@PrecioVenta", precioVenta);
   cmdInsert.ExecuteNonQuery();
        }
      }
    }
 }

   private void buttonImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.png;*.jpeg;*.bmp";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
{
   pictureBoxImagen.Image = Image.FromFile(openFileDialog.FileName);
   pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

   private bool ImagenesIguales(Image img1, Image img2)
        {
          if (img1 == null || img2 == null) return false;
   if (img1.Width != img2.Width || img1.Height != img2.Height) return false;

  using (var ms1 = new MemoryStream())
            using (var ms2 = new MemoryStream())
          {
                img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
      img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
 return ms1.ToArray().SequenceEqual(ms2.ToArray());
     }
        }

 private void LimpiarCamposResultados()
        {
txtBoxCodigoProducto.Clear();
   txtBoxNombreProducto.Clear();
       textBoxDescripcion.Clear();
            textBoxCostoUnitario.Clear();
     textBoxDescuento.Clear();
     textBoxStock.Clear();
       textBoxUnidadMedida.Clear();
            textBoxAbrevLongitud.Clear();
     textBoxPeso.Clear();
     textBoxAbrevPeso.Clear();
 textBoxProveedorNombre.Clear();
      textBoxTipoServicioTipo.Clear();
textBoxCategoria.Clear();
          pictureBoxImagen.Image = null;
     productoIdActual = -1;
      rutaImagenAnterior = "";
    codigoProductoActual = "";
        }

        private void LimpiarTodosCampos()
  {
 txtBoxCodigoProductoB.Clear();
            textBoxNombreProductoBU.Clear();
  LimpiarCamposResultados();
        }

    private void buttonAtras_Click(object sender, EventArgs e)
        {
         OpcionesForm opcionesForm = new OpcionesForm();
            opcionesForm.Show();
            this.Hide();
        }

        private void lblTitulo_Click(object sender, EventArgs e) { }
    private void txtBoxCodigoProductoB_TextChanged(object sender, EventArgs e) { }
    }
}
