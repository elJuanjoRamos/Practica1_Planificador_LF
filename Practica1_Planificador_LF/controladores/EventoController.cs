using System;
using System.Collections;
using Practica1_Planificador_LF.modelos;

namespace Practica1_Planificador_LF.controladores
{
    class EventoController
    {
        //Variables
        ArrayList listaEventos = new ArrayList();
        int idEvento = 1;
        String nombreEvento = "";
        string auxiliarNombre = "";

        //Singleton
        private readonly static EventoController instancia = new EventoController();

        private EventoController()
        {
        }

        public static EventoController getInstancia()
        {

            {
                return instancia;
            }
        }

        //METODO AGREGAR EVENTO
        public void agregar(String nombre, String descripcion, String imagen, int year, int mes, int dia)
        {

            Evento evento = new Evento(idEvento, nombre, year, mes, dia, descripcion, imagen);
            listaEventos.Add(evento);
            idEvento++;

        }


        public void formarCadenaEventos()
        {
            auxiliarNombre = ((Evento)listaEventos[0]).getNombreEvento();
            for (int i = 0; i < listaEventos.Count; i++)
            {
                Evento e = (Evento)listaEventos[i];

                if (auxiliarNombre == e.getNombreEvento())
                {
                    nombreEvento = e.getNombreEvento();
                    nombreEvento = nombreEvento + e.getMes();
                }
                else
                {
                    nombreEvento = e.getNombreEvento() + " " + e.getMes();
                }
                
                Console.WriteLine(nombreEvento);
            }



        }




        public ArrayList getArray()
        {
            return this.listaEventos;
        }

        public void verEventos()
        {
            foreach(Evento e in listaEventos)
            {
                Console.WriteLine("NOMBRE " +e.getNombreEvento() + "FECHA" + e.getDia() + "-" + e.getMes() + "-" +e.getYear() + " DES " + e.getDescripcion() + " PAHT " + e.getImagen() );
            }
        }
    }

}
