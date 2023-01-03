using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

public class Cadastrar : MonoBehaviour
{
    conexaoBanco conexaoBanco = new conexaoBanco();
    SqlCommand cmd = new SqlCommand();
    public string mensagem;

    public Cadastrar(String usuario,String nome, String senha)
    {
        cmd.CommandText = "INSERT INTO JOGADOR(NOME, USUARIO, SENHA) VALUES (@nome, @usuario, @senha)";
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@senha", senha);

        try
        {
            cmd.Connection = conexaoBanco.conectar();
            cmd.ExecuteNonQuery();
            conexaoBanco.Desconectar();
            Debug.Log("Cadastrado com Sucesso");
        }
        catch (SqlException e)
        {

            Debug.Log(e.Message);
        }
    }
}
