using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CDatos;

namespace cNegocio
{
    public class nPrueba
    {
        cPrueba ocPrueba = new cPrueba();

        public DataTable fMantenimientoAlumnoB(cEntidades.ePrueba Ent)
        {
            return ocPrueba.fMantenimientoAlumnoDB(Ent);

        }
    }
}
