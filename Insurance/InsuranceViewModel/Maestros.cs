using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceViewModel
{
    public class Maestros
    {


        public enum TiposDocumentos
        {

            CC=1,
            NIT=2,
            CE=3

        }

        public enum TiposCubrimeinto
        {
            Terremoto=1,
            Incendio=2,
            Robo=3,
            Perdida=4

        }

        public enum TiposRiesgo
        {
            Bajo=1,
            Medio=2,
            MedioAlto=3,
            Alto=4
        }

        public enum Estados
        {
            Activo=1,
            Pendiente=2,
            Vencido=3
        }

    }
}
