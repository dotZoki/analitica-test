using System;

namespace WebAPI
{

	class MainClass
	{
		public static void Main(string[] args)
		{
			//Console.WriteLine("Starting REST API server on port " + 12);
			using (var server = new Grapevine.Server.RestServer())
			{
				server.LogToConsole().Start();
				Console.ReadLine();
				server.Stop();
			}
		}
	}
}
