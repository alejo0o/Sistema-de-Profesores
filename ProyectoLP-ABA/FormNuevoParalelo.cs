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
    public partial class FormNuevoParalelo : Form
    {
        string[] docentes;
        string path;
        bool activarEventosTextChanged = false; //El nombre lo dice todo
        public FormNuevoParalelo()
        {

            InitializeComponent();
            cbClases.Enabled = false;
            tAsignatura.Enabled = false;
            tNivel.Enabled = false;
            tParalelo.Enabled = false;
            bIngresar.Enabled = false;
            bEliminar.Enabled = false;
            ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
            docentes = File.ReadAllLines("datos\\docentes.txt");

            foreach (string docente in docentes)
            {
                lbDocente.Items.Add(docente);
            }
        }


        //Busca en un arreglo de strings todos los strings
        //que contengan la cadena especificada, no es sensible a mayus
        //Devuelve un arreglo con las coincidencias
        private string[] BuscarEnArreglo(string[] arr, string cad)
        {
            List<string> resul = new List<string>();
            foreach (string nombre in arr)
            {
                if (nombre.ToLower().Contains(cad.ToLower()))
                {
                    resul.Add(nombre);
                }
            }
            return resul.ToArray();
        }
        //Guarda un archivo de texto path con el string texto
        //Devuelve true si se ha guardado, false si no

        private void AplicarCambiosClases()
        {
            string[] clases, aux;
            int indice;
            if (activarEventosTextChanged)
            {
                ManejoDeArchivos.CrearArchivo(path);
                clases = File.ReadAllLines(path);
                indice = cbClases.SelectedIndex;
                if (indice != 0)
                {
                    clases[indice - 1] = tAsignatura.Text + "░" + tNivel.Text + "░" + tParalelo.Text;
                    ManejoDeArchivos.GuardarArchivo(path, clases);

                    //Cargamos devuelta la informacion del combobox
                    cbClases.Items.Clear();
                    cbClases.Items.Add("Ingresar nueva clase");
                    foreach (string clase in clases)
                    {
                        aux = clase.Split('░');
                        cbClases.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
                    }
                    cbClases.SelectedIndex = indice;
                }
            }
        }
        private bool AniadirLineaArchivo(string path, string linea)//Añade un string llamado linea a un archivo de texto path
        {                                                          //Devuelve true si se ha guardado, false si no
            StreamWriter escribir;
            ManejoDeArchivos.CrearArchivo(path);
            try
            {

                using (escribir = new StreamWriter(path, true))
                {
                    escribir.WriteLine(linea);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void tBuscar_TextChanged(object sender, EventArgs e)
        {
            string[] aux = BuscarEnArreglo(docentes, tBuscar.Text);
            lbDocente.Items.Clear();
            foreach (string docente in aux)
            {
                lbDocente.Items.Add(docente);
            }
        }

        private void lbDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] clases;
            string[] aux;
            path = "datos\\" + lbDocente.SelectedItem.ToString() + "\\Paralelos.txt";

            //Cargamos la lista de paralelos
            cbClases.Items.Clear();
            cbClases.Items.Add("Ingresar nueva clase");
            cbClases.SelectedIndex = 0;
            ManejoDeArchivos.CrearArchivo(path);
            ManejoDeArchivos.CrearArchivo(path);
            clases = File.ReadAllLines(path);
            foreach (string clase in clases)
            {
                aux = clase.Split('░');
                cbClases.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
            }

            //Activar componentes de interfaz necesarios
            cbClases.Enabled = true;
            activarEventosTextChanged = true;
        }

        private void cbClases_SelectedIndexChanged(object sender, EventArgs e)
        {
            activarEventosTextChanged = false;

            //Si el indice es 0, la opcion agregar nuevo es seleccionada y va a limpiar los campos y activar el boton ingresar
            //Si el indice es cualquier otro, una clase ha sido seleccionada y va a cargar la informacion en los campos y activar el boton eliminar
            string clase = cbClases.SelectedItem.ToString();
            tAsignatura.Enabled = true;
            tNivel.Enabled = true;
            tParalelo.Enabled = true;
            if (cbClases.SelectedIndex == 0)
            {
                bIngresar.Enabled = true;
                bEliminar.Enabled = false;
                tAsignatura.Text = "";
                tNivel.Text = "";
                tParalelo.Text = "";
            }
            else
            {
                bEliminar.Enabled = true;
                bIngresar.Enabled = false;
                tAsignatura.Text = clase.Substring(0, clase.IndexOf(", "));
                tNivel.Text = clase.Substring(clase.IndexOf(": ") + 2, clase.LastIndexOf(", ") - clase.IndexOf(": ") - 2);
                tParalelo.Text = clase.Substring(clase.LastIndexOf(": ") + 2);
            }

            activarEventosTextChanged = true;
        }

        private void tAsignatura_TextChanged(object sender, EventArgs e)
        {
            AplicarCambiosClases();
        }

        private void tNivel_TextChanged(object sender, EventArgs e)
        {
            AplicarCambiosClases();
        }

        private void tParalelo_TextChanged(object sender, EventArgs e)
        {
            AplicarCambiosClases();
        }

        private void bIngresar_Click(object sender, EventArgs e)
        {
            string[] clases, aux;

            AniadirLineaArchivo(path, tAsignatura.Text + "░" + tNivel.Text + "░" + tParalelo.Text);

            //Cargamos devuelta la informacion del combobox
            ManejoDeArchivos.CrearArchivo(path);
            clases = File.ReadAllLines(path);
            cbClases.Items.Clear();
            cbClases.Items.Add("Ingresar nueva clase");
            foreach (string clase in clases)
            {
                aux = clase.Split('░');
                cbClases.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
            }
            cbClases.SelectedIndex = 0;
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            string[] clases, aux;
            int indice = cbClases.SelectedIndex - 1;

            if (MessageBox.Show("¿Desea eliminar esta clase?", "Eliminar Clase", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                ManejoDeArchivos.CrearArchivo(path);
                clases = File.ReadAllLines(path);
                clases[indice] = "";
                ManejoDeArchivos.GuardarArchivo(path, clases);

                //Cargamos devuelta la informacion del combobox
                ManejoDeArchivos.CrearArchivo(path);
                clases = File.ReadAllLines(path);
                cbClases.Items.Clear();
                cbClases.Items.Add("Ingresar nueva clase");
                foreach (string clase in clases)
                {
                    aux = clase.Split('░');
                    cbClases.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
                }
                cbClases.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
