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
    public partial class FormEditarUsuario : Form
    {
        string[] usuarios;//Va a almacenar la informacion del archivo de usuarios, cada linea es un usuario
        string[] docentes;
        int? pos = null;                              //Va a guardar la posicion en el arreglo de usuarios del usuarios que queremos editar/eliminar
        string[] posInfo = new string[4]; //Va a guardar la informacion del usuario en la posicion en el arreglo de usuarios del usuarios que queremos editar/eliminar
        bool activarEventosTextChanged = false; //El nombre lo dice todo
        List<string[]> cambiosNombreCarpetas = new List<string[]>(); //Va a almacenar los cambios de nombre de carpeta pendientes
        public FormEditarUsuario()
        {
            InitializeComponent();
            //Impide que se usen los botones de guardar cambios y eliminar si no hay nungun usuario seleccionado
            bEliUsuario.Enabled = false;
            tNomCompleto.Enabled = false;
            tContrasenia.Enabled = false;
            tNomUsuario.Enabled = false;
            groupBox1.Enabled = false;
            //Carga los nombres de usuario en la list view
            ManejoDeArchivos.CrearArchivo("datos\\usuarios.txt");
            ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
            usuarios = File.ReadAllLines("datos\\usuarios.txt");
            docentes = File.ReadAllLines("datos\\docentes.txt");
            string[] aux;
            foreach (string usuario in usuarios)
            {
                if (usuario != "")
                {
                    aux = usuario.Split('░');
                    aux[2] = aux[2].Substring(0, aux[2].Length - 3); //Se encarga de eliminar el ';' de los nombres de usuario
                    lbUsuario.Items.Add(aux[0] + ": " + aux[2]);
                }
            }
            foreach (string docente in docentes)
            {
                cambiosNombreCarpetas.Add(new string[] { docente, docente });
            }
        }

        private void FormEditarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tContrasenia.UseSystemPasswordChar == true)
            {
                tContrasenia.UseSystemPasswordChar = false;
            }
            else
                tContrasenia.UseSystemPasswordChar = true;
        }
        //El evento lo que hace es buscar de entre los usuarios cual tiene
        //la subcadena especifica ya sea en su nombre de usuario o nombre completo del usuario
        private void tBuscar_TextChanged(object sender, EventArgs e)
        {
            activarEventosTextChanged = false;
            string[] aux;
            string[] resul; //Va a almacenar los resultados de la busqueda

            //El if es para que solo busque si hay mas de un caracter o esta vacio
            //Esto se debe a que tambien revisa los caracteres de la contraseña
            //encriptada al momento de buscar
            if (tBuscar.Text.Length >= 2 || tBuscar.Text == "")
            {
                bEliUsuario.Enabled = false;
                tNomCompleto.Enabled = false;
                tContrasenia.Enabled = false;
                tNomUsuario.Enabled = false;
                groupBox1.Enabled = false;
                tNomUsuario.Text = "";
                tNomCompleto.Text = "";
                tContrasenia.Text = "";
                rbAdmin.Checked = false;
                rbDocente.Checked = false;
                rbCoordinador.Checked = false;
                rbDocCor.Checked = false;
                lbUsuario.Items.Clear();

                resul = BuscarEnArreglo(usuarios, tBuscar.Text);
                foreach (string usuario in resul)
                {
                    if (usuario != "")
                    {
                        aux = usuario.Split('░');
                        aux[2] = aux[2].Substring(0, aux[2].Length - 3); //Se encarga de eliminar el ';' de los nombres de usuario
                        lbUsuario.Items.Add(aux[0] + ": " + aux[2]);
                    }
                }
            }
        }
        private string[] BuscarEnArreglo(string[] arr, string cad) //Busca en un arreglo de strings todos los strings
                                                                   //que contengan la cadena especificada, no es sensible a mayus
                                                                   //Devuelve un arreglo con las coincidencias
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

        //No guarda los cambios en el archivo, solo los aplica en el arreglo
        //Devuelve true si lo consiguio, o false si no
        private bool AplicarCambios()
        {
            activarEventosTextChanged = false;
            Random r = new Random(); //Se va a usar este numero aleatorio para añadirle al nombre
            string nombre = tNomCompleto.Text;
            string usuario = tNomUsuario.Text;
            string contrasenia = tContrasenia.Text;
            byte tipo = 3; //va a almacenar el tipo de docente en un dato numerico
                           //0: Administrador
                           //1: Coordinador - docente
                           //2: Coordinador
                           //3: Docente
            string nuevaLinea; //Es la linea que contiene la informacion del usuario y la que se añadira al archivo
            string[] docentesAux = new string[docentes.Length + 1]; //Se va a usar esta variable en caso que se un usuario cambie su tipo a docente
            bool continuar = true;
            bool guardar = true;
            string[] aux;
            if (pos != null)
            {
                //Añade un numero aleatorio al nombre para asegurarse que sea unico
                nombre += ";" + r.Next(0, 9) + "" + r.Next(10, 99) % 10;
                //Determina el dato numerico correspondiente al tipo
                if (rbDocente.Checked)
                {
                    tipo = 3;
                }
                else if (rbCoordinador.Checked)
                {
                    tipo = 2;
                }
                else if (rbDocCor.Checked)
                {
                    tipo = 1;
                }
                else if (rbAdmin.Checked)
                {
                    tipo = 0;
                }

                do
                {
                    foreach (string linea in usuarios)
                    {
                        if (linea != "" && linea != usuarios[pos.Value])
                        {
                            continuar = true;
                            aux = linea.Split('░');
                            if (aux[0].Equals(usuario))
                            {
                                labelInfo.Text = "Nombre de usuario no disponible, por favor intente con otro.";
                                continuar = true;
                                guardar = false;
                                break;
                            }
                            else
                            {
                                labelInfo.Text = "";
                            }
                            if (aux[2].Equals(nombre))
                            {
                                nombre = nombre.Substring(0, nombre.Length - 3) + ";" + r.Next(0, 9) + "" + r.Next(10, 99) % 10;
                                continuar = false;
                                break;
                            }
                        }
                    }
                } while (!continuar);
                nuevaLinea = usuario + "░";
                nuevaLinea += StringCipher.Encrypt(contrasenia + tipo, nombre) + "░";
                nuevaLinea += nombre;


                //Añadimos los cambios tambien al arreglo docentes con informacion correspondientes a datos\\docentes.txt
                //En caso de que haya una nuevo docente
                if (tipo == 3 || tipo == 1)
                {
                    aux = usuarios[pos.Value].Split('░');
                    continuar = true; //vamos a reutilizar la variable continuar, ahora significara que si es verdadero, el
                                      //usuario especificado no existe en el arreglo docente y procedera a añadirlo
                                      //si es falso, significa que no existe y procedera a añadirlo
                    for (int i = 0; i < docentes.Length; i++)
                    {
                        docentesAux[i] = docentes[i];
                        if (aux[2] == docentes[i])
                        {
                            continuar = false;
                            docentes[i] = nombre;
                            //Añadimos un pendiente de cambiar nombre de carpeta
                            foreach (string[] cambios in cambiosNombreCarpetas)
                            {
                                if (cambios[1] == aux[2])
                                {
                                    cambios[1] = nombre;
                                }
                            }
                            break;
                        }
                    }
                    if (continuar)
                    {
                        docentesAux[docentes.Length] = nombre;
                        docentes = docentesAux;
                    }

                }
                //En caso de que un docente deje de serlo
                if (tipo == 2 || tipo == 0)
                {
                    aux = usuarios[pos.Value].Split('░');
                    for (int i = 0; i < docentes.Length; i++)
                    {
                        if (aux[2] == docentes[i])
                        {
                            docentes[i] = "";
                            break;
                        }
                    }

                }

                usuarios[pos.Value] = nuevaLinea;
            }

            return guardar;
        }
        //Aplica los cambios a los arreglos y a la interfaz
        private void AplicarCambiosInterfaz()
        {
            activarEventosTextChanged = false;
            string[] usuario = new string[4];
            string tipo = posInfo[2];

            //Las siguientes 2 variables son para la busqueda con el fin de actualizar la lista
            string[] resul, aux;

            if (rbDocente.Checked)
            {
                tipo = "3";
            }
            else if (rbCoordinador.Checked)
            {
                tipo = "2";
            }
            else if (rbDocCor.Checked)
            {
                tipo = "1";
            }
            else if (rbAdmin.Checked)
            {
                tipo = "0";
            }
            usuario[0] = tNomUsuario.Text;
            usuario[1] = tContrasenia.Text;
            usuario[2] = tipo;
            usuario[3] = tNomCompleto.Text;
            if (pos != null && !usuario.SequenceEqual(posInfo))
            {
                lbUsuario.Enabled = false;
                tBuscar.Enabled = false;
                bModUsuario.Enabled = false;
                bEliUsuario.Enabled = false;
                if (AplicarCambios())
                {
                    lbUsuario.Enabled = true;
                    tBuscar.Enabled = true;
                    bModUsuario.Enabled = true;
                    bEliUsuario.Enabled = true;
                    //Si se quita esto de abajo, entrara en un bucle infinito al realizar cambios y seleccionar otro usuario
                    posInfo[0] = usuario[0];
                    posInfo[1] = usuario[1];
                    posInfo[2] = usuario[2];
                    posInfo[3] = usuario[3];
                }

                lbUsuario.Items.Clear();
                resul = BuscarEnArreglo(usuarios, tBuscar.Text);
                foreach (string linea in resul)
                {
                    if (linea != "")
                    {
                        aux = linea.Split('░');
                        aux[2] = aux[2].Substring(0, aux[2].Length - 3); //Se encarga de eliminar el ';' de los nombres de usuario
                        lbUsuario.Items.Add(aux[0] + ": " + aux[2]);
                    }
                }
            }
        }

        //Se encarga de llenar los campos de texto una vez se ha seleccionado
        //un elemento de listbox
        private void lbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            activarEventosTextChanged = false;
            string[] aux;
            string usuario;
            char tipo;

            try
            {
                usuario = lbUsuario.SelectedItem.ToString();
                usuario = usuario.Substring(0, usuario.IndexOf(':'));
                for (int i = 0; i < usuarios.Length; i++)
                {
                    if (usuarios[i] != "" && usuarios[i].Substring(0, usuario.Length).Equals(usuario))
                    {
                        aux = usuarios[i].Split('░');
                        tNomUsuario.Text = aux[0];
                        tContrasenia.Text = StringCipher.Decrypt(aux[1], aux[2]);
                        tipo = tContrasenia.Text[tContrasenia.Text.Length - 1];
                        tContrasenia.Text = tContrasenia.Text.Substring(0, tContrasenia.Text.Length - 1);
                        tNomCompleto.Text = aux[2].Substring(0, aux[2].Length - 3);
                        pos = i;
                        posInfo[0] = tNomUsuario.Text;
                        posInfo[1] = tContrasenia.Text;
                        posInfo[2] = tipo.ToString();
                        posInfo[3] = tNomCompleto.Text;
                        switch (tipo)
                        {
                            case '0':
                                rbAdmin.Checked = true;
                                break;
                            case '1':
                                rbDocCor.Checked = true;
                                break;
                            case '2':
                                rbCoordinador.Checked = true;
                                break;
                            case '3':
                                rbDocente.Checked = true;
                                break;
                            default:
                                break;
                        }
                        bEliUsuario.Enabled = true;
                        tNomCompleto.Enabled = true;
                        tContrasenia.Enabled = true;
                        tNomUsuario.Enabled = true;
                        groupBox1.Enabled = true;
                        if (aux[0] == "Admin" && aux[2].Substring(0, aux[2].Length - 3) == "Admin" && tipo == '0')
                        {
                            bEliUsuario.Enabled = false;
                            tNomCompleto.Enabled = false;
                            tNomUsuario.Enabled = false;
                            groupBox1.Enabled = false;
                        }
                        break;
                    }
                }
                activarEventosTextChanged = true;
            }
            catch { }
        }
        //Cuando se cambia el nombre del docente, tambien debe 
        //cambiar el nombre de la carpeta, pues el programa usa 
        //el nombre para hallar la carpeta
        //Esta funcion se encarga de cambiar el nombre a dichas carpetas
        private void CambiarNombresCarpetas()
        {
            string path;
            foreach (string[] item in cambiosNombreCarpetas)
            {
                path = "datos\\" + item[0];
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                catch
                {

                }
                if (item[0] != item[1])
                {
                    Directory.Move(path, "datos\\" + item[1]);
                }
            }
        }

        //Eventos que se encargan de aplicar los cambios a la interfaz
        //y al arreglo que contiene toda la informacion
        //Estos cambios solo se guardaran cuando se haga clic en 
        //el boton modificar
        private void tNomCompleto_TextChanged(object sender, EventArgs e)
        {
            if (activarEventosTextChanged)
            {
                AplicarCambiosInterfaz();
                activarEventosTextChanged = true;
            }
        }

        private void tNomUsuario_TextChanged(object sender, EventArgs e)
        {
            if (activarEventosTextChanged)
            {
                AplicarCambiosInterfaz();
                activarEventosTextChanged = true;
            }
        }

        private void tContrasenia_TextChanged(object sender, EventArgs e)
        {
            if (activarEventosTextChanged)
            {
                AplicarCambiosInterfaz();
                activarEventosTextChanged = true;
            }
        }

        private void rbDocente_CheckedChanged(object sender, EventArgs e)
        {
            if (activarEventosTextChanged)
            {
                AplicarCambiosInterfaz();
                activarEventosTextChanged = true;
            }
        }

        private void rbCoordinador_CheckedChanged(object sender, EventArgs e)
        {
            if (activarEventosTextChanged)
            {
                AplicarCambiosInterfaz();
                activarEventosTextChanged = true;
            }
        }

        private void rbDocCor_CheckedChanged(object sender, EventArgs e)
        {
            if (activarEventosTextChanged)
            {
                AplicarCambiosInterfaz();
                activarEventosTextChanged = true;
            }
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (activarEventosTextChanged)
            {
                AplicarCambiosInterfaz();
                activarEventosTextChanged = true;
            }
        }

        //Este evento guarda todos los cambios y actualiza los arreglos y listas
        private void bModUsuario_Click(object sender, EventArgs e)
        {
            //Guardamos todos los cambios
            ManejoDeArchivos.GuardarArchivo("datos\\usuarios.txt", usuarios);
            ManejoDeArchivos.GuardarArchivo("datos\\docentes.txt", docentes);
            CambiarNombresCarpetas();

            //Actualizamos todos los arreglos y listas
            cambiosNombreCarpetas.Clear();
            lbUsuario.Items.Clear();
            ManejoDeArchivos.CrearArchivo("datos\\usuarios.txt");
            ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
            usuarios = File.ReadAllLines("datos\\usuarios.txt");
            docentes = File.ReadAllLines("datos\\docentes.txt");
            string[] aux;
            foreach (string usuario in usuarios)
            {
                if (usuario != "")
                {
                    aux = usuario.Split('░');
                    aux[2] = aux[2].Substring(0, aux[2].Length - 3); //Se encarga de eliminar el ';' de los nombres de usuario
                    lbUsuario.Items.Add(aux[0] + ": " + aux[2]);
                }
            }
            foreach (string docente in docentes)
            {
                cambiosNombreCarpetas.Add(new string[] { docente, docente });
            }
        }

        //Este evento se encarga de eliminar el usuario
        //Existe un message box que pide una confirmacion por motivos de seguridad
        private void bEliUsuario_Click(object sender, EventArgs e)
        {
            string usuarioSelec = tNomUsuario.Text;
            string[] aux;
            string[] resul;
            if (MessageBox.Show("¿Desea eliminar el usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                //Borramos el usuario del arreglo de usuarios, de docentes y de la lista de cambios por realizar a los nombres de carpetas
                for (int i = 0; i < usuarios.Length; i++)
                {
                    aux = usuarios[i].Split('░');
                    if (usuarioSelec == aux[0])
                    {
                        usuarioSelec = aux[2];
                        usuarios[i] = "";
                    }
                }
                for (int i = 0; i < docentes.Length; i++)
                {
                    if (usuarioSelec == docentes[i])
                    {
                        docentes[i] = "";
                    }
                }
                foreach (string[] item in cambiosNombreCarpetas.ToArray())
                {
                    if (usuarioSelec == item[1])
                    {
                        cambiosNombreCarpetas.Remove(item);
                    }
                }

                //Actualizamos la interfaz
                lbUsuario.Items.Clear();
                resul = BuscarEnArreglo(usuarios, tBuscar.Text);
                foreach (string linea in resul)
                {
                    if (linea != "")
                    {
                        aux = linea.Split('░');
                        aux[2] = aux[2].Substring(0, aux[2].Length - 3); //Se encarga de eliminar el ';' de los nombres de usuario
                        lbUsuario.Items.Add(aux[0] + ": " + aux[2]);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
