using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using MCCM.AccesoDatos;
using MCCM.Entidad;

namespace MCCM.ReglasNegocio
{
    public class CasoNegocio
    {
        AccesoDatos.CasoDatos casoDatos = new AccesoDatos.CasoDatos();

        public void InsertarCaso(TMCCM_Caso caso) {
            casoDatos.InsertarCaso(caso);
        }

        public void ActualizarCaso(TMCCM_Caso caso)
        {
            casoDatos.ActualizarCaso(caso);
        }

        public string EliminarCaso(int ID) {
            casoDatos.EliminarCaso(ID);
            return "S";
        }
        public string ListarCasos() {
            return casoDatos.ListarCasos();
        }

        public string ObtenerCasoPorID(int ID) {
            return casoDatos.ObtenerCasoPorID(ID);
        }

        public Dictionary<string, int> ReporteDeEventos(int idCaso, DateTime inicio, DateTime final, bool eventos) 
        {
            if (eventos) return casoDatos.ReporteDeEventos(idCaso, inicio, final);
            else return null;
        }

        public Dictionary<string, int> ReporteDeTareas(
            int idCaso,
            DateTime inicio,
            DateTime final,
            bool tareasTerminadas,
            bool tareasPendientes)
        {
            return casoDatos.ReporteDeTareas(idCaso, inicio, final, tareasTerminadas, tareasPendientes);
        }

        public Dictionary<string, int> ReporteDeEntidades(
            int idCaso,
            DateTime inicio,
            DateTime final,
            bool persona,
            bool personaJuridica,
            bool vehiculo,
            bool ubicacion,
            bool telefono,
            bool arma,
            bool droga)
        {
            return casoDatos.ReporteDeEntidades(idCaso, inicio, final, persona, personaJuridica, vehiculo, ubicacion, telefono, arma, droga);
        }

        public Dictionary<string, float> ReporteDeGastos(
            int idCaso,
            DateTime inicio, DateTime final,
            bool operativo,
            bool combustible)
        {
            return casoDatos.ReporteDeGastos(idCaso, inicio, final, operativo, combustible);
        }

        public Dictionary<string, int> ReporteDeRecursos(
            int idCaso,
            DateTime inicio,
            DateTime final,
            bool personal,
            bool vehiculo)
        {
            return casoDatos.ReporteDeRecursos(idCaso, inicio, final, personal, vehiculo);
        }
    }
}
