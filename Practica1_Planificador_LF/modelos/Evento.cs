using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Planificador_LF.modelos
{
    class Evento
    {
        private int idEvento;
        private String nombreEvento;
        private int year;
        private int mes;
        private int dia;
        private String descripcion;
        private String imagen;

        public Evento(int idEvento, string nombreEvento, int year, int mes, int dia, string descripcion, string imagen)
        {
            this.idEvento = idEvento;
            this.nombreEvento = nombreEvento;
            this.year = year;
            this.mes = mes;
            this.dia = dia;
            this.descripcion = descripcion;
            this.imagen = imagen;
        }

        public int getIdEvento()
        {
            return this.idEvento;
        }
        public int getYear()
        {
            return this.year;
        }

        public int getMes()
        {
            return this.mes;
        }
        public int getDia()
        {
            return this.dia;
        }
        public string getNombreEvento()
        {
            return this.nombreEvento;
        }

        public string getDescripcion()
        {
            return this.descripcion;
        }

        public string getImagen()
        {
            return this.imagen;
        }



    }
}
