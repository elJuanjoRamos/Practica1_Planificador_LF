﻿using System;
using System.Collections;
using Practica1_Planificador_LF.modelos;

namespace Practica1_Planificador_LF.controladores
{
    class EventoController
    {
        //Variables
        ArrayList listaEventos = new ArrayList();
        int idEvento = 1;
        
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
        public ArrayList getArray()
        {
            return this.listaEventos;
        }
    }

}
