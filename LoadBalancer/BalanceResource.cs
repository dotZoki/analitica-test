using System;
using System.Diagnostics.Contracts;
using System.Text;
using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using RestSharp;

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
				if (MainClass.ActiveService == null)
				{
					context.Response.SendResponse(Encoding.UTF8.GetBytes("All instances down!"));
					return context;
				}
				var client = new RestClient(MainClass.ActiveService);
				var request = new RestRequest(context.Request.PathInfo, Method.GET);
				var content = client.Execute(request).Content;

				context.Response.SendResponse(Encoding.UTF8.GetBytes(content));

				return context;
			}
		}

	}
}
