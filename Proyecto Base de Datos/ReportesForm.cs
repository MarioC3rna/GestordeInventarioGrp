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
using OfficeOpenXml;
using System.IO;

namespace Proyecto_Base_de_Datos
{
    public partial class ReportesForm : Form
    {
        private string connectionString = "Data Source=SRV-BD\\MYISTANCE;Initial Catalog=Db_EmpresaDev;User ID=admin_inventario;Password=Adm!n2025$;Encrypt=True;TrustServerCertificate=True;";
        private DataTable datosReporte;

        public ReportesForm()
    {
          InitializeComponent();
 // Configurar EPPlus
     ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
    }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
 CargarCombos();
     radioButtonInventario.Checked = true; // Seleccionar por defecto
        }

        private void CargarCombos()
     {
            try
            {
     // Cargar categorías
        CargarComboBox(comboBoxCategoria, "Invt.Tb_Categorias", "Categoria_Id", "Categoria_Nombre");
       
   // Cargar proveedores
 CargarComboBox(comboBoxProveedor, "Invt.Tb_Proveedores", "Proveedor_Id", "Proveedor_Nombre");
          
   // ? Cargar bodegas activas
         CargarBodegas();
     }
       catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message, "Error", 
        MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
        }

        private void CargarComboBox(ComboBox combo, string tabla, string idCol, string nombreCol)
 {
            using (SqlConnection connection = new SqlConnection(connectionString))
       {
          string query = $"SELECT {idCol}, {nombreCol} FROM {tabla} ORDER BY {nombreCol}";
       SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
   adapter.Fill(data);

              combo.DataSource = data;
       combo.DisplayMember = nombreCol;
    combo.ValueMember = idCol;
 combo.SelectedIndex = -1;
  }
 }

 // ? Método para cargar bodegas activas
     private void CargarBodegas()
     {
    using (SqlConnection connection = new SqlConnection(connectionString))
       {
       // ? Consulta corregida usando esquema Invt.Tb_Bodegas
       string query = @"
    SELECT B.Bodega_Id, B.Bodega_NumeroBodega 
    FROM Invt.Tb_Bodegas B
ORDER BY B.Bodega_NumeroBodega";

       SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
  DataTable data = new DataTable();
  adapter.Fill(data);

        comboBoxBodega.DataSource = data;
   // ? Mostrar número de bodega
   comboBoxBodega.DisplayMember = "Bodega_NumeroBodega";
         // ? Usar ID de bodega
     comboBoxBodega.ValueMember = "Bodega_Id";
    comboBoxBodega.SelectedIndex = -1;
     }
        }

   private void checkBoxFechas_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerDesde.Enabled = checkBoxFechas.Checked;
            dateTimePickerHasta.Enabled = checkBoxFechas.Checked;
            
