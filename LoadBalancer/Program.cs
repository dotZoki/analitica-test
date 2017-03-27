using System;
using System.Collections.Generic;

namespace LoadBalancer
{
	class MainClass
	{
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Load balancer for REST started on port 8888");

			using (var server = new Grapevine.Server.RestServer())
			{
				server.Port = "8888";
				server.LogToConsole().Start();
				Console.ReadLine();
				server.Stop();
			}

		}
	}
}
