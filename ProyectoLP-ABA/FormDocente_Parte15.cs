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
    public partial class FormDocente_Parte15 : Form
    {
        string nombre;
        string path;
        string ruta;


        string[] docentes;
        public FormDocente_Parte15()
        {
            InitializeComponent();
            //Lee con que docente se va a trabajar
            ManejoDeArchivos.CrearArchivo("nombre.txt");
            nombre = File.ReadAllLines("nombre.txt")[0];
            path = "datos\\" + nombre + "\\Libros y capitulos de libros publicados en los ultimos 4 años\\" + "Datos.txt";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = "datos\\" + nombre + "\\Libros y capitulos de libros publicados en los ultimos 4 años\\" + "Datos.txt";
            string cad = "";
            string[] cad1 = new string[dataGridView1.RowCount - 1];
            try
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    {
                        cad += dataGridView1.Rows[i].Cells[j].Value.ToString() + "░";
                        if (dataGridView1.Rows[i].Cells[6].Value == null || Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value) == false)
                        {
                            cad = dataGridView1.Rows[i].Cells[0].Value.ToString() + "░" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "░" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "░"
                                + dataGridView1.Rows[i].Cells[3].Value.ToString() + "░" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "░" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "░" + "False░";
                            break;
                        }
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


        private void button2_Click(object sender, EventArgs e)
        {
           //No hace nada no borrar
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                try
                {
                    string archivo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + ";";
                    archivo += dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + ".pdf";
                    path = "datos\\" + nombre + "\\Libros y capitulos de libros publicados en los ultimos 4 años\\" + archivo;
                    string pathOld;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pathOld = openFileDialog1.FileName;
                        if (pathOld.Substring(pathOld.Length - 4) == ".pdf")
                        {
                            ManejoDeArchivos.CrearArchivo(path);
                            try
                            {
                                File.Copy(pathOld, path, true);
                                dataGridView1.Rows[e.RowIndex].Cells[7].Value = "Estado: Subido";
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Por favor contacte al administrador", "No se puedo subir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor suba solo archivos .pdf", "No se puedo subir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch { MessageBox.Show("Asegurese de llenar todos los campos antes de subir un archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
    }
}
