﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_TipoUbicacionNegocio
    {
        C_TipoUbicacionDatos c_TipoUbicacionDatos = new C_TipoUbicacionDatos();

        public string ListaTipoUbicacion()
        {
            return c_TipoUbicacionDatos.ListarTipoUbicacion();
        }
        public void InsertarTipoUbicacion(TMCCM_C_Ubicacion_Tipo_Ubicacion tipoUbicacion)
        {
            c_TipoUbicacionDatos.InsertarTipoUbicacion(tipoUbicacion);
        }

    }
}
