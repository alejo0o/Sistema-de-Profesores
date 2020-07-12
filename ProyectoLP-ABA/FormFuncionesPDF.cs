using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using draw = System.Drawing;
using System.IO;


namespace ProyectoLP_ABA
{
    public partial class FormFuncionesPDF : Form
    {
        Font fontEncabezado;
        Font fontTitulo;
        Font fontTexto;
        Font fontTituloTabla;
        Font fontTextoTabla;
        string[] docentes;
        string coordinador;
        public FormFuncionesPDF()
        {
            InitializeComponent();

            try
            {
                //Lee con que docente se va a trabajar
                ManejoDeArchivos.CrearArchivo("nombre.txt");
                coordinador = File.ReadAllLines("nombre.txt")[0];
                coordinador = coordinador.Substring(0, coordinador.LastIndexOf(';'));
                //Actulizamos la lista de fonts disponibles
                FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
                //Declaracion de fuentes
                fontEncabezado = FontFactory.GetFont("Cambria", 14, 1, BaseColor.BLACK);
                fontTitulo = FontFactory.GetFont("Cambria", 11, 1, BaseColor.BLACK);
                fontTexto = FontFactory.GetFont("Cambria", 11, 0, BaseColor.BLACK);
                fontTituloTabla = FontFactory.GetFont("Cambria", 9, 1, BaseColor.BLACK);
                fontTextoTabla = FontFactory.GetFont("Cambria", 9, 0, BaseColor.BLACK);
                //Leemos los docentes
                ManejoDeArchivos.CrearArchivo("datos\\docentes.txt");
                docentes = File.ReadAllLines("datos\\docentes.txt");
                //Cargamos el año actual en el numericUpDown correspondiente al año
                nudAnio.Value = Convert.ToDecimal(DateTime.Now.Year);
                //Cargamos los periodos
                cbPeriodo.SelectedIndex = 0;
            }
            catch { }

            

        }
        #region funciones varias y eventos
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

