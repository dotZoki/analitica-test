using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using Eneter.Messaging.MessagingSystems.MessagingSystemBase;
using Eneter.Messaging.MessagingSystems.TcpMessagingSystem;
using Eneter.Messaging.Nodes.LoadBalancer;
using System.Linq;
using RestSharp;

namespace LoadBalancer
{
	class MainClass
	{

		public static string ActiveService;

		private static ICollection<KeyValuePair<String, String>> serverList = new Dictionary<String, String>()
		{
			{"http://localhost:8900", "/heartbeat"},
			{"http://localhost:8901", "/heartbeat"}
		};

		public static void Main(string[] args)
		{
			ActiveService = serverList.First().Value;

			Console.WriteLine("Load balancer for REST started on port 8888");

			using (var server = new Grapevine.Server.RestServer())
			{
				server.Port = "8888";
				server.LogToConsole().Start();

				Thread thread = new Thread(new ThreadStart(ContinuousHealthChecker));
				thread.IsBackground = true;
				thread.Name = "Health Checker Thread";
				thread.Start();

				Console.ReadLine();
				server.Stop();
			}

		}

		public static void ContinuousHealthChecker()
		{
			while (true)
			{
				Boolean firstAliveFound = false;
				foreach (var server in serverList)
				{
					var client = new RestClient(server.Key);
					var request = new RestRequest(server.Value, Method.GET);
					var content = client.Execute(request).Content;

					if (!firstAliveFound && content.Equals("thump thump"))
					{
						firstAliveFound = true;
						ActiveService = server.Key;
					}
				}

				if (!firstAliveFound)
				{
					Console.WriteLine("all services dead send message to admin");
					// send message to admin via email or smtin
					ActiveService = null;
				}

				Thread.Sleep(5000);

			}
		}
	}
}
