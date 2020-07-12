using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLP_ABA
{
    public partial class FormEscribirInfo : Form
    {
        string path2;
        public FormEscribirInfo()
        {
            
            InitializeComponent();
        }
        public FormEscribirInfo(string ruta)
        {
            InitializeComponent();
            path2 = ruta;
            escribir(ruta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ManejoDeArchivos.GuardarArchivo(path2, new string[] { richTextBox1.Text}))
            {
                MessageBox.Show("Se ha guardado el archivo con éxito", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar, contacte con el Administrador", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void escribir(string ruta)
        {
            ManejoDeArchivos.CrearArchivo(ruta);
            ManejoDeArchivos.CrearArchivo(ruta);
            string[] arr = File.ReadAllLines(ruta);
            foreach (string cad in arr)
            {
                richTextBox1.AppendText(cad);
            }


        }

        private void FormEscribirInfo_Load(object sender, EventArgs e)
        {

           //No hace nada no borrar
            


        }
    }
}
