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
    public partial class FormDocente : Form
    {
        
        public FormDocente()
        {
            InitializeComponent();
        }

        private void labelcerrarI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormDocente_Load(object sender, EventArgs e)
        {

        }
        //NO HACE NADA NO TOCAR
        private void ingreseProgramaMicrocurricularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelContenedorD.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la conexión el formulario
            //si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelContenedorD.Controls.Add(formulario);
                panelContenedorD.Tag = formulario;
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
            if (Application.OpenForms["FormDocente"] == null)
                ingreseProgramaMicrocurricularToolStripMenuItem.BackColor = Color.FromArgb(0, 122, 204);

        }

        private void miniToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //No hace nada no borrar
        }

        private void ingreseProgramaMicrocurricularToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<SubirSy_D>();
        }

        private void sistemaDeEvaluaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte5>();
        }

        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Docente_Parte8>();
        }

        private void sistemaDeEvaluaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte6>();
        }

        private void proyectosDeInvestigaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //No hace nada no borrar
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //No hace nada no borrar
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // No hace nada no borrar
        }

        private void proyectosDeInvestigaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte10>();
        }

        private void maestríasODoctoradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte12>();
        }

        private void producciónCientíficaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte14>();
        }

        private void necesidadesBibliograficasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte16>();
        }

        private void cuestionariosExámenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte_7>();
        }

        private void desarrolloDelSílaboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte9>();
        }

        private void actualizaciónCientíficaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte11>();
        }

        private void requerimentoDePerfeccionamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte13>();
        }

        private void librosCapítulosPublicadosUltimos4AñosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormDocente_Parte15>();
        }
    }
}
