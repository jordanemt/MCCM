﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCM.Entidad;
using MCCM.AccesoDatos;

namespace MCCM.ReglasNegocio
{
    public class C_PersonaSexoNegocio
    {
        C_PersonaSexoDatos c_PersonaSexoDatos = new C_PersonaSexoDatos();
        public string ListarPersonaSexo()
        {
           
            return c_PersonaSexoDatos.ListarPersonaSexo();
        }
        public void InsertarPersonaSexo(TMCCM_C_Persona_Sexo personaSexo)
        {
            c_PersonaSexoDatos.InsertarPersonaSexo(personaSexo);
        }


    }
}

