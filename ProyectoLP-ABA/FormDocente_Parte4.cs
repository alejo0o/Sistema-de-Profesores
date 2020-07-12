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
    public partial class SubirSy_D : Form
    {
        string nombre;
        string path;
        string[] paralelos;
        public SubirSy_D()
        {
            
            InitializeComponent();
            try
            {
                string[] aux;
                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                nombre = File.ReadAllLines("nombre.txt")[0];
                //Desactiva los botones ya que al principio no esta seleccionado ningun curso
                bVerArch.Enabled = false;
                bSubArch.Enabled = false;

                //Lee los paralelos
                ManejoDeArchivos.CrearArchivo("datos\\" + nombre + "\\Paralelos.txt");
                paralelos = File.ReadAllLines("datos\\" + nombre + "\\Paralelos.txt");
                foreach (string paralelo in paralelos) //Lee cada paralelo para insertarlo en el list view
                {
                    aux = paralelo.Split('░');
                    lbParalelos.Items.Add(aux[0] + ", Nivel: " + aux[1] + ", Paralelo: " + aux[2]);
                }
            }
            catch { }
            


        }
        //Se encarga de subir seleccionado con un openFileDialog y cambiar el estado a subido
        //Solo guardara el archivo si es un pdf
        //Si el archivo antiguo no esta aprovado, tendra el mismo nombre que el nuevo y el antiguo sera soobreescribo
        //Si el archivo antiguo ha sido aprovado, tendra un nombre distinto, asi que borrara en antiguo y guardara el nuevo
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
        //Abre el archivo que ha sido subido
        private void bVerArch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch { }
        }

        private void lbParalelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lee la opcion seleccionada en la lista y traduce el nombre
            //para hallar el path
            //Ej.: Materia, Nivel: 1, Paralelo: 2 -> Materia;1;1
            string aux, nombreArch, paralelo = lbParalelos.SelectedItem.ToString();
            int prueba1 = paralelo.IndexOf(": ") + 2, prueba2 = paralelo.LastIndexOf(", "), prueba3 = paralelo.Length;
            nombreArch = paralelo.Substring(0, paralelo.IndexOf(", "));
            nombreArch += ";" + paralelo.Substring(paralelo.IndexOf(": ") + 2, paralelo.LastIndexOf(", ") - paralelo.IndexOf(": ") - 2);
            nombreArch += ";" + paralelo.Substring(paralelo.LastIndexOf(": ") + 2);

            path = "datos\\" + nombre + "\\Seguimiento programas microcurriculares\\" + nombreArch;
            //El siguiente if-else sirve para ver si el archivo esta aprobado o no
            //El indicador de si esta aprobado o no esta en el propio nombre del archivo
            //y lo traduce para presentarlo en la interfaz
            if (File.Exists(path + ".pdf"))                                       
            {                                                                     
                path = path + ".pdf";                                             
                bVerArch.Enabled = true;
                labelEstado.Text = "Estado: Subido";
            }
            else if (File.Exists(path + ";Aprobado.pdf"))
            {
                path = path + ";Aprobado.pdf";
                bVerArch.Enabled = true;
                labelEstado.Text = "Estado: Aprobado";
            }
            else
            {
                labelEstado.Text = "Estado: Si subir";
            }
            bSubArch.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
