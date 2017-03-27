using System;
using System.Text;
using Grapevine.Client;
using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;

namespace LoadBalancer
{
	public class BalanceResource
	{
		public BalanceResource()
		{
		}

		[RestResource]
		public class MonitorResource
		{
			[RestRoute]
			public IHttpContext Answer(IHttpContext context)
			{
				//var client = new RESTClient("localhost:8900");
				var client = new RESTClient("www.mocky.io");
				Console.WriteLine("=========================");
				Console.WriteLine(context.Request.PathInfo);
				Console.WriteLine("=========================");
				RESTResponse response = client.Execute(new RESTRequest("/v2/58d8dd6f0f0000721fdcc7af"));
				Console.WriteLine(response.Content);

				//context.Response.SendResponse(Encoding.UTF8.GetBytes("thump thump"));
				context.Response.SendResponse(Encoding.UTF8.GetBytes(response.Content));

				return context;
			}
		}

	}
}
