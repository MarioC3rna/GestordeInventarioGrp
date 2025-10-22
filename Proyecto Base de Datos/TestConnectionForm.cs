using System;
using System.Windows.Forms;

namespace Proyecto_Base_de_Datos
{
    public partial class TestConnectionForm : Form
    {
        private Button btnTestConnection;
    private Button btnTestDetails;
        private TextBox txtResults;
        private Label lblTitle;

   public TestConnectionForm()
      {
       InitializeComponent();
 }

     private void InitializeComponent()
        {
   this.btnTestConnection = new Button();
    this.btnTestDetails = new Button();
            this.txtResults = new TextBox();
   this.lblTitle = new Label();
       this.SuspendLayout();

     // lblTitle
     this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
   this.lblTitle.Location = new System.Drawing.Point(12, 9);
      this.lblTitle.Size = new System.Drawing.Size(200, 20);
            this.lblTitle.Text = "Prueba de Conexi�n a BD";

   // btnTestConnection
        this.btnTestConnection.Location = new System.Drawing.Point(15, 40);
            this.btnTestConnection.Size = new System.Drawing.Size(150, 30);
     this.btnTestConnection.Text = "Probar Conexi�n";
     this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new EventHandler(this.BtnTestConnection_Click);

  // btnTestDetails
            this.btnTestDetails.Location = new System.Drawing.Point(180, 40);
    this.btnTestDetails.Size = new System.Drawing.Size(150, 30);
     this.btnTestDetails.Text = "Detalles de Conexi�n";
 this.btnTestDetails.UseVisualStyleBackColor = true;
       this.btnTestDetails.Click += new EventHandler(this.BtnTestDetails_Click);

     // txtResults
       this.txtResults.Location = new System.Drawing.Point(15, 80);
     this.txtResults.Multiline = true;
      this.txtResults.ReadOnly = true;
    this.txtResults.ScrollBars = ScrollBars.Vertical;
    this.txtResults.Size = new System.Drawing.Size(450, 200);

      // TestConnectionForm
       this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
       this.ClientSize = new System.Drawing.Size(484, 301);
     this.Controls.Add(this.txtResults);
     this.Controls.Add(this.btnTestDetails);
       this.Controls.Add(this.btnTestConnection);
  this.Controls.Add(this.lblTitle);
     this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
   this.MinimizeBox = false;
     this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Prueba de Conexi�n";
  this.ResumeLayout(false);
     this.PerformLayout();
        }

  private void BtnTestConnection_Click(object sender, EventArgs e)
     {
  try
    {
this.Cursor = Cursors.WaitCursor;
     txtResults.Text = "Probando conexi�n...\r\n";
      Application.DoEvents();

       bool isConnected = DatabaseConnection.TestConnection();
  
       if (isConnected)
       {
       txtResults.Text += "? CONEXI�N EXITOSA\r\n";
         txtResults.Text += "La aplicaci�n puede conectarse correctamente a la base de datos.\r\n";
            }
   else
      {
       txtResults.Text += "? ERROR DE CONEXI�N\r\n";
 txtResults.Text += "No se pudo conectar a la base de datos. Verifica:\r\n";
           txtResults.Text += "- Que SQL Server est� ejecut�ndose\r\n";
txtResults.Text += "- Que la instancia SRV-BD\\MYISTANCE est� disponible\r\n";
         txtResults.Text += "- Que las credenciales sean correctas\r\n";
      txtResults.Text += "- Que la base de datos Db_EmpresaDev exista\r\n";
                }
            }
        catch (Exception ex)
       {
   txtResults.Text += $"? EXCEPCI�N: {ex.Message}\r\n";
      }
            finally
        {
  this.Cursor = Cursors.Default;
         }
      }

      private void BtnTestDetails_Click(object sender, EventArgs e)
      {
       try
     {
   this.Cursor = Cursors.WaitCursor;
     txtResults.Text = "Obteniendo detalles de conexi�n...\r\n";
           Application.DoEvents();

     string details = DatabaseConnection.TestConnectionWithDetails();
        txtResults.Text += details + "\r\n";
        
    txtResults.Text += "\r\n--- INFORMACI�N ADICIONAL ---\r\n";
         txtResults.Text += $"Cadena de conexi�n: {DatabaseConnection.ConnectionString}\r\n";
  txtResults.Text += $"Fecha/Hora de prueba: {DateTime.Now}\r\n";
     }
     catch (Exception ex)
    {
      txtResults.Text += $"? Error al obtener detalles: {ex.Message}\r\n";
            }
            finally
     {
         this.Cursor = Cursors.Default;
      }
   }
    }
}