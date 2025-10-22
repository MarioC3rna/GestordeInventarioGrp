using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Base_de_Datos
{
    public partial class OpcionesForm : Form
    {
        public OpcionesForm()
        {
            InitializeComponent();
   
          // Configurar label de usuario con mejor posicionamiento
    lblUsuario = new Label();
        lblUsuario.AutoSize = true;
   lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
  lblUsuario.ForeColor = Color.MediumSlateBlue;
lblUsuario.Location = new Point(20, 70);
         lblUsuario.Name = "lblUsuario";
   lblUsuario.Size = new Size(100, 23);
  Controls.Add(lblUsuario);

   // Mejorar posición del botón atrás
       ConfigurarBotonAtras();
        
      // Configurar el formulario
    ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
 {
    // Establecer tamaño fijo del formulario
            this.Size = new Size(700, 500);
    this.StartPosition = FormStartPosition.CenterScreen;
   this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        
       // Configurar el panel superior
         topPanel.Size = new Size(this.Width, 60);
    topPanel.Location = new Point(0, 0);
 topPanel.Dock = DockStyle.Top;
            
         // Configurar el título
          lblopciones.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblopciones.ForeColor = Color.MediumSlateBlue;
       lblopciones.Text = "OPCIONES";
   lblopciones.AutoSize = false;
         lblopciones.Size = new Size(200, 40);
      lblopciones.TextAlign = ContentAlignment.MiddleCenter;
   lblopciones.Location = new Point((this.Width - lblopciones.Width) / 2, 80);
      }

        private void ConfigurarBotonAtras()
        {
    buttonAtrasOP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonAtrasOP.Location = new Point(20, this.Height - 80);
    buttonAtrasOP.Size = new Size(80, 30);
  buttonAtrasOP.BackColor = Color.FromArgb(128, 128, 128);
          buttonAtrasOP.ForeColor = Color.White;
            buttonAtrasOP.FlatStyle = FlatStyle.Flat;
        buttonAtrasOP.FlatAppearance.BorderSize = 0;
     buttonAtrasOP.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
       buttonAtrasOP.Text = "Atrás";
       buttonAtrasOP.Cursor = Cursors.Hand;
        }

    private void lblTitle_Click(object sender, EventArgs e)
     {
        }

   private void OpcionesForm_Load(object sender, EventArgs e)
    {
    string usuario = UsuarioActivo.NombreUsuario;

      // Mostrar usuario en algún label opcional
            lblUsuario.Text = $"👤 Usuario: {usuario.ToUpper()}";
   
   // Crear lista de botones disponibles según el rol
         List<Button> botonesDisponibles = new List<Button>();

          // Configurar visibilidad y recopilar botones según rol
            switch (usuario)
            {
           case "admin_inventario":
 botonesDisponibles.Add(IngresarButton);
            botonesDisponibles.Add(BuscarButton);
          botonesDisponibles.Add(butonActualizar);
        botonesDisponibles.Add(buttonEliminarRegistro);
   botonesDisponibles.Add(buttonGenerarReporte);
     break;

      case "gerente":
          botonesDisponibles.Add(IngresarButton);
       botonesDisponibles.Add(BuscarButton);
 botonesDisponibles.Add(butonActualizar);
       botonesDisponibles.Add(buttonGenerarReporte);
            break;

    case "bodega":
    botonesDisponibles.Add(IngresarButton);
           botonesDisponibles.Add(BuscarButton);
          break;

     case "analista":
             botonesDisponibles.Add(BuscarButton);
         botonesDisponibles.Add(buttonGenerarReporte);
          break;

default:
       MessageBox.Show("Usuario no reconocido, permisos limitados.", "Atención", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        botonesDisponibles.Add(BuscarButton); // Solo acceso básico
          break;
        }

 // Ocultar todos los botones primero
            OcultarTodosLosBotones();

            // Reorganizar y mostrar solo los botones disponibles
            ReorganizarBotones(botonesDisponibles);
            
   // Mostrar información del rol
  MostrarInformacionRol(usuario, botonesDisponibles.Count);
        }

        private void MostrarInformacionRol(string usuario, int cantidadBotones)
        {
string rolDescripcion = "";
  switch (usuario)
      {
                case "admin_inventario":
  rolDescripcion = "ADMINISTRADOR - Acceso Total";
     break;
     case "gerente":
             rolDescripcion = "GERENTE - Gestión Completa";
 break;
case "bodega":
           rolDescripcion = "BODEGA - Operaciones Básicas";
           break;
                case "analista":
 rolDescripcion = "ANALISTA - Solo Consultas";
   break;
     default:
         rolDescripcion = "INVITADO - Acceso Limitado";
     break;
     }

         // Crear o actualizar label de rol si no existe
        Label lblRol = Controls.Find("lblRol", true).FirstOrDefault() as Label;
        if (lblRol == null)
            {
   lblRol = new Label();
    lblRol.Name = "lblRol";
  lblRol.AutoSize = true;
     lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
         lblRol.ForeColor = Color.Gray;
     Controls.Add(lblRol);
         }

            lblRol.Text = $"{rolDescripcion} ({cantidadBotones} funciones disponibles)";
      lblRol.Location = new Point(20, 95);
        }

        private void OcultarTodosLosBotones()
    {
       IngresarButton.Visible = false;
            BuscarButton.Visible = false;
    butonActualizar.Visible = false;
 buttonEliminarRegistro.Visible = false;
            buttonGenerarReporte.Visible = false;
      }

        private void ReorganizarBotones(List<Button> botonesDisponibles)
        {
   // Configuración de diseño mejorada
         int margenIzquierdo = 110;
 int margenSuperior = 140;
       int anchoBoton = 220;
            int altoBoton = 50;
     int espaciadoHorizontal = 260;
            int espaciadoVertical = 70;
         int columnas = 2;

      // Personalizar apariencia y posición de cada botón
            for (int i = 0; i < botonesDisponibles.Count; i++)
   {
            Button boton = botonesDisponibles[i];
  
          // Calcular posición en grid
    int fila = i / columnas;
        int columna = i % columnas;
  
  // Establecer posición
            boton.Location = new Point(
  margenIzquierdo + (columna * espaciadoHorizontal),
       margenSuperior + (fila * espaciadoVertical)
  );
    
 // Establecer tamaño uniforme
boton.Size = new Size(anchoBoton, altoBoton);
 
                // Personalizar apariencia según tipo de botón
     PersonalizarBoton(boton);
 
   // Hacer visible
              boton.Visible = true;
   }

            // Centrar los botones si hay número impar en la última fila
            CentrarUltimaFila(botonesDisponibles, columnas, margenIzquierdo, espaciadoHorizontal, anchoBoton);
        }

        private void PersonalizarBoton(Button boton)
        {
     // Configuración base para todos los botones
            boton.FlatStyle = FlatStyle.Flat;
      boton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            boton.ForeColor = Color.White;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.DarkGray;
     boton.Cursor = Cursors.Hand;

      // Colores específicos según función
      if (boton == IngresarButton)
   {
   boton.BackColor = Color.FromArgb(34, 139, 34);  // Verde
         boton.Text = "INGRESAR PRODUCTOS";
          }
      else if (boton == BuscarButton)
         {
    boton.BackColor = Color.FromArgb(70, 130, 180);  // Azul
     boton.Text = "BUSCAR PRODUCTOS";
            }
  else if (boton == butonActualizar)
       {
         boton.BackColor = Color.FromArgb(255, 140, 0); // Naranja
       boton.Text = "ACTUALIZAR";
       }
    else if (boton == buttonEliminarRegistro)
            {
                boton.BackColor = Color.FromArgb(220, 20, 60);   // Rojo
     boton.Text = "ELIMINAR REGISTRO";
       }
            else if (boton == buttonGenerarReporte)
 {
          boton.BackColor = Color.FromArgb(138, 43, 226);// Púrpura
        boton.Text = "GENERAR REPORTE";
            }

   // Efectos hover
        boton.MouseEnter += (s, e) => {
       Button btn = s as Button;
         btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.BorderColor = Color.White;
            };

            boton.MouseLeave += (s, e) => {
         Button btn = s as Button;
         btn.FlatAppearance.BorderSize = 1;
    btn.FlatAppearance.BorderColor = Color.DarkGray;
         };
        }

        private void CentrarUltimaFila(List<Button> botones, int columnas, int margenIzquierdo, 
   int espaciadoHorizontal, int anchoBoton)
   {
     int totalBotones = botones.Count;
            int botonesUltimaFila = totalBotones % columnas;
 
    // Si hay botones en la última fila y no completan las columnas
   if (botonesUltimaFila > 0 && botonesUltimaFila < columnas)
 {
          int filaActual = (totalBotones - 1) / columnas;
   
       // Calcular posición centrada para el botón único en la última fila
     if (botonesUltimaFila == 1)
          {
           int indiceBoton = totalBotones - 1;
             int posicionCentrada = (this.ClientSize.Width - anchoBoton) / 2;
        botones[indiceBoton].Location = new Point(
        posicionCentrada,
     botones[indiceBoton].Location.Y
     );
  }
            }
        }

 private void IngresarButton_Click(object sender, EventArgs e)
        {
            IngresarForm ingresarForm = new IngresarForm();
            ingresarForm.Show();
      this.Hide();
        }

      private void buttonEliminarRegistro_Click(object sender, EventArgs e)
    {
      EliminarForm eliminarForm = new EliminarForm();
 eliminarForm.Show();
    this.Hide();
    }

        private void butonActualizar_Click(object sender, EventArgs e)
        {
            ActualizarForm actualizarForm = new ActualizarForm();
            actualizarForm.Show();
  this.Hide();
      }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
     BuscarForm buscarForm = new BuscarForm();
            buscarForm.Show();
       this.Hide();
        }

        private void buttonGenerarReporte_Click(object sender, EventArgs e)
   {
            ReportesForm reportesForm = new ReportesForm();
            reportesForm.Show();
            this.Hide();
        }
    }
}
