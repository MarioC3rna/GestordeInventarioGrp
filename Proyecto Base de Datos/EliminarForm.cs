using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Base_de_Datos
{
    public partial class EliminarForm : Form
    {
        private string connectionString = "Data Source=SRV-BD\\MYISTANCE;Initial Catalog=Db_EmpresaDev;User ID=admin_inventario;Password=Adm!n2025$;Encrypt=True;TrustServerCertificate=True;";

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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT Producto_Codigo, Producto_Nombre, Proveedor_Id, ServicioBien_Id
                        FROM Invt.Tb_Productos 
                        WHERE Producto_Codigo = @Codigo";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtBoxCodigoProducto.Text = reader["Producto_Codigo"].ToString();
                                txtBoxNombreProducto.Text = reader["Producto_Nombre"].ToString();
                                txtBoxProveedor.Text = reader["Proveedor_Id"].ToString();
                                txtBoxTipoServicio.Text = reader["ServicioBien_Id"].ToString();
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

        // 🔹 Botón Eliminar
        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = txtBoxCodigoProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("No hay producto seleccionado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Invt.Tb_Productos WHERE Producto_Codigo = @Codigo";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Codigo", codigo);
                            connection.Open();

                            int filas = cmd.ExecuteNonQuery();

                            if (filas > 0)
                            {
                                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // 🔸 Si hay error de referencia (producto en inventario)
                    if (ex.Message.Contains("REFERENCE constraint") || ex.Message.Contains("FK_Inventario_Producto"))
                    {
                        DialogResult eliminarInventario = MessageBox.Show(
                            "Este producto tiene registros en inventario.\n¿Desea eliminar también los registros asociados en la tabla de inventario?",
                            "Producto con dependencias",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (eliminarInventario == DialogResult.Yes)
                        {
                            try
                            {
                                using (SqlConnection connection2 = new SqlConnection(connectionString))
                                {
                                    connection2.Open();

                                    // 1️⃣ Eliminar inventario asociado
                                    string deleteInventario = "DELETE FROM Invt.Tb_Inventario WHERE Producto_Id = (SELECT Producto_Id FROM Invt.Tb_Productos WHERE Producto_Codigo = @Codigo)";
                                    using (SqlCommand cmdInv = new SqlCommand(deleteInventario, connection2))
                                    {
                                        cmdInv.Parameters.AddWithValue("@Codigo", codigo);
                                        cmdInv.ExecuteNonQuery();
                                    }

                                    // 2️⃣ Eliminar producto
                                    string deleteProducto = "DELETE FROM Invt.Tb_Productos WHERE Producto_Codigo = @Codigo";
                                    using (SqlCommand cmdProd = new SqlCommand(deleteProducto, connection2))
                                    {
                                        cmdProd.Parameters.AddWithValue("@Codigo", codigo);
                                        cmdProd.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Producto y registros de inventario eliminados correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimpiarCampos();
                                }
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show("Error al eliminar inventario asociado: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Operación cancelada. El producto no se ha eliminado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void lblopciones_Click(object sender, EventArgs e)
        {
            // Acción opcional si se hace click en el título
        }
    }
}
