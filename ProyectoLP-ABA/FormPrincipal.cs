using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace ProyectoLP_ABA
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        #region Funcionalidades del Formulario
        //Este siguientes lineas sirven para poder mover (arrastrar) el formulario principal donde se van a derivar los siguientes forms dentro de una panel 
        //Para ello también se necesita algunas eventos del mouse.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        //YA NO FUNCIONA
        private void btnSlide_Click(object sender, EventArgs e)
        {
            
        }
        //NO FUNCIONA
        private void iconcerrar_Click(object sender, EventArgs e)
        {
            
        }
        

        //YA NO SIRVE, NO LA PUEDO ELIMINAR PORQUE SE CAE EL PROGRAMA
        private void iconmaximizar_Click(object sender, EventArgs e)
        {

        }
        //NO REALIZA NADA, NO TOCAR
        private void iconrestaurar_Click(object sender, EventArgs e)
        {

        }
        //ESTE METODO YA NO REALIZA NADA, NO TOCAR
        private void iconminimizar_Click(object sender, EventArgs e)
        {
            
        }
        //NO HACE NADA, NO TOCAR
        private void button1_Click(object sender, EventArgs e)//A este boton lo renombre como "btningreso" solo que por error cree antes el evento.
        {

        }
        
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        int LX, LY, SW, SH;
        

        

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            //lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        
        private void mostrarlogoalcerrarformulario(object sender, FormClosedEventArgs e)
        {
            

        }
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        private void iconcerrar_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Desea Salir de la Aplicación",
               "Salir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btningreso_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Ingresos>();
            btningreso.BackColor = Color.FromArgb(12,61,92);
        }

        private void btnSlide_Click_1(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }

        private void iconminimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconmaximizar_Click_1(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            LX = this.Location.X;
            LY = this.Location.Y;
            SW = this.Size.Width;
            SH = this.Size.Height;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconrestaurar_Click_1(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(SW, SH);
            this.Location = new Point(LX, LY);
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55,61,69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent , sizeGripRectangle);
        }

        #endregion
        private void HF_Tick(object sender, EventArgs e)
        {
            lblh.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente>();
            btndocente.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Desea Salir de la Aplicación",
               "Salir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCoordinador_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCoordinador>();
            btnCoordinador.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Configuraciones>();
            btnConfig.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<FormFuncionesPDF>();
        }

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {
            //No hace nada no borrar
        }

        

        private void AbrirFormulario<MiForm>()where MiForm :Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la conexión el formulario
            //si el formulario no existe
            if(formulario==null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Ingresos"] == null)
                btningreso.BackColor = Color.FromArgb(0, 122, 204);
            if (Application.OpenForms["FormDocente"] == null)
                btndocente.BackColor = Color.FromArgb(0, 122, 204);
            if (Application.OpenForms["FormCoordinador"] == null)
                btnCoordinador.BackColor = Color.FromArgb(0, 122, 204);
            if (Application.OpenForms["Configuraciones"] == null)
                btnConfig.BackColor = Color.FromArgb(0, 122, 204);
            if (Application.OpenForms["FormFuncionesPDF"] == null)
                button1.BackColor = Color.FromArgb(0, 122, 204);

        }

    }

}
