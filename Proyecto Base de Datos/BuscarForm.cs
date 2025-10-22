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
    public partial class BuscarForm : Form
    {
        // ✅ Remover connectionString, usar DatabaseConnection

        public BuscarForm()
      {
            InitializeComponent();
        }

        private void buttonAtrasBUS_Click(object sender, EventArgs e)
      {
    OpcionesForm opcionesForm = new OpcionesForm();
 opcionesForm.Show();
   this.Hide();
  }

  private void BuscarForm_Load(object sender, EventArgs e)
        {

    }

        private void buttonBuscar_Click(object sender, EventArgs e)
      {
            // 🔹 Obtener datos ingresados
            string codigoProducto = textBoxCodigoProductoBU.Text.Trim();
    string nombreProducto = textBoxNombreProductoBU.Text.Trim();

          // 🔹 Validar que al menos haya algo escrito
       if (string.IsNullOrEmpty(codigoProducto) && string.IsNullOrEmpty(nombreProducto))
       {
     MessageBox.Show("Por favor ingresa el código o el nombre del producto.", "Advertencia",
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
        }

       // 🔹 Limpiar campos antes de buscar
    textBoxDescripcionBU.Clear();
   textBoxCostoBU.Clear();
   textBoxDescuentoBU.Clear();
   textBoxProveedorBU.Clear();
      textBoxTipoServicioBU.Clear();
    textBoxStockBU.Clear();
  pictureBoxBuscarForm.Image = null;

   // ✅ Consulta actualizada para mostrar solo el TIPO (Servicio/Bien) en lugar del nombre completo
    string query = @"
   SELECT 
       P.Producto_Nombre,
  P.Producto_Descripcion,
      P.Producto_CostoUnitario,
   P.Producto_Descuento,
  UM.UnidadMedida_Longitud AS UnidadMedida,
 PR.Proveedor_Nombre AS Proveedor,
 SB.ServicioBien_Tipo AS ServicioBien,
   C.Categoria_Nombre AS Categoria,
  P.Producto_ImagenRuta AS ImagenRuta,
   ISNULL(SUM(I.Cantidad_Disponible), 0) AS Stock_Total
 FROM Invt.Tb_Productos P
  INNER JOIN Invt.Tb_UnidadMedidas UM ON P.UnidadMedida_Id = UM.UnidadMedida_Id
    INNER JOIN Invt.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
     INNER JOIN Invt.Tb_ServiciosBienes SB ON P.ServicioBien_Id = SB.ServicioBien_Id
      INNER JOIN Invt.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
   WHERE (P.Producto_Codigo = @Codigo OR P.Producto_Nombre = @Nombre)
 GROUP BY 
 P.Producto_Nombre, P.Producto_Descripcion, P.Producto_CostoUnitario,
        P.Producto_Descuento, UM.UnidadMedida_Longitud, PR.Proveedor_Nombre,
  SB.ServicioBien_Tipo, C.Categoria_Nombre, P.Producto_ImagenRuta;
  ";

       // ✅ Usar DatabaseConnection
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
  // ✅ Mostrar los datos encontrados
   textBoxNombreProductoBU.Text = reader["Producto_Nombre"].ToString();
  textBoxDescripcionBU.Text = reader["Producto_Descripcion"].ToString();
      textBoxCostoBU.Text = reader["Producto_CostoUnitario"].ToString();
      textBoxDescuentoBU.Text = reader["Producto_Descuento"].ToString();
    textBoxProveedorBU.Text = reader["Proveedor"].ToString();
  textBoxTipoServicioBU.Text = reader["ServicioBien"].ToString();
   
  // ✅ Mostrar stock disponible
   textBoxStockBU.Text = reader["Stock_Total"].ToString();

  // ✅ 🔹 Mostrar imagen desde C:\ImagenesDB usando la ruta directa
   if (reader["ImagenRuta"] != DBNull.Value)
  {
    string rutaImagen = reader["ImagenRuta"].ToString();
     
      if (!string.IsNullOrEmpty(rutaImagen))
    {
       // ✅ Cargar imagen desde archivo usando ImageHelper
      Image imagen = ImageHelper.LoadProductImage(rutaImagen);
     if (imagen != null)
   {
      pictureBoxBuscarForm.Image = imagen;
     pictureBoxBuscarForm.SizeMode = PictureBoxSizeMode.StretchImage;
       }
  else
     {
        pictureBoxBuscarForm.Image = null;
      }
    }
     else
     {
     pictureBoxBuscarForm.Image = null;
}
}
     else
     {
    pictureBoxBuscarForm.Image = null;
   }

 MessageBox.Show("✅ Producto encontrado.", "Resultado",
          MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
     else
   {
  pictureBoxBuscarForm.Image = null;
    MessageBox.Show("❌ No se encontró ningún producto con ese código o nombre.",
          "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
