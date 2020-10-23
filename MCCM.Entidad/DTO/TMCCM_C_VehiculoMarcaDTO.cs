﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.Entidad.DTO
{
    public class TMCCM_C_VehiculoMarcaDTO
    {
        public int TN_ID_Marca_Vehiculo { get; set; }
        public string TC_Descripcion { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public Nullable<bool> TB_Eliminado { get; set; }


    }
}
