using MCCM.AccesoDatos;
using MCCM.Entidad;

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
        public string ListarEntidadTelefonos(int caso)
        {
            return entidadTelefonoDatos.ListarEntidadTelefonos(caso);
        }

        public string ObtenerEntidadTelefonoPorID(int ID)
        {
            return entidadTelefonoDatos.ObtenerEntidadTelefonoPorID(ID);
        }

        public string ListarTelefonosProveedores()
        {
            return entidadTelefonoDatos.ListarTelefonosProveedores();
        }

        public void InsertarProveedor(TMCCM_C_Telefono_Empresa_Telefonica proveedor)
        {
            entidadTelefonoDatos.InsertarTelefonoProveedor(proveedor);
        }
    }
}
