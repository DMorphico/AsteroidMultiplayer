using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


public class ControleJogo : MonoBehaviour
{
    const int MAXIMO = 2;

    public Jogador[] jogadores;

    public bool Rodando { get; private set; } = true;

    public ControleJogo()
    {
        jogadores = new Jogador[MAXIMO];
    }

    public void DesconectedClient(TcpClient cliente)
    {
        NetworkStream stream = cliente.GetStream();
        StreamWriter writer = new StreamWriter(stream);
        Console.WriteLine("Servidor lotado");
        writer.WriteLine("Servidor lotado");
        writer.Flush();
        writer.Close();
    }

    public void AdicionarJogador(TcpClient client)
    {
        for (int i = 0; i < jogadores.Length; i++)
        {
            if (jogadores[i] == null)
            {
                int id = i;
                jogadores[id] = new Jogador(this, id, client);
                Console.WriteLine($"Novo jogador conectado com o id {id}");
                return;
            }
        }
    }
}
