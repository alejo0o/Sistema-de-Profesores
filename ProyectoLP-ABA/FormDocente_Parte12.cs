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
    public partial class FormDocente_Parte12 : Form
    {
        string path;
        string nombre;
        string[] info;
        bool activarEventosValueChanged = false;
        public FormDocente_Parte12()
        {
            InitializeComponent();
            try
            {
                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                nombre = File.ReadAllLines("nombre.txt")[0];
                //Carga la informacion en el data grid
                path = "datos\\" + nombre + "\\Maestria y doctorados en curso.txt";
                ManejoDeArchivos.CrearArchivo(path);
                info = File.ReadAllLines(path);
                PonerInfoEnDataGrid(info);
                activarEventosValueChanged = true;
            }
            catch { }
            
        }
        //Esta funcion se encarga de poner la informacion en el datagrid
        //
        private void PonerInfoEnDataGrid(string[] info)
        {
            string[] aux;
            bool maestria, doctorado;
            activarEventosValueChanged = false;
            dataGridView1.Rows.Clear();
            foreach (string linea in info)
            {
                //La linea ░No░No es basicamente una linea vacia
                //Esto se hace porque cada vez que se extrae informacion de un datagrid
                //Siempre extrae tambien la de la ultima fila, la que solo esta ahi para
                //crear una nueva fila.
                //Como resultado, en el archivo se guarda esta fila vacia
                //y cuando se lo habre de vuelta habra 2 filas vacias, la que venia en el archivo
                //y la que el datagrid añade por defecto, y cada vez que se añada informacion y se
                //habra de vuelta del archivo, el numero de filas vacias aumentara en 1
                if (linea != "" && linea != "░No░No")
                {
                    aux = linea.Split('░');
                    if (aux[1] == "Si")
                    {
                        maestria = true;
                    }
                    else
                    {
                        maestria = false;
                    }
                    if (aux[2] == "Si")
                    {
                        doctorado = true;
                    }
                    else
                    {
                        doctorado = false;
                    }
                    dataGridView1.Rows.Add(aux[0], maestria, doctorado);
                }

            }
            activarEventosValueChanged = true;
        }
        //Esta funcion convierte la informacion del data grid en un arreglo
        //Esto se hace con el proposito de usar dicho arreglo para guardarlo en el .txt
        private string[] ConvertirDataGridEnArr()
        {
            List<string> lista = new List<string>();
            string aux = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                aux = "";
                try
                {
                    aux += dataGridView1[0, i].Value.ToString() + "░";
                }
                catch { aux += "░"; }
                try
                {
                    string prueba = dataGridView1[2, i].Value.ToString();
                    if (dataGridView1[1, i].Value.ToString() == "True")
                    {
                        aux += "Si" + "░";
                    }
                    else
                    {
                        aux += "No" + "░";
                    }
                }
                catch { aux += "No" + "░"; }

                try
                {
                    string prueba = dataGridView1[2, i].Value.ToString();
                    if (dataGridView1[2, i].Value.ToString() == "True")
                    {
                        aux += "Si";
                    }
                    else
                    {
                        aux += "No";
                    }
                }
                catch { aux += "No"; }
                //En un comentario anterior se mencionaba que al leer el archivo
                //no leia el string "░░░░░░", con este if, lo que se hacia arriba ya no 
                //es necesario, sin embargo no se borrar lo de arriba para recalcar la importancia
                //de este if de aqui abajo
                if (aux != "░No░No")
                {
                    lista.Add(aux);
                }
                
            }


            return lista.ToArray();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Este evento guarda los cambios
        private void button1_Click(object sender, EventArgs e)
        {
            if (activarEventosValueChanged)
            {
                info = ConvertirDataGridEnArr();
                ManejoDeArchivos.GuardarArchivo(path, info);
                PonerInfoEnDataGrid(info);
            }
        }
    }



}
