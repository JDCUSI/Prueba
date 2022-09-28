using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CDatos
{
    public class cPrueba
    {

        public SqlConnection Conexion()
        {
            string sCadena = "";
            sCadena = "Data Source=LAPTOP-S0V0BLUJ; User ID=xis; Password=xis; Initial Catalog=COLEGIO";
            SqlConnection oConexion = new SqlConnection(sCadena);
            oConexion.Open();

            return oConexion;
        }

        public DataTable fMantenimientoAlumnoDB(cEntidades.ePrueba Ent)
        {
            DataTable oDT = new DataTable();
            SqlCommand oProceso = new SqlCommand("SP_MANTENIMIENTO_ALUMNO", Conexion());
            oProceso.CommandType = CommandType.StoredProcedure;
            oProceso.Parameters.Add("@IND", SqlDbType.VarChar).Value = Ent.Ind;
            oProceso.Parameters.Add("@AL1_CCODIGO", SqlDbType.VarChar).Value = Ent.Codigo;
            oProceso.Parameters.Add("@AL1_CPATERNO", SqlDbType.VarChar).Value = Ent.Paterno;
            oProceso.Parameters.Add("@AL1_CMATERNO", SqlDbType.VarChar).Value = Ent.Materno;
            oProceso.Parameters.Add("@AL1_CNOMBRES", SqlDbType.VarChar).Value = Ent.Nombres;
            oProceso.Parameters.Add("@AL1_CDIRECCION", SqlDbType.VarChar).Value = Ent.Direccion;
            oProceso.Parameters.Add("@AL1_FECHA", SqlDbType.VarChar).Value = Ent.FechaNac;
            SqlDataAdapter oDA = new SqlDataAdapter(oProceso);
            oDA.Fill(oDT);
            return oDT;
        }






    }
}
