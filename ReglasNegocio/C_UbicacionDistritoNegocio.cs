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
    public class C_UbicacionDistritoNegocio
    {
        C_UbicacionDistritoDatos c_UbicacionDistritoDatos = new C_UbicacionDistritoDatos();
        public string ListarUbicacionDistrito(int idCanton)
        {
            return c_UbicacionDistritoDatos.ListarUbicacionDistrito(idCanton);
        }
        public void InsertarUbicacionDistrito(TMCCM_C_Ubicacion_Distrito ubicacionDistrito)
        {
            c_UbicacionDistritoDatos.InsertarUbicacionDistrito(ubicacionDistrito);
        }

    }
}
