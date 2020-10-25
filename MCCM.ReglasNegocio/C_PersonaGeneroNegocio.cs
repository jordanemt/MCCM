using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;
using MCCM.Entidad.DTO;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaGeneroNegocio
    {
        C_PersonaGeneroDatos c_PersonaGeneroDatos = new C_PersonaGeneroDatos();
        public List<TMCCM_C_PersonaGeneroDTO> ListarPersonaGenero()
        {
            return c_PersonaGeneroDatos.ListarPersonaGenero();
        }
    }



}
