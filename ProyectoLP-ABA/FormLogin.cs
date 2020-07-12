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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }
        //Este siguientes lineas sirven para poder mover (arrastrar) el formulario del login 
        //Para ello también se necesita algunas eventos del mouse.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.LightGray;
                
            }
                
           
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if(txtusuario.Text=="")
            {
                txtusuario.Text = "USUARIO";
                txtusuario.ForeColor = Color.DimGray;
                

            }


        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
                
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
                
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Desea Salir de la Aplicación",
               "Salir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btningreso_Click(object sender, EventArgs e)
        {
            int prioridad = VerificarIngreso(txtusuario.Text.Trim(), txtpass.Text.Trim());
            if (txtpass.Text.Trim() == "CONTRASEÑA" && txtusuario.Text.Trim() == "USUARIO")
            {
                //label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                txtpass.Focus();
            }
            else if (txtusuario.Text == "USUARIO")
            {
                label4.Visible = true;
                txtusuario.Focus();
                label5.Visible = false;
            }
            else if (txtpass.Text== "CONTRASEÑA")
            {
                label5.Visible = true;
                txtpass.Focus();
                label4.Visible = false;
            }

            else if (!(prioridad == -1 || prioridad == -2))
            {

                FormPrincipal obj = new FormPrincipal();
                obj.Visible = true;
                Visible = false;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                label3.Visible = true;
            }
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }


        //Recibe el usuario y contraseña
        //Devuelve un int especificando el resultado de la operacion
        //  -2: No se encontro el nombre de usuario
        //  -1: Se encontro el nombre de usuario, pero la contraseia es incorrecta
        //   0: Prioridad de Administrador
        //   1: Prioridad de Docente Coordinador
        //   2: Prioridad de Coordinador
        //   3: Prioridad de Docente
        private int VerificarIngreso(string nombre, string contrasenia)
        {
            string[] aux, usuarios;
            string desencriptar;
            int tipo = -2;
            ManejoDeArchivos.CrearArchivo("datos\\usuarios.txt");
            usuarios = File.ReadAllLines("datos\\usuarios.txt");
            //▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
            if (usuarios.Length == 0)
            {
                ManejoDeArchivos.AniadirLineaArchivo("datos\\usuarios.txt", "alejandro░0EAiLOtyIOF1pKRUr72kC/fKmocSMuyY+R7OO5PI7dNytmCzxUl7i3y57VasfAfVjQlrs4+daBaTs2te0B48ZwTusXhBQMu1DcY4mKOkSDp7Ev+FGS1A8yRpKDzE5bmq░AlejandroVivanco;11");
            }
            for (int i = 0; i < usuarios.Length; i++)
            {
                aux = usuarios[i].Split('░');
                if (aux[0].Equals(nombre))
                {
                    tipo = -1;
                    desencriptar = StringCipher.Decrypt(aux[1], aux[2]);
                    if (desencriptar.Substring(0, desencriptar.Length - 1).Equals(contrasenia))
                    {
                        tipo = Convert.ToInt32(desencriptar[desencriptar.Length - 1] + "");
                        ManejoDeArchivos.GuardarArchivo("nombre.txt", new string[] { aux[2] });
                    }
                    break;
                }
            }
            return tipo;
        }
    }
}
