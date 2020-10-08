using MCCM.Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCCM.AccesoDatos
{
   public class EntidadPersonaDatos
    {
        public void InsertarEntidadPersona(TMCCM_Entidad_Persona entidadPersona)
        {
            using (var context = new MCCMEntities())
            {

                entidadPersona.TB_Eliminado = true;
                entidadPersona.TF_Fecha_Creacion = DateTime.Now;

                context.TMCCM_Entidad_Persona.Add(entidadPersona);
                context.SaveChanges();
            }
        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }


    }
}
