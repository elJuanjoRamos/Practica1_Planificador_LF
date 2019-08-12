using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Planificador_LF.modelos
{
    class Token
    {
        private int idToken;
        private string lexema;
        private string nombreToken;
        private int fila;
        private int columna;

        //Constructor
        public Token(int idToken, String nombreToken, String lexema)
        {
            this.lexema = lexema;
            this.idToken = idToken;
            this.nombreToken = nombreToken;
        }

        public Token(int idToken, String nombreToken, String lexema, int fila, int columna)
        {
            this.lexema = lexema;
            this.idToken = idToken;
            this.nombreToken = nombreToken;
            this.fila = fila;
            this.columna = columna;
        }

        //Metodos get
        public int getIdToken()
        {
            return this.idToken;
        }
        public String getLexema()
        {
            return this.lexema;
        }
        public String getNombreToken()
        {
            return this.nombreToken;
        }

        public int getColumna()
        {
            return this.columna;
        }
        public int getFila()
        {
            return this.fila;
        }

        //Metodos Set

        public void setIdToken(int idToken)
        {
            this.idToken = idToken;
        }

        public void setLexema(String lexema)
        {
            this.lexema = lexema;
        }

        public void setNombreToken(String nombreToken)
        {
            this.nombreToken = nombreToken;
        }

        public void setColumna(int columna)
        {
            this.columna = columna;
        }

        public void setFila(int fila)
        {
            this.fila = fila;
        }

    }
}
