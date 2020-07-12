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
    public partial class FormCoordinador_Parte11 : Form
    {
        string[] docentes;
        public FormCoordinador_Parte11()
        {
            InitializeComponent();
            ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
            docentes = File.ReadAllLines("datos\\docentes.txt");
            //Activa el evento de cambio de texto en el buscador
            //El evento lo que hace es buscar de entre los docentes cual tiene
            //la subcadena especifica
            tBuscar.Text = " ";
            tBuscar.Text = "";
        }

        private void tBuscar_TextChanged(object sender, EventArgs e)
        {
            dGridDocentes.Rows.Clear();
            string[] docSelec = BuscarEnArreglo(docentes, tBuscar.Text);
            string[] datos;
            string[] aux;
            string path;
            foreach (string nombre in docSelec)
            {
                try
                {
                    ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Actualizacion Cientifica\\Datos.txt");
                    datos = File.ReadAllLines("datos\\" + nombre + "\\Actualizacion Cientifica\\Datos.txt");
                    foreach (string item in datos) //Lee cada paralelo
                    {
                        //Separa los contenidos de cada paralelo
                        aux = item.Split('░');

                        //Va a crear el path para leer si hay documento o no y su estado
                        if (aux.Length > 2)
                        {
                            path = "datos\\" + nombre + "\\Actualizacion Cientifica\\";
                            path += aux[0] + ";" + aux[2] + ";" + aux[3] + ".pdf";
                            if (File.Exists(path))
                            {
                                dGridDocentes.Rows.Add(nombre.Substring(0, nombre.IndexOf(";")), aux[0], verif(aux[1]), aux[2], aux[3], "Ver Certificado");
                            }
                            else
                            {
                                dGridDocentes.Rows.Add(nombre.Substring(0, nombre.IndexOf(";")), aux[0], verif(aux[1]), aux[2], aux[3], "Sin Certificado");
                            }
                        }
                        else
                        {
                            dGridDocentes.Rows.Add(nombre.Substring(0, nombre.IndexOf(";")), aux[0], verif(aux[1]), "", "", "");
                        }
                    }
                }
                catch { }


            }
        }
        private string[] BuscarEnArreglo(string[] arr, string cad) //Busca en un arreglo de strings todos los strings
                                                                   //que contengan la cadena especificada, no es sensible a mayus
                                                                   //Devuelve un arreglo con las coincidencias
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

        private void dGridDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {

                string path;
                string nombreArch = dGridDocentes.Rows[e.RowIndex].Cells[1].Value.ToString() + ";";
                nombreArch += dGridDocentes.Rows[e.RowIndex].Cells[3].Value.ToString() + ";";
                nombreArch += dGridDocentes.Rows[e.RowIndex].Cells[4].Value.ToString() + ".pdf";
                path = "datos\\" + codigo(dGridDocentes.Rows[e.RowIndex].Cells[0].Value.ToString()) + "\\Actualizacion Cientifica\\" + nombreArch;
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch { MessageBox.Show("El archivo que intenta abrir no esta guardado o no existe","Error"); }
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
    }
}
