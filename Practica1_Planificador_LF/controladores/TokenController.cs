using Practica1_Planificador_LF.modelos;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practica1_Planificador_LF.controladores
{
    class TokenController
    {

        //VARIABLES 
        ArrayList listaTokens = new ArrayList();
        ArrayList listaErrores = new ArrayList();
        int idToken = 1;
        int idTokenError = 1;

        //Singleton
        private readonly static TokenController instancia = new TokenController();

        private TokenController()
        {
        }

        public void clearListaTokens()
        {
            listaTokens.Clear();
        }

        public void clearListaTokensError()
        {
            listaTokens.Clear();
        }

        public static TokenController getInstancia()
        {
            
            {
                return instancia;
            }
        }

        //METODO AGREGAR TOKEN
        public void agregar(int fila, String valor, String contenido)
        {

            Token token = new Token(fila, contenido, valor);
            listaTokens.Add(token);
            idToken++;

        }

        public void error(String valor, String contenido, int fila, int columna)
        {
            Console.WriteLine("ERROR" + valor);
            Token token = new Token(idTokenError, contenido, valor, fila, columna);
            listaErrores.Add(token);
            idTokenError++;
        }

        //OBTENER LISTADO
        public void generarLista()
        {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token actual = (Token)listaTokens[i];
                Console.WriteLine("-->Lexema:" + actual.getLexema() + ", --->IdToken: " + actual.getIdToken() + ", --->token: " + actual.getNombreToken() + "");
            }
        }
        //Obtener errores
        public void generarListaError()
        {
            Console.WriteLine(listaErrores.Count);
            for (int i = 0; i < listaErrores.Count; i++)
            {
                Token actual = (Token)listaErrores[i];
                Console.WriteLine("[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",token: " + actual.getNombreToken() + "]");
            }
        }


        public ArrayList getArray()
        {
            return this.listaTokens;
        }

        //IMPRIMIR LOS TOKENS
        public void ImprimirTokens(string name)
        {
            string cadena = "";
            string contenido = "" ;

            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token tok = (Token)listaTokens[i];

                contenido = "<tr>\n" +
                    "     <th scope=\"row\">" + (i).ToString() + "</th>\n" +
                    "     <td>" + tok.getIdToken() + "</td>\n" +
                    "     <td>" + tok.getLexema() + "</td>\n" +
                    "     <td>" + tok.getNombreToken() + "</td>\n" +
                    "</tr>";
                cadena = cadena + contenido;

            }
            string cadena2 = "<th scope =\"col\">No</th>\n" +
            "          <th scope=\"col\">Id</th>\n" +
            "          <th scope=\"col\">Lexema</th>\n"+
            "          <th scope=\"col\">Token</th>\n";
            armarHTML(cadena, cadena2, "Tokens " + name);

        }
        public void ImprimirErrores(string name)
        {
            string cadena = "";
            string contenido = "";

            for (int i = 0; i < listaErrores.Count; i++)
            {
                Token tok = (Token)listaErrores[i];

                contenido = "<tr>\n" +
                    "     <th scope=\"row\">" + (i).ToString() + "</th>\n" +
                    "     <td>" + tok.getLexema() + "</td>\n" +
                    "     <td>" + tok.getNombreToken() + "</td>\n" +
                    "     <td>" + tok.getFila() + "</td>\n" +
                    "     <td>" + tok.getColumna() + "</td>\n" +
                    "</tr>";
                cadena = cadena + contenido;

            }
            string cadena2 = "<th scope =\"col\">No</th>\n" +
            "          <th scope=\"col\">Caracter</th>\n" +
            "          <th scope=\"col\">Descripcion</th>\n"+
            "          <th scope=\"col\">Fila</th>\n"+
            "          <th scope=\"col\">Columna</th>\n";
              armarHTML(cadena, cadena2, "Errores " + name);

        }


        public void armarHTML(string cadena, string cadena2,  string titulo)
        {

            string head = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "    <meta charset='utf-8'>\n" +
            "    <meta http-equiv='X-UA-Compatible' content='IE=edge'>\n" +
            "    <title> Repote " + titulo + "</title>\n" +
            "    <meta name='viewport' content='width=device-width, initial-scale=1'>\n" +
            "    <link rel='stylesheet' type='text/css' media='screen' href='main.css'>\n" +
            "    <script src='main.js'></script>\n" +
            "    <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css\">\n" +
            "    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css\">\n" +
            "</head>" +
            "<body>\n" +
            "  <nav class=\"navbar navbar-light bg-light\">\n" +
            "    <span class=\"navbar-brand mb-0 h1\">Lenguajes formales</span>\n" +
            "  </nav>";

            string body1 = "<div class=\"container\">\n" +
          "    <div class=\"jumbotron jumbotron-fluid\">\n" +
          "      <div class=\"container\">\n" +
          "        <h1 class=\"display-4\">" + titulo + "</h1>\n" +
          "        <p class=\"lead\">Listado de " + titulo + " detectados por el analizador</p>\n" +
          "      </div>\n" +
          "    </div>\n" +
          "    <div class=\"row\">\n" +
          "    <table id=\"data\"  cellspacing=\"0\" style=\"width: 100 %\" class=\"table table-striped table-bordered table-sm\">\n" +
          "      <thead class=\"thead-dark\">\n" +
          "        <tr>\n" +
                    cadena2+          
          "        </tr>\n" +
          "      </thead>" +
          "<tbody>";


            string body2 = "</tbody>\n" +
           "    </table>\n" +
           "</div>\n" +
           "  </div>";

            string script =
                "  <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js\" ></script>\n" +
                "  <script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js\"></script>\n" +
                "  <script src=\"https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js\"></script>\n" +
                "  <script src=\"https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js\" ></script>\n" +
                "<script>" +
                "$(document).ready(function () { " +
                 "$('#data').DataTable(" +

                 "{ \"aLengthMenu\" " + ":" + " [[5, 10, 25, -1], [5, 10, 25, \"All\"]], \"iDisplayLength\" : 5" +
                 "}" +
                 ");" +
                 "}" +
                 "); " +
               "</script>";

            string html;

            html = head + body1 + cadena + body2 +
            script +
            "</body>" +
            "</html>";

            
            /*creando archivo html*/
            File.WriteAllText("Reporte de "+ titulo + ".html", html);
            System.Diagnostics.Process.Start("Reporte de " + titulo + ".html");



        }
    }
}
