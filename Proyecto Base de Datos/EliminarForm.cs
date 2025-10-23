using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Base_de_Datos
{
    public partial class EliminarForm : Form
    {
        public EliminarForm()
        {
            InitializeComponent();
        }

        private void EliminarForm_Load(object sender, EventArgs e)
        {
            // Opcional: cargar listado inicial en PanelListado
        }

        // 🔹 Botón Buscar
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtBoxCodigoProductoBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese un código de producto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ✅ Consulta actualizada para mostrar TODOS los datos del producto
                using (var connection = DatabaseConnection.CreateConnection())
                {
                    string query = @"
                        SELECT 
        P.Producto_Codigo, 
         P.Producto_Nombre,
       P.Producto_Descripcion,
   P.Producto_CostoUnitario,
 P.Producto_Descuento,
         P.Producto_FechaIngreso,
         CONCAT(UM.UnidadMedida_Longitud, ' ', UM.UnidadMedida_AbrevLongitud) AS UnidadMedida,
  CONCAT(UM.Unidad_Medida_Peso, ' ', UM.UnidadMedida_AbrevPeso) AS Peso,
        PR.Proveedor_Nombre AS Proveedor,
              SB.ServicioBien_Tipo AS ServicioBien,
            C.Categoria_Nombre AS Categoria,
   P.Producto_ImagenRuta,
      ISNULL(SUM(I.Cantidad_Disponible), 0) AS Stock_Total,
         STRING_AGG(B.Bodega_NumeroBodega, ', ') AS Bodegas
FROM Invt.Tb_Productos P
      INNER JOIN Invt.Tb_UnidadMedidas UM ON P.UnidadMedida_Id = UM.UnidadMedida_Id
  INNER JOIN Invt.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
          INNER JOIN Invt.Tb_ServiciosBienes SB ON P.ServicioBien_Id = SB.ServicioBien_Id
  INNER JOIN Invt.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
 LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
   LEFT JOIN Invt.Tb_Estanterias E ON I.Estanteria_Id = E.Estanteria_Id
     LEFT JOIN Invt.Tb_Bodegas B ON E.Bodega_Id = B.Bodega_Id
       WHERE P.Producto_Codigo = @Codigo
   GROUP BY 
           P.Producto_Codigo, P.Producto_Nombre, P.Producto_Descripcion, P.Producto_CostoUnitario,
   P.Producto_Descuento, P.Producto_FechaIngreso, UM.UnidadMedida_Longitud, UM.UnidadMedida_AbrevLongitud,
    UM.Unidad_Medida_Peso, UM.UnidadMedida_AbrevPeso, PR.Proveedor_Nombre,
    SB.ServicioBien_Tipo, C.Categoria_Nombre, P.Producto_ImagenRuta";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ✅ Mostrar TODOS los datos del producto
                                txtBoxCodigoProducto.Text = reader["Producto_Codigo"].ToString();
                                txtBoxNombreProducto.Text = reader["Producto_Nombre"].ToString();
                                txtBoxProveedor.Text = reader["Proveedor"].ToString();
                                txtBoxTipoServicio.Text = reader["ServicioBien"].ToString();

                                // ✅ Mostrar información completa en el panel
                                string informacion = $@"
═══════════════════════════════════════════════════
         INFORMACIÓN DEL PRODUCTO
═══════════════════════════════════════════════════
Código: {reader["Producto_Codigo"]}
Nombre: {reader["Producto_Nombre"]}
Descripción: {reader["Producto_Descripcion"]}
───────────────────────────────────────────────────
Costo Unitario: ${reader["Producto_CostoUnitario"]}
Descuento: {reader["Producto_Descuento"]}%
Fecha Ingreso: {Convert.ToDateTime(reader["Producto_FechaIngreso"]):dd/MM/yyyy}
───────────────────────────────────────────────────
Unidad de Medida: {reader["UnidadMedida"]}
Peso: {reader["Peso"]}
───────────────────────────────────────────────────
Proveedor: {reader["Proveedor"]}
Tipo: {reader["ServicioBien"]}
Categoría: {reader["Categoria"]}
───────────────────────────────────────────────────
Stock Total: {reader["Stock_Total"]} unidades
Bodega(s): {(reader["Bodegas"] != DBNull.Value ? reader["Bodegas"].ToString() : "Sin bodega asignada")}
═══════════════════════════════════════════════════";

                                // ✅ Mostrar en el panel usando un TextBox multilínea
                                MostrarInformacionEnPanel(informacion);

                                MessageBox.Show("✅ Producto encontrado. Revisa la información antes de eliminar.", 
                                "Producto encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Producto no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarCampos();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarInformacionEnPanel(string informacion)
        {
            // ✅ Limpiar panel y agregar TextBox con la información
            PanelListado.Controls.Clear();

            TextBox txtInfo = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Consolas", 9),
                Text = informacion,
                BackColor = System.Drawing.Color.LightYellow
            };

            PanelListado.Controls.Add(txtInfo);
        }

        // 🔹 Botón Eliminar
        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = txtBoxCodigoProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("No hay producto seleccionado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar el producto:\n\n{txtBoxNombreProducto.Text}\n\nCódigo: {codigo}\n\n⚠️ Esta acción eliminará también los registros en inventario.", 
                        "Confirmar eliminación", 
                MessageBoxButtons.YesNo, 
        MessageBoxIcon.Warning);

          if (resultado == DialogResult.Yes)
          {
           try
          {
           using (var connection = DatabaseConnection.CreateConnection())
         {
       connection.Open();
           using (var transaction = connection.BeginTransaction())
        {
                  try
            {
        // ✅ 1. Eliminar registros de inventario
          string deleteInventario = @"
          DELETE FROM Invt.Tb_Inventario 
              WHERE Producto_Id = (SELECT Producto_Id FROM Invt.Tb_Productos WHERE Producto_Codigo = @Codigo)";

        using (var cmdInv = new SqlCommand(deleteInventario, connection, transaction))
           {
  cmdInv.Parameters.AddWithValue("@Codigo", codigo);
int filasInventario = cmdInv.ExecuteNonQuery();
            }

  // ✅ 2. Eliminar producto
          string deleteProducto = "DELETE FROM Invt.Tb_Productos WHERE Producto_Codigo = @Codigo";

        using (var cmdProd = new SqlCommand(deleteProducto, connection, transaction))
{
          cmdProd.Parameters.AddWithValue("@Codigo", codigo);
   int filasProducto = cmdProd.ExecuteNonQuery();

             if (filasProducto > 0)
  {
      transaction.Commit();
    MessageBox.Show("✅ Producto eliminado correctamente junto con sus registros de inventario.", 
         "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  LimpiarCampos();
         }
              else
        {
 transaction.Rollback();
   MessageBox.Show("❌ Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     }
      }
   }
     catch (Exception ex)
    {
      transaction.Rollback();
       throw new Exception("Error al eliminar: " + ex.Message);
     }
         }
           }
}
    catch (Exception ex)
 {
        MessageBox.Show("❌ Error al eliminar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
   }
        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
 OpcionesForm opcionesForm = new OpcionesForm();
         opcionesForm.Show();
this.Hide();
        }

  private void LimpiarCampos()
        {
     txtBoxCodigoProductoBusqueda.Clear();
    txtBoxCodigoProducto.Clear();
      txtBoxNombreProducto.Clear();
  txtBoxProveedor.Clear();
      txtBoxTipoServicio.Clear();
        PanelListado.Controls.Clear();
        }

        private void lblopciones_Click(object sender, EventArgs e)
   {
            // Acción opcional si se hace click en el título
 }
    }
}
