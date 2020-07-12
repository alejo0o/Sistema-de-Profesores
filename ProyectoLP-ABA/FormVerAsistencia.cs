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
    public partial class FormVerAsistencia : Form
    {
        public FormVerAsistencia()
        {
            string path = "datos\\Asistencia a Reuniones de Area.txt";
            InitializeComponent();
            ManejoDeArchivos.CrearArchivo(path);
            string[] docentes = File.ReadAllLines(path);
            foreach (var item in docentes)
            {
                string[] arr = item.Split(Convert.ToChar("░"));
                dataGridView1.Rows.Add(arr[0], arr[1], arr[2], arr[3]);

            }
        }
            
    }
}
