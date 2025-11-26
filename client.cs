using System.Net;
using System.Net.Sockets;
using System.Text;

public static class Client
{
    public static void Run()
    {
        UdpClient client = new UdpClient();
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 5000);

        Console.WriteLine("Client started...");

        while (true)
        {
            string msg = Console.ReadLine();
            byte[] data = Encoding.UTF8.GetBytes(msg);
            client.Send(data, data.Length, serverEP);

            byte[] resp = client.Receive(ref serverEP);
            string answer = Encoding.UTF8.GetString(resp);

            Console.WriteLine($"Server: {answer}");
        }
    }
}
