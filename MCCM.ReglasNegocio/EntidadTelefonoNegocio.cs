using MCCM.AccesoDatos;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class EntidadTelefonoNegocio
    {
        EntidadTelefonoDatos entidadTelefonoDatos = new EntidadTelefonoDatos();
        public void InsertarEntidadTelefono(TMCCM_Entidad_Telefono entidadTelefonoDTO)
        {
            entidadTelefonoDatos.InsertarEntidadTelefono(entidadTelefonoDTO);
        }

        public void ActualizarEntidadTelefono(TMCCM_Entidad_Telefono entidadTelefonoDTO)
        {
            entidadTelefonoDatos.ActualizarEntidadTelefono(entidadTelefonoDTO);
        }

        public string EliminarEntidadTelefono(int ID)
        {
            entidadTelefonoDatos.EliminarEntidadTelefono(ID);
            return "S";
        }
        public List<sp_listarEntidadTelefono_Result> ListarEntidadTelefonos(int caso)
        {
            return entidadTelefonoDatos.ListarEntidadTelefonos(caso);
        }

        public TMCCM_EntidadTelefonoDTO ObtenerEntidadTelefonoPorID(int ID)
        {
            return entidadTelefonoDatos.ObtenerEntidadTelefonoPorID(ID);
        }


    }
}
