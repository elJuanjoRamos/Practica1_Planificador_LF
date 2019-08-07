using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data;
using Practica1_Planificador_LF.controladores;
using Practica1_Planificador_LF.modelos;
//Material Design
//using MaterialSkin;
//using MaterialSkin.Controls;


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

        ////////////////VARIABLES///////////////


        //Sirven para llenar el treeview
        DateTime[] dates = new DateTime[20];
        DataSet dataSetArbol;
        string nombreEvento = "";
        string descripcionEvento = "";
        string imagenEvento = "";
        //Sirven para llenar el calendario
        int dia = 0;
        int mes = 0;
        int year = 0;


        //////////////////////////////////////////


        //Boton Analizar
        private void Analizar_Click(object sender, EventArgs e)
        {

            analizador(textAnalizar.Text); //Manda a llamar al metodo analizar cadena que se encarga de separar las instrucciones del textArea
            CREARTHREEVIEW(0, null); //CREA EL THREEVIEW
        }

        private void VerEventos_Click(object sender, EventArgs e)
        {
            
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
                //Abre una alerta
                alerta("No se ha encontrado la ruta o archivo");
            }

        }



        //Analizador lexico
        public async void analizador(String totalTexto)
        {
            
            ////
            int opcion = 0;
            int columna = 0;
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
                                //Console.WriteLine("esta entrando a puntuacion");

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
                                    //Console.WriteLine("ULTIMO ELSE PUNTUACION");
                                    TokenController.getInstancia().error(c.ToString(), "Desconocido");
                                    opcion = 10;
                                    i--;
                                }

                            }
                            //VERIFICA SI LO QUE VIENE ES SIMBOLO
                            else if (char.IsSymbol(c))
                            {
                                //Console.WriteLine("esta entrando a simbolos");
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
                                    //Console.WriteLine("esta entrando al ultimo else");
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
                                //Console.WriteLine("esta entrando al ultimo else");
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
                                    if (auxiliar.ToLower().Equals("descripcion") || auxiliar.ToLower().Equals("imagen"))
                                    {
                                        TokenController.getInstancia().agregar(auxiliar, "Identificador");
                                    } else
                                    {
                                        TokenController.getInstancia().error(auxiliar, "Desconocido");
                                    }

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
                                if (year == 0)
                                {
                                    year = Int32.Parse(auxiliar);
                                }
                                else if (mes == 0)
                                {
                                    mes = Int32.Parse(auxiliar);
                                }
                                else if (dia == 0)
                                {
                                    dia = Int32.Parse(auxiliar);
                                }
                                if (year != 0 && mes != 0 && dia != 0)
                                {
                                    llenarCalendario(year, mes, dia);
                                }

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
                                if (nombreEvento.Equals(""))
                                {
                                    nombreEvento = auxiliar;
                                }
                                else if (descripcionEvento.Equals(""))
                                {
                                    descripcionEvento = auxiliar;
                                }
                                else if (imagenEvento.Equals(""))
                                {
                                    imagenEvento = auxiliar;
                                }
                                if (!nombreEvento.Equals("") && !descripcionEvento.Equals("") && !imagenEvento.Equals(""))
                                {
                                    llenarCadena(nombreEvento, descripcionEvento, imagenEvento, year,mes,dia);
                                    nombreEvento = "";
                                    descripcionEvento = "";
                                    imagenEvento = "";
                                    year = 0;
                                    mes = 0;
                                    dia = 0;
                                }
                                
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
                            //TokenController.getInstancia().error(auxiliar, "Desconocido");
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


        /////////////////////////////////////////////////
        ///               PARA LA PARTE VISUAL        ///
        /////////////////////////////////////////////////


        /////////////////////////////
        ///    CALENDARIO        ///
        ////////////////////////////
        ///METODO PARA LLENAR EL CALENDARIO
        public void llenarCalendario(int year, int mes, int dia)
        {
            //esta variable va a servir para corroborar si las fechas tienen sentido
            Boolean validar = false;
            //Valida el mes
            if ( mes <= 12 )
            {
                //meses con 31 dias
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    //validacion que la cantidad de días sea menor a 31
                    if (dia <= 31)
                    {
                        //Como todo es correcto la variable validar pasa a ser true
                        validar = true;

                    } else
                    {
                        alerta("El numero de días para el mes solicitado debe ser menor a 31");
                    }     
                }
                //Verifica febrero
                else if ( mes == 2 )
                {
                    if (dia <= 28)
                    {
                        //Si los días son menor a 28 la variable pasa a ser true
                        validar = true;
                    }
                    else
                    {
                        alerta("El numero de días para el mes solicitado debe ser menor a 28");
                    }
                }
                //Verifica meses con 30 dias
                else if ( mes == 4 || mes == 6 || mes == 9 || mes == 11 )
                {
                    if (dia <= 30)
                    {
                        validar = true;
                    }
                    else
                    {
                        alerta("El numero de días para el mes solicitado debe ser menor a 30");
                    }

                }
                //Si la variable validar es true, entra al if
                if (validar)
                {
                    //Primero hace un for hasta el tamaño de dates, dates es un arreglo de fechas declarado más arriba
                    for (int i = 0; i < dates.Length; i++)
                    {
                        //Verifica que si el arreglo en la posicion i cumple con la condicion
                        if (dates[i].ToString().Equals("1/1/0001 12:00:00 AM"))
                        {
                            //si cumple, sustituye la fecha por defecto, por la que vienen en el texto
                            //la fecha por defecto se crea cuando se declara el arreglo,
                            dates[i] = new DateTime(year, mes, dia);
                            break;
                        }
                    }
                    //Marca en negrita las fechas en el calendario
                    calendario.BoldedDates = dates;
                }
            }
            else
                {
                    alerta("El mes debe ser menor a 12");
                }
           
        }



        ///////////////////////////
        ///    THREEVIEW        //
        //////////////////////////

        //LLENAR CADENA, ESTO SIRVE PARA CREAR EVENTOS QUE VAN A SER LEIDOS POR EL TREEVIEW
        public void llenarCadena(string nombre, string descripcion, string imagen, int year, int mes, int dia)
        {
            EventoController.getInstancia().agregar(nombre, descripcion,imagen, year,mes,dia);
        }


        //LLenado del treeview
        private void CREARTHREEVIEW(int indicePadre, TreeNode nodePadre)
        {
            CrearDataSet(); //este metodo inicializa el threeview
            
            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            DataView dataViewHijos = new DataView(dataSetArbol.Tables["TablaArbol"]);
            dataViewHijos.RowFilter = dataSetArbol.Tables["TablaArbol"].Columns["IdentificadorPadre"].ColumnName + " = " + indicePadre;

            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["NombreNodo"].ToString().Trim();

                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (nodePadre == null)
                {
                    treeView1.Nodes.Add(nuevoNodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodePadre.Nodes.Add(nuevoNodo);
                }

                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.

                CREARTHREEVIEW(Int32.Parse(dataRowCurrent["IdentificadorNodo"].ToString()), nuevoNodo);
            }
        }


        //INICIALIZA EL THREEVIEW CON LOS VALORES DE EVENTOS DEL ARREGLO
        private void CrearDataSet()
        {
            dataSetArbol = new DataSet("DataSetArbol");

            DataTable tablaArbol = dataSetArbol.Tables.Add("TablaArbol");
            tablaArbol.Columns.Add("NombreNodo", typeof(string));
            tablaArbol.Columns.Add("IdentificadorNodo", typeof(Int32));
            tablaArbol.Columns.Add("IdentificadorPadre", typeof(Int32));

            //LLAMA AL ARREGLO DE EVENTOS
            ArrayList array = EventoController.getInstancia().getArray();

            //CONTADORES PARA INSERTAR LOS NODOS
            int padre = 0;
            int hijo = 0;
            foreach (Evento a in array)
            {
                hijo++; 
                InsertarDataRow(a.getNombreEvento(), hijo, padre);
                hijo++;
                InsertarDataRow(a.getYear().ToString(), hijo, hijo-1);
                hijo++;
                InsertarDataRow(a.getMes().ToString(), hijo, hijo - 1);
                hijo++;
                InsertarDataRow(a.getDia().ToString(), hijo, hijo - 1);
                //DEBE HACERSE DE ESA FORMA POR QUE SI NO SE CRUZAN LAS FECHAS, SUPONE QUE PONE UN EVENTO DE UNA FECHA EN OTRA Y ASÍ
            }

        }
        //METODO QUE INSERTA LOS NODOS AL THREEVIEW
        private void InsertarDataRow(string column1, int column2, int column3)
        {
            DataRow nuevaFila = dataSetArbol.Tables["TablaArbol"].NewRow();
            nuevaFila["NombreNodo"] = column1;
            nuevaFila["IdentificadorNodo"] = column2;
            nuevaFila["IdentificadorPadre"] = column3;
            dataSetArbol.Tables["TablaArbol"].Rows.Add(nuevaFila);
        }

        

    



















        //Muestra una alerta
        public void alerta(String mensaje)
        {

            MessageBox.Show(mensaje, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

}
