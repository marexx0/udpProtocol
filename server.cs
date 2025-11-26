using System.Net;
using System.Net.Sockets;
using System.Text;

public static class Server
{
    public static void Run()
    {
        UdpClient server = new UdpClient(5000);
        Console.WriteLine("Server started on port 5000...");

        Dictionary<string, string> answers = new()
        {
            {"hello", "Hello client!"},
            {"how are you", "Everything is good! Thanks!"},
            {"do you love c#", "Yes, of course!"}
        };

        while (true)
        {
            IPEndPoint clientEP = null;
            byte[] data = server.Receive(ref clientEP);
            string message = Encoding.UTF8.GetString(data);

            Console.WriteLine($"Client: {message}");

            string lower = message.ToLower();
            string response = "I don't understand.";

            foreach (var kv in answers)
                if (lower.Contains(kv.Key))
                    response = kv.Value;

            server.Send(
                Encoding.UTF8.GetBytes(response),
                response.Length,
                clientEP);

            Console.WriteLine($"Server: {response}");
        }
    }
}
