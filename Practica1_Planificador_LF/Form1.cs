using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Practica1_Planificador_LF.controladores;
//Material Design
using MaterialSkin;
using MaterialSkin.Controls;


namespace Practica1_Planificador_LF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Analizar_Click(object sender, EventArgs e)
        {
            analizador(textAnalizar.Text); //Manda a llamar al metodo analizar cadena que se encarga de separar las instrucciones del textArea
            //TokenController.getInstancia().generarLista();
            TokenController.getInstancia().generarListaError();

        }


        /*MENU BAR*/

        /*Nueva pestaña*/
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /*Abrir archivo*/
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo.Text = buscar.FileName;

            }

            if (File.Exists(rutaArchivo.Text))  //verifica si el archivo existe
            {

                StreamReader leer = new StreamReader(rutaArchivo.Text); //Carga el archivo

                string linea;

                try
                {
                    linea = leer.ReadLine();
                    while (linea != null)
                    {
                        textAnalizar.AppendText(linea + "\n"); //lee la linea y la inserta en el textAarea hasta que se sea nula
                        linea = leer.ReadLine();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado la ruta o archivo", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        //Analizador lexico
        public async void analizador(String totalTexto)
        {
            int opcion = 0;
            string auxiliar = "";
            totalTexto = totalTexto + " ";

            char[] charsRead = new char[totalTexto.Length]; 
            using (StringReader reader = new StringReader(totalTexto))
            {
                await reader.ReadAsync(charsRead, 0, totalTexto.Length);
            }

            StringBuilder reformattedText = new StringBuilder();
            using (StringWriter writer = new StringWriter(reformattedText))
            {
                for(int i = 0; i < charsRead.Length; i++)
                {
                    Char c = totalTexto[i];

                    switch (opcion)
                    {
                        case 0:
                            //VERIFICA SI LO QUE VIENE ES LETRA
                            if (char.IsLetter(c))
                            {
                                opcion = 1;
                                auxiliar += c;
                            }
                            //VERIFICA SI LO QUE VIENE ES DIGITO
                            else if (char.IsDigit(c))
                            {
                                opcion = 2;
                                auxiliar += c;
                            }
                            //VERIFICA SI LO QUE VIENE ES SIGNO DE PUNTUACION
                            else if (char.IsPunctuation(c))
                            {
                                Console.WriteLine("esta entrando a puntuacion");

                                if (c.Equals('"'))
                                {
                                    opcion = 4;
                                    i--;
                                }
                                else if (c.Equals(','))
                                {
                                    opcion = 6;
                                    i--;
                                }
                                else if (c.Equals('{'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Llave derecha");

                                }
                                else if (c.Equals('}'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Llave Derecha");
                                }
                                else if (c.Equals('('))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Parentesis Derecho");
                                }
                                else if (c.Equals(')'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Parentesis Derecho");
                                }
                                else if (c.Equals(','))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Coma");
                                }
                                else if (c.Equals(';'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Punto y Coma");
                                }
                                else if (c.Equals(':'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Dos puntos");
                                }
                                else if (c.Equals('.'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Punto");

                                }
                                else if (c.Equals('['))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Corchete Derecho");
                                }
                                else if (c.Equals(']'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Corchete Izquierdo");
                                }
                                else
                                {
                                    Console.WriteLine("esta entrando al ultimo else");
                                    TokenController.getInstancia().error(c.ToString(), "Desconocido");
                                    opcion = 10;
                                    i--;
                                }

                            }
                            //VERIFICA SI LO QUE VIENE ES SIMBOLO
                            else if (char.IsSymbol(c))
                            {
                                Console.WriteLine("esta entrando a simbolos");
                                if (c.Equals('<'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Menor que");
                                }
                                else if (c.Equals('>'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Mayor que");
                                }
                                else
                                {
                                    Console.WriteLine("esta entrando al ultimo else");
                                    TokenController.getInstancia().error(c.ToString(), "Desconocido");
                                    opcion = 10;
                                    i--;
                                }
                            }
                            //VERIFICA SI ES ESPACIO EN BLANCO O SALTO DE LINEA
                            else if (char.IsWhiteSpace(c) || c.Equals('\n'))
                            {
                                opcion = 0;
                            }
                            //LO MANDA A SIGNOS DESCONOCIDOS
                            else
                            {
                                Console.WriteLine("esta entrando al ultimo else");
                                TokenController.getInstancia().error(c.ToString(), "Desconocido");
                                opcion = 10;
                                i--;
                            }
                            break;
                        case 1:
                            if (Char.IsLetterOrDigit(c) || c == '_')
                            {
                                auxiliar += c;
                                opcion = 1;
                            }
                            else
                            {
                                if (auxiliar.ToLower().Equals("planificador") || auxiliar.ToLower().Equals("mes")
                                        || auxiliar.ToLower().Equals("año") || auxiliar.ToLower().Equals("dia"))
                                {
                                    TokenController.getInstancia().agregar(auxiliar, "Palabra Reservada");
                                }
                                else
                                {
                                    TokenController.getInstancia().agregar(auxiliar, "Identificador");
                                }

                                auxiliar = "";
                                i--;

                                opcion = 0;
                            }
                            break;
                        case 2:
                            if (Char.IsDigit(c))
                            {
                                auxiliar += c;
                                opcion = 2;
                            }
                            else if (c == '.')
                            {
                                opcion = 8;
                                auxiliar += c;
                            }
                            else
                            {
                                TokenController.getInstancia().agregar(auxiliar, "Digito");
                                auxiliar = "";
                                i--;
                                opcion = 0;
                            }
                            break;
                        case 3:
                            if (Char.IsDigit(c))
                            {
                                auxiliar += c;
                                opcion = 2;
                            }
                            else
                            {
                                opcion = 10;
                                i = i - 2;
                                auxiliar = "";
                            }
                            break;
                        case 4:
                            if (c == '"')
                            {
                                auxiliar += c;
                                opcion = 5;
                            }
                            break;
                        case 5:
                            if (c != '"')
                            {
                                auxiliar += c;
                                opcion = 5;
                            }
                            else
                            {
                                opcion = 6;
                                i--;

                            }
                            break;
                        case 6:
                            if (c == '"')
                            {
                                auxiliar += c;
                                TokenController.getInstancia().agregar(auxiliar, "Cadena");
                                opcion = 0;
                                auxiliar = "";
                            }
                            else if (c == ',')
                            {
                                auxiliar += c;
                                TokenController.getInstancia().agregar(auxiliar, "Coma");
                                opcion = 0;
                                auxiliar = "";
                            }
                            break;
                        case 8:
                            if (char.IsDigit(c))
                            {
                                opcion = 9;
                                auxiliar += c;
                            }
                            else
                            {
                                opcion = 0;
                                auxiliar = "";
                            }
                            break;
                        case 9:
                            if (Char.IsDigit(c))
                            {
                                opcion = 9;
                                auxiliar += c;
                            }
                            else
                            {
                                TokenController.getInstancia().agregar(auxiliar, "Digito");
                                auxiliar = "";
                                i--;

                                opcion = 0;
                            }

                            break;
                        case 10:
                            auxiliar += c;
                            TokenController.getInstancia().error(auxiliar, "Desconocido");
                            opcion = 0;
                            auxiliar = "";
                            break;
                    }
                }
            }
            Result.Text = reformattedText.ToString();

        }

        private void ImprimirTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TokenController.getInstancia().ImprimirTokens();
        }

        private void ImprimirErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TokenController.getInstancia().ImprimirErrores();
        }
    }

}
