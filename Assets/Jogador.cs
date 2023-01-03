using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class Jogador : MonoBehaviour
{
    private ControleJogo ControleJogo;
    private TcpClient cliente;
    private StreamReader reader = null;
    private StreamWriter writer = null;
    private Thread thread;
    private bool rodando = false;

    public int id { get; private set; }

    public Jogador(ControleJogo controleJogo, int id, TcpClient cliente)
    {
        ControleJogo = controleJogo;
        this.cliente = cliente;
        this.id = id;

        NetworkStream stream = this.cliente.GetStream();
        reader = new StreamReader(stream);
        writer = new StreamWriter(stream);

        thread = new Thread(Run);
        thread.Start();
    }

    public void EnviarMensagem (string dados)
    {
        writer.WriteLine(dados);
        writer.Flush();
    }

    public void Run()
    {
        Console.WriteLine($"Start id:{id}.listener");
        EnviarMensagem($"jogador:{id}");
        string dados = reader.ReadLine();
        while (dados != null)
        {
            try
            {
                for (int i = 0; i < ControleJogo.jogadores.Length; i++)
                {
                    if (i != id && ControleJogo.jogadores[i] != null)
                        ControleJogo.jogadores[i].EnviarMensagem(dados);
                }
                dados = reader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro de rede: {e}");
                dados = null;
            }
            cliente.Close();
        }

    }
}
