using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    

namespace VentaDirecta
{
    internal class Conexion
    {
    }
}

public class Conexion
{
    private SqlConnection conn = new SqlConnection("Server=localhost;Database=Basededatos_VinoAR;Trusted_Connection=True;");

    public SqlConnection AbrirConexion()
    {
        if (conn.State == System.Data.ConnectionState.Closed)
            conn.Open();
        return conn;
    }

    public void CerrarConexion()
    {
        if (conn.State == System.Data.ConnectionState.Open)
            conn.Close();
    }
}