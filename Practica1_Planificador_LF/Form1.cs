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
        #region variables
        ////////////////VARIABLES///////////////


        //Sirven para llenar el treeview
        DateTime[] dates = new DateTime[20];
        DataSet dataSetArbol;
        string nombreEvento = "";
        string descripcionEvento = "";
        string imagenEvento = "";
        //Sirven para llenar el calendario
        
        Boolean masMeses = false;
        Boolean masYears = false;
        int dia = 0;// 
        int mes = 0;
        int year = 0;
        int cont = 0;//contadores para ver si hay mas de un dia
        int contMes = 0;
        int contYear = 0;
        #endregion


        #region BotonesVista

        //Boton Analizar
        private void Analizar_Click(object sender, EventArgs e)
        {

            analizador(textAnalizar.Text); //Manda a llamar al metodo analizar cadena que se encarga de separar las instrucciones del textArea
            CREARTHREEVIEW(0, null); //CREA EL THREEVIEW
        }


        private void VerEventos_Click(object sender, EventArgs e)
        {
            
        }
        #endregion


        #region Menu BAR

        /////////////////////////////
        ///    MENU BAR        ///
        ////////////////////////////

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

        /*Guardar archivo*/
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            
            String dir = path + "\\archivo.txt";


            StreamWriter escribir = new StreamWriter(@dir);
            try
            {
                escribir.WriteLine(textAnalizar.Text);
                escribir.WriteLine("\n");
            }
            catch
            {
                MessageBox.Show("Error");
            }
            escribir.Close();
        }
        /*Cerrar programa*/
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        ////////////////////////
        ///    OTROS        ///
        //////////////////////

        // IMPRIMIR TOKENS
        private void ImprimirTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TokenController.getInstancia().ImprimirTokens();
        }
        // IMPRIMIR ERRORES
        private void ImprimirErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TokenController.getInstancia().ImprimirErrores();
        }


        ////////////////////////
        ///    Ayuda        ///
        //////////////////////

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre: Juan José Ramos Campos\nCarnet: 201812620\n" +
                "Curso: Lenguajes Foramales\nSección: B", "Detalles",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion


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
                                    TokenController.getInstancia().agregar(c.ToString(), "Llave Izquierda");

                                }
                                else if (c.Equals('}'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Llave Derecha");
                                    masYears = true;
                                    year = 0;
                                }
                                else if (c.Equals('('))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Parentesis Derecho");
                                }
                                else if (c.Equals(')'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Parentesis Izquierdo");
                                    masMeses = true;
                                    mes = 0;
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

                                if (auxiliar.ToLower().Equals("planificador"))
                                {
                                    TokenController.getInstancia().agregar(auxiliar, "Palabra Reservada");
                                    //Si encuentra la palabra palificador, eso quiere decir que todo lo demás es nuevo
                                    //por tanto, devuelve la variables a sus valores iniciales
                                    dia = 0;
                                    mes = 0;
                                    year = 0;
                                    masMeses = false;
                                    masYears = false;
                                    nombreEvento = "";
                                    cont = 0;
                                    contMes = 0;
                                    contYear = 0;

                                }
                                //Si la palabra reservada es año
                                else if (auxiliar.ToLower().Equals("año") || auxiliar.ToLower().Equals("anio"))
                                {
                                    //lo envia a los token
                                    TokenController.getInstancia().agregar(auxiliar, "Palabra Reservada");

                                    //verifica si viene mas de un año
                                    contYear = contYear + 1;
                                    if (contYear > 1)
                                    {
                                        masYears = true;
                                    }
                                }
                                //si la palabra reservada es mes
                                else if (auxiliar.ToLower().Equals("mes"))
                                {
                                    //lo envia a token
                                    TokenController.getInstancia().agregar(auxiliar, "Palabra Reservada");
                                    //verifica si viene mas de un mes
                                    contMes = contMes + 1;
                                    if (contMes > 1)
                                    {
                                        masMeses = true;
                                    }
                                }
                                //si la palabra reservada es dia
                                else if (auxiliar.ToLower().Equals("dia"))
                                {
                                    TokenController.getInstancia().agregar(auxiliar, "Palabra Reservada");
                                    //verifica si viene mas de un dia
                                    cont = cont + 1;
                                    if (cont > 1)
                                    {
                                        masMeses = false;
                                    }
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

                                //EN ESTA PARTE GUARDA EN VARIABLES EL AÑO, MES Y DIA PARA PODER CREAR EVENTOS CON ESAS FECHAS

                                //LA PRIMERA FECHA ES SIEMPRE EL AÑO
                                if (year == 0)
                                {
                                    year = Int32.Parse(auxiliar);
                                }
                                //COMO EL AÑO YA SE LLENO, LA SIGUIENTE FECHA EN EL PLANIFICADOR ES EL MES
                                else if (mes == 0)
                                {
                                    mes = Int32.Parse(auxiliar);
                                }
                                //LA ULTIMA FECHA EN EL PLANIFICADOR ES EL DIA
                                else if (dia == 0)
                                {
                                    dia = Int32.Parse(auxiliar);
                                }
                                //MANDA LAS VARIABLES A UN METODO PARA LLENAR EL CALENDARIO
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

                                //en esta parte llena las variables para crear eventos
                                //primero verifica si el nombre ya esta lleno,
                                if (nombreEvento.Equals(""))
                                {
                                    nombreEvento = auxiliar;
                                }
                                //si está lleno quiere decir que la segunda cadena es la descripcion,
                                else if (descripcionEvento.Equals(""))
                                {
                                    descripcionEvento = auxiliar;
                                }
                                //si la cadena ya está llena solo queda la imagen
                                else if (imagenEvento.Equals(""))
                                {
                                    imagenEvento = auxiliar;
                                }
                                if (!nombreEvento.Equals("") && !descripcionEvento.Equals("") && !imagenEvento.Equals(""))
                                {
                                    
                                    
                                    //Cuando verifica que las variables estan llenas las envia al metodo de llenar cadena que a su vez crea eventos
                                    llenarCadena(nombreEvento, descripcionEvento, imagenEvento, year,mes,dia);

                                    //limpia las variables por si vien mas de un planificador en el archivo de texto

                                    //esto es dias
                                    if (masMeses == false)
                                    {
                                        Console.WriteLine(nombreEvento + " " + descripcionEvento + " " + imagenEvento + " " + year + " " + mes + " " + dia);
                                        descripcionEvento = "";
                                        imagenEvento = "";
                                        dia = 0;
                                    }
                                    //esto es meses
                                    else if (masMeses == true)
                                    {
                                        Console.WriteLine("viene mas de un mes");
                                        descripcionEvento = "";
                                        imagenEvento = "";
                                        mes = 0;
                                        dia = 0;

                                    }
                                    //esto es años
                                    else if (masYears == true)
                                    {
                                        Console.WriteLine("viene mas de un año");
                                        descripcionEvento = "";
                                        imagenEvento = "";
                                        dia = 0;
                                        mes = 0;
                                        year = 0;
                                    }

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
                        if (dates[i].ToString().Equals("1/1/0001 12:00:00 AM") || dates[i].ToString().Equals("01/01/0001 12:00:00 a. m."))
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

        private void Detalle_Click(object sender, EventArgs e)
        {
            treeView1.PathSeparator = ".";

            // Get the count of the child tree nodes contained in the SelectedNode.
            int myNodeCount = treeView1.SelectedNode.GetNodeCount(true);
            decimal myChildPercentage = ((decimal)myNodeCount /
              (decimal)treeView1.GetNodeCount(true)) * 100;

            // Display the tree node path and the number of child nodes it and the tree view have.
            MessageBox.Show("The '" + treeView1.SelectedNode.FullPath + "' node has "
              + myNodeCount.ToString() + " child nodes.\nThat is "
              + string.Format("{0:###.##}", myChildPercentage)
              + "% of the total tree nodes in the tree view control.");
        }
    }

}
