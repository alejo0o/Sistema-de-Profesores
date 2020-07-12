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
    public partial class FormDocente_Parte10 : Form
    {
        string nombre;
        string path, pathCertificado;
        string[] info;
        bool activarEventosTextChanged = false;
        public FormDocente_Parte10()
        {
            InitializeComponent();
            try
            {
                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                nombre = File.ReadAllLines("nombre.txt")[0];
                //Carga los registros existentes
                path = "datos\\" + nombre + "\\Proyectos de investigación.txt";
                ManejoDeArchivos.CrearArchivo(path);
                info = File.ReadAllLines(path);
                ActualizarRegistrosListBox(path);
                //Desactiva los botones ya que al principio no esta seleccionado ningun curso
                bVerArch.Enabled = false;
                bSubArch.Enabled = false;
                //Tambien el checkbox de los fondos
                tFondos.Enabled = false;
            }
            catch { }

        }

        //Se encarga de cargar el contenido del .txt en el listbox
        private void ActualizarRegistrosListBox(string path)
        {
            string[] aux;
            lbRegistros.Items.Clear();
            ManejoDeArchivos.CrearArchivo(path);
            info = File.ReadAllLines(path);
            foreach (string linea in info)
            {
                aux = linea.Split('░');
                lbRegistros.Items.Add(aux[0]);
            }
        }
        //Se encarga de subir un archivo seleccionado con
        //openFileDialog, almacena el path del archivo y
        //cambia el estado a subido
        private void bSubArch_Click(object sender, EventArgs e)
        {
            string pathOld;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathOld = openFileDialog1.FileName;
                if (pathOld.Substring(pathOld.Length - 4) == ".pdf") //Verifica que el archivo seleccionado si sea .pdf
                {
                    try
                    {
                        if (pathCertificado == "")
                        {
                            pathCertificado = "datos\\" + nombre + "\\Participacion en proyectos - Certificados\\";
                            pathCertificado += pathOld.Substring(pathOld.LastIndexOf('\\') + 1);
                        }
                        else
                        {
                            File.Delete(pathCertificado);
                            pathCertificado = "datos\\" + nombre + "\\Participacion en proyectos - Certificados\\";
                            pathCertificado += pathOld.Substring(pathOld.LastIndexOf('\\') + 1);
                        }
                        if (File.Exists(pathCertificado))
                        {
                            MessageBox.Show("Ya existe un archivo con este nombre", "No se puedo subir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ManejoDeArchivos.CrearArchivo(pathCertificado);
                            File.Copy(pathOld, pathCertificado, true);
                            labelEstado.Text = "Estado: Subido";
                            bVerArch.Enabled = true;
                            AplicarCambios();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se puede subir el archivo debido a que el archivo anterior esta abierto, por favor cierre el archivo. Si el problema persiste, por favor contacte al administrador", "No se puedo subir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor suba solo archivos .pdf", "No se puedo subir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Carga en los campos de texto la informacion del registro
        //seleccionado en listbox y tambien almacena el path
        //del certificado
        private void lbRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lee la opcion seleccionada en la lista y traduce el nombre
            //para hallar el path Ej.: Materia, Nivel: 1, Paralelo: 2 -> Materia;1;1
            string[] registro;

            activarEventosTextChanged = false;
            bVerArch.Enabled = false;
            bSubArch.Enabled = false;

            try
            {
                registro = info[lbRegistros.SelectedIndex].Split('░');
                tTitulo.Text = registro[0];
                tInstitucion.Text = registro[1];
                if (registro[2] == "Director")
                {
                    rbDirector.Checked = true;
                }
                else
                {
                    rbInvestigador.Checked = true;
                }
                if (registro[3] == "Si")
                {
                    rbPuceSi.Checked = true;
                }
                else
                {
                    rbPuceNo.Checked = true;
                }
                if (registro[4] != "")
                {
                    cbFondos.Checked = true;
                    tFondos.Text = registro[4];
                }
                else
                {
                    cbFondos.Checked = false;
                    tFondos.Text = registro[4];
                }
                if (registro[5] != "" && registro[5].EndsWith(".pdf"))
                {
                    pathCertificado = "datos\\" + nombre + "\\Participacion en proyectos - Certificados\\" + registro[5];
                }
                else
                {
                    pathCertificado = "";
                }

                if (pathCertificado != "")
                {
                    labelEstado.Text = "Estado: Subido";
                    bVerArch.Enabled = true;
                }
                else
                {
                    labelEstado.Text = "Estado: Sin subir";
                    bVerArch.Enabled = false;
                }
                bSubArch.Enabled = true;

                activarEventosTextChanged = true;
            }
            catch { }
        }
        //Abre el archivo subido por el usuario
        private void bVerArch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(pathCertificado);
            }
            catch { }
        }

        //Estos eventos se encargan de actualizar la informacion
        //cada vez que se cambie el contenido de estos

        //En el caso de la caja de texto del titulo, tambien refresca el contenido
        //de la listbox, pues ahi se muestra en titulo del archivo
        private void tTitulo_TextChanged(object sender, EventArgs e)
        {
            int index;
            try
            {
                if (activarEventosTextChanged)
                {
                    index = lbRegistros.SelectedIndex;
                    AplicarCambios();
                    ActualizarRegistrosListBox(path);
                    lbRegistros.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void tInstitucion_TextChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            ManejoDeArchivos.AniadirLineaArchivo(path, "Nuevo Registro░░░░░");
            ActualizarRegistrosListBox(path);
            tTitulo.Text = "";
            tInstitucion.Text = "";
            pathCertificado = "";
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                info[lbRegistros.SelectedIndex] = "";
                ManejoDeArchivos.GuardarArchivo(path, info);
                info = File.ReadAllLines(path);
                ActualizarRegistrosListBox(path);
            }
            catch { }
        }

        private void rbPuceSi_CheckedChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void cbFondos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarCambios();
            if (cbFondos.Checked)
            {
                tFondos.Enabled = true;
            }
            else
            {
                tFondos.Enabled = false;
            }
        }

        private void tFondos_TextChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void rbDirector_CheckedChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Esta funcion se encarga de recolectar la informacion de diferentes
        //Campos del formulario para guardarla en su respectivo .txt
        private void AplicarCambios()
        {
            string linea = "";
            try
            {
                if (activarEventosTextChanged)
                {
                    linea += tTitulo.Text + "░" +
                    tInstitucion.Text + "░";
                    if (rbDirector.Checked)
                    {
                        linea += "Director" + "░";
                    }
                    else
                    {
                        linea += "Investigador" + "░";
                    }
                    if (rbPuceSi.Checked)
                    {
                        linea += "Si" + "░";
                    }
                    else
                    {
                        linea += "No" + "░";
                    }
                    if (cbFondos.Checked)
                    {
                        linea += tFondos.Text + "░";
                    }
                    else
                    {
                        linea += "" + "░";
                    }
                    linea += pathCertificado.Substring(pathCertificado.LastIndexOf("\\") + 1);
                    info[lbRegistros.SelectedIndex] = linea;
                    ManejoDeArchivos.GuardarArchivo(path, info);
                }
            }
            catch { }
        }

    }
}
