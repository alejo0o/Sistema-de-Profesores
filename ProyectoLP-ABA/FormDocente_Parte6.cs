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
    public partial class FormDocente_Parte6 : Form
    {
        string pathPlantillas, pathParalelos, pathInfo;
        string paralelo, nombre;
        bool activarEventosTextChangedPlantillas = false;
        bool activarEventosTextChangedInfo = false;
        string[] plantillas, paralelos;
        public FormDocente_Parte6()
        {
            
            InitializeComponent();

            string[] aux;
            bool aniadirParalelo = true;

            try
            {
                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                nombre = File.ReadAllLines("nombre.txt")[0];
                pathInfo = "datos\\" + nombre + "\\Sistema de evaluacion.txt";
                ManejoDeArchivos.CrearArchivo(pathInfo);
                //Para la tab de plantillas
                tNomPla.Enabled = false;
                rtPlantilla.Enabled = false;
                bEliminar.Enabled = false;
                cbUsarPlantilla.Enabled = false;

                pathPlantillas = "datos\\" + nombre + "\\Plantillas.txt";
                RefrescarPlantillas();

                //Para la tab de de editar la informacion
                pathParalelos = "datos\\" + nombre + "\\Paralelos.txt";
                ManejoDeArchivos.CrearArchivo(pathParalelos);
                paralelos = File.ReadAllLines(pathParalelos);
                foreach (string paralelo in paralelos) //Lee cada paralelo para insertarlo en el list view
                {
                    aux = paralelo.Split('░');
                    lbParalelos.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
                }

                //Va a revisar que se encuentren todas las asignaturas en el archivo Sistema de evaluacion.txt
                ManejoDeArchivos.CrearArchivo(pathInfo);
                aux = File.ReadAllLines(pathInfo);
                for (int i = 0; i < paralelos.Length; i++)
                {
                    for (int j = 0; j < aux.Length; j++)
                    {
                        if (aux[j].Contains(paralelos[i] + "░"))
                        {
                            aniadirParalelo = false;
                            break;
                        }
                    }
                    if (aniadirParalelo)
                    {
                        //Hay espacios en blanco en cada separador por que ahi va a ir los datos

                        ManejoDeArchivos.AniadirLineaArchivo(pathInfo, paralelos[i] + "░");
                    }
                    aniadirParalelo = true;
                }
            }
            catch { }
            


        }

        //Funcion que recibe un arreglo y devuelve un arreglo
        //Lo que hace es, siendo cada espacio del arreglo un linea, 
        //ver que lineas no tienen el simbolo '░'
        //Las que no tengan, les añadira a la linea anterior
        private string[] UnirLineasArr(string[] arr)
        {
            List<string> resul = new List<string>();
            string aux = "";
            foreach (string linea in arr)
            {
                if (linea.Contains('░'))
                {
                    if (aux != "")
                    {
                        resul.Add(aux);
                    }
                    aux = "";
                    aux += linea;
                }
                else
                {
                    aux += "\n" + linea;
                }

            }
            if (aux != "")
            {
                resul.Add(aux);
            }
            return resul.ToArray();
        }

        //Guarda los cambios realizados en la seccion de plantillas en su .txt correspondiente
        private void AplicarCambiosPlantillas()
        {
            int indice;

            if (activarEventosTextChangedPlantillas)
            {
                indice = cbSelecPlantilla.SelectedIndex;
                if (indice != 0)
                {
                    plantillas[indice - 1] = tNomPla.Text + "░" + rtPlantilla.Text;
                    ManejoDeArchivos.GuardarArchivo(pathPlantillas, plantillas);
                }
            }
        }

        //Refrescamos los nombres de las plantillas contenidas en el combo box
        private void RefrescarPlantillas()
        {
            //Refrescamos el combo box
            cbSelecPlantilla.Items.Clear();
            cbUsarPlantilla.Items.Clear();
            tNomPla.Text = "";
            rtPlantilla.Text = "";
            cbSelecPlantilla.Items.Add("Ingresar nueva plantilla");
            cbUsarPlantilla.Items.Add("(Ninguno)");
            cbUsarPlantilla.SelectedIndex = 0;
            cbSelecPlantilla.SelectedIndex = 0;
            ManejoDeArchivos.CrearArchivo(pathPlantillas);
            plantillas = File.ReadAllLines(pathPlantillas);
            plantillas = UnirLineasArr(plantillas);
            for (int i = 0; i < plantillas.Length; i++)
            {
                cbSelecPlantilla.Items.Add(plantillas[i].Substring(0, plantillas[i].IndexOf("░")));
                cbUsarPlantilla.Items.Add(plantillas[i].Substring(0, plantillas[i].IndexOf("░")));
            }
        }

        //Cuando se selecciona un plantilla del combobox, este evento va a agregar los datos 
        //de dicha plantilla en sus respectivos campos
        private void cbSelecPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            activarEventosTextChangedPlantillas = false;

            //Si el indice es 0, la opcion agregar nuevo es seleccionada y va a limpiar los campos y activar el boton ingresar
            //Si el indice es cualquier otro, una clase ha sido seleccionada y va a cargar la informacion en los campos y activar el boton eliminar
            string plantilla = cbSelecPlantilla.SelectedItem.ToString();
            int indice = cbSelecPlantilla.SelectedIndex;
            tNomPla.Enabled = true;
            rtPlantilla.Enabled = true;
            if (indice == 0)
            {
                bIngresar.Enabled = true;
                bEliminar.Enabled = false;
                tNomPla.Enabled = true;
                rtPlantilla.Enabled = true;
                tNomPla.Text = "";
                rtPlantilla.Text = "";
            }
            else
            {
                bEliminar.Enabled = true;
                bIngresar.Enabled = false;
                tNomPla.Enabled = true;
                rtPlantilla.Enabled = true;
                tNomPla.Text = plantilla;
                rtPlantilla.Text = plantillas[indice - 1].Substring(plantillas[indice - 1].IndexOf('░') + 1);
            }

            activarEventosTextChangedPlantillas = true;
        }

        private void tNomPla_TextAlignChanged(object sender, EventArgs e)
        {
            //No hace nada, no eliminar
        }

        //Los cambios realizados en la plantilla se guardaran el instante que cambiemos la informacion
        //de sus respectivos campos
        private void tNomPla_TextChanged(object sender, EventArgs e)
        {
            AplicarCambiosPlantillas();
        }

        private void rtPlantilla_TextChanged(object sender, EventArgs e)
        {
            AplicarCambiosPlantillas();
        }

        ////Cuando se selecciona una plantilla del comboboxbox, este evento va a agregar los datos 
        //de dicha plantilla en sus respectivos campos
        private void cbUsarPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aux;
            if (cbUsarPlantilla.SelectedIndex != 0)
            {
                aux = plantillas[cbUsarPlantilla.SelectedIndex - 1];
                rtInfo.Text = aux.Substring(aux.IndexOf("░") + 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //Los cambios realizados en la sobre la informacion se guardaran el instante que cambiemos la informacion
        //de sus respectivos campos
        private void rtInfo_TextChanged(object sender, EventArgs e)
        {
            activarEventosTextChangedInfo = false;
            ManejoDeArchivos.CrearArchivo(pathInfo);
            
            string[] aux = null, info = UnirLineasArr(File.ReadAllLines(pathInfo));
            bool hay = false;
            try
            {
                for (int j = 0; j < info.Length; j++)
                {
                    if (info[j].Contains(paralelo + "░"))
                    {
                        aux = info[j].Split('░');
                        aux[3] = rtInfo.Text;
                        info[j] = aux[0] + "░" + aux[1] + "░" + aux[2] + "░" + aux[3];
                        break;
                    }
                }
                if (hay)
                {

                }
            }
            catch { }
            ManejoDeArchivos.GuardarArchivo(pathInfo, info);

            activarEventosTextChangedInfo = true;
        }

        //Cuando se selecciona un registro del listbox, este evento va a agregar los datos 
        //de dicha registro en sus respectivos campos
        private void lbParalelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            activarEventosTextChangedInfo = false;
            string auxString;
            ManejoDeArchivos.CrearArchivo(pathInfo);
            string[] aux = null, info = UnirLineasArr(File.ReadAllLines(pathInfo));
            bool hay = false;
            try
            {
                paralelo = lbParalelos.SelectedItem.ToString();
                auxString = paralelo.Substring(0, paralelo.IndexOf(", "));
                auxString += "░" + paralelo.Substring(paralelo.IndexOf(": ") + 2, paralelo.LastIndexOf(", ") - paralelo.IndexOf(": ") - 2);
                auxString += "░" + paralelo.Substring(paralelo.LastIndexOf(": ") + 2);
                paralelo = auxString;
                for (int j = 0; j < info.Length; j++)
                {
                    if (info[j].Contains(auxString + "░"))
                    {
                        aux = info[j].Split('░');
                        hay = true;
                        break;
                    }
                }
                if (hay)
                {
                    rtInfo.Text = aux[3];
                }
                cbUsarPlantilla.Enabled = true;
                cbUsarPlantilla.SelectedIndex = 0;
            }
            catch { }


            activarEventosTextChangedInfo = true;
        }

        //Este evento se encarga de ingresar nuevas plantillas
        private void bIngresar_Click(object sender, EventArgs e)
        {
            activarEventosTextChangedPlantillas = false;

            ManejoDeArchivos.AniadirLineaArchivo(pathPlantillas, tNomPla.Text + "░" + rtPlantilla.Text);

            RefrescarPlantillas();

            activarEventosTextChangedPlantillas = true;
        }
        //Este evento se encarga de eliminar la plantilla selccionada en el combobox
        private void bEliminar_Click(object sender, EventArgs e)
        {
            activarEventosTextChangedPlantillas = false;

            plantillas[cbSelecPlantilla.SelectedIndex - 1] = "";
            ManejoDeArchivos.GuardarArchivo(pathPlantillas, plantillas);

            RefrescarPlantillas();

            activarEventosTextChangedPlantillas = true;
        }
    }
}
