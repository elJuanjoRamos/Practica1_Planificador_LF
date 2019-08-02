using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using Practica1_Planificador_LF.controladores;
//Material Design
using MaterialSkin;
using MaterialSkin.Controls;


namespace Practica1_Planificador_LF
{
    public partial class Form1 : MaterialForm
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
            TokenController.getInstancia().generarLista();
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




        public void analizador(String entrada)
        {
            int estado = 0;
            int columna = 0;
            int fila = 1;
            string lexema = "";
            Char c;
            //MessageBox.Show(entrada, "111 entrada");
            entrada = entrada + " ";
            //entrada = entrada;
            //MessageBox.Show(entrada, "222 entrada");
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                columna++;
                //MessageBox.Show(c.ToString(), i.ToString() );
                //MessageBox.Show(estado.ToString(), "estado");
                switch (estado)
                {
                    case 0:
                        //columna++;
                        if (Char.IsLetter(c))
                        {
                            estado = 1;
                            lexema += c;
                        }
                        else if (Char.IsDigit(c))
                        {
                            estado = 2;
                            lexema += c;
                        }
                        //else if (c == '-')
                        //{
                        //    estado = 3;
                        //    lexema += c;
                        // }
                        else if (c == '"')
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (c == ',')
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        else if (c == '\n')
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        /*nuevos*/
                        else if (c == '{')
                        {
                            lexema += c;
                            ////TokenController.getInstancia().agregar(lexema, "llaveIzq", pos + 1, 0);

                            TokenController.getInstancia().agregar(lexema, "llaveIzq");
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "llaveDer");
                            ////TokenController.getInstancia().agregar(lexema, "llaveDer", pos + 1, 0);
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "parIzq");
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "parDer");
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            //TokenController.getInstancia().agregar(lexema, "coma", pos + 1, 0);
                            lexema = "";
                        }

                        else if (c == ';')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Punto y Coma");
                            lexema = "";
                        }

                        else if (c == '<')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Menor");
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Mayor");
                            lexema = "";
                        }

                        else if (c == '.')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Punto");
                            lexema = "";
                        }

                        /*fin nuevos*/

                        /*operadores mat*/
                        else if (c == '+')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Suma");
                            lexema = "";
                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Menos");
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Multiplicacion");
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            TokenController.getInstancia().agregar(lexema, "Division");
                            lexema = "";
                        }


                        /*fin operadors mat*/
                        else
                        {
                            //addError(c.ToString() , "Desconocido", fila, columna);
                            estado = -99;
                            i--;
                            columna--;
                        }
                        break;
                    case 1:
                        //if (Char.IsLetter(c))
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            lexema += c;
                            estado = 1;
                            //MessageBox.Show("*1*"+lexema + "*1*", "lexema");
                        }
                        else
                        {
                            if (lexema.ToLower().Equals("Planificador") || lexema.ToLower().Equals("Mes")
                                    || lexema.ToLower().Equals("Anio") || lexema.ToLower().Equals("Dia"))
                            {
                                TokenController.getInstancia().agregar(lexema, "Reservada");
                            }
                            else
                            {
                                TokenController.getInstancia().agregar(lexema, "Identificador");
                            }
                            
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        /*nuevo*/
                        else if (c == '.')
                        {
                            estado = 8;
                            lexema += c;
                        }
                        /*nuevo fin*/
                        else
                        {
                            //token = new Token(3, "Numero", lexema, fila, columna);
                            //tokens.add(token);
                            TokenController.getInstancia().agregar(lexema, "Digito");
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else
                        {
                            estado = -99;
                            i = i - 2;
                            columna = columna - 2;
                            lexema = "";
                        }
                        break;
                    case 4:
                        if (c == '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        break;
                    case 5:
                        if (c != '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        break;
                    case 6:
                        if (c == '"')
                        {
                            lexema += c;
                            //token = new Token(2, "Cadena", lexema, fila, columna);
                            //tokens.add(token);
                            TokenController.getInstancia().agregar(lexema, "Cadena");
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            //token = new Token(4, "Coma", lexema, fila, columna);
                            //tokens.add(token);
                            TokenController.getInstancia().agregar(lexema, "Coma");
                            estado = 0;
                            lexema = "";
                        }

                        break;

                    /**inicio nuevo**/
                    case 8:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                            //retorno += "Se esperaba un digito[" + caracter + "]" + Environment.NewLine;
                            //addError(lexema, "Se esperaba un digito [" + lexema + "]", fila, columna);
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                            //TokenController.getInstancia().agregar(lexema, "decimal", pos + 1, 0);
                            //estado = 0;
                            //lexema = "";
                            //pos -= 1;
                            TokenController.getInstancia().agregar(lexema, "Digito");
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }

                        break;
                    /*fin nuevo*/

                    case -99:
                        lexema += c;


                        //addError(lexema, "Carácter Desconocido", fila, columna);

                        estado = 0;
                        lexema = "";
                        break;
                }
            }


        }








    }

}
