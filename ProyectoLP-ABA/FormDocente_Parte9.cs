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
    public partial class FormDocente_Parte9 : Form
    {
        string nombre;
        string path;
        string[] paralelos;
        decimal valor = 0;
        public FormDocente_Parte9()
        {
            InitializeComponent();
            //Lee con que docente se va a trabajar
            ManejoDeArchivos.CrearArchivo("nombre.txt");
            nombre = File.ReadAllLines("nombre.txt")[0];
            string[] aux;
            ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
            paralelos = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
            
            foreach (string paralelo in paralelos) //Lee cada paralelo para insertarlo en el list view
            {
                aux = paralelo.Split('░');
                lbParalelos.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
            }
            button2.Enabled = false;
        }

        private void lbParalelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = true;
                string nombreArch, paralelo = lbParalelos.SelectedItem.ToString();
                nombreArch = paralelo.Substring(0, paralelo.IndexOf(", "));
                nombreArch += ";" + paralelo.Substring(paralelo.IndexOf(": ") + 2, paralelo.LastIndexOf(", ") - paralelo.IndexOf(": ") - 2);
                nombreArch += ";" + paralelo.Substring(paralelo.LastIndexOf(": ") + 2) + ".txt";
                ManejoDeArchivos.CrearArchivo(path);
                path = "datos\\" + nombre + "\\Desarrollo del Sílabo\\" + nombreArch;

                if (File.Exists(path))
                {
                    dataGridView1.Rows.Clear();
                    ManejoDeArchivos.CrearArchivo(path);
                    string cadena = File.ReadAllText(path);
                    string[] datos = cadena.Split(Convert.ToChar("░"));
                    if (datos[0].Trim(' ') != "")
                    {
                        numericUpDown1.Value = Convert.ToDecimal(datos[0]);
                        for (int i = 1; i < datos.Length; i++)
                        {
                            dataGridView1.Rows.Add(datos[i]);
                        }
                        lbarchivo.Text = "Estado: Subido";
                    }
                    else
                    {
                        numericUpDown1.Value = 0;
                        dataGridView1.Rows.Clear();
                        lbarchivo.Text = "Estado: Sin subir";
                    }
                }
                else
                {
                    numericUpDown1.Value = 0;
                    dataGridView1.Rows.Clear();
                    lbarchivo.Text = "Estado: Sin subir";
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cad = "";
            cad += numericUpDown1.Value.ToString() + "░";
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                cad += dataGridView1.Rows[i].Cells[0].Value + "░";
            }
            cad = cad.Substring(0, cad.LastIndexOf("░"));
            if (ManejoDeArchivos.GuardarArchivo(path, new string[] { cad }))
            {
                MessageBox.Show("Se ha guardado el archivo con éxito", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar, contacte con el Administrador", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                FormVerDesarrolloS form2 = new FormVerDesarrolloS(path);
                form2.Text = lbParalelos.SelectedItem.ToString();
                form2.Show();
            }
            else
            {
                MessageBox.Show("El archivo no exixte o no se ha subido", "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            button2.Enabled = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            valor = numericUpDown1.Value;
        }
        public string[] vacios(string[] arr)
        {
            List<string> list = arr.ToList();
            if (arr.Length != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list.ElementAt<string>(i).Trim(' ') == "")
                    {
                        list.RemoveAt(i);
                    }
                }
                if (list.ElementAt<string>(list.Count - 1).Trim(' ') == "")
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
            else
            {

            }
            return list.ToArray();
        }

        private void FormDocente_Parte9_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
