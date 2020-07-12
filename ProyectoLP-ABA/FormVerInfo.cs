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
    public partial class FormVerInfo : Form
    {
        string nombreaux;
        public FormVerInfo()
        {
            InitializeComponent();
        }
        public FormVerInfo(string ruta, string nombre)
        {
            InitializeComponent();
            try
            {
                string path;
                ManejoDeArchivos.CrearArchivo(ruta);
                string[] lineas = File.ReadAllLines(ruta);
                string[] aux;
                nombreaux = nombre;
                foreach (var dato in lineas)
                {
                    aux = dato.Split('░');

                    //Va a crear el path para leer si hay documento o no y su estado
                    if (aux.Length > 2)
                    {
                        path = "datos\\" + nombre + "\\Actualizacion Cientifica\\";
                        path += aux[0] + ";" + aux[2] + ";" + aux[3] + ".pdf";
                        if (File.Exists(path))
                        {
                            dataGridView1.Rows.Add(aux[0], verif(aux[1]), aux[2], aux[3], "Ver Certificado");
                        }
                        else
                        {
                            dataGridView1.Rows.Add(aux[0], verif(aux[1]), aux[2], aux[3], "Sin Certificado");
                        }
                    }
                    else
                    {
                        dataGridView1.Rows.Add(aux[0], verif(aux[1]), "", "", "");
                    }

                }
            }
            catch
            {
                MessageBox.Show("No se ha guardado el archivo o este no existe", "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        public string verif(string cad)
        {
            if (cad == "True")
            {
                cad = "Si";
            }
            else
            {
                cad = "No";

            }
            return cad;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string path;
                string nombreArch = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + ";";
                nombreArch += dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + ";";
                nombreArch += dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + ".pdf";
                path = "datos\\" + nombreaux + "\\Actualizacion Cientifica\\" + nombreArch;
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch { }
            }
        }
    }
}
