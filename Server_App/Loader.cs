using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server_Lab3
{
    internal class Loader
    {
        public static async Task Load(int model, int numberNewVehicles, NetworkStream stream, NetworkStream streamData)
        {
            Random rand = new Random();

            if (model == 1)
            {
                for (int i = 0; i < numberNewVehicles; ++i)
                {
                    string number = "";
                    char sym;

                    sym = (char)rand.Next(65, 91);
                    number += sym;
                    sym = (char)rand.Next(65, 91);
                    number += sym;
                    sym = (char)rand.Next(48, 58);
                    number += sym;
                    sym = (char)rand.Next(48, 58);
                    number += sym;
                    sym = (char)rand.Next(48, 58);
                    number += sym;
                    sym = (char)rand.Next(65, 91);
                    number += sym;

                    int numWheels = rand.Next(2, 6) * 2;

                    int voluem = rand.Next(8, 16);

                    //Создание Json обьекта для отправки
                    VehicleTruck truck = new VehicleTruck(number, numWheels, voluem);
                    string jsonString = JsonConvert.SerializeObject(truck);
                    
                    byte[] data = Encoding.UTF8.GetBytes(jsonString);
                    byte[] progressData = Encoding.UTF8.GetBytes(Convert.ToString(i));

                    //Отправка длины данных об обьекте
                    byte[] lengthBytes = BitConverter.GetBytes(data.Length);
                    await streamData.WriteAsync(lengthBytes, 0, lengthBytes.Length);

                    // Отправка обьекта и прогресса клиенту.
                    await streamData.WriteAsync(data, 0, data.Length);
                    await stream.WriteAsync(progressData, 0, progressData.Length);
                    
                    await Task.Delay(300); // Имитация загрузки данных
                }
            }
            else if (model == 2)
            {
                for (int i = 0; i < numberNewVehicles; ++i)
                {
                    string number = "";
                    char sym;

                    sym = (char)rand.Next(65, 91);
                    number += sym;
                    sym = (char)rand.Next(65, 91);
                    number += sym;
                    sym = (char)rand.Next(48, 58);
                    number += sym;
                    sym = (char)rand.Next(48, 58);
                    number += sym;
                    sym = (char)rand.Next(48, 58);
                    number += sym;
                    sym = (char)rand.Next(65, 91);
                    number += sym;

                    string multi = "";

                    sym = (char)rand.Next(65, 91);
                    multi += sym;
                    sym = (char)rand.Next(65, 91);
                    multi += sym;
                    sym = (char)rand.Next(48, 58);
                    multi += sym;
                    sym = (char)rand.Next(48, 58);
                    multi += sym;
                    sym = (char)rand.Next(48, 58);
                    multi += sym;
                    sym = (char)rand.Next(65, 91);
                    multi += sym;
                    sym = (char)rand.Next(48, 58);
                    multi += sym;
                    sym = (char)rand.Next(48, 58);
                    multi += sym;
                    sym = (char)rand.Next(65, 91);
                    multi += sym;
                    sym = (char)rand.Next(65, 91);
                    multi += sym;
                    sym = (char)rand.Next(65, 91);
                    multi += sym;
                    sym = (char)rand.Next(48, 58);
                    multi += sym;

                    int airbags = rand.Next(2, 12);

                    new VehicleCar(number, multi, airbags);

                    //Создание Json обьекта для отправки
                    VehicleCar car = new VehicleCar(number, multi, airbags);
                    string jsonString = JsonConvert.SerializeObject(car);

                    byte[] data = Encoding.UTF8.GetBytes(jsonString);
                    byte[] progressData = Encoding.UTF8.GetBytes(Convert.ToString(i));
         
                    //Отправка длины данных об обьекте
                    byte[] lengthBytes = BitConverter.GetBytes(data.Length);
                    await streamData.WriteAsync(lengthBytes, 0, lengthBytes.Length);

                    // Отправка обьекта и прогресса клиенту.
                    await streamData.WriteAsync(data, 0, data.Length);
                    await stream.WriteAsync(progressData, 0, progressData.Length);

                    await Task.Delay(300); // Имитация загрузки данных
                }
            }
        }
    }
}

