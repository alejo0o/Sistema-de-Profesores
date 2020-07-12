using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoLP_ABA
{
    public partial class FormVerDesarrolloS : Form
    {
        public FormVerDesarrolloS()
        {
            InitializeComponent();
        }
        public FormVerDesarrolloS(string path)
        {
            InitializeComponent();
            try
            {
                ManejoDeArchivos.CrearArchivo(path);
                string cadena = File.ReadAllText(path);
                string[] datos = cadena.Split(Convert.ToChar("░"));
                richTextBox1.AppendText("Porcentaje de desarrollo del Silabo:  " + datos[0] + " %\n");
                richTextBox1.AppendText("Temas no Tratados:\n");
                for (int i = 1; i < datos.Length; i++)
                {
                    richTextBox1.AppendText(i + ".- " + datos[i] + "\n");
                }
            }
            catch
            {

            }

        }
    }
}