        //Evento que activa la funcion crear pdf
        private void bCrear_Click(object sender, EventArgs e)
        {
            //Aqui se va a leer el path seleccionado por el usuario
            string semestre = nudAnio.Value.ToString() + "-" + cbPeriodo.SelectedItem.ToString();
            string path = "Reporte.pdf";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                path += "\\Reporte de " + tArea.Text + " " + semestre + ".pdf";
                //Ahora que ya todo esta listo, enviamos los valores a la funcion CrearPDF
                CrearPDF(semestre, coordinador, tArea.Text, path, cbVerTodo.Checked,
                Convert.ToSingle(nudIzq.Value), Convert.ToSingle(nudDer.Value), 
                Convert.ToSingle(nudArriba.Value), Convert.ToSingle(nudAbajo.Value),
                Convert.ToSingle(nudInterlineado.Value));
            }
            
        }
        #endregion
        //Funcion que crea el pdf
        //Como argumentos recibe:
        //string semestre: string correspondiente al semestre al que pertenece el informe
        //string coordinador: string del nombre de coordinador
        //string areAcademica: string del nombre del area academica
        //string path: string de la ubicacion en la cual se va a almacenar el reporte
        //bool verDocentesSinDatos: bool que indicara si imprimir o no los docentes que no poseen ningun dato al 
        //respecto de una determinada tabla
        //float izq: float correpondiente a la anchura del margen izquierdo
        //float der: float correpondiente a la anchura del margen derecho
        //float arriba: float correpondiente a la anchura del margen de arriba
        //float abajo: float correpondiente a la anchura del margen de abajo
        //float interlineado: float que indica el espacio entre lineas de texto
        private void CrearPDF(string semestre, string coordinador, string areaAcademica, string path, bool verDocentesSinDatos = false,
                              float izq = 80, float der = 80, float arriba = 80, float abajo = 80, float interlineado = 30)
        {
            Document doc = new Document(PageSize.A4, izq, der, arriba, abajo);

            //Phrase para utilizar en los parrafos con fuentes mixtas
            Phrase phrase = new Phrase();
            Paragraph paragraph = new Paragraph();
            PdfPTable tabla;

            try
            {
                using (PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create)))
                {
                    // Le colocamos el título y el autor
                    // **Nota: Esto no será visible en el documento
                    doc.AddTitle("Reporte del Semetre " + semestre);
                    doc.AddCreator(coordinador);
                    doc.Open();

                    //Encabezado
                    paragraph = new Paragraph("INFORME DEL COORDINADOR DE ÁREA ACADEMICA", fontEncabezado);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    doc.Add(paragraph);
                    paragraph = new Paragraph("SEMESTRE " + semestre, fontEncabezado);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    doc.Add(paragraph);

                    //En las tablas 10, 12, 14 y 16 no se muestran los docentes, aunque la opcion siempre esta ahi para cambiarla


                    //1.- Area Academica
                    phrase.Clear();
                    phrase.Add(new Chunk("1. ÁREA ACADEMICA: ", fontTitulo));
                    phrase.Add(new Chunk(areaAcademica, fontTexto));
                    phrase.SetLeading(interlineado, 0);
                    doc.Add(new Paragraph(phrase));
                    phrase.Clear();
                    phrase.Add(new Chunk("     COORDINADOR: ", fontTitulo));
                    phrase.Add(new Chunk(coordinador, fontTexto));
                    phrase.SetLeading(interlineado, 0);
                    doc.Add(new Paragraph(phrase));

                    //2.- Integrantes del area
                    paragraph = new Paragraph("2. INTEGRANTES DEL ÁREA: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla2(docentes, verDocentesSinDatos));

                    //3 Asistencia a Reuniones de Area
                    paragraph = new Paragraph("3. ASISTENCIA A REUNIONES DE ÁREA: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla3(docentes));

                    //4.- Integrantes del area
                    paragraph = new Paragraph("4. SEGUIMIENTO DE INGRESO Y APROBACIÓN DE PROGRAMAS MICROCURRICULARES", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla4(docentes, verDocentesSinDatos));

                    //5.- Seguimiento al Silabo
                    paragraph = new Paragraph("5. SEGUIMIENTO AL SÍLABO: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla5(docentes));
                    
                    //6.- Sistema de evaluacion aplicado en las asignaturas
                    paragraph = new Paragraph("6. SISTEMA DE EVALUACIÓN APLICADO EN LAS ASIGNATURAS", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla6(docentes, verDocentesSinDatos));

                    //7.- Presentacion de Cuestionarios de Examenes a Coordinacion de Area
                    paragraph = new Paragraph("7.PRESENTACIÓN DE CUESTIONARIOS DE EXAMENES A COORDINACIÓN DE ÁREA: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla7(docentes));

                    //8.-Estadiscticas de la asignatura
                    paragraph = new Paragraph("8. ESTADÍSTICA DE LA ASIGNATURA", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    tabla = CrearTabla8(docentes, verDocentesSinDatos);
                    tabla.WidthPercentage = 100;
                    doc.Add(tabla);

                    //9.- Desarrollodel Silabo
                    paragraph = new Paragraph("9. DESARROLLO DEL SÍLABO: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla9(docentes));

                    //10.- Proyectos de investigacion en los que participado en el semestre
                    paragraph = new Paragraph("10. PROYECTOS DE INVESTIGACIÓN EN LOS QUE HA PARTICIPADO EN EL SEMESTRE", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    tabla = CrearTabla10(docentes, false);
                    tabla.WidthPercentage = 100;
                    doc.Add(tabla);

                    //11.- Actualizacion Cientifica
                    phrase.Clear();
                    paragraph = new Paragraph("11.ACTUALIZACIÓN CIENTÍFICA: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla11(docentes));
                    phrase.Add(" ");
                    phrase.SetLeading(interlineado, 0);
                    doc.Add(new Paragraph(phrase));
                    phrase.Clear();
                    doc.Add(CrearTabla11_Parte2(docentes));

                    //12.- Docentes que cursan programas de maestria o doctorado
                    paragraph = new Paragraph("12. DOCENTES QUE CURSAN PROGRAMAS DE MAESTRÍA O DOCTORADO", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla12(docentes, false));

                    //13.- REQUERIMIENTO DE PERFECCIONAMIENTO DOCENTE
                    //aqui se generan dos tablas
                    phrase.Clear();
                    paragraph = new Paragraph("13.REQUERIMIENTO DE PERFECCIONAMIENTO DOCENTE: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla13(docentes));
                    phrase.Add(" ");
                    phrase.SetLeading(interlineado, 0);
                    doc.Add(new Paragraph(phrase));
                    phrase.Clear();
                    doc.Add(CrearTabla13Adjuntos(docentes));

                    //14.- Produccion cientifica
                    paragraph = new Paragraph("14. PRODUCCIÓN CIENTÍFICA", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    tabla = CrearTabla14(docentes, false);
                    tabla.WidthPercentage = 100;
                    doc.Add(tabla);

                    //15.-LIBROS Y CAPÍTULOS DE LIBROS PUBLICADOS EN LOS ÚLTIMOS CUATRO AÑOS:
                    phrase.Clear();
                    paragraph = new Paragraph("15.LIBROS Y CAPÍTULOS DE LIBROS PUBLICADOS EN LOS ÚLTIMOS CUATRO AÑOS: ", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    doc.Add(CrearTabla15(docentes));

                    //16.- Necesidades Bibliograficas
                    paragraph = new Paragraph("16. NECESIDADES BIBLIOGRAFICAS", fontTitulo);
                    paragraph.SetLeading(interlineado, 0);
                    doc.Add(paragraph);
                    paragraph = new Paragraph(" ", fontTitulo);
                    paragraph.SetLeading(interlineado / 2, 0);
                    doc.Add(paragraph);
                    tabla = CrearTabla16(docentes, false);
                    tabla.WidthPercentage = 100;
                    doc.Add(tabla);

                    //Cerramos los archivos
                    doc.Close();
                    writer.Close();

                }
            }
            catch
            {
                MessageBox.Show("El archivo que usted desea guardar ya existe y se encuentra abierto. Por favor cierrelo e intente de vuelta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #region tablas pares
        private PdfPTable CrearTabla2(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] cursos, aux;
            PdfPTable tabla = new PdfPTable(4);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nivel", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Paralelo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Paralelos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Paralelos.txt");
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        p = new Phrase(aux[i], fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && verDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }

        private PdfPTable CrearTabla4(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] cursos, aux;
            string archivo;
            PdfPTable tabla = new PdfPTable(5);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nivel", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Paralelo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Ingreso (Si/No)", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Paralelos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Paralelos.txt");
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        p = new Phrase(aux[i], fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);

                    archivo = string.Join(";", aux);
                    archivo += ";Aprobado.pdf";
                    if (File.Exists("datos\\" + docente + "\\Seguimiento programas microcurriculares\\" + archivo))
                    {
                        p = new Phrase("Si", fontTextoTabla);
                    }
                    else
                    {
                        p = new Phrase("No", fontTextoTabla);
                    }
                    tabla.AddCell(p);
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && verDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }

        private PdfPTable CrearTabla6(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] cursos, aux;
            PdfPTable tabla = new PdfPTable(4);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nivel", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Paralelo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Evaluación de la asignatura", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\Sistema de evaluacion.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\Sistema de evaluacion.txt");
                cursos = UnirLineasArr(cursos);
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        p = new Phrase(aux[i], fontTextoTabla);
                        tabla.AddCell(p);
                    }
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && verDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }

        private PdfPTable CrearTabla8(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] cursos, aux;
            float porcentaje;
            PdfPTable tabla = new PdfPTable(13);
            Phrase p;
            PdfPCell c;

            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 2;
            c.Rowspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Nivel", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Paralelo", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Matriculados", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Aprobados", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Reprobados", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Retirados", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Media", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Desviación Estándar", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 2;
            tabla.AddCell(c);

            p = new Phrase("Cant.", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Porc.", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Cant.", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Porc.", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Cant.", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Porc.", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\Estadisticas de asignatura.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\Estadisticas de asignatura.txt");
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        //Este if se encarga de darle mas espacio a la columna de asignatura
                        if (i == 0)
                        {
                            p = new Phrase(aux[i], fontTextoTabla);
                            c = new PdfPCell(p);
                            c.Colspan = 2;
                            tabla.AddCell(c);
                        }
                        else
                        {
                            p = new Phrase(aux[i], fontTextoTabla);
                            tabla.AddCell(p);
                        }

                        //Esto se encarga de añadir porcentajes en las filas necesarias
                        //Porcentajde de aprobados, retirados y reprobados
                        if (i == 4 || i == 5 || i == 6)
                        {
                            try
                            {
                                porcentaje = (Convert.ToSingle(aux[i]) / Convert.ToSingle(aux[3]) * 100);
                                p = new Phrase(Math.Round(porcentaje, 1) + "%", fontTextoTabla);
                                tabla.AddCell(p);
                            }
                            catch { }
                        }

                    }
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && verDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 2;
                    tabla.AddCell(c);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }

        private PdfPTable CrearTabla10(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] registros, aux;
            PdfPTable tabla = new PdfPTable(17);
            Phrase p;
            PdfPCell c;

            //Añadimos los encabezados
            p = new Phrase("Docente", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 3;
            c.Colspan = 3;
            tabla.AddCell(c);
            p = new Phrase("Titulo del proyecto de investigación", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 3;
            c.Colspan = 3;
            tabla.AddCell(c);
            p = new Phrase("Institución auspiciante", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 3;
            c.Colspan = 3;
            tabla.AddCell(c);
            p = new Phrase("Participación como (Director / Investigador)", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 3;
            c.Colspan = 3;
            tabla.AddCell(c);
            p = new Phrase("Fondos", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 5;
            tabla.AddCell(c);
            p = new Phrase("PUCE", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 2;
            tabla.AddCell(c);
            p = new Phrase("Otros (detallar)", fontTituloTabla);
            c = new PdfPCell(p);
            c.Rowspan = 2;
            c.Colspan = 3;
            tabla.AddCell(c);
            p = new Phrase("Si", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("No", fontTituloTabla);
            tabla.AddCell(p);
            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Proyectos de investigación.txt");
                registros = File.ReadAllLines("datos\\" + docente + "\\" + "Proyectos de investigación.txt");
                foreach (string registro in registros)
                {
                    aux = registro.Split('░');

                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    for (int i = 0; i < aux.Length; i++)
                    {
                        if (i == 3)
                        {
                            if (aux[3] == "Si")
                            {
                                p = new Phrase("x", fontTextoTabla);
                                tabla.AddCell(p);
                                p = new Phrase("", fontTextoTabla);
                                tabla.AddCell(p);
                            }
                            else
                            {
                                p = new Phrase("", fontTextoTabla);
                                tabla.AddCell(p);
                                p = new Phrase("x", fontTextoTabla);
                                tabla.AddCell(p);

                            }
                        }
                        else if (i == 5)
                        {
                            //Este registro es solo el nombre del archivo, eso no va en la tabla, asi que por eso esta vacio
                        }
                        else
                        {
                            p = new Phrase(aux[i], fontTextoTabla);
                            c = new PdfPCell(p);
                            c.Colspan = 3;
                            tabla.AddCell(c);
                        }
                    }
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (registros.Length == 0 && verDocentesSinDatos)
                {

                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    p = new Phrase("", fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    p = new Phrase("", fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    p = new Phrase("", fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                }
            }

            return tabla;
        }

        private PdfPTable CrearTabla12(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] registros, aux;
            PdfPTable tabla = new PdfPTable(8);
            Phrase p;
            PdfPCell c;
            int maestrias = 0, doctorados = 0;

            //Añadimos los encabezados
            p = new Phrase("Docente", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 3;
            tabla.AddCell(c);
            p = new Phrase("Asignatura", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 3;
            tabla.AddCell(c);
            p = new Phrase("Maestría (Si/No)", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Doctorado (Si/No)", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Maestria y doctorados en curso.txt");
                registros = File.ReadAllLines("datos\\" + docente + "\\" + "Maestria y doctorados en curso.txt");
                foreach (string registro in registros)
                {
                    aux = registro.Split('░');
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTituloTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    for (int i = 0; i < aux.Length; i++)
                    {
                        if (i == 0)
                        {
                            p = new Phrase(aux[i], fontTituloTabla);
                            c = new PdfPCell(p);
                            c.Colspan = 3;
                            tabla.AddCell(c);
                        }
                        else
                        {
                            p = new Phrase(aux[i], fontTextoTabla);
                            tabla.AddCell(p);
                        }
                    }
                    //Contador del numero de maestrias y doctorados
                    if (aux[1] == "Si")
                    {
                        maestrias++;
                    }
                    if (aux[2] == "Si")
                    {
                        doctorados++;
                    }
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (registros.Length == 0 && verDocentesSinDatos)
                {
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    p = new Phrase("", fontTextoTabla);
                    c = new PdfPCell(p);
                    c.Colspan = 3;
                    tabla.AddCell(c);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            //Añadimos los totales de maestrias y doctorados
            p = new Phrase("Total", fontTituloTabla);
            c = new PdfPCell(p);
            c.Colspan = 6;
            tabla.AddCell(c);
            p = new Phrase(maestrias + "", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase(doctorados + "", fontTituloTabla);
            tabla.AddCell(p);

            return tabla;
        }

        private PdfPTable CrearTabla14(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] registros, aux;
            PdfPTable tabla = new PdfPTable(8);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Artículo Científico", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nombre del artículo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Fechas", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("DOI del artículos y/o dirección web", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Indexado a:", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("ISSN de la revista", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nombre de la revista y volumen", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Producción científica.txt");
                registros = File.ReadAllLines("datos\\" + docente + "\\" + "Producción científica.txt");
                foreach (string registro in registros)
                {
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    aux = registro.Split('░');
                    for (int i = 0; i < aux.Length - 2; i++)
                    {
                        p = new Phrase(aux[i], fontTextoTabla);
                        tabla.AddCell(p);
                    }
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (registros.Length == 0 && verDocentesSinDatos)
                {
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }

        private PdfPTable CrearTabla16(string[] docentes, bool verDocentesSinDatos = false)
        {
            string[] cursos, aux;
            PdfPTable tabla = new PdfPTable(8);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nombre del libro", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Autor/es", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Editorial", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Edicion", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Año", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("ISBN", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Necesidades Bibliograficas.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Necesidades Bibliograficas.txt");
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        p = new Phrase(aux[i], fontTextoTabla);
                        tabla.AddCell(p);
                        if (i == 0)
                        {
                            p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                            tabla.AddCell(p);
                        }
                    }
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && verDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }
        #endregion
        #region tablas impares
        private PdfPTable CrearTabla3(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] info, aux;
            string path = "datos\\Asistencia a Reuniones de Area.txt";
            PdfPTable tabla = new PdfPTable(4);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("1ra. Reunion (Fecha)", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("2da. Reunion (Fecha)", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("3ra. Reunion (Fecha)", fontTituloTabla);
            tabla.AddCell(p);
            ManejoDeArchivos.CrearArchivo(path);
            info = File.ReadAllLines(path);

            //Añadimos la informacion
            foreach (var item in info)
            {
                aux = item.Split('░');
                for (int i = 0; i < aux.Length; i++)
                {
                    p = new Phrase(aux[i], fontTextoTabla);
                    tabla.AddCell(p);
                }
            }
            //Esto imprime o no los docentes que no poseen datos en sus archivos
            if (info.Length == 0 && imprimirDocentesSinDatos)
            {
                p = new Phrase("", fontTextoTabla);
                tabla.AddCell(p);
                p = new Phrase("", fontTextoTabla);
                tabla.AddCell(p);
                p = new Phrase("", fontTextoTabla);
                tabla.AddCell(p);
                p = new Phrase("", fontTextoTabla);
                tabla.AddCell(p);
            }

            return tabla;
        }
        private PdfPTable CrearTabla5(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] cursos, aux;
            string camino1, camino2, camino3;
            PdfPTable tabla = new PdfPTable(7);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nivel", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Paralelo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Seguimiento I Bimestre", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Seguimiento II Bimestre", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Seguimiento III Bimestre", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (var docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\Paralelos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\Paralelos.txt");
                foreach (var curso in cursos)
                {
                    aux = curso.Split('░');
                    camino1 = "datos\\" + docente + "\\Seguimiento al Silabo\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ";1";
                    camino2 = "datos\\" + docente + "\\Seguimiento al Silabo\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ";2";
                    camino3 = "datos\\" + docente + "\\Seguimiento al Silabo\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ";3";

                    p = new Phrase(aux[0], fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(aux[1], fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(aux[2], fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    if (File.Exists(camino1 + ";Aprobado.pdf"))
                    {
                        p = new Phrase("Aprobado", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    else
                    {
                        p = new Phrase("Sin Aprobar", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    if (File.Exists(camino2 + ";Aprobado.pdf"))
                    {
                        p = new Phrase("Aprobado", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    else
                    {
                        p = new Phrase("Sin Aprobar", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    if (File.Exists(camino3 + ";Aprobado.pdf"))
                    {
                        p = new Phrase("Aprobado", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    else
                    {
                        p = new Phrase("Sin Aprobar", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                }
            }

            return tabla;
        }
        private PdfPTable CrearTabla7(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] cursos, aux;
            string aux2;
            string camino1, camino2, camino3, camino_observacion;
            PdfPTable tabla = new PdfPTable(8);
            Phrase p;
            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nivel", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Paralelo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Examen y Rubrica 1er Bimestre", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Examen y Rubrica 2do Bimestre", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Examen y Rubrica 3er Bimestre", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Observaciones", fontTituloTabla);
            tabla.AddCell(p);


            //Añadimos la info
            foreach (var docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\Paralelos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\Paralelos.txt");
                foreach (var curso in cursos)
                {
                    aux = curso.Split('░');
                    camino1 = "datos\\" + docente + "\\Presentacion de cuestionarios de examenes a coordinadores de area\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ";1";
                    camino2 = "datos\\" + docente + "\\Presentacion de cuestionarios de examenes a coordinadores de area\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ";2";
                    camino3 = "datos\\" + docente + "\\Presentacion de cuestionarios de examenes a coordinadores de area\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ";3";
                    camino_observacion = "datos\\" + docente + "\\Presentacion de cuestionarios de examenes a coordinadores de area\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ".txt";
                    p = new Phrase(aux[0], fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(aux[1], fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(aux[2], fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    if (File.Exists(camino1 + ";Aprobado.pdf"))
                    {
                        p = new Phrase("Aprobado", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    else
                    {
                        p = new Phrase("Sin Aprobar", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    if (File.Exists(camino2 + ";Aprobado.pdf"))
                    {
                        p = new Phrase("Aprobado", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    else
                    {
                        p = new Phrase("Sin Aprobar", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    if (File.Exists(camino3 + ";Aprobado.pdf"))
                    {
                        p = new Phrase("Aprobado", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    else
                    {
                        p = new Phrase("Sin Aprobar", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    if (File.Exists(camino_observacion))
                    {
                        ManejoDeArchivos.CrearArchivo(camino_observacion);
                        aux2 = File.ReadAllText(camino_observacion);
                        p = new Phrase(aux2, fontTextoTabla);
                        tabla.AddCell(p);
                    }
                    else
                    {
                        p = new Phrase(" ", fontTextoTabla);
                        tabla.AddCell(p);
                    }
                }
            }

            return tabla;
        }
        private PdfPTable CrearTabla9(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] cursos, aux, aux2, aux3;
            string camino, cadaux = "";
            PdfPTable tabla = new PdfPTable(5);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nivel", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Paralelo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Porcentaje de Desarrollo del Silabo", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Temas no Tratados", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Paralelos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Paralelos.txt");
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    camino = "datos\\" + docente + "\\" + "Desarrollo del Sílabo\\" + aux[0] + ";" + aux[1] + ";" + aux[2] + ".txt";
                    if (File.Exists(camino))
                    {

                        p = new Phrase(aux[0], fontTextoTabla);
                        tabla.AddCell(p);
                        p = new Phrase(aux[1], fontTextoTabla);
                        tabla.AddCell(p);
                        p = new Phrase(aux[2], fontTextoTabla);
                        tabla.AddCell(p);
                        ManejoDeArchivos.CrearArchivo(camino);
                        aux2 = File.ReadAllLines(camino);
                        
                        if (aux2.Length != 0)
                        {
                            aux2 = aux2[0].Split('░');
                            cadaux = "";
                            p = new Phrase(aux2[0], fontTextoTabla);
                            tabla.AddCell(p);
                            for (int i = 1; i < aux2.Length; i++)
                            {
                                    cadaux += aux2[i] + "\n";
                            }
                            p = new Phrase(cadaux, fontTextoTabla);
                            tabla.AddCell(p);
                            cadaux = "";
                        }
                        else
                        {
                            p = new Phrase("", fontTextoTabla);
                            tabla.AddCell(p);
                            p = new Phrase("", fontTextoTabla);
                            tabla.AddCell(p);
                        }
                    }
                    else
                    {
                        
                        p = new Phrase(aux[0], fontTextoTabla);
                        tabla.AddCell(p);
                        p = new Phrase(aux[1], fontTextoTabla);
                        tabla.AddCell(p);
                        p = new Phrase(aux[2], fontTextoTabla);
                        tabla.AddCell(p);
                        p = new Phrase("", fontTextoTabla);
                        tabla.AddCell(p);
                        p = new Phrase("", fontTextoTabla);
                        tabla.AddCell(p);

                    }

                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && imprimirDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }
        private PdfPTable CrearTabla11(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] cursos, aux;
            PdfPTable tabla = new PdfPTable(5);
            Phrase p;
            //Añadimos los encabezados
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("¿Ha Participado en Eventos Afín al Área? ", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Tipo de Evento", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Participación", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (var docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Actualizacion Cientifica\\Datos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Actualizacion Cientifica\\Datos.txt");
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    for (int i = 0; i < aux.Length; i++)
                    {
                        if (aux[i].ToString() == "True")
                        {
                            p = new Phrase("Si", fontTextoTabla);
                            tabla.AddCell(p);
                        }
                        else if (aux[i].ToString() == "False")
                        {
                            p = new Phrase("No", fontTextoTabla);
                            tabla.AddCell(p);
                            p = new Phrase("", fontTextoTabla);
                            tabla.AddCell(p);
                            p = new Phrase("", fontTextoTabla);
                            tabla.AddCell(p);
                        }
                        else
                        {
                            p = new Phrase(aux[i], fontTextoTabla);
                            tabla.AddCell(p);
                        }
                    }


                }
                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && imprimirDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                }

            }

            return tabla;
        }
        private PdfPTable CrearTabla11_Parte2(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string aux;
            string[] arreglo;
            int curso = 0, congreso = 0, coloquio = 0, seminario = 0, ponencia = 0;
            string path2;
            PdfPTable tabla = new PdfPTable(2);
            Phrase p;
            //Añadimos los encabezados
            p = new Phrase("Tipo de Evento", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Total", fontTituloTabla);
            tabla.AddCell(p);


            //Añadimos la info
            foreach (var docente in docentes)
            {
                path2 = "datos\\" + docente + "\\Actualizacion Cientifica\\" + "Tabla2.txt";
                ManejoDeArchivos.CrearArchivo(path2);
               
                aux = File.ReadAllText(path2);
                if (aux.Length > 3)
                {


                    arreglo = aux.Split('░');

                    curso += Convert.ToInt32(arreglo[0]);
                    congreso += Convert.ToInt32(arreglo[1]);
                    coloquio += Convert.ToInt32(arreglo[2]);
                    seminario += Convert.ToInt32(arreglo[3]);
                    ponencia += Convert.ToInt32(arreglo[4]);
                }
            }
            p = new Phrase("Curso", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase(curso.ToString(), fontTextoTabla);
            tabla.AddCell(p);
            p = new Phrase("Congreso", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase(congreso.ToString(), fontTextoTabla);
            tabla.AddCell(p);
            p = new Phrase("Coloquio", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase(coloquio.ToString(), fontTextoTabla);
            tabla.AddCell(p);
            p = new Phrase("Seminario", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase(seminario.ToString(), fontTextoTabla);
            tabla.AddCell(p);
            p = new Phrase("Ponencia", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase(ponencia.ToString(), fontTextoTabla);
            tabla.AddCell(p);

            return tabla;
        }
        private PdfPTable CrearTabla13(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] cursos, aux;
            PdfPTable tabla = new PdfPTable(5);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Asignatura", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Curso/Nombre del Evento", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Insitución Organizadora del Evento", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Profesional o Perfeccionamiento Docente", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Requerimiento de perfeccionamiento docente\\Datos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Requerimiento de perfeccionamiento docente\\Datos.txt");

                foreach (string curso in cursos)
                {
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        p = new Phrase(aux[i], fontTextoTabla);
                        tabla.AddCell(p);
                    }

                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && imprimirDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                }
            }

            return tabla;
        }
        private PdfPTable CrearTabla13Adjuntos(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] cursos, aux;
            PdfPTable tabla = new PdfPTable(7);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Maestría o Doctorado", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Lugar (Pais/Ciudad)", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Fecha de Inicio", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Fecha de Fin", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Institución Superior", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Profesional o Investigación", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Título a Obtener", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Requerimiento de perfeccionamiento docente\\Adjuntos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Requerimiento de perfeccionamiento docente\\Adjuntos.txt");
                foreach (string curso in cursos)
                {
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        p = new Phrase(aux[i], fontTextoTabla);
                        tabla.AddCell(p);
                    }

                }
                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && imprimirDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);

                }
            }

            return tabla;
        }
        private PdfPTable CrearTabla15(string[] docentes, bool imprimirDocentesSinDatos = false)
        {
            string[] cursos, aux;
            PdfPTable tabla = new PdfPTable(8);
            Phrase p;

            //Añadimos los encabezados
            p = new Phrase("Docente", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Autor o Coautor", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nombre del Libro", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Fecha de Publicación", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("ISBN del Libro", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Nombre de la Editorial", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Volumen, Número, Paginas del Libro", fontTituloTabla);
            tabla.AddCell(p);
            p = new Phrase("Revisión por Pares", fontTituloTabla);
            tabla.AddCell(p);

            //Añadimos la info
            foreach (string docente in docentes)
            {
                ManejoDeArchivos.CrearArchivo("datos\\" + docente + "\\" + "Libros y capitulos de libros publicados en los ultimos 4 años\\Datos.txt");
                cursos = File.ReadAllLines("datos\\" + docente + "\\" + "Libros y capitulos de libros publicados en los ultimos 4 años\\Datos.txt");

                foreach (string curso in cursos)
                {
                    p = new Phrase(docente.Substring(0, docente.LastIndexOf(';')), fontTextoTabla);
                    tabla.AddCell(p);
                    aux = curso.Split('░');
                    for (int i = 0; i < aux.Length; i++)
                    {
                        if (aux[i].ToString() == "True")
                        {
                            p = new Phrase("Si", fontTextoTabla);
                            tabla.AddCell(p);
                        }
                        else if (aux[i].ToString() == "False")
                        {
                            p = new Phrase("No", fontTextoTabla);
                            tabla.AddCell(p);
                        }
                        else
                        {
                            p = new Phrase(aux[i], fontTextoTabla);
                            tabla.AddCell(p);
                        }
                    }
                }

                //Esto imprime o no los docentes que no poseen datos en sus archivos
                if (cursos.Length == 0 && imprimirDocentesSinDatos)
                {
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);
                    p = new Phrase("", fontTextoTabla);
                    tabla.AddCell(p);

                }
            }

            return tabla;
        }
        #endregion

        private void cerrarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
