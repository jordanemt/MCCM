using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaGeneroNegocio
    {
        C_PersonaGeneroDatos c_PersonaGeneroDatos = new C_PersonaGeneroDatos();
        public string ListarPersonaGenero()
        {
            return c_PersonaGeneroDatos.ListarPersonaGenero();
        }
        public void InsertarPersonaGenero(TMCCM_C_Persona_Genero personaGenero)
        {
            c_PersonaGeneroDatos.InsertarPersonaGenero(personaGenero);
        }

    }
}
