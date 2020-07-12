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
    public partial class FormDocente_Parte16 : Form
    {
        string path;
        string nombre;
        string[] info;
        bool activarEventosValueChanged = false;
        public FormDocente_Parte16()
        {
            InitializeComponent();
            try
            {
                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                nombre = File.ReadAllLines("nombre.txt")[0];
                //Declara los path a utilizar y pone la informacion del .txt en el dadta grid
                path = "datos\\" + nombre + "\\Necesidades Bibliograficas.txt";
                ManejoDeArchivos.CrearArchivo(path);
                info = File.ReadAllLines(path);
                PonerInfoEnDataGrid(info);
                activarEventosValueChanged = true;
            }
            catch { }
            
        }

        private void PonerInfoEnDataGrid(string[] info)
        {
            string[] aux;
            activarEventosValueChanged = false;
            dataGridView1.Rows.Clear();
            foreach (string linea in info)
            {
                //La linea ░░░░░░ es basicamente una linea vacia
                //Esto se hace porque cada vez que se extrae informacion de un datagrid
                //Siempre extrae tambien la de la ultima fila, la que solo esta ahi para
                //crear una nueva fila.
                //Como resultado, en el archivo se guarda esta fila vacia
                //y cuando se lo habre de vuelta habra 2 filas vacias, la que venia en el archivo
                //y la que el datagrid añade por defecto, y cada vez que se añada informacion y se
                //habra de vuelta del archivo, el numero de filas vacias aumentara en 1
                if (linea != "" & linea != "░░░░░░")
                {
                    aux = linea.Split('░');
                    dataGridView1.Rows.Add(aux[0], aux[1], aux[2], aux[3], aux[4], aux[5], aux[6]);
                }

            }
            activarEventosValueChanged = true;
        }
        
        //Extrae la informacion del ddata grid y la convierte en un arreglo
        //Se utiliza para crear el arreglo con el cual se va a guardar la informacion
        private string[] ConvertirDataGridEnArr()
        {
            List<string> lista = new List<string>();
            string aux = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                aux = "";
                try
                {
                    //much wow
                    if (true) 
                    {
                        //Big();
                    }
                    //Con la funcion .ToString() se cae, con los siguiente no
                    aux += (dataGridView1[0, i].Value as String) + "░";
                    aux += (dataGridView1[1, i].Value as String) + "░";
                    aux += (dataGridView1[2, i].Value as String) + "░";
                    aux += (dataGridView1[3, i].Value as String) + "░";
                    aux += (Convert.ToString(dataGridView1[4, i].Value)) + "░";
                    aux += (Convert.ToString(dataGridView1[5, i].Value)) + "░";
                    aux += (Convert.ToString(dataGridView1[6, i].Value));
                    //sugoi
                }
                catch { aux += "░"; }
                //En un comentario anterior se mencionaba que al leer el archivo
                //no leia el string "░░░░░░", con este if, lo que se hacia arriba ya no 
                //es necesario, sin embargo no se borrar lo de arriba para recalcar la importancia
                //de este if de aqui abajo

                if (aux != "░░░░░░")
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
