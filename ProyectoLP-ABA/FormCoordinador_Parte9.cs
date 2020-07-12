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
    public partial class FormCoordinador_Parte9 : Form
    {
        string[] docentes;
        public FormCoordinador_Parte9()
        {
            InitializeComponent();
            ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
            docentes = File.ReadAllLines("datos\\docentes.txt");
            tBuscar.Text = " ";
            tBuscar.Text = "";
        }

        private void tBuscar_TextChanged(object sender, EventArgs e)
        {
            dGridDocentes.Rows.Clear();
            string[] docSelec = BuscarEnArreglo(docentes, tBuscar.Text);
            string[] paralelos;
            string[] aux;
            string path;
            foreach (string nombre in docSelec)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
                paralelos = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
                foreach (string paralelo in paralelos) //Lee cada paralelo
                {
                    //Separa los contenidos de cada paralelo
                    aux = paralelo.Split('░');

                    //Va a crear el path para leer si hay documento o no y su estado
                    path = "datos\\" + nombre + "\\Desarrollo del Sílabo\\";
                    path += aux[0] + ";" + aux[1] + ";" + aux[2];


                    if (File.Exists(path + ".txt"))
                    {
                        ManejoDeArchivos.CrearArchivo(path + ".txt");
                        string cad = File.ReadAllText(path + ".txt");
                        string[] info = cad.Split(('░'));
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), info[0] + " %", "Ver");
                    }
                    else
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), "", "Sin Subir");
                    }

                }

            }
        }
        private string[] BuscarEnArreglo(string[] arr, string cad) //Busca en un arreglo de strings todos los strings                                                                 //que contengan la cadena especificada, no es sensible a mayus                                                                //Devuelve un arreglo con las coincidencias
        {

            List<string> resul = new List<string>();
            foreach (string nombre in docentes)
            {
                if (nombre.ToLower().Contains(cad.ToLower()))
                {
                    resul.Add(nombre);
                }
            }
            return resul.ToArray();
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

        private void dGridDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreArch, path, aux;

            // Va creando el nombre del archivo en base a la informacion de las celdas
            nombreArch = dGridDocentes[0, e.RowIndex].Value.ToString();
            nombreArch += ";" + dGridDocentes[1, e.RowIndex].Value.ToString();
            nombreArch += ";" + dGridDocentes[2, e.RowIndex].Value.ToString();
            path = "datos\\" + codigo(dGridDocentes[3, e.RowIndex].Value.ToString()) + "\\Desarrollo del Sílabo\\" + nombreArch + ".txt";

            if (e.ColumnIndex == 5)
            {
                if (File.Exists(path))
                {
                    FormTemasNoTratados form4 = new FormTemasNoTratados(path);
                    form4.Show();
                }
                else
                {
                    MessageBox.Show("El archivo no exixte o no se ha subido", "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void cargar()
        {
            string path;
            string[] aux1, aux2, aux3;
            string cad = "";
            string[] cad1 = new string[dGridDocentes.RowCount - 1];


            for (int i = 0; i < dGridDocentes.RowCount - 1; i++)
            {
                for (int j = 0; j < dGridDocentes.ColumnCount - 2; j++)
                {

                    cad += dGridDocentes.Rows[i].Cells[j].Value.ToString() + "░";

                }
                aux1 = cad.Split('░');
                path = "datos\\" + codigo(dGridDocentes.Rows[i].Cells[3].Value.ToString()) + "\\Desarrollo del Sílabo\\";
                path += aux1[0] + ";" + aux1[1] + ";" + aux1[2] + ".txt";
                if (File.Exists(path))
                {
                    ManejoDeArchivos.CrearArchivo(path);
                    aux2 = File.ReadAllLines(path);
                    foreach (var info in aux2)
                    {
                        aux3 = info.Split('░');
                        for (int j = 0; j < aux3.Length; j++)
                        {
                            cad += aux3[j] + "░";
                        }
                    }

                }
                else
                {
                    cad += "No Agregado░Sin Subir░";
                }
                cad = cad.Substring(0, cad.LastIndexOf("░"));
                cad1[i] = cad;
                cad = "";
                path = "";
            }



            if (ManejoDeArchivos.GuardarArchivo("datos\\Desarrollo del Sílabo.txt", cad1))
            {

            }

        }
    }
}
