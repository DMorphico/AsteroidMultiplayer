using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System;

namespace Server
{
    public class Servidor : MonoBehaviour
    {
        static void Main(string[] args)
        {
            int porta = 5000;
            ControleJogo controle = new ControleJogo();

            try
            {
                IPAddress enderecoServidor = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(enderecoServidor, porta);
                listener.Start();
                while (controle.Rodando)
                {
                    Console.WriteLine("Aguardando conexões");
                    TcpClient cliente = listener.AcceptTcpClient();
                    controle.AdicionarJogador(cliente);
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine($"Erro de rede: {se}");
            }
        }
    }
}