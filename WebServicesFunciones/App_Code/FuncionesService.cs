using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class FuncionesService : FuncionesIService
{
    private string cadenaConexion = ConfigurationManager.ConnectionStrings["ServiceFunciones"].ConnectionString;


    public string GenerarDocumentosRrhh(Funciones funciones)
    {
        var lstResultado = new List<Funciones>();

        var estado = "";
        var mensaje = "";
        try
        {
            using (var con = new SqlConnection(cadenaConexion))
            {
                using (var cmd = new SqlCommand("DBO.SP_ARH_Procesos_AugestionRH", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@@Empleado", funciones.Usuario);
                    cmd.Parameters.AddWithValue("@@Password", funciones.Contrasena);
                    cmd.Parameters.AddWithValue("@@Empresa", funciones.Compania);
                    cmd.Parameters.AddWithValue("@@Proceso", funciones.Proceso);

                    cmd.Parameters.Add("@@Estado", SqlDbType.VarChar, 1);
                    cmd.Parameters["@@Estado"].Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@@Mensaje", SqlDbType.VarChar, 255);
                    cmd.Parameters["@@Mensaje"].Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    estado = cmd.Parameters["@@Estado"].Value.ToString();
                    mensaje = cmd.Parameters["@@Mensaje"].Value.ToString();

                    //lstResultado.Add(new Funciones {});
                    //tbResultado.Columns.Add("ESTADO", typeof(string));
                    //tbResultado.Columns.Add("MENSAJE", typeof(string));
                    //tbResultado.Rows.Add(estado,mensaje);

                }
            }

        }
        catch (Exception e)
        {
            throw new Exception("Error al validar el usuario",e);
        }
        return estado+","+mensaje;
    }

}
