
namespace Server_Lab3
{
    internal static class Programm
    {
        static void Main()
        {
            Server server = new Server();
            server.Start();

            // Оставляем консольное приложение открытым
            Console.ReadLine();
        }
    }
}