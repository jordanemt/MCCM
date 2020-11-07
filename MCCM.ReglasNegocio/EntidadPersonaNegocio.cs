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
        
        public void InsertarEntidadPersona(TMCCM_Entidad_Persona entidadPersona)
        {
            entidadPersonaDatos.InsertarEntidadPersona(entidadPersona);
        }

        public void ActualizarEntidadPersona(TMCCM_Entidad_Persona entidadPersona)
        {
            entidadPersonaDatos.ActualizarEntidadPersona(entidadPersona);
        }

        public string EliminarEntidadPersona(int ID)
        {
            entidadPersonaDatos.EliminarEntidadPersona(ID);
            return "S";
        }
        public string ListarEntidadPersonas(int caso)
        {
            return entidadPersonaDatos.ListarEntidadPersonas(caso);
        }

        public string ObtenerEntidadPersonaPorID(int ID)
        {
            return entidadPersonaDatos.ObtenerEntidadPersonaPorID(ID);
        }

    }
}
