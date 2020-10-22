using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
    public class UsuarioDatos
    {
        public List<TMCCM_Usuario> Listar()
        {
            using (var context = new MCCMEntities())
            {
                return context.TMCCM_Usuario
                    .Where(e => e.TB_Eliminado == true)
                    .ToList();
            }
        }
    }
}
