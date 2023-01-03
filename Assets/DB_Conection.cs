using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
public class DB_Conection : MonoBehaviour
{
    private string connectionstring;

    
    void Start()
    {
        
    }

    public void ConexaoBanco()
    {
        Debug.Log("connecting to database...");
        connectionstring = @"Data Source = DESKTOP-8P0KPOU;
        user id = sa;
        password = king1121;
        Initial Catalog = ASTEROIDS;";
        SqlConnection dbConnection = new SqlConnection(connectionstring);

        try
        {
            dbConnection.Open();
            Debug.Log("Connected to database");

        }
        catch (SqlException _exception)
        {
            Debug.LogWarning(_exception.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
