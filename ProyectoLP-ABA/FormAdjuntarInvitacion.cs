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
    public partial class FormAdjuntarInvitacion : Form
    {
        string nombre;
        string[] materias;
        string path;
        string ruta;
        public FormAdjuntarInvitacion()
        {
            InitializeComponent();
            //Lee con que docente se va a trabajar
            ManejoDeArchivos.CrearArchivo("nombre.txt");
            nombre = File.ReadAllLines("nombre.txt")[0];
            path = "datos\\" + nombre + "\\Requerimiento de perfeccionamiento docente\\" + "Adjuntos.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = "datos\\" + nombre + "\\Requerimiento de perfeccionamiento docente\\" + "Adjuntos.txt";
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


    }
}
