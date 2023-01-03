using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

public class Login : MonoBehaviour
{
    conexaoBanco conexaoBanco = new conexaoBanco();
    dadosJogador dadosJogador = new dadosJogador();


    SqlCommand cmd = new SqlCommand();
    public string mensagem;

    public Login(String usuario, String senha)
    {
        cmd.CommandText = "SELECT COD, USUARIO, SENHA FROM JOGADOR WHERE USUARIO = '@usuario' AND SENHA = '@senha'";
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@senha", senha);


        try
        {
            cmd.Connection = conexaoBanco.conectar();
            cmd.ExecuteNonQuery();
            SqlDataReader rdr = cmd.ExecuteReader();
            Debug.Log("login realizado com sucesso");
            conexaoBanco.Desconectar();
        }
        catch (SqlException e)
        {
            Debug.Log(e.Message);
        }

    }
}
