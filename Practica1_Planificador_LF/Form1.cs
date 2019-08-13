using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Data;
using Practica1_Planificador_LF.controladores;
using Practica1_Planificador_LF.modelos;
using System.Drawing;
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
            calendario.MaxSelectionCount = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region VARIABLES_GLOBALES
        ////////////////VARIABLES///////////////
        //TAB
        int tabContador = 2;
        

        //analizador_Lexico LEXICO
        string auxiliar = "";
        string fila = "";

        //Treeview
        int aumento = 0;



        //Panel detalle de evetos
        string nombreEvento = "";
        string descripcionEvento = "";
        string imagenEvento = "";


        

        //Calendario
        DateTime[] dates = new DateTime[20];
        Boolean masMeses = false;
        Boolean masYears = false;
        string dia = "";// 
        string mes = "";
        string year = "";
        //contadores para ver si hay mas de un dia
        int cont = 0;
        int contMes = 0;
        int contYear = 0;




        #endregion

        #region BOTONES_VISTA

        //Boton Analizar
        private void Analizar_Click(object sender, EventArgs e)
        {
            //LIMPIA EL TREEVIEW Y EL CALENDARIO
            //treeView1.Nodes.Clear();
            calendario.RemoveAllBoldedDates();
            calendario.UpdateBoldedDates();

            //LIMPIA LAS VARIABLES
            limpiarTodo("planificador");
            //OBTENER LOS CONTROLES DE TAB
            foreach (Control c in tabControl1.SelectedTab.Controls)
            {
                RichTextBox richTextBox = c as RichTextBox;
                TokenController.getInstancia().clearListaTokens();
                TokenController.getInstancia().clearListaTokensError();
                analizador_Lexico(richTextBox.Text); //Manda a llamar al metodo analizar cadena que se encarga de separar las instrucadenaFechasiones del textArea
            }                
            //CrearTreeView(0, null); //CREA EL THREEVIEW
        }


        private void Detalle_Click(object sender, EventArgs e)
        {
            Result.SelectAll();
            Result.Clear();
            Result.Update();
            var fechaEvento = calendario.SelectionRange.Start.ToShortDateString();

            ArrayList array = EventoController.getInstancia().getEventosDiaEspecifico(fechaEvento);
            foreach (Evento x in array)
            {
                Result.AppendText("EVENTO: " + x.getNombreEvento() + "\n");
                Result.AppendText("DESCRIPCION: " + x.getDescripcion() + "\n");
                Result.AppendText("FECHA: " + x.getDia() + "-" + x.getMes() + "-" + x.getYear() + "" + "\n");

                string var = x.getImagen().Replace("\"", "");
                Console.WriteLine( "la imagen es " +  var);
                if (File.Exists(var))
                {
                    Clipboard.SetImage(Image.FromFile(x.getImagen().Replace("\"", "")));
                }
                else
                {
                    Result.AppendText("--IMAGEN NO DISPONIBLE---");
                }

                Result.Paste();
                Result.AppendText("\n");
            }

        }

        private void ImprimirEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
             EventoController.getInstancia().verEventos();
             foreach(Evento x in EventoController.getInstancia().getArray())
             {
                Result.AppendText("EVENTO: " + x.getNombreEvento() + "\n");
                Result.AppendText("DESCRIPCION: " + x.getDescripcion() + "\n");
                Result.AppendText("FECHA: " + x.getDia() + "-" + x.getMes() + "-" + x.getYear() + "" + "\n");

                string var = x.getImagen().Replace("\"", "");
                Console.WriteLine("la imagen es " + var);
                if (File.Exists(var))
                {
                    Clipboard.SetImage(Image.FromFile(x.getImagen().Replace("\"", "")));
                }
                else
                {
                    Result.AppendText("--IMAGEN NO DISPONIBLE---");
                }

                Result.Paste();
                Result.AppendText("\n");
            }

        }



        #endregion

        #region MENU_BAR

        /////////////////////////////
        ///    MENU BAR        ///
        ////////////////////////////

        /*Nueva pestaña*/
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabContador++;
            var tabPage = new TabPage("Pestaña " + tabContador);
            tabControl1.Controls.Add(tabPage);
            var richTextBox = new RichTextBox();
            richTextBox.Width = 530;
            richTextBox.Height = 562;
            tabPage.Controls.Add(richTextBox);
        }


        /*Abrir archivo*/
        /*Abrir archivo*/
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            buscar.Filter = "ly files (*.ly)|*.ly";
            buscar.FilterIndex = 2;
            buscar.RestoreDirectory = true;

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo.Text = buscar.FileName;
            }

            if (File.Exists(rutaArchivo.Text))  //verifica si el archivo existe
            {

                StreamReader leer = new StreamReader(rutaArchivo.Text); //Carga el archivo

                string linea;
                //OBTENER LOS CONTROLES DE TAB
                foreach (Control c in tabControl1.SelectedTab.Controls)
                {
                    RichTextBox richTextBox = c as RichTextBox;
                    try
                    {
                        linea = leer.ReadLine();
                        while (linea != null)
                        {
                            richTextBox.AppendText(linea + "\n"); //lee la linea y la inserta en el textAarea hasta que se sea nula
                            linea = leer.ReadLine();
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                    }
                }
                leer.Close();
                rutaArchivo.Text = "";
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
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.DefaultExt = "ly";
            saveFileDialog1.Filter = "ly files (*.ly)|*.ly";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = tabControl1.SelectedTab.Text;


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                String dir = saveFileDialog1.FileName;
                Console.WriteLine();
                StreamWriter escribir = new StreamWriter(@dir);
                try
                {

                    foreach (Control c in tabControl1.SelectedTab.Controls)
                    {
                        RichTextBox richTextBox = c as RichTextBox;
                        try
                        {
                            escribir.WriteLine(richTextBox.Text);
                            escribir.WriteLine("\n");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                escribir.Close();
            }



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
            TokenController.getInstancia().ImprimirTokens(tabControl1.SelectedTab.Text);
        }
        // IMPRIMIR ERRORES
        private void ImprimirErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TokenController.getInstancia().ImprimirErrores(tabControl1.SelectedTab.Text);
        }


        ////////////////////////
        ///    Ayuda        ///
        //////////////////////

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre: Juan José Ramos Campos\nCarnet: 201812620\n" +
                "Curso: Lenguajes Foramales\nSeccion: B", "Detalles",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion

        #region analizador_Lexico
        //analizador_Lexico lexico
        public async void analizador_Lexico(String totalTexto)
        {

            ////
            int opcion = 0;
            int columna = 0;
            int fila = 1;
            totalTexto = totalTexto + " ";

            char[] charsRead = new char[totalTexto.Length];
            using (StringReader reader = new StringReader(totalTexto))
            {
                await reader.ReadAsync(charsRead, 0, totalTexto.Length);
            }

            StringBuilder reformattedText = new StringBuilder();
            using (StringWriter writer = new StringWriter(reformattedText))
            {
                for (int i = 0; i < charsRead.Length; i++)
                {
                    columna++;
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
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Llave_Izquierda");

                                }
                                else if (c.Equals('}'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Llave_Derecha");
                                    masYears = true;
                                    year = "";
                                }
                                else if (c.Equals('('))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Parentesis_Derecho");
                                }
                                else if (c.Equals(')'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Parentesis_Izquierdo");
                                    masMeses = true;
                                    mes = "";
                                }
                                else if (c.Equals(','))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Coma");
                                }
                                else if (c.Equals(';'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Punto_y_Coma");
                                }
                                else if (c.Equals(':'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Dos_puntos");
                                }
                                else if (c.Equals('.'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Punto");
                                }
                                else if (c.Equals('['))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Corchete_Derecho");
                                }
                                else if (c.Equals(']'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Punt_Corchete_Izquierdo");
                                }
                                else
                                {
                                    //Console.WriteLine("ULTIMO ELSE PUNTUACION");
                                    TokenController.getInstancia().error(c.ToString(), "Simb_Desconocido", fila, columna);
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
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Menor_que");
                                }
                                else if (c.Equals('>'))
                                {
                                    TokenController.getInstancia().agregar(c.ToString(), "Simb_Mayor_que");
                                }
                                else
                                {
                                    //Console.WriteLine("esta entrando al ultimo else");
                                    TokenController.getInstancia().error(c.ToString(), "Simb_Desconocido", fila, columna);
                                    opcion = 10;
                                    i--;
                                }
                            }
                            //VERIFICA SI ES ESPACIO EN BLANCO O SALTO DE LINEA
                            else if (char.IsWhiteSpace(c))
                            {
                                opcion = 0;
                            }
                             //VERIFICA SI ES ESPACIO EN BLANCO O SALTO DE LINEA
                            else if (c.Equals('\n'))
                            {
                                columna = 0;//COLUMNA 0
                                fila++; //FILA INCREMENTA
                                opcion = 0;
                            }
                            //LO MANDA A SIGNOS DESCONOCIDOS
                            else
                            {
                                //Console.WriteLine("esta entrando al ultimo else");
                                TokenController.getInstancia().error(c.ToString(), "Simb_Desconocido", fila, columna);
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
                                    || auxiliar.ToLower().Equals("dia") ||
                                    auxiliar.ToLower().Equals("año") || auxiliar.ToLower().Equals("anio"))
                                {
                                    TokenController.getInstancia().agregar(auxiliar, "Palabra_Reservada_" + auxiliar.ToLower());
                                    limpiarTodo(auxiliar.ToLower());
                                }
                                else
                                {
                                    if (auxiliar.ToLower().Equals("descripcion") || auxiliar.ToLower().Equals("imagen"))
                                    {
                                        TokenController.getInstancia().agregar(auxiliar, "Identificador");
                                    }
                                    else
                                    {
                                        TokenController.getInstancia().error(auxiliar, "Cadena_Desconocida", fila, columna);
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
                                crearFechas();
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
                                generarEventos();
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

        #endregion


        /////////////////////////////////////////////////
        ///               PARA LA PARTE VISUAL        ///
        /////////////////////////////////////////////////


        #region calendario
        /////////////////////////////
        ///    CALENDARIO        ///
        ////////////////////////////
        ///

        //METODO QUE GUARDA EN VARIABLES EL AÑO, MES Y DIA PARA PODER CREAR EVENTOS CON ESAS FECHAS

        public void crearFechas()
        {

            //LA PRIMERA FECHA ES SIEMPRE EL AÑO
            if (year == "")
            {
                year = (auxiliar);
                crearAnios(nombreEvento, year.ToString(), 1);
            }
            //COMO EL AÑO YA SE LLENO, LA SIGUIENTE FECHA EN EL PLANIFICADOR ES EL MES
            else if (mes == "")
            {
                mes = (auxiliar);
                crearMeses(nombreEvento, year.ToString(), mes.ToString());
            }
            //LA ULTIMA FECHA EN EL PLANIFICADOR ES EL DIA
            else if (dia == "")
            {
                dia = (auxiliar);
                crearDias(nombreEvento, year.ToString(), mes.ToString(), auxiliar);

            }
            //MANDA LAS VARIABLES A UN METODO PARA LLENAR EL CALENDARIO
            if (year != "" && mes != "" && dia != "")
            {

                llenarCalendario(Int32.Parse(year), Int32.Parse(mes), Int32.Parse(dia));
            }
        }


        //Metodo que sirve para obtener los detalles de evento y sus fechas
        public void generarEventos()
        {
            //en esta parte llena las variables para crear eventos
            //primero verifica si el nombre ya esta lleno,
            if (nombreEvento.Equals(""))
            {
                nombreEvento = auxiliar;
                crearDataSet(nombreEvento);
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
            //VERIFICA SI TODAS LAS VARIABLES NO ESTAN VACIOS PARA PODER CREAR LOS EVENTOS
            if (!nombreEvento.Equals("") && !descripcionEvento.Equals("") && !imagenEvento.Equals(""))
            {


                //Cuando verifica que las variables estan llenas las envia al metodo de llenar cadena que a su vez crea eventos
                llenarCadena(nombreEvento, descripcionEvento, imagenEvento, year, mes, dia);


                //limpia las variables por si vien mas de un planificador en el archivo de texto
                if (masMeses == false)
                {
                    //Limpia las variables necesarias
                    descripcionEvento = "";
                    imagenEvento = "";
                    dia = "";

                }

            }
        }
        //METODO que limpia las variables globales que sirven para llenar el calendario con fechas
        public void limpiarTodo(string cadena)
        {
            //La palabra encontrada fue Planificador, lo que indica que todas la variables globales
            //deben limpiarse para generar nuevas fechas y eventos
            if (cadena.Equals("planificador"))
            {
                dia = "";
                mes = "";
                year = "";
                masMeses = false;
                masYears = false;
                nombreEvento = "";
                cont = 0;
                contMes = 0;
                contYear = 0;
            }
            else if (cadena.Equals("anio") || cadena.Equals("anio"))
            {
                contYear = contYear + 1;
                if (contYear > 1)
                {
                    masYears = true;
                }
            }
            else if (cadena.Equals("mes"))
            {
                contMes = contMes + 1;
                if (contMes > 1)
                {
                    masMeses = true;
                }
            }
            else if (cadena.Equals("dia"))
            {
                cont = cont + 1;
                if (cont > 1)
                {
                    masMeses = false;
                }
            }


        }



        ///METODO PARA LLENAR EL CALENDARIO
        public void llenarCalendario(int year, int mes, int dia)
        {
            //esta variable va a servir para corroborar si las fechas tienen sentido
            Boolean validar = false;
            //Valida el mes
            if (mes <= 12)
            {
                //meses con 31 dias
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    //validacion que la cantidad de días sea menor a 31
                    if (dia <= 31)
                    {
                        //Como todo es correcto la variable validar pasa a ser true
                        validar = true;

                    }
                    else
                    {
                        alerta("El numero de días para el mes solicitado debe ser menor a 31");
                    }
                }
                //Verifica febrero
                else if (mes == 2)
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
                else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
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
                        string fechaDefecto = dates[i].ToString();
                        string resultado = fechaDefecto.Substring(0, 10);
                        //Verifica que si el arreglo en la posicion i cumple con la condicion
                        if (resultado.ToString().Equals("01/01/0001"))
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

        #endregion

        #region TREEVIEW

        ///////////////////////////
        ///    THREEVIEW        //
        //////////////////////////



        //Este metodo inserta los titulos de los planificadores en el treeview
        public void crearDataSet(string evento)
        {
            //treeView1.BeginUpdate();
            treeView1.Nodes.Add(aumento.ToString(), evento);
            treeView1.Nodes[treeView1.Nodes.Count - 1].Tag = evento;
            aumento++;
        }

        //este metodo inserta los años a cada titulo de evento
        public void crearAnios(string padre, string anio, int nivel)
        {
            for (int i = 0; i < 500; i++)
            {
                if (treeView1.Nodes[i.ToString()].Text.Equals(padre))
                {
                    if (nivel == 1)
                    {
                        treeView1.Nodes[i.ToString()].Nodes.Add(anio, anio);
                        treeView1.EndUpdate();
                        treeView1.Refresh();
                    }
                    break;
                }
            }

        }
        //este metodo inserta los meses a cada año del planificador
        public void crearMeses(string padre, string anio, string mes)
        {
            for (int i = 0; i < 100; i++)
            {
                if (treeView1.Nodes[i.ToString()].Text.Equals(padre))
                {
                    if (treeView1.Nodes[i.ToString()].Nodes[anio].Text.Equals(anio))
                    {
                        treeView1.Nodes[i.ToString()].Nodes[anio].Nodes.Add(mes, mes);
                        treeView1.EndUpdate();
                        treeView1.Refresh();
                    }

                    break;
                }
            }
        }
        //Inserta los dias a cada año del planificador
        public void crearDias(string padre, string anio, string mes, string dia)
        {
            for (int i = 0; i < 100; i++)
            {
                if (treeView1.Nodes[i.ToString()].Text.Equals(padre))
                {

                    if (treeView1.Nodes[i.ToString()].Nodes[anio].Text.Equals(anio))
                    {
                        if (treeView1.Nodes[i.ToString()].Nodes[anio].Nodes[mes].Text.Equals(mes))
                        {
                            treeView1.Nodes[i.ToString()].Nodes[anio].Nodes[mes].Nodes.Add(dia, dia);
                            treeView1.EndUpdate();
                            treeView1.Refresh();
                        }

                    }

                    break;
                }
            }
        }

        #endregion



        //////////////////////////////
        /// PANEL DE DESCRIPCION  ///
        /// /////////////////////////

        //LLENAR CADENA, ESTO SIRVE PARA CREAR EVENTOS QUE VAN A SER LEIDOS POR EL TREEVIEW
        public void llenarCadena(string nombre, string descripcion, string imagen, string y, string m, string d)
        {
            EventoController.getInstancia().agregar(nombre, descripcion, imagen, y, m, d);
        }



















        //Muestra una alerta
        public void alerta(String mensaje)
        {

            MessageBox.Show(mensaje, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    
        private void Result_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
