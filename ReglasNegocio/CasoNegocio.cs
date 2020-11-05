using System;
using System.Collections.Generic;
using System.Linq;
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

        public int ReporteDeEventos(int idCaso, DateTime inicio, DateTime final) 
        {
            return casoDatos.ReporteDeEventos(idCaso, inicio, final);
        }

        public List<int> ReporteDeTareas(int idCaso, DateTime inicio, DateTime final)
        {
            return casoDatos.ReporteDeTareas(idCaso, inicio, final);
        }
        public List<int> ReporteDeEntidades(int idCaso, DateTime inicio, DateTime final) 
        {
            return casoDatos.ReporteDeEntidades(idCaso, inicio, final);
        }

        public List<float> ReporteDeGastos(int idCaso, DateTime inicio, DateTime final) 
        {
            return casoDatos.ReporteDeGastos(idCaso, inicio, final);
        }

        public List<int> ReporteDeRecursos(int idCaso, DateTime inicio, DateTime final) 
        {
            return casoDatos.ReporteDeRecursos(idCaso, inicio, final);
        }
    }
}
