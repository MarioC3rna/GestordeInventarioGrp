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
        // 🔹 Cadena de conexión — cámbiala cuando conectes a tu VMware
        private string connectionString = "Data Source=192.168.116.129\\MYISTANCE;Initial Catalog=Db_EmpresaDev;User ID=admin_inventario;Password=Adm!n2025$;Encrypt=True;TrustServerCertificate=True;";





        public IngresarForm()
        {
            InitializeComponent();
        }

        private void lblNombreProducto_Click(object sender, EventArgs e)
        {

        }



        private void IngresarForm_Load(object sender, EventArgs e)
        {
            // 🔹 Cargar combos con nombres correctos de columnas
            CargarComboBox(comboBoxUnidadMedida, "Invt.Tb_UnidadMedidas", "UnidadMedida_Id", "UnidadMedida_Longitud");
            CargarComboBox(comboBoxProveedor, "Invt.Tb_Proveedores", "Proveedor_Id", "Proveedor_Nombre");
            CargarComboBox(comboBoxTipoServicioProducto, "Invt.Tb_ServiciosBienes", "ServicioBien_Id", "ServicioBien_Nombre");
            CargarComboBox(comboBoxCategoria, "Invt.Tb_Categorias", "Categoria_Id", "Categoria_Nombre");
            
            comboBoxUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoServicioProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;



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
                MessageBox.Show("❌ Error al cargar datos del combo: " + ex.Message);
            }
        }




        private void buttonAtras_Click(object sender, EventArgs e)
        {
            OpcionesForm opcionesForm = new OpcionesForm();
            opcionesForm.Show();
            this.Hide();
        }



        private void buttonIngresarBD_Click(object sender, EventArgs e)
        {
            // 🔹 Validar campos vacíos (incluyendo el stock)
            var cajasVacias = this.Controls.OfType<TextBox>()
                .Where(tb => string.IsNullOrWhiteSpace(tb.Text))
                .ToList();

            if (cajasVacias.Any() ||
                comboBoxUnidadMedida.SelectedIndex == -1 ||
                comboBoxProveedor.SelectedIndex == -1 ||
                comboBoxTipoServicioProducto.SelectedIndex == -1 ||
                comboBoxCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("⚠️ Hay campos vacíos o sin seleccionar. Completa todos los datos incluyendo el stock inicial.",
                                 "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 🔹 Capturar datos del formulario (incluyendo stock)
                string nombreProducto = txtBoxNombreProducto.Text.Trim();
                string descripcion = textBoxDescripcion.Text.Trim();
                decimal costoUnitario = Convert.ToDecimal(textBoxCostoUnitario.Text);
                decimal descuento = Convert.ToDecimal(textBoxDescuento.Text);
                int stockInicial = Convert.ToInt32(textBoxStock.Text); // ✅ Capturar stock inicial
                DateTime fechaIngreso = dateTimePicker1.Value;

                int unidadMedidaId = Convert.ToInt32(comboBoxUnidadMedida.SelectedValue);
                int proveedorId = Convert.ToInt32(comboBoxProveedor.SelectedValue);
                int servicioBienId = Convert.ToInt32(comboBoxTipoServicioProducto.SelectedValue);
                int categoriaId = Convert.ToInt32(comboBoxCategoria.SelectedValue);

                // 🔹 Generar un código único para el producto
                string codigo = "PRD-" + DateTime.Now.Ticks.ToString().Substring(8);

                // 🔹 Convertir la imagen a bytes
                byte[] imagenBytes = null;
                if (pictureBoxImagen.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imagenBytes = ms.ToArray();
                    }
                }

                // 🔹 Insertar en la base de datos usando transacciones
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // ✅ 1. Insertar producto
                            string queryProducto = @"
          INSERT INTO Invt.Tb_Productos
        (Producto_Codigo, Producto_Nombre, Producto_Descripcion, Producto_CostoUnitario, Producto_Descuento,
          Producto_FechaIngreso, UnidadMedida_Id, Proveedor_Id, ServicioBien_Id, Categoria_Id, Producto_Imagen)
           OUTPUT INSERTED.Producto_Id
     VALUES (@Codigo, @Nombre, @Descripcion, @Costo, @Descuento, 
          @Fecha, @Unidad, @Proveedor, @Servicio, @Categoria, @Imagen)";

                            int productoId;
                            using (SqlCommand commandProducto = new SqlCommand(queryProducto, connection, transaction))
                            {
                                commandProducto.Parameters.AddWithValue("@Codigo", codigo);
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

                                productoId = (int)commandProducto.ExecuteScalar();
                            }

                            // ✅ 2. Insertar en inventario si hay stock inicial
                            if (stockInicial > 0)
                            {
                                // Obtener una estantería disponible
                                string queryEstanteria = @"
              SELECT TOP 1 Estanteria_Id 
     FROM Invt.Tb_Estanterias 
      WHERE EstadoBodega_Id IN (SELECT EstadoBodega_Id FROM Invt.Tb_EstadoBodegas WHERE EstadoBodega_Estado = 'Activo')
             ORDER BY Estanteria_Id";

                                int estanteriaId = 1; // Valor por defecto
                                using (SqlCommand commandEstanteria = new SqlCommand(queryEstanteria, connection, transaction))
                                {
                                    var result = commandEstanteria.ExecuteScalar();
                                    if (result != null)
                                    {
                                        estanteriaId = Convert.ToInt32(result);
                                    }
                                }

                                // Calcular precio de venta (costo + 30% de margen)
                                decimal precioVenta = costoUnitario * 1.30m;

                                string queryInventario = @"
      INSERT INTO Invt.Tb_Inventario 
        (Estanteria_Id, Producto_Id, Cantidad_Disponible, Fecha_de_Actualizacion, Precio_Venta)
              VALUES (@EstanteriaId, @ProductoId, @Stock, GETDATE(), @PrecioVenta)";

                                using (SqlCommand commandInventario = new SqlCommand(queryInventario, connection, transaction))
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

                            MessageBox.Show("✅ Producto y stock ingresados exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 🔹 Limpiar formulario
                            txtBoxNombreProducto.Clear();
                            textBoxDescripcion.Clear();
                            textBoxCostoUnitario.Clear();
                            textBoxDescuento.Clear();
                            textBoxStock.Clear(); // ✅ Limpiar campo de stock
                            comboBoxUnidadMedida.SelectedIndex = -1;
                            comboBoxProveedor.SelectedIndex = -1;
                            comboBoxTipoServicioProducto.SelectedIndex = -1;
                            comboBoxCategoria.SelectedIndex = -1;
                            pictureBoxImagen.Image = null;
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
                MessageBox.Show("⚠️ Por favor verifica que los campos numéricos (costo, descuento, stock) tengan valores válidos.", "Error de formato",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al insertar en la base de datos: " + ex.Message, "Error",
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
            }
        }

        private void comboBoxUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
