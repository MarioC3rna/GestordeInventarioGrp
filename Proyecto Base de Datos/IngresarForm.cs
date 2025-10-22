using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Proyecto_Base_de_Datos
{
    public partial class IngresarForm : Form
    {
      public IngresarForm()
      {
   InitializeComponent();
        }

        private void IngresarForm_Load(object sender, EventArgs e)
    {
        // ✅ Ya no necesitamos cargar ComboBox
        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
         try
         {
     OpcionesForm opcionesForm = new OpcionesForm();
             opcionesForm.Show();
          this.Close(); // ✅ Cambiado de Hide() a Close()
            }
 catch (Exception ex)
    {
          MessageBox.Show("Error al volver: " + ex.Message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonIngresarBD_Click(object sender, EventArgs e)
        {
  // 🔹 Validar campos vacíos (excluyendo campos opcionales)
         var cajasRequeridas = new[] {
                txtBoxCodigoProducto, txtBoxNombreProducto, textBoxDescripcion,
      textBoxCostoUnitario, textBoxDescuento, textBoxStock,
        textBoxUnidadMedida, textBoxAbrevLongitud, textBoxPeso, textBoxAbrevPeso,
              textBoxProveedorNombre, textBoxTipoServicioTipo, textBoxCategoria
      };

     var cajasVacias = cajasRequeridas.Where(tb => string.IsNullOrWhiteSpace(tb.Text)).ToList();

 if (cajasVacias.Any())
            {
          MessageBox.Show("⚠️ Hay campos vacíos. Completa todos los datos obligatorios.",
      "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
     }

 try
         {
          // 🔹 Capturar datos del formulario
      string codigoProducto = txtBoxCodigoProducto.Text.Trim();
     string nombreProducto = txtBoxNombreProducto.Text.Trim();
    string descripcion = textBoxDescripcion.Text.Trim();
     
          // ✅ Validar que los valores numéricos sean válidos
       if (!decimal.TryParse(textBoxCostoUnitario.Text, out decimal costoUnitario))
                {
     MessageBox.Show("⚠️ El costo unitario debe ser un valor numérico válido.", "Validación",
   MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
       }

    if (!decimal.TryParse(textBoxDescuento.Text, out decimal descuento))
      {
               MessageBox.Show("⚠️ El descuento debe ser un valor numérico válido.", "Validación",
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
return;
         }

 if (!int.TryParse(textBoxStock.Text, out int stockInicial) || stockInicial < 0)
        {
   MessageBox.Show("⚠️ El stock debe ser un número entero válido y no negativo.", "Validación",
             MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
}

        DateTime fechaIngreso = dateTimePicker1.Value;

     // ✅ Capturar datos de UNIDAD DE MEDIDA
   if (!decimal.TryParse(textBoxUnidadMedida.Text, out decimal longitud))
     {
       MessageBox.Show("⚠️ La longitud debe ser un valor numérico válido.", "Validación",
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
     }

string abrevLongitud = textBoxAbrevLongitud.Text.Trim();

              if (!decimal.TryParse(textBoxPeso.Text, out decimal peso))
           {
    MessageBox.Show("⚠️ El peso debe ser un valor numérico válido.", "Validación",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
          }

     string abrevPeso = textBoxAbrevPeso.Text.Trim();

// ✅ Capturar datos de PROVEEDOR (solo nombre)
                string proveedorNombre = textBoxProveedorNombre.Text.Trim();

       // ✅ Capturar datos de SERVICIO/BIEN (solo tipo)
string servicioTipo = textBoxTipoServicioTipo.Text.Trim();

          // ✅ Validar que tipo sea "Servicio" o "Bien"
       if (servicioTipo != "Servicio" && servicioTipo != "Bien")
        {
   MessageBox.Show("⚠️ El Tipo debe ser 'Servicio' o 'Bien'",
  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

       // ✅ Capturar CATEGORÍA
            string categoriaNombre = textBoxCategoria.Text.Trim();

             // ✅ Guardar imagen
        string rutaImagen = null;
  if (pictureBoxImagen.Image != null)
   {
  rutaImagen = ImageHelper.SaveProductImage(pictureBoxImagen.Image, codigoProducto);
    if (rutaImagen == null)
     {
         MessageBox.Show("⚠️ No se pudo guardar la imagen. ¿Deseas continuar sin imagen?",
           "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
          }
      }

    // ✅ Usar DatabaseConnection para transacciones
                using (var connection = DatabaseConnection.CreateConnection())
   {
          connection.Open();
using (var transaction = connection.BeginTransaction())
  {
      try
    {
      // ✅ 1. INSERTAR O OBTENER UNIDAD DE MEDIDA
 int unidadMedidaId;
          string queryUnidad = @"
  SELECT UnidadMedida_Id FROM Invt.Tb_UnidadMedidas
         WHERE UnidadMedida_Longitud = @Longitud 
     AND UnidadMedida_AbrevLongitud = @AbrevLong
         AND UnidadMedida_Peso = @Peso
        AND UnidadMedida_AbrevPeso = @AbrevPeso";

       using (var cmdCheck = new SqlCommand(queryUnidad, connection, transaction))
    {
  cmdCheck.Parameters.AddWithValue("@Longitud", longitud);
          cmdCheck.Parameters.AddWithValue("@AbrevLong", abrevLongitud);
        cmdCheck.Parameters.AddWithValue("@Peso", peso);
         cmdCheck.Parameters.AddWithValue("@AbrevPeso", abrevPeso);

           var result = cmdCheck.ExecuteScalar();

              if (result != null)
                      {
           unidadMedidaId = Convert.ToInt32(result);
      }
        else
         {
  // Insertar nueva unidad
     string queryInsertUnidad = @"
            INSERT INTO Invt.Tb_UnidadMedidas 
            (UnidadMedida_Longitud, UnidadMedida_AbrevLongitud, UnidadMedida_AbrevPeso, UnidadMedida_Peso)
             OUTPUT INSERTED.UnidadMedida_Id
       VALUES (@Longitud, @AbrevLong, @AbrevPeso, @Peso)";

   using (var cmdInsert = new SqlCommand(queryInsertUnidad, connection, transaction))
         {
              cmdInsert.Parameters.AddWithValue("@Longitud", longitud);
         cmdInsert.Parameters.AddWithValue("@AbrevLong", abrevLongitud);
         cmdInsert.Parameters.AddWithValue("@Peso", peso);
          cmdInsert.Parameters.AddWithValue("@AbrevPeso", abrevPeso);

        unidadMedidaId = (int)cmdInsert.ExecuteScalar();
       }
   }
    }

    // ✅ 2. INSERTAR O OBTENER PROVEEDOR (solo por nombre)
   int proveedorId;
     string queryProveedor = "SELECT Proveedor_Id FROM Invt.Tb_Proveedores WHERE Proveedor_Nombre = @Nombre";

               using (var cmdCheckProv = new SqlCommand(queryProveedor, connection, transaction))
       {
     cmdCheckProv.Parameters.AddWithValue("@Nombre", proveedorNombre);
       var result = cmdCheckProv.ExecuteScalar();

          if (result != null)
             {
     proveedorId = Convert.ToInt32(result);
     }
          else
             {
            // ✅ Generar NIT automático de MÁXIMO 9 caracteres
        string nitAutomatico = DateTime.Now.ToString("yyMMddHHmmss").Substring(0, 9);

        string queryInsertProv = @"
  INSERT INTO Invt.Tb_Proveedores (Proveedor_NIT, Proveedor_Nombre, Municipio_Id)
    OUTPUT INSERTED.Proveedor_Id
   VALUES (@NIT, @Nombre, 1)";

          using (var cmdInsertProv = new SqlCommand(queryInsertProv, connection, transaction))
    {
               cmdInsertProv.Parameters.AddWithValue("@NIT", nitAutomatico);
                   cmdInsertProv.Parameters.AddWithValue("@Nombre", proveedorNombre);

           proveedorId = (int)cmdInsertProv.ExecuteScalar();
         }
     }
         }

   // ✅ 3. INSERTAR O OBTENER SERVICIO/BIEN (solo por tipo, nombre automático)
           int servicioBienId;
       string servicioNombre = $"{servicioTipo} - {codigoProducto}"; // Nombre automático

    string queryServicio = "SELECT ServicioBien_Id FROM Invt.Tb_ServiciosBienes WHERE ServicioBien_Tipo = @Tipo AND ServicioBien_Nombre = @Nombre";

     using (var cmdCheckServ = new SqlCommand(queryServicio, connection, transaction))
   {
          cmdCheckServ.Parameters.AddWithValue("@Tipo", servicioTipo);
   cmdCheckServ.Parameters.AddWithValue("@Nombre", servicioNombre);
  var result = cmdCheckServ.ExecuteScalar();

           if (result != null)
             {
   servicioBienId = Convert.ToInt32(result);
           }
  else
         {
string queryInsertServ = @"
             INSERT INTO Invt.Tb_ServiciosBienes (ServicioBien_Nombre, ServicioBien_Tipo)
     OUTPUT INSERTED.ServicioBien_Id
    VALUES (@Nombre, @Tipo)";

             using (var cmdInsertServ = new SqlCommand(queryInsertServ, connection, transaction))
  {
        cmdInsertServ.Parameters.AddWithValue("@Nombre", servicioNombre);
cmdInsertServ.Parameters.AddWithValue("@Tipo", servicioTipo);

           servicioBienId = (int)cmdInsertServ.ExecuteScalar();
      }
    }
        }

           // ✅ 4. INSERTAR O OBTENER CATEGORÍA
       int categoriaId;
        string queryCat = "SELECT Categoria_Id FROM Invt.Tb_Categorias WHERE Categoria_Nombre = @Nombre";

       using (var cmdCheckCat = new SqlCommand(queryCat, connection, transaction))
           {
            cmdCheckCat.Parameters.AddWithValue("@Nombre", categoriaNombre);
   var result = cmdCheckCat.ExecuteScalar();

         if (result != null)
      {
                 categoriaId = Convert.ToInt32(result);
          }
         else
          {
                  string queryInsertCat = @"
       INSERT INTO Invt.Tb_Categorias (Categoria_Nombre)
         OUTPUT INSERTED.Categoria_Id
            VALUES (@Nombre)";

      using (var cmdInsertCat = new SqlCommand(queryInsertCat, connection, transaction))
           {
       cmdInsertCat.Parameters.AddWithValue("@Nombre", categoriaNombre);
         categoriaId = (int)cmdInsertCat.ExecuteScalar();
         }
    }
          }

          // ✅ 5. INSERTAR PRODUCTO
           string queryProducto = @"
            INSERT INTO Invt.Tb_Productos
        (Producto_Codigo, Producto_Nombre, Producto_Descripcion, Producto_CostoUnitario, Producto_Descuento,
    Producto_FechaIngreso, UnidadMedida_Id, Proveedor_Id, ServicioBien_Id, Categoria_Id, Producto_ImagenRuta)
          OUTPUT INSERTED.Producto_Id
      VALUES (@Codigo, @Nombre, @Descripcion, @Costo, @Descuento, 
          @Fecha, @Unidad, @Proveedor, @Servicio, @Categoria, @ImagenRuta)";

     int productoId;
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
    commandProducto.Parameters.AddWithValue("@ImagenRuta", (object)rutaImagen ?? DBNull.Value);

        productoId = (int)commandProducto.ExecuteScalar();
     }

    // ✅ 6. INSERTAR EN INVENTARIO
             if (stockInicial > 0)
     {
           string queryEstanteria = @"
             SELECT TOP 1 Estanteria_Id 
      FROM Invt.Tb_Estanterias 
      WHERE EstadoBodega_Id IN (SELECT EstadoBodega_Id FROM Invt.Tb_EstadoBodegas WHERE EstadoBodega_Estado = 'Activo')
        ORDER BY Estanteria_Id";

    int estanteriaId = 1;
      using (var commandEstanteria = new SqlCommand(queryEstanteria, connection, transaction))
     {
             var result = commandEstanteria.ExecuteScalar();
   if (result != null)
      {
             estanteriaId = Convert.ToInt32(result);
        }
           }

               decimal precioVenta = costoUnitario * 1.30m;

 string queryInventario = @"
     INSERT INTO Invt.Tb_Inventario 
    (Estanteria_Id, Producto_Id, Cantidad_Disponible, Fecha_de_Actualizacion, Precio_Venta)
     VALUES (@EstanteriaId, @ProductoId, @Stock, GETDATE(), @PrecioVenta)";

   using (var commandInventario = new SqlCommand(queryInventario, connection, transaction))
          {
        commandInventario.Parameters.AddWithValue("@EstanteriaId", estanteriaId);
         commandInventario.Parameters.AddWithValue("@ProductoId", productoId);
 commandInventario.Parameters.AddWithValue("@Stock", stockInicial);
            commandInventario.Parameters.AddWithValue("@PrecioVenta", precioVenta);
   commandInventario.ExecuteNonQuery();
              }
       }

     // ✅ Confirmar transacción
            transaction.Commit();

         MessageBox.Show("✅ Producto ingresado exitosamente.", "Éxito",
               MessageBoxButtons.OK, MessageBoxIcon.Information);

   // 🔹 Limpiar formulario
            LimpiarFormulario();
        }
          catch (Exception ex)
    {
        transaction.Rollback();

     if (!string.IsNullOrEmpty(rutaImagen))
   {
 ImageHelper.DeleteProductImage(rutaImagen);
       }

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
      catch (SqlException sqlEx)
      {
    MessageBox.Show($"❌ Error de base de datos: {sqlEx.Message}\nCódigo: {sqlEx.Number}", "Error SQL",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
    catch (Exception ex)
     {
     MessageBox.Show("❌ Error al insertar: " + ex.Message, "Error",
 MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
        }

        private void buttonImagen_Click(object sender, EventArgs e)
     {
   try
       {
      OpenFileDialog openFileDialog = new OpenFileDialog();
  openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.png;*.jpeg;*.bmp";
  openFileDialog.Title = "Seleccionar imagen del producto";

          if (openFileDialog.ShowDialog() == DialogResult.OK)
       {
        pictureBoxImagen.Image = Image.FromFile(openFileDialog.FileName);
          pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;
  }
       }
     catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        }

        private void LimpiarFormulario()
        {
   foreach (var textBox in this.Controls.OfType<TextBox>())
            {
          textBox.Clear();
         }
            pictureBoxImagen.Image = null;
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