            if (checkBoxFechas.Checked)
      {
       dateTimePickerDesde.Value = DateTime.Now.AddDays(-30);
   dateTimePickerHasta.Value = DateTime.Now;
        }
    }

        private void checkBoxCategoria_CheckedChanged(object sender, EventArgs e)
        {
      comboBoxCategoria.Enabled = checkBoxCategoria.Checked;
  if (!checkBoxCategoria.Checked)
            {
       comboBoxCategoria.SelectedIndex = -1;
       }
        }

    private void checkBoxProveedor_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxProveedor.Enabled = checkBoxProveedor.Checked;
            if (!checkBoxProveedor.Checked)
      {
   comboBoxProveedor.SelectedIndex = -1;
          }
    }

        // ? Evento para habilitar/deshabilitar comboBoxBodega
        private void checkBoxBodega_CheckedChanged(object sender, EventArgs e)
        {
     comboBoxBodega.Enabled = checkBoxBodega.Checked;
   if (!checkBoxBodega.Checked)
            {
  comboBoxBodega.SelectedIndex = -1;
      }
  }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
 try
          {
    string query = ObtenerConsultaSegunTipo();
 
    if (string.IsNullOrEmpty(query))
    {
           MessageBox.Show("Por favor selecciona un tipo de reporte.", "Advertencia", 
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
       return;
     }

  using (SqlConnection connection = new SqlConnection(connectionString))
              {
               SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
   
         // Agregar parámetros si es necesario
        AgregarParametros(adapter.SelectCommand);
        
  datosReporte = new DataTable();
        adapter.Fill(datosReporte);

         dataGridViewReporte.DataSource = datosReporte;
     
      if (datosReporte.Rows.Count > 0)
       {
             buttonExportar.Enabled = true;
    labelInfo.Text = $"Reporte generado: {datosReporte.Rows.Count} registros encontrados";
       labelInfo.ForeColor = Color.Green;
              }
           else
           {
      buttonExportar.Enabled = false;
             labelInfo.Text = "No se encontraron datos para los criterios especificados";
  labelInfo.ForeColor = Color.Orange;
         }
     }
     }
    catch (Exception ex)
   {
    MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
         labelInfo.Text = "Error al generar el reporte";
        labelInfo.ForeColor = Color.Red;
            }
        }

        private string ObtenerConsultaSegunTipo()
     {
  string whereClause = ObtenerClausulaWhere();
   
     if (radioButtonInventario.Checked)
            {
// ? Reporte de Inventario con Bodega - usando esquema correcto
 return $@"
SELECT 
    P.Producto_Codigo AS 'Código',
  P.Producto_Nombre AS 'Producto',
  C.Categoria_Nombre AS 'Categoría',
   PR.Proveedor_Nombre AS 'Proveedor',
     I.Cantidad_Disponible AS 'Stock',
   I.Precio_Venta AS 'Precio Venta',
     B.Bodega_NumeroBodega AS 'Bodega',
  E.Estanteria_Codigo AS 'Estantería'
    FROM Invt.Tb_Inventario I
      INNER JOIN Invt.Tb_Productos P ON I.Producto_Id = P.Producto_Id
         INNER JOIN Invt.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
  INNER JOIN Invt.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
       INNER JOIN Invt.Tb_Estanterias E ON I.Estanteria_Id = E.Estanteria_Id
 INNER JOIN Invt.Tb_Bodegas B ON E.Bodega_Id = B.Bodega_Id
         {whereClause}
       ORDER BY B.Bodega_NumeroBodega, P.Producto_Nombre";
  }
 else if (radioButtonProductos.Checked)
     {
 return $@"
    SELECT 
P.Producto_Codigo AS 'Código',
  P.Producto_Nombre AS 'Producto',
    P.Producto_Descripcion AS 'Descripción',
P.Producto_CostoUnitario AS 'Costo Unitario',
 P.Producto_Descuento AS 'Descuento',
   P.Producto_FechaIngreso AS 'Fecha Ingreso',
         C.Categoria_Nombre AS 'Categoría',
   PR.Proveedor_Nombre AS 'Proveedor',
SB.ServicioBien_Nombre AS 'Tipo Servicio',
   UM.UnidadMedida_Longitud AS 'Unidad Medida'
    FROM Invt.Tb_Productos P
   INNER JOIN Invt.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
      INNER JOIN Invt.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
    INNER JOIN Invt.Tb_ServiciosBienes SB ON P.ServicioBien_Id = SB.ServicioBien_Id
INNER JOIN Invt.Tb_UnidadMedidas UM ON P.UnidadMedida_Id = UM.UnidadMedida_Id
       {whereClause}
  ORDER BY P.Producto_Nombre";
 }
 else if (radioButtonProveedores.Checked)
   {
     return $@"
   SELECT 
  PR.Proveedor_NIT AS 'NIT',
           PR.Proveedor_Nombre AS 'Proveedor',
    M.Municipio_Nombre AS 'Municipio',
        D.Depto_Nombre AS 'Departamento',
      COUNT(DISTINCT P.Producto_Id) AS 'Productos Registrados',
 ISNULL(SUM(I.Cantidad_Disponible), 0) AS 'Stock Total'
   FROM Invt.Tb_Proveedores PR
     INNER JOIN Invt.Tb_Municipios M ON PR.Municipio_Id = M.Municipio_Id
          INNER JOIN Invt.Tb_Departamentos D ON M.Depto_Id = D.Depto_Id
       LEFT JOIN Invt.Tb_Productos P ON PR.Proveedor_Id = P.Proveedor_Id
    LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
 GROUP BY PR.Proveedor_Id, PR.Proveedor_NIT, PR.Proveedor_Nombre, 
       M.Municipio_Nombre, D.Depto_Nombre
        ORDER BY PR.Proveedor_Nombre";
         }
         else if (radioButtonCategorias.Checked)
   {
      return $@"
    SELECT 
    C.Categoria_Nombre AS 'Categoría',
         COUNT(DISTINCT P.Producto_Id) AS 'Productos',
   AVG(P.Producto_CostoUnitario) AS 'Costo Promedio',
   SUM(ISNULL(I.Cantidad_Disponible, 0)) AS 'Stock Total'
     FROM Invt.Tb_Categorias C
   LEFT JOIN Invt.Tb_Productos P ON C.Categoria_Id = P.Categoria_Id
 LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
    GROUP BY C.Categoria_Id, C.Categoria_Nombre
   ORDER BY C.Categoria_Nombre";
 }
     else if (radioButtonVentas.Checked)
  {
   // ? Reporte de Productos por Bodega - usando esquema correcto
  return $@"
       SELECT 
       B.Bodega_NumeroBodega AS 'Bodega',
P.Producto_Codigo AS 'Código',
            P.Producto_Nombre AS 'Producto',
        PR.Proveedor_Nombre AS 'Proveedor',
      C.Categoria_Nombre AS 'Categoría',
    I.Cantidad_Disponible AS 'Stock',
    P.Producto_CostoUnitario AS 'Costo',
   I.Precio_Venta AS 'Precio Venta'
FROM Invt.Tb_Bodegas B
         INNER JOIN Invt.Tb_Estanterias E ON B.Bodega_Id = E.Bodega_Id
   INNER JOIN Invt.Tb_Inventario I ON E.Estanteria_Id = I.Estanteria_Id
     INNER JOIN Invt.Tb_Productos P ON I.Producto_Id = P.Producto_Id
 INNER JOIN Invt.Tb_Proveedores PR ON P.Proveedor_Id = PR.Proveedor_Id
    INNER JOIN Invt.Tb_Categorias C ON P.Categoria_Id = C.Categoria_Id
  {whereClause}
    ORDER BY B.Bodega_NumeroBodega, P.Producto_Nombre";
   }

         return string.Empty;
      }

        private string ObtenerClausulaWhere()
  {
  List<string> condiciones = new List<string>();

  if (checkBoxFechas.Checked && (radioButtonProductos.Checked || radioButtonVentas.Checked))
     {
   condiciones.Add("P.Producto_FechaIngreso BETWEEN @FechaDesde AND @FechaHasta");
   }

      if (checkBoxCategoria.Checked && comboBoxCategoria.SelectedValue != null)
  {
condiciones.Add("P.Categoria_Id = @CategoriaId");
}

     if (checkBoxProveedor.Checked && comboBoxProveedor.SelectedValue != null)
 {
   condiciones.Add("P.Proveedor_Id = @ProveedorId");
     }

 // ? Filtro por bodega usando Bodega_Id
    if (checkBoxBodega.Checked && comboBoxBodega.SelectedValue != null)
    {
     condiciones.Add("B.Bodega_Id = @BodegaId");
 }

  return condiciones.Count > 0 ? "WHERE " + string.Join(" AND ", condiciones) : "";
     }

        private void AgregarParametros(SqlCommand command)
     {
    if (checkBoxFechas.Checked)
            {
      command.Parameters.AddWithValue("@FechaDesde", dateTimePickerDesde.Value.Date);
   command.Parameters.AddWithValue("@FechaHasta", dateTimePickerHasta.Value.Date.AddDays(1).AddSeconds(-1));
  }

        if (checkBoxCategoria.Checked && comboBoxCategoria.SelectedValue != null)
            {
    command.Parameters.AddWithValue("@CategoriaId", comboBoxCategoria.SelectedValue);
      }

            if (checkBoxProveedor.Checked && comboBoxProveedor.SelectedValue != null)
            {
   command.Parameters.AddWithValue("@ProveedorId", comboBoxProveedor.SelectedValue);
            }

            // ? Agregar parámetro de bodega
            if (checkBoxBodega.Checked && comboBoxBodega.SelectedValue != null)
      {
         command.Parameters.AddWithValue("@BodegaId", comboBoxBodega.SelectedValue);
      }
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
        if (datosReporte == null || datosReporte.Rows.Count == 0)
            {
      MessageBox.Show("No hay datos para exportar.", "Advertencia", 
         MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
   saveDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
            saveDialog.Title = "Guardar Reporte";
 saveDialog.FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

       if (saveDialog.ShowDialog() == DialogResult.OK)
  {
       try
  {
ExportarAExcel(saveDialog.FileName);
        MessageBox.Show($"Reporte exportado exitosamente a:\n{saveDialog.FileName}", 
       "Exportación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
       }
     catch (Exception ex)
     {
   MessageBox.Show("Error al exportar: " + ex.Message, "Error", 
       MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
  }
        }

     private void ExportarAExcel(string rutaArchivo)
        {
      using (ExcelPackage package = new ExcelPackage())
            {
        // Crear hoja de trabajo
    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Reporte");

      // Agregar título
        string tipoReporte = ObtenerNombreTipoReporte();
           worksheet.Cells[1, 1].Value = $"REPORTE: {tipoReporte}";
       worksheet.Cells[1, 1].Style.Font.Bold = true;
            worksheet.Cells[1, 1].Style.Font.Size = 16;
                
// Agregar fecha de generación
              worksheet.Cells[2, 1].Value = $"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}";
    worksheet.Cells[2, 1].Style.Font.Italic = true;

     // Agregar filtros aplicados
         string filtros = ObtenerDescripcionFiltros();
      if (!string.IsNullOrEmpty(filtros))
  {
     worksheet.Cells[3, 1].Value = filtros;
    worksheet.Cells[3, 1].Style.Font.Italic = true;
       }

      // Agregar encabezados
     int filaInicio = 5;
    for (int col = 0; col < datosReporte.Columns.Count; col++)
     {
   worksheet.Cells[filaInicio, col + 1].Value = datosReporte.Columns[col].ColumnName;
         worksheet.Cells[filaInicio, col + 1].Style.Font.Bold = true;
         worksheet.Cells[filaInicio, col + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    worksheet.Cells[filaInicio, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
          }

            // Agregar datos
           for (int fila = 0; fila < datosReporte.Rows.Count; fila++)
                {
         for (int col = 0; col < datosReporte.Columns.Count; col++)
        {
     var valor = datosReporte.Rows[fila][col];
               worksheet.Cells[fila + filaInicio + 1, col + 1].Value = valor;
   }
           }

       // Ajustar ancho de columnas
      worksheet.Cells.AutoFitColumns();

     // Agregar bordes
       var rango = worksheet.Cells[filaInicio, 1, filaInicio + datosReporte.Rows.Count, datosReporte.Columns.Count];
        rango.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            rango.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        rango.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
          rango.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

    // Guardar archivo
   FileInfo file = new FileInfo(rutaArchivo);
       package.SaveAs(file);
         }
        }

        private string ObtenerNombreTipoReporte()
  {
   if (radioButtonInventario.Checked) return "INVENTARIO DISPONIBLE POR BODEGA";
        if (radioButtonProductos.Checked) return "LISTA DE PRODUCTOS";
 if (radioButtonProveedores.Checked) return "LISTA DE PROVEEDORES";
            if (radioButtonCategorias.Checked) return "LISTA DE CATEGORÍAS";
     if (radioButtonVentas.Checked) return "PRODUCTOS POR BODEGA";
            return "REPORTE GENERAL";
   }

        private string ObtenerDescripcionFiltros()
        {
   List<string> filtros = new List<string>();

        if (checkBoxFechas.Checked)
            {
       filtros.Add($"Fechas: {dateTimePickerDesde.Value:dd/MM/yyyy} - {dateTimePickerHasta.Value:dd/MM/yyyy}");
  }

            if (checkBoxCategoria.Checked && comboBoxCategoria.SelectedItem != null)
          {
       filtros.Add($"Categoría: {comboBoxCategoria.Text}");
   }

        if (checkBoxProveedor.Checked && comboBoxProveedor.SelectedItem != null)
 {
       filtros.Add($"Proveedor: {comboBoxProveedor.Text}");
         }

       // ? Agregar filtro de bodega en la descripción
            if (checkBoxBodega.Checked && comboBoxBodega.SelectedItem != null)
            {
                filtros.Add($"Bodega: {comboBoxBodega.Text}");
 }

 return filtros.Count > 0 ? "Filtros aplicados: " + string.Join(", ", filtros) : "";
        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
          OpcionesForm opcionesForm = new OpcionesForm();
   opcionesForm.Show();
            this.Hide();
  }
    }
}