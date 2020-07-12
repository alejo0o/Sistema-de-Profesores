using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLP_ABA
{
    public partial class Ingresos : Form
    {
        public Ingresos()
        {
            InitializeComponent();
        }

        private void labelcerrarI_Click(object sender, EventArgs e)
        {
            //NO HACE NADA NO TOCAR
        }

        //CerrarRegistro
        private void cerrarDocente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<NuevoUsuario>();
           
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelCU.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la conexión el formulario
            //si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelCU.Controls.Add(formulario);
                panelCU.Tag = formulario;
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormEditarUsuario>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormNuevoParalelo>();
        }
    }
}
