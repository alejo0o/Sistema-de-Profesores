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
    public partial class FormDocente_Parte14 : Form
    {
        string nombre;
        string path, pathArticulo = "", pathCertificado = "";
        string[] info;
        bool activarEventosTextChanged = false;
        public FormDocente_Parte14()
        {
            InitializeComponent();
            try
            {
                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                nombre = File.ReadAllLines("nombre.txt")[0];
                //Carga los articulos existentes
                path = "datos\\" + nombre + "\\Producción científica.txt";
                ManejoDeArchivos.CrearArchivo(path);
                info = File.ReadAllLines(path);
                ActualizarArticulosListBox(path);
                //Desactiva los botones ya que al principio no esta seleccionado ningun curso
                bVerArch.Enabled = false;
                bVerArch2.Enabled = false;
                bSubArch.Enabled = false;
                bSubArch2.Enabled = false;
            }
            catch { }
            
        }
        //Esta funcion se encarga de recolectar la informacion de diferentes
        //Campos del formulario para guardarla en su respectivo .txt
        private void AplicarCambios()
        {
            string linea = "";
            string fecha;
            try
            {
                if (activarEventosTextChanged)
                {
                    linea += tArticulo.Text + "░" +
                    tNombre.Text + "░";
                    fecha = dateTimePicker1.Value.ToString();
                    fecha = fecha.Substring(0, fecha.IndexOf(" "));
                    linea += fecha + "░" +
                    tDOI.Text + "░" +
                    tIndexado.Text + "░" +
                    tISSN.Text + "░" +
                    tRevista.Text + "░" +
                    pathArticulo.Substring(pathArticulo.LastIndexOf("\\") + 1) + "░" +
                    pathCertificado.Substring(pathCertificado.LastIndexOf("\\") + 1);
                    info[lbArticulos.SelectedIndex] = linea;
                    ManejoDeArchivos.GuardarArchivo(path, info);
                }
            }
            catch { }
        }

        //Esta funcion se encarga de cargar todos los registros del .txt
        //en el listbox
        private void ActualizarArticulosListBox(string path)
        {
            string[] aux;
            lbArticulos.Items.Clear();
            ManejoDeArchivos.CrearArchivo(path);
            info = File.ReadAllLines(path);
            foreach (string linea in info)
            {
                aux = linea.Split('░');
                lbArticulos.Items.Add(aux[1]);
            }
        }

        //Carga en los campos de texto la informacion del registro 
        //seleccionado en listbox y tambien almacena el path
        //del certificado y del articulo cientifico
        private void lbArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] articulo;
            string[] fecha;

            activarEventosTextChanged = false;
            bVerArch.Enabled = false;
            bVerArch2.Enabled = false;
            bSubArch.Enabled = false;
            bSubArch2.Enabled = false;

            try
            {
                articulo = info[lbArticulos.SelectedIndex].Split('░');
                tArticulo.Text = articulo[0];
                tNombre.Text = articulo[1];
                if (articulo[2].Contains('/'))
                {
                    fecha = articulo[2].Split('/');
                    dateTimePicker1.Value = new DateTime(Convert.ToInt32(fecha[2]), Convert.ToInt32(fecha[1]), Convert.ToInt32(fecha[0]));
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Today;
                }
                tDOI.Text = articulo[3];
                tIndexado.Text = articulo[4];
                tISSN.Text = articulo[5];
                tRevista.Text = articulo[6];
                if (articulo[7].EndsWith(".pdf"))
                {
                    pathArticulo = "datos\\" + nombre + "\\Articulos cientificos\\" + articulo[7];
                }
                else
                {
                    pathArticulo = "";
                }
                if (articulo[8].EndsWith(".pdf"))
                {
                    pathCertificado = "datos\\" + nombre + "\\Certificados de articulos\\" + articulo[8];
                }
                else
                {
                    pathCertificado = "";
                }

                if (pathArticulo != "")
                {
                    labelEstado.Text = "Estado: Subido";
                    bVerArch.Enabled = true;
                }
                else
                {
                    labelEstado.Text = "";
                    bVerArch.Enabled = false;
                }
                if (pathCertificado != "")
                {
                    labelEstado2.Text = "Estado: Subido";
                    bVerArch2.Enabled = true;
                }
                else
                {
                    labelEstado2.Text = "";
                    bVerArch2.Enabled = false;
                }
                bSubArch.Enabled = true;
                bSubArch2.Enabled = true;

                activarEventosTextChanged = true;
            }
            catch { }
        }
        //Elimina el registro seleccionado
        private void bEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                info[lbArticulos.SelectedIndex] = "";
                ManejoDeArchivos.GuardarArchivo(path, info);
                info = File.ReadAllLines(path);
                ActualizarArticulosListBox(path);
            }
            catch { }
        }
        //Estos eventos se encargan de actualizar la informacion 
        //cada vez que se cambie el contenido de estos

        //En el caso de la caja de texto del titulo, tambien refresca el contenido
        //de la listbox, pues ahi se muestra en titulo del archivo
        private void tNombre_TextChanged(object sender, EventArgs e)
        {
            int index;
            try
            {
                if (activarEventosTextChanged)
                {
                    index = lbArticulos.SelectedIndex;
                    AplicarCambios();
                    ActualizarArticulosListBox(path);
                    lbArticulos.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void tArticulo_TextChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void tIndexado_TextChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void tDOI_TextChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void tRevista_TextChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }

        private void tISSN_TextChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }
        //Se encarga de subir un archivo seleccionado con 
        //openFileDialog, almacena el path del archivo y
        //cambia el estado a subido
        //Esta funcion en especifico es para el boton de subir articulos
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
                        if (pathArticulo == "")
                        {
                            pathArticulo = "datos\\" + nombre + "\\Articulos cientificos\\";
                            pathArticulo += pathOld.Substring(pathOld.LastIndexOf('\\') + 1);
                        }
                        else
                        {
                            File.Delete(pathArticulo);
                            pathArticulo = "datos\\" + nombre + "\\Articulos cientificos\\";
                            pathArticulo += pathOld.Substring(pathOld.LastIndexOf('\\') + 1);
                        }
                        if (File.Exists(pathArticulo))
                        {
                            MessageBox.Show("Ya existe un archivo con este nombre", "No se puedo subir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ManejoDeArchivos.CrearArchivo(pathArticulo);
                            File.Copy(pathOld, pathArticulo, true);
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

        //Abre el archivo subido por el usuario
        private void bVerArch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(pathArticulo);
            }
            catch { }
        }

        private void bVerArch2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(pathCertificado);
            }
            catch { }
        }
        //Se encarga de subir un archivo seleccionado con 
        //openFileDialog, almacena el path del archivo y
        //cambia el estado a subido
        //Esta funcion en especifico es para el boton de subir certificados
        private void bSubArch2_Click(object sender, EventArgs e)
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
                            pathCertificado = "datos\\" + nombre + "\\Certificados de articulos\\";
                            pathCertificado += pathOld.Substring(pathOld.LastIndexOf('\\') + 1);
                        }
                        else
                        {
                            File.Delete(pathCertificado);
                            pathCertificado = "datos\\" + nombre + "\\Certificados de articulos\\";
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
                            labelEstado2.Text = "Estado: Subido";
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
        //Continuacion de los eventos que al cambiar su valor guardan el archivo
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AplicarCambios();
        }
        //Creaa un nuevo registro
        private void bNuevo_Click(object sender, EventArgs e)
        {
            ManejoDeArchivos.AniadirLineaArchivo(path, "░Nuevo Articulo░░░░░░░");
            ActualizarArticulosListBox(path);
            tNombre.Text = "";
            tArticulo.Text = "";
            tDOI.Text = "";
            tIndexado.Text = "";
            tISSN.Text = "";
            tRevista.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            pathArticulo = "";
            pathCertificado = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
