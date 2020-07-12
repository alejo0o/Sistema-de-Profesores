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
    public partial class FormEscribirRecomen2 : Form
    {
        public FormEscribirRecomen2()
        {
            InitializeComponent();
        }
        public FormEscribirRecomen2(string path)
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            richTextBox1.Clear();
            try
            {
                ManejoDeArchivos.CrearArchivo(path);
                string[] collection = File.ReadAllLines(path);
                foreach (var item in collection)
                {
                    richTextBox1.AppendText(item);
                }
            }
            catch
            {
                MessageBox.Show("El archivo no se ha subido", "Archivo Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
