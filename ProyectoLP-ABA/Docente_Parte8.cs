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
    public partial class Docente_Parte8 : Form
    {
        string nombre;
        string path;
        string[] paralelos;
        string paralelo;
        bool activarEventosValueChanged = false;
        public Docente_Parte8()
        {
            
            InitializeComponent();

            try
            {
                string[] aux;
                bool aniadirParalelo = true;

                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                nombre = File.ReadAllLines("nombre.txt")[0];
                //Lee los paralelos
                ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
                paralelos = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
                foreach (string paralelo in paralelos) //Lee cada paralelo para insertarlo en el list view
                {
                    aux = paralelo.Split('░');
                    lbParalelos.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
                }

                //Setea el path del archivo con el que vamos a trabajar
                path = "datos\\" + nombre + "\\Estadisticas de asignatura.txt";
                ManejoDeArchivos.CrearArchivo(path);
                //Va a revisar que se encuentren todas las asignaturas en el archivo Estadisticas de asignatura.txt
                aux = File.ReadAllLines(path);
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
                        //Inicial:
                        //Asignatura░Nivel░Paralelo
                        //Final:
                        //Asignatura░Nivel░Paralelo░Matri.░Aprob.░Reprob.░Retir.░Media░DesvEst
                        ManejoDeArchivos.AniadirLineaArchivo(path, paralelos[i] + "░0░0░0░0░0░0");
                    }
                    aniadirParalelo = true;
                }
            }
            catch { }
            

        }

        //Se encarga de recuperar la informacion en los campos de texto para guardarla en su respectivo .txt
        private void AplicarCambiosDatos()
        {
            string[] clases;


            if (activarEventosValueChanged)
            {
                ManejoDeArchivos.CrearArchivo(path);
                clases = File.ReadAllLines(path);
                for (int j = 0; j < clases.Length; j++)
                {
                    if (clases[j].Contains(paralelo + "░"))
                    {
                        clases[j] = paralelo +
                        "░" + nudEstMat.Value +
                        "░" + nudEstApr.Value +
                        "░" + nudEstRep.Value +
                        "░" + nudEstRet.Value +
                        "░" + nudMedia.Value +
                        "░" + nudDesEst.Value;
                        ManejoDeArchivos.GuardarArchivo(path, clases);
                        break;
                    }
                }


            }
        }
        //Cuando se selecciona un registro del listbox, este evento va a agregar los datos 
        //de dicha registro en sus respectivos campos
        private void lbParalelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            activarEventosValueChanged = false;
            string auxString;
            ManejoDeArchivos.CrearArchivo(path);
            string[] aux = null, info = File.ReadAllLines(path);
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
                    nudEstMat.Value = Convert.ToDecimal(aux[3]);
                    nudEstApr.Value = Convert.ToDecimal(aux[4]);
                    nudEstRep.Value = Convert.ToDecimal(aux[5]);
                    nudEstRet.Value = Convert.ToDecimal(aux[6]);
                    nudMedia.Value = Convert.ToDecimal(aux[7]);
                    nudDesEst.Value = Convert.ToDecimal(aux[8]);
                }
            }
            catch { }


            activarEventosValueChanged = true;
        }


        //Los cambios realizados en los datos se guardaran el instante que cambiemos la informacion
        //de sus respectivos campos
        //Estos eventos se encargan de eso
        private void nudEstMat_ValueChanged(object sender, EventArgs e)
        {
            AplicarCambiosDatos();
        }

        private void nudEstApr_ValueChanged(object sender, EventArgs e)
        {
            AplicarCambiosDatos();
        }

        private void nudMedia_ValueChanged(object sender, EventArgs e)
        {
            AplicarCambiosDatos();
        }

        private void nudEstRet_ValueChanged(object sender, EventArgs e)
        {
            AplicarCambiosDatos();
        }

        private void nudEstRep_ValueChanged(object sender, EventArgs e)
        {
            AplicarCambiosDatos();
        }

        private void nudDesEst_ValueChanged(object sender, EventArgs e)
        {
            AplicarCambiosDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Docente_Parte8_Load(object sender, EventArgs e)
        {

        }
    }
}
