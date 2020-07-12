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
    public partial class FormTemasNoTratados : Form
    {
        public FormTemasNoTratados()
        {
            InitializeComponent();
        }
        public FormTemasNoTratados(string path)
        {
            InitializeComponent();
            ManejoDeArchivos.CrearArchivo(path);
            string cad = File.ReadAllText(path);
            string[] info = cad.Split('░');
            for (int i = 1; i < info.Length; i++)
            {
                dataGridView1.Rows.Add(info[i]);

            }
            

        }
    }
}
