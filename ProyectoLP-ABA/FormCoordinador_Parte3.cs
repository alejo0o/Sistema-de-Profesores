using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using draw = System.Drawing;
using System.IO;

namespace ProyectoLP_ABA
{
    public partial class FormCoordinador_Parte3 : Form
    {
        int n = 0;
        string path = "datos\\Asistencia a Reuniones de Area.txt";
        string[] docentes;
        public FormCoordinador_Parte3()
        {
            InitializeComponent();
            string aux;
            dataGridView1.ReadOnly = true;
            ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
            docentes = File.ReadAllLines("datos\\docentes.txt");
            foreach (string nombre in docentes) //Lee cada paralelo para insertarlo en el list view
            {
                aux = nombre.Substring(0, nombre.IndexOf(";"));
                lbParalelos.Items.Add(aux);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker1.Value;
            DateTime fecha1 = dateTimePicker2.Value;
            DateTime fecha2 = dateTimePicker3.Value;
            int indice = lbParalelos.SelectedIndex;

            if (lbParalelos.SelectedItem != null)
            {
                int x = dataGridView1.Rows.Add();
                dataGridView1.Rows[x].Cells[0].Value = lbParalelos.SelectedItem;
                dataGridView1.Rows[x].Cells[1].Value = fecha.ToString().Substring(0, fecha.ToString().IndexOf(' '));
                dataGridView1.Rows[x].Cells[2].Value = fecha1.ToString().Substring(0, fecha.ToString().IndexOf(' ')); ;
                dataGridView1.Rows[x].Cells[3].Value = fecha2.ToString().Substring(0, fecha.ToString().IndexOf(' ')); ;
                lbParalelos.Items.RemoveAt(lbParalelos.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n != -1)
            {
                lbParalelos.Items.Add(dataGridView1.Rows[n].Cells[0].Value);
                dataGridView1.Rows.RemoveAt(n);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cad = "";
            string[] cad1 = new string[dataGridView1.RowCount - 1];
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    cad += dataGridView1.Rows[i].Cells[j].Value.ToString() + "░";
                }
                cad = cad.Substring(0, cad.LastIndexOf("░"));
                cad1[i] = cad;
                cad = "";
            }
            if (ManejoDeArchivos.GuardarArchivo(path, cad1))
            {
                MessageBox.Show("GUARDAD EXITOSO");
            }

        }

        public string codigo(string cad)
        {
            string resp = "";
            foreach (string nombre in docentes)
            {
                if (nombre.Contains(cad))
                {
                    resp = nombre;
                }
            }
            return resp;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
