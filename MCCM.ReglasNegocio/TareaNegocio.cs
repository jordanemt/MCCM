using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.Entidad.DTO;


namespace MCCM.ReglasNegocio
{
    public class TareaNegocio
    {
        AccesoDatos.TareaDatos tareaDatos = new AccesoDatos.TareaDatos();

        public void InsertarTarea(TMCCM_Tarea tarea)
        {
            tareaDatos.InsertarTarea(tarea);
        }

        public void ActualizarTarea(TMCCM_Tarea tarea)
        {
            tareaDatos.ActualizarTarea(tarea);
        }

        public string EliminarTarea(int ID)
        {
            tareaDatos.EliminarTarea(ID);
            return "S";
        }
        public List<TareaCasoResult> ListarTarea(int idCaso)
        {
            return tareaDatos.ListarTareas(idCaso);
        }

        public TMCCM_TareaDTO ObtenerTareaPorID(int ID)
        {
            return tareaDatos.ObtenerTareaPorID(ID);
        }

        public List<CatalogoUsuarioResult> ObtenerCatalogoUsuarios() {
            return tareaDatos.ObtenerCatalogoUsuarios();
        }


    }
}
