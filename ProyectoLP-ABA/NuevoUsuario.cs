using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace ProyectoLP_ABA
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void bIngUsuario_Click(object sender, EventArgs e)
        {
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
            string[] archivo; //Arreglo correspondiente a las lineas del archivo que se va a leer para buscar que no haya conflicto en los nombres de usuario
            bool continuar = true;
            bool guardar = true;
            string[] aux;

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

            ManejoDeArchivos.CrearArchivo("datos//usuarios.txt");
            archivo = File.ReadAllLines("datos//usuarios.txt");
            do
            {
                foreach (string linea in archivo)
                {
                    continuar = true;
                    aux = linea.Split('░');
                    if (aux[0].Equals(usuario))
                    {
                        MessageBox.Show("Nombre de usuario no disponible, por favor intente con otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        continuar = true;
                        guardar = false;
                        break;
                    }
                    if (aux[2].Equals(nombre))
                    {
                        nombre = nombre.Substring(0, nombre.Length - 3) + ";" + r.Next(0, 9) + "" + r.Next(10, 99) % 10;
                        continuar = false;
                        break;
                    }
                }
            } while (!continuar);

            if (guardar)
            {
                //Se procede a modificar el archivo con la informacion de los usuarios
                nuevaLinea = usuario + "░";
                nuevaLinea += StringCipher.Encrypt(contrasenia + tipo, nombre) + "░";
                nuevaLinea += nombre;
                ManejoDeArchivos.AniadirLineaArchivo("datos//usuarios.txt", nuevaLinea);
                //Se procede a modificar el archivo con la informacion de los nombres de los docentes
                if (tipo == 3 || tipo == 1)
                {
                    ManejoDeArchivos.AniadirLineaArchivo("datos//docentes.txt", nombre);
                }
            }
        }

        private void rbDocente_CheckedChanged(object sender, EventArgs e)
        {
            //Se genero por error no hace nada
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tNomCompleto.Clear();
            tNomUsuario.Clear();
            tContrasenia.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(tContrasenia.UseSystemPasswordChar==true)
            {
                tContrasenia.UseSystemPasswordChar = false;
            }
            else
                tContrasenia.UseSystemPasswordChar = true;

        }
    }


    public static class ManejoDeArchivos
    {

        //Crea el archivo solo si no existe un previo
        //Devuelve un true si se ha creado el archivo y false si el archivo ya existe
        public static bool CrearArchivo(string path)
        {
            bool bien = false;
            if (!File.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path.Substring(0, path.LastIndexOf("\\")));
                }
                catch { }

                try
                {
                    if (!path.EndsWith(".pdf"))
                    {
                        File.Create(path).Close();
                    }
                }
                catch { }
                bien = true;
            }
            return bien;
        }
        //Guarda un archivo de texto path con el string texto
        //Solo guarda el archivo si lo que se quiere guardar no es igual a lo que ya esta guardado
        //Devuelve true si se ha guardado, false si no
        public static bool GuardarArchivo(string path, string[] texto)
        {
            StreamWriter escribir;
            CrearArchivo(path);
            try
            {
                using (escribir = new StreamWriter(path, false, Encoding.Unicode))
                {
                    foreach (string linea in texto)
                    {
                        if(linea.Trim() != "")
                        {
                            escribir.WriteLine(linea);
                        }
                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Añade un string llamado linea a un archivo de texto path
        //Devuelve true si se ha guardado, false si no
        public static bool AniadirLineaArchivo(string path, string linea)
        {
            StreamWriter escribir;
            CrearArchivo(path);
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
    }

    //Magia de StackOverflow

    public static class StringCipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
