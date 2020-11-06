using MCCM.AccesoDatos;
using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.ReglasNegocio
{
    public class UsuarioNegocio
    {
        private UsuarioDatos datos;

        public UsuarioNegocio()
        {
            datos = new UsuarioDatos();
        }

        public List<TMCCM_Usuario> Listar()
        {
            return datos.Listar();
        }

        public TMCCM_Usuario ObtenerPorID(int id)
        {
            return datos.ObtenerPorID(id);
        }

        public TMCCM_Usuario Insertar(TMCCM_Usuario data)
        {
            return datos.Insertar(data);
        }

        public void Actualizar(TMCCM_Usuario data)
        {
            datos.Actualizar(data);
        }

        public void EliminarPorID(int id)
        {
            datos.EliminarPorID(id);
        }
        public TMCCM_Usuario Verificar(string Usuario, string contrasennia)
        {
            return datos.Verificar(Usuario, contrasennia);
        }
    }
}
