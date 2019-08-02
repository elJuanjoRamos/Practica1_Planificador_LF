using Practica1_Planificador_LF.modelos;
using System;
using System.Collections;
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
        int idToken = 1;

        //Singleton
        private readonly static TokenController instancia = new TokenController();

        private TokenController()
        {
        }

        public static TokenController getInstancia()
        {
            
            {
                return instancia;
            }
        }

        //METODO AGREGAR TOKEN
        public void agregar(String valor, String contenido)
        {

            Token token = new Token(idToken, contenido, valor);
            listaTokens.Add(token);
            idToken++;

        }

        //OBTENER LISTADO
        public void generarLista()
        {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token actual = (Token)listaTokens[i];
                Console.WriteLine("[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",token: " + actual.getNombreToken() + "]");
            }
        }


        public ArrayList getArray()
        {
            return this.listaTokens;
        }
    }
}
