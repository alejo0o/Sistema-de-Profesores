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
    
    public partial class FormDocente_Parte11 : Form
    {
        string nombre;
        string[] materias;
        string[] docentes;
        string path, path2;
        string ruta;
        int curso = 0, congreso = 0, coloquio = 0, seminario = 0, ponencia = 0;
        public FormDocente_Parte11()
        {
            InitializeComponent();
            ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
            docentes= File.ReadAllLines("datos\\docentes.txt");
            cargar();
            //Lee con que docente se va a trabajar
            ManejoDeArchivos.CrearArchivo("nombre.txt");
            nombre = File.ReadAllLines("nombre.txt")[0];
            ruta = "datos\\" + nombre + "\\Actualizacion Cientifica\\" + "Datos.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Actualizacion Cientifica\\" + "Datos.txt");
            path = "datos\\" + nombre + "\\Actualizacion Cientifica\\" + "Datos.txt";
            string cad = "";
            string[] cad1 = new string[dataGridView1.RowCount - 1];
            try
            {

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    {
                        cad += dataGridView1.Rows[i].Cells[j].Value.ToString() + "░";

                        if (dataGridView1.Rows[i].Cells[1].Value == null || Convert.ToBoolean(dataGridView1.Rows[i].Cells[1].Value) == false)
                        {
                            cad += "False░";
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
            agregar_a_tabla();
        }
        public void cargar()
        {
            List<string> listamaterias = new List<string>();
            string[] info;
            foreach (var nombre in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
                materias = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
                
                foreach (var materia in materias)
                {
                    info = materia.Split('░');
                    listamaterias.Add(info[0]);
                }
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[1].Value) == true)
            {
                try
                {
                    string archivo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + ";";
                    archivo += dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + ";";
                    archivo += dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + ".pdf";
                    path = "datos\\" + nombre + "\\Actualizacion Cientifica\\" + archivo;
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
                                dataGridView1.Rows[e.RowIndex].Cells[4].Value = "Estado: Subido";
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
            else if (e.ColumnIndex == 4 && Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[1].Value) == false)
            {
                MessageBox.Show("Asegurese de llenar todos los campos antes de subir un archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (File.Exists(ruta))
            {
                FormVerInfo form2 = new FormVerInfo(ruta, nombre);
                form2.Show();
            }
            else
            {
                MessageBox.Show("No se ha guardado el archivo o este no existe", "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            button2.Enabled = false;
        }

        private void FormDocente_Parte11_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
        public void agregar_a_tabla()
        {
            curso = 0;
            congreso = 0;
            coloquio = 0;
            seminario = 0;
            ponencia = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if(dataGridView1.Rows[i].Cells[2].Value!=null)
                {
                    switch (dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {
                        case "Curso":
                            curso += 1;
                            break;
                        case "Congreso":
                            congreso += 1;
                            break;
                        case "Coloquio":
                            coloquio += 1;
                            break;
                        case "Seminario":
                            seminario += 1;
                            break;
                        case "Ponencia":
                            ponencia += 1;
                            break;
                    }
                }             
            }
            string cadena = curso + "░" + congreso + "░" + coloquio + "░" + seminario + "░" + ponencia + "░";
            cadena = cadena.Substring(0, cadena.LastIndexOf('░'));
            path2 = "datos\\" + nombre + "\\Actualizacion Cientifica\\" + "Tabla2.txt";
            ManejoDeArchivos.GuardarArchivo(path2, new string[] { cadena });

        }

    }
}
