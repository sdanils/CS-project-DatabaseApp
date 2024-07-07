using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Server_Lab3
{
    internal class Server
    {
        private TcpListener commandListener;
        public Server()
        {
            IPAddress ipServer = IPAddress.Parse("IP");
            commandListener = new TcpListener(ipServer, 8888); // Порт для команд

        }
        public void Start()
        {
            commandListener.Start();
            Console.WriteLine("Сервер запущен. Адрес - " + ((IPEndPoint)commandListener.LocalEndpoint).Address.ToString() + " Ожидание подключений...");

            // Принимаем асинхронно команды и данные от клиента
            Task.Run(() => AcceptCommandsAndProgress());
        }

        private async Task AcceptCommandsAndProgress()
        {
            while (true)
            {
                TcpClient commandClient = await commandListener.AcceptTcpClientAsync();
                Console.WriteLine("Получено подключение для команд и прогресса.");

                // Обработка команд и прогресса от клиента в асинхронном режиме
                _ = HandleCommandsAndProgress(commandClient);
            }
        }

        private async Task HandleCommandsAndProgress(TcpClient commandClient)
        {
            try
            {
                NetworkStream stream = commandClient.GetStream();

                //получение типа машин от клиента
                byte[] buffer = new byte[256];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                int typeVeh = int.Parse(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                
                //определение числа найденных машин
                int numberVeh = (new Random()).Next(10,20);
                string numberVehString = Convert.ToString(numberVeh);

                // Отправка числа машин
                byte[] responseBytes = Encoding.UTF8.GetBytes(numberVehString);
                stream.Write(responseBytes, 0, responseBytes.Length);

                IPAddress clientAdr = ((IPEndPoint)commandClient.Client.RemoteEndPoint).Address;
                int clientPort = ((IPEndPoint)commandClient.Client.RemoteEndPoint).Port + 10;
                IPEndPoint clientAdrData = new IPEndPoint(clientAdr, clientPort);
                // отправка клтиенту машин
                using (TcpClient thisClient = new TcpClient())
                {
                    await thisClient.ConnectAsync(clientAdrData);
                    Console.WriteLine("Подключено для отправки данных.");
                    try
                    {
                        NetworkStream streamData = thisClient.GetStream();
                        await Loader.Load(typeVeh, numberVeh, stream, streamData);
                    }
                    finally
                    {
                        thisClient.Close();
                    }

                }
            }
            finally
            {
                commandClient.Close();
            }
        }
    }
}
