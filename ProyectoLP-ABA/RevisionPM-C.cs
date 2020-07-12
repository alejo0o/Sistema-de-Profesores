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
    public partial class IngresoPM_D : Form
    {
        string[] docentes;
        public IngresoPM_D()
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

        private void tBuscar_TextChanged(object sender, EventArgs e)
        {
            //El evento lo que hace es buscar de entre los docentes cual tiene
            //la subcadena especifica

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
                    path = "datos\\" + nombre + "\\Seguimiento programas microcurriculares\\";
                    path += aux[0] + ";" + aux[1] + ";" + aux[2];
                    if (File.Exists(path + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre, false, "Archivo subido");
                    }
                    else if (File.Exists(path + ";Aprobado.pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre, true, "Archivo subido");
                    }
                    else
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre);
                    }
                }

            }

        }

        private void dGridDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreArch, path, aux;

            // Va creando el nombre del archivo en base a la informacion de las celdas
            nombreArch = dGridDocentes[0, e.RowIndex].Value.ToString();
            nombreArch += ";" + dGridDocentes[1, e.RowIndex].Value.ToString();
            nombreArch += ";" + dGridDocentes[2, e.RowIndex].Value.ToString();

            if (e.ColumnIndex == 5)//Solo entra si cliqueo en la casilla 5, donde esta el hipervinculo
            {
                if (dGridDocentes[4, e.RowIndex].Value.ToString() == "True") //Revisa si esta aprobado o no
                {
                    nombreArch += ";Aprobado";
                }
                //Junta todo el nombre y lo inicia
                path = "datos\\" + dGridDocentes[3, e.RowIndex].Value.ToString() + "\\Seguimiento programas microcurriculares\\" + nombreArch + ".pdf";
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch { }
            }
            else if (e.ColumnIndex == 4)//Solo entra si cliqueo en la casilla 4, donde esta el checkbox de confirmacion
            {                           //Lee los archivos y los modifica acorde a las especificaciones, si esta Aprobado
                                        //le quitara el Aprobado, y si no esta Aprovado,lo añadira
                                        //Ademas, si no hay archivo, regresara el check box a desmarcado
                try
                {
                    path = "datos\\" + dGridDocentes[3, e.RowIndex].Value.ToString() + "\\Seguimiento programas microcurriculares\\" + nombreArch;
                    if (File.Exists(path + ".pdf"))
                    {
                        aux = "datos\\" + dGridDocentes[3, e.RowIndex].Value.ToString() + "\\Seguimiento programas microcurriculares\\" + nombreArch + ";Aprobado.pdf";
                        File.Move(path + ".pdf", aux);
                    }
                    else if (File.Exists(path + ";Aprobado.pdf"))
                    {
                        aux = "datos\\" + dGridDocentes[3, e.RowIndex].Value.ToString() + "\\Seguimiento programas microcurriculares\\" + nombreArch + ".pdf";
                        File.Move(path + ";Aprobado.pdf", aux);
                    }
                }
                catch { }

            }
        }
    }
}
