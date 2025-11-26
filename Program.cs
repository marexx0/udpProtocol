Console.Write("Run as (server/client): ");
string mode = Console.ReadLine().ToLower();

if (mode == "server")
    Server.Run();
else
    Client.Run();