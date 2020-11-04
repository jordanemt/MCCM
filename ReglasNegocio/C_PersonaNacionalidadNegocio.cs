using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.Entidad.DTO;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaNacionalidadNegocio
    {
        C_PersonaNacionalidadDatos c_PersonaNacionalidadDatos = new C_PersonaNacionalidadDatos();
        public List<TMCCM_C_PersonaNacionalidadDTO> ListarPersonaNacionalidad()
        {
        
            return c_PersonaNacionalidadDatos.ListarPersonaNacionalidad();
        }
        public void InsertarPersonaNacionalidad(TMCCM_C_Persona_Nacionalidad personaNacionalidad)
        {
            c_PersonaNacionalidadDatos.InsertarPersonaNacionalidad(personaNacionalidad);
        }

    }
}
