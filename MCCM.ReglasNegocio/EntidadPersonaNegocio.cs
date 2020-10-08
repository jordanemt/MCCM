using MCCM.AccesoDatos;
using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadPersonaNegocio
    {

        EntidadPersonaDatos entidadPersonaDatos = new EntidadPersonaDatos();
        public void InsertarEntidadPersona(TMCCM_Entidad_Persona entidad_Persona)
        {
            entidadPersonaDatos.InsertarEntidadPersona(entidad_Persona);
        }


    }
}
