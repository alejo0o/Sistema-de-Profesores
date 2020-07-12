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

    public partial class FormDocente_Parte13 : Form
    {
        string nombre;
        string[] materias;
        string path;
        string ruta;

        string[] docentes;
        public FormDocente_Parte13()
        {
            InitializeComponent();
            //Lee con que docente se va a trabajar
            ManejoDeArchivos.CrearArchivo("nombre.txt");
            nombre = File.ReadAllLines("nombre.txt")[0];
            cargar();
            path = "datos\\" + nombre + "\\Requerimiento de perfeccionamiento docente\\" + "Datos.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = "datos\\" + nombre + "\\Requerimiento de perfeccionamiento docente\\" + "Datos.txt";
            string cad = "";
            string[] cad1 = new string[dataGridView1.RowCount - 1];
            try
            {
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
                    MessageBox.Show("Se ha guardado el archivo con éxito", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar, contacte con el Administrador", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { MessageBox.Show("Asegurese de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void cargar()
        {
            ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
            materias = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
            List<string> listamaterias = new List<string>();
            string[] info;
            foreach (var materia in materias)
            {
                info = materia.Split('░');
                listamaterias.Add(info[0]);
            }
            Column1.Items.AddRange(verif(listamaterias).ToArray());
        }
        public List<string> verif(List<string> list)
        {
            string cad = "";
            for (int i = 0; i < list.Count; i++)
            {
                cad = list.ElementAt<string>(i);
                if (list.Count == i + 1)
                {
                    if (list.ElementAt<string>(i - 1) == list.ElementAt<string>(i))
                    {
                        list.RemoveAt(i);
                    }
                }
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (cad == list.ElementAt<string>(j))
                    {
                        list.RemoveAt(j);
                    }
                }
            }
            return list;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            FormAdjuntarInvitacion form3 = new FormAdjuntarInvitacion();
            form3.Show();
        }

        private void FormDocente_Parte13_Load(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
    }
}
