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
    public partial class FormCoordinador : Form
    {
        public FormCoordinador()
        {
            InitializeComponent();
        }

        private void cerrarDocente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seguimientoProgramaMicrocurricularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<IngresoPM_D>();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelContenedorC.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la conexión el formulario
            //si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelContenedorC.Controls.Add(formulario);
                panelContenedorC.Tag = formulario;
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
            if (Application.OpenForms["FormCoordinador"] == null)
                asistenciaReunionesToolStripMenuItem.BackColor = Color.FromArgb(0, 122, 204);

        }
        private void asistenciaReunionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //No hace nada no borrar
        }

        private void verAsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCoordinador_Parte3>();
        }

        private void verAsistenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormVerAsistencia>();
        }

        private void revisiónCuestionariosExamenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //No hace nada no borrar
        }

        private void revisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCoordinador_Parte5>();
        }

        private void revisiónCuestionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCoordinador_Parte7>();
        }

        private void dDesarroloSílaboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCoordinador_Parte9>();
        }

        private void actualizaciónCientíficaDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCoordinador_Parte11>();
        }
    }
}
