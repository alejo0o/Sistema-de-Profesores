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
    public partial class FormCoordinador_Parte5 : Form
    {
        string[] docentes;
        public FormCoordinador_Parte5()
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
                                                                   //que contengan la cadena especificada, no es sensible a mayus                                                                 //Devuelve un arreglo con las coincidencias
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
            string path, path2, path3;
            foreach (string nombre in docSelec)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
                paralelos = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
                foreach (string paralelo in paralelos) //Lee cada paralelo
                {
                    //Separa los contenidos de cada paralelo
                    aux = paralelo.Split('░');

                    //Va a crear el path para leer si hay documento o no y su estado
                    path = "datos\\" + nombre + "\\Seguimiento al Silabo\\";
                    path2 = "datos\\" + nombre + "\\Seguimiento al Silabo\\";
                    path3 = "datos\\" + nombre + "\\Seguimiento al Silabo\\";

                    path += aux[0] + ";" + aux[1] + ";" + aux[2] + ";1";
                    path2 += aux[0] + ";" + aux[1] + ";" + aux[2] + ";2";
                    path3 += aux[0] + ";" + aux[1] + ";" + aux[2] + ";3";

                    if (File.Exists(path + ".pdf") && File.Exists(path2 + ".pdf") && File.Exists(path3 + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), false, false, false, "Archivo subido", "Archivo subido", "Archivo subido");
                    }
                    else if (File.Exists(path + ".pdf") && File.Exists(path2 + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), false, false, false, "Archivo subido", "Archivo subido", " ");
                    }
                    else if (File.Exists(path + ".pdf") && File.Exists(path3 + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), false, false, false, "Archivo subido", " ", "Archivo subido");
                    }
                    else if (File.Exists(path2 + ".pdf") && File.Exists(path3 + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), false, false, false, " ", "Archivo subido", "Archivo subido");
                    }
                    else if (File.Exists(path + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), false, false, false, "Archivo subido", " ", " ");
                    }
                    else if (File.Exists(path2 + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), false, false, false, " ", "Archivo subido", " ");
                    }
                    else if (File.Exists(path3 + ".pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), false, false, false, " ", " ", "Archivo subido");
                    }

                    else if (File.Exists(path + ";Aprobado.pdf") && File.Exists(path2 + ";Aprobado.pdf") && File.Exists(path3 + ";Aprobado.pdf"))
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")), true, true, true, "Archivo subido", "Archivo subido", "Archivo subido");
                    }

                    else
                    {
                        dGridDocentes.Rows.Add(aux[0], aux[1], aux[2], nombre.Substring(0, nombre.IndexOf(";")));
                    }

                    if (File.Exists(path + ";Aprobado.pdf"))
                    {

                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[4].Value = true;
                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[7].Value = "Archivo Subido";
                    }
                    else
                    {
                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[4].Value = false;
                    }
                    if (File.Exists(path2 + ";Aprobado.pdf"))
                    {

                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[5].Value = true;
                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[8].Value = "Archivo Subido";
                    }
                    else
                    {
                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[5].Value = false;
                    }
                    if (File.Exists(path3 + ";Aprobado.pdf"))
                    {
                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[6].Value = true;
                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[9].Value = "Archivo Subido";
                    }
                    else
                    {
                        dGridDocentes.Rows[dGridDocentes.RowCount - 2].Cells[6].Value = false;
                    }

                }

            }
        }

        private void dGridDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreArch, path, aux;
            int bim = 0;
            switch (e.ColumnIndex)
            {
                case 4:
                    bim = 1;
                    break;
                case 5:
                    bim = 2;
                    break;
                case 6:
                    bim = 3;
                    break;
                case 7:
                    bim = 1;
                    break;
                case 8:
                    bim = 2;
                    break;
                case 9:
                    bim = 3;
                    break;
            }
            // Va creando el nombre del archivo en base a la informacion de las celdas
            nombreArch = dGridDocentes[0, e.RowIndex].Value.ToString();
            nombreArch += ";" + dGridDocentes[1, e.RowIndex].Value.ToString();
            nombreArch += ";" + dGridDocentes[2, e.RowIndex].Value.ToString();
            nombreArch += ";" + bim;

            if (e.ColumnIndex == 7)//Solo entra si cliqueo en la casilla 7, donde esta el hipervinculo
            {
                if (dGridDocentes[4, e.RowIndex].Value.ToString() == "True") //Revisa si esta aprobado o no
                {
                    nombreArch += ";Aprobado";
                }
                //Junta todo el nombre y lo inicia
                path = "datos\\" + codigo(dGridDocentes[3, e.RowIndex].Value.ToString()) + "\\Seguimiento al Silabo\\" + nombreArch + ".pdf";
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch { }
            }
            else if (e.ColumnIndex == 8)
            {
                if (dGridDocentes[5, e.RowIndex].Value.ToString() == "True") //Revisa si esta aprobado o no
                {
                    nombreArch += ";Aprobado";
                }
                //Junta todo el nombre y lo inicia
                path = "datos\\" + codigo(dGridDocentes[3, e.RowIndex].Value.ToString()) + "\\Seguimiento al Silabo\\" + nombreArch + ".pdf";
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch { }
            }
            else if (e.ColumnIndex == 9)
            {
                if (dGridDocentes[6, e.RowIndex].Value.ToString() == "True") //Revisa si esta aprobado o no
                {
                    nombreArch += ";Aprobado";
                }
                //Junta todo el nombre y lo inicia
                path = "datos\\" + codigo(dGridDocentes[3, e.RowIndex].Value.ToString()) + "\\Seguimiento al Silabo\\" + nombreArch + ".pdf";
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch { }
            }
            else if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)//Solo entra si cliqueo en la casilla 4, donde esta el checkbox de confirmacion
            {                           //Lee los archivos y los modifica acorde a las especificaciones, si esta Aprobado
                                        //le quitara el Aprobado, y si no esta Aprovado,lo añadira
                                        //Ademas, si no hay archivo, regresara el check box a desmarcado
                try
                {
                    path = "datos\\" + codigo(dGridDocentes[3, e.RowIndex].Value.ToString()) + "\\Seguimiento al Silabo\\" + nombreArch;
                    if (File.Exists(path + ".pdf"))
                    {
                        aux = "datos\\" + codigo(dGridDocentes[3, e.RowIndex].Value.ToString()) + "\\Seguimiento al Silabo\\" + nombreArch + ";Aprobado.pdf";
                        File.Move(path + ".pdf", aux);
                    }
                    else if (File.Exists(path + ";Aprobado.pdf"))
                    {
                        aux = "datos\\" + codigo(dGridDocentes[3, e.RowIndex].Value.ToString()) + "\\Seguimiento al Silabo\\" + nombreArch + ".pdf";
                        File.Move(path + ";Aprobado.pdf", aux);
                    }
                }
                catch { }

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

    }
}
