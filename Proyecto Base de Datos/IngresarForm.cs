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
          // ✅ Configurar evento para detectar cambios en el tipo de servicio/bien
   comboBoxTipoServicioTipo.SelectedIndexChanged += ComboBoxTipoServicioTipo_SelectedIndexChanged;
     }

  // ✅ Evento para habilitar/deshabilitar stock según el tipo
   private void ComboBoxTipoServicioTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
   if (comboBoxTipoServicioTipo.SelectedItem == null)
        return;
 
       string tipo = comboBoxTipoServicioTipo.SelectedItem.ToString();
    
 if (tipo.Equals("Servicio", StringComparison.OrdinalIgnoreCase))
     {
         textBoxStock.Enabled = false;
       textBoxStock.Text = "0";
      textBoxStock.BackColor = SystemColors.Control;
      }
   else if (tipo.Equals("Bien", StringComparison.OrdinalIgnoreCase))
   {
   textBoxStock.Enabled = true;
   textBoxStock.BackColor = SystemColors.Window;
    if (textBoxStock.Text == "0")
     {
 textBoxStock.Clear();
     }
  }
   else
      {
          // Si está vacío o es inválido, habilitar el campo
     textBoxStock.Enabled = true;
     textBoxStock.BackColor = SystemColors.Window;
      }
        }

   private void IngresarForm_Load(object sender, EventArgs e)
    {
        // ✅ Cargar bodegas en el ComboBox
CargarBodegas();
        // ✅ Cargar categorías en el ComboBox
     CargarCategorias();
    // ✅ Cargar proveedores en el ComboBox
        CargarProveedores();
     }

        private void CargarBodegas()
        {
            try
          {
     using (var connection = DatabaseConnection.CreateConnection())
     {
// ✅ Consulta corregida usando el esquema correcto Invt.Tb_Bodegas
 string query = @"
      SELECT Bodega_Id, Bodega_NumeroBodega
FROM Invt.Tb_Bodegas B
   ORDER BY Bodega_NumeroBodega";
       
 SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
   DataTable data = new DataTable();
adapter.Fill(data);

          if (data.Rows.Count > 0)
         {
comboBoxBodega.DataSource = data;
          // ✅ Mostrar el número de bodega
     comboBoxBodega.DisplayMember = "Bodega_NumeroBodega";
     // ✅ Usar el ID de bodega como valor
     comboBoxBodega.ValueMember = "Bodega_Id";
    comboBoxBodega.SelectedIndex = 0;
        }
  else
         {
    MessageBox.Show("⚠️ No hay bodegas disponibles.", "Advertencia",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
   }
     }
}
   catch (Exception ex)
     {
     MessageBox.Show("Error al cargar bodegas: " + ex.Message, "Error",
 MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
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
      comboBoxCategoria.SelectedIndex = 0;
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
        comboBoxProveedor.SelectedIndex = 0;
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

        private void buttonAtras_Click(object sender, EventArgs e)
   {
   try
         {
     OpcionesForm opcionesForm = new OpcionesForm();
             opcionesForm.Show();
          this.Close();
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
 var cajasRequeridas = new List<TextBox> {
  txtBoxCodigoProducto, txtBoxNombreProducto, textBoxDescripcion,
   textBoxCostoUnitario, textBoxDescuento,
     textBoxUnidadMedida, textBoxAbrevLongitud, textBoxPeso, textBoxAbrevPeso
};

// ✅ Validar que se haya seleccionado un tipo de servicio/bien
   if (comboBoxTipoServicioTipo.SelectedItem == null)
   {
 MessageBox.Show("⚠️ Debes seleccionar el tipo (Servicio o Bien).", "Validación",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
      }

   string servicioTipo = comboBoxTipoServicioTipo.SelectedItem.ToString();
   
// ✅ Solo validar stock si NO es servicio
   if (!servicioTipo.Equals("Servicio", StringComparison.OrdinalIgnoreCase))
  {
       cajasRequeridas.Add(textBoxStock);
   }

  var cajasVacias = cajasRequeridas.Where(tb => string.IsNullOrWhiteSpace(tb.Text)).ToList();

 if (cajasVacias.Any())
{
        MessageBox.Show("⚠️ Hay campos vacíos. Completa todos los datos obligatorios.",
 "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
  }

    // ✅ Validar que se haya seleccionado una bodega
  if (comboBoxBodega.SelectedValue == null)
  {
       MessageBox.Show("⚠️ Debes seleccionar una bodega.", "Validación",
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

 // ✅ Si es servicio, stock es 0
      int stockInicial;
    if (servicioTipo.Equals("Servicio", StringComparison.OrdinalIgnoreCase))
   {
   stockInicial = 0;
        }
       else
  {
  if (!int.TryParse(textBoxStock.Text, out stockInicial) || stockInicial < 0)
    {
   MessageBox.Show("⚠️ El stock debe ser un número entero válido y no negativo.", "Validación",
             MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
    }
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


    // ✅ Capturar PROVEEDOR seleccionado
     int proveedorId = Convert.ToInt32(comboBoxProveedor.SelectedValue);

       // ✅ Validar que tipo sea "Servicio" o "Bien"
       if (servicioTipo != "Servicio" && servicioTipo != "Bien")
        {
   MessageBox.Show("⚠️ El Tipo debe ser 'Servicio' o 'Bien'",
  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

       // ✅ Capturar CATEGORÍA seleccionada
    int categoriaId = Convert.ToInt32(comboBoxCategoria.SelectedValue);

       // ✅ Capturar BODEGA seleccionada
          int bodegaId = Convert.ToInt32(comboBoxBodega.SelectedValue);

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

    // ✅ 2. Usar PROVEEDOR seleccionado del ComboBox (ya no es necesario buscar/crear)

   // ✅ 3. INSERTAR OBTENER SERVICIO/BIEN (solo por tipo, nombre automático)
int servicioBienId;
       string servicioNombre = $"{servicioTipo} - {codigoProducto}";

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

     // ✅ 4. INSERTAR OBTENER CATEGORÍA (ya seleccionada del ComboBox)
   // Ya no es necesario buscar o insertar, solo usar categoriaId

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

    // ✅ 6. INSERTAR EN INVENTARIO usando la bodega seleccionada (solo si NO es servicio)
    if (stockInicial > 0 && !servicioTipo.Equals("Servicio", StringComparison.OrdinalIgnoreCase))
     {
    // ✅ Obtener una estantería de la bodega seleccionada
string queryEstanteria = @"
 SELECT TOP 1 E.Estanteria_Id 
      FROM Invt.Tb_Estanterias E
WHERE E.Bodega_Id = @BodegaId
      ORDER BY E.Estanteria_Id";

    int estanteriaId = 0;
      using (var commandEstanteria = new SqlCommand(queryEstanteria, connection, transaction))
     {
commandEstanteria.Parameters.AddWithValue("@BodegaId", bodegaId);
 var result = commandEstanteria.ExecuteScalar();
 if (result != null)
    {
   estanteriaId = Convert.ToInt32(result);
      }
  else
 {
 throw new Exception($"No se encontró una estantería en la bodega seleccionada.");
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
 if (comboBoxBodega.Items.Count > 0)
     comboBoxBodega.SelectedIndex = 0;
 if (comboBoxCategoria.Items.Count > 0)
    comboBoxCategoria.SelectedIndex = 0;
   if (comboBoxProveedor.Items.Count > 0)
      comboBoxProveedor.SelectedIndex = 0;
 // ✅ Limpiar comboBox de tipo servicio/bien
      if (comboBoxTipoServicioTipo.Items.Count > 0)
          comboBoxTipoServicioTipo.SelectedIndex = -1;
        }
    }
}
