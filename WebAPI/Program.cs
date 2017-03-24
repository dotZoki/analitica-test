using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI
{

	class MainClass
	{
		private static string port = "8900";

		public static string Port
		{
			get
			{
				return port;
			}
			protected set
			{ 
				port = value;
			}
		}

		public static void Main(string[] args)
		{
			List<string> argsList = new List<string>(args);
			port = (argsList.ElementAtOrDefault(0) != null) ? args[0] : port;

			Console.WriteLine("Starting on port " + port + " ...");

			using (var server = new Grapevine.Server.RestServer())
			{
				server.Port = port;
				server.LogToConsole().Start();
				Console.ReadLine();
				server.Stop();
			}
		}

	}
}
