using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

public class conexaoBanco : MonoBehaviour
{
    SqlConnection con = new SqlConnection();

    public conexaoBanco()
    {
        con.ConnectionString = @"Data Source = DESKTOP-8P0KPOU;
        user id = sa;
        password = king1121;
        Initial Catalog = ASTEROIDS;";
    }

    public SqlConnection conectar()
    {
        if(con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        return con;
    }
    public void Desconectar()
    {
        if (con.State == System.Data.ConnectionState.Open)
        {
            con.Close();
        }
    }
}
