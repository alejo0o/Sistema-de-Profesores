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
    public partial class FormDocente_Parte_7 : Form
    {
        string nombre;
        string path, path2;
        string[] paralelos;
        int bimestre = -1;
        
        public FormDocente_Parte_7()
        {
            string[] aux;
            InitializeComponent();

            //Lee con que docente se va a trabajar
            ManejoDeArchivos.CrearArchivo("nombre.txt");
            nombre = File.ReadAllLines("nombre.txt")[0];
            //Desactiva los botones ya que al principio no esta seleccionado ningun curso
            bVerArch.Enabled = false;
            bSubArch.Enabled = false;
            button1.Enabled = false;
            richTextBox1.ReadOnly = true;
            lbParalelos.Enabled = false;
            labelEstado.Hide();
            richTextBox1.Enabled = false;
            //Lee los paralelos
            ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
            paralelos = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
            foreach (string paralelo in paralelos) //Lee cada paralelo para insertarlo en el list view
            {
                aux = paralelo.Split('░');
                lbParalelos.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
            }
        }

        private void bVerArch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch { }
        }

        private void bSubArch_Click(object sender, EventArgs e)
        {
            string pathOld;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOld = openFileDialog1.FileName;
                if (pathOld.Substring(pathOld.Length - 4) == ".pdf")
                {
                    try
                    {
                        ManejoDeArchivos.CrearArchivo(path);
                        if (path.Contains(";Aprobado.pdf"))
                        {
                            File.Delete(path);
                            path = path.Substring(0, path.Length - 13) + ".pdf";
                        }
                        File.Copy(pathOld, path, true);
                        labelEstado.Text = "Estado: Subido";
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

        private void lbParalelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                labelEstado.Show();
                button1.Enabled = true;
                string nombreArch, nombreArch2, paralelo = lbParalelos.SelectedItem.ToString();
                nombreArch = paralelo.Substring(0, paralelo.IndexOf(", "));
                nombreArch += ";" + paralelo.Substring(paralelo.IndexOf(": ") + 2, paralelo.LastIndexOf(", ") - paralelo.IndexOf(": ") - 2);
                nombreArch += ";" + paralelo.Substring(paralelo.LastIndexOf(": ") + 2);
                nombreArch2 = nombreArch + ".txt";
                nombreArch += ";" + bimestre + ".pdf";


                path = "datos\\" + nombre + "\\Presentacion de cuestionarios de examenes a coordinadores de area\\" + nombreArch;
                path2 = "datos\\" + nombre + "\\Presentacion de cuestionarios de examenes a coordinadores de area\\" + nombreArch2;
                if (File.Exists(path))                                       //El siguiente if-else sirve para ver si el archivo esta aprobado o no
                {                                                                     //El indicador de si esta aprobado o no esta en el propio nombre del archivo                                                                        //y lo traduce para presentarlo en la interfaz               
                    labelEstado.Text = "Estado: Subido";
                }
                else if (File.Exists(path.Substring(0, path.LastIndexOf(".")) + ";Aprobado.pdf"))
                {
                    path = path.Substring(0, path.LastIndexOf(".")) + ";Aprobado.pdf";
                    labelEstado.Text = "Estado: Aprobado";
                }
                else
                {
                    labelEstado.Text = "Estado: Sin subir";
                }
                if (File.Exists(path2))
                {
                    escribir(path2);
                }
                else
                {
                    richTextBox1.Clear();
                }
                bSubArch.Enabled = true;
                bVerArch.Enabled = true;
                richTextBox1.Enabled = true;
            }
            catch { }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string err = "";
            lbParalelos.Enabled = true;
            if (comboBox1.SelectedIndex == 0)
            {
                bimestre = 1;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                bimestre = 2;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                bimestre = 3;
            }
            if (path != null)
            {
                string nombreArch, paralelo = lbParalelos.SelectedItem.ToString();
                nombreArch = paralelo.Substring(0, paralelo.IndexOf(", "));
                nombreArch += ";" + paralelo.Substring(paralelo.IndexOf(": ") + 2, paralelo.LastIndexOf(", ") - paralelo.IndexOf(": ") - 2);
                nombreArch += ";" + paralelo.Substring(paralelo.LastIndexOf(": ") + 2);
                nombreArch += ";" + bimestre + ".pdf";

                path = "datos\\" + nombre + "\\Presentacion de cuestionarios de examenes a coordinadores de area\\" + nombreArch;
                err = path.Substring(0, path.LastIndexOf("."));
            }
            if (File.Exists(path))                                       //El siguiente if-else sirve para ver si el archivo esta aprobado o no
            {                                                           //El indicador de si esta aprobado o no esta en el propio nombre del archivo                                             //y lo traduce para presentarlo en la interfaz               
                labelEstado.Text = "Estado: Subido";
            }
            else if (File.Exists(err + ";Aprobado.pdf"))
            {
                path = err + ";Aprobado.pdf";
                labelEstado.Text = "Estado: Aprobado";
            }
            else
            {
                labelEstado.Text = "Estado: Sin subir";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                FormEscribirInfo form4 = new FormEscribirInfo(path2);
                form4.Text = lbParalelos.SelectedItem.ToString();
                form4.Show();
                button1.Enabled = false;


        }

        private void FormDocente_Parte_7_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;

        }

        public void escribir(string ruta)
        {
            richTextBox1.Clear();
            ManejoDeArchivos.CrearArchivo(ruta);
            string[] arr = File.ReadAllLines(ruta);
            foreach (string cad in arr)
            {
                richTextBox1.AppendText(cad);
            }
        }

    }
}
