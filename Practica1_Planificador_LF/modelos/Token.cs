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

        //Constructor
        public Token(int idToken, String nombreToken, String lexema)
        {
            this.lexema = lexema;
            this.idToken = idToken;
            this.nombreToken = nombreToken;
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

    }
}
