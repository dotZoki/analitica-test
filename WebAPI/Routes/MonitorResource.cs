using System;
using System.Text;
using Grapevine;
using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;

namespace WebAPI
{
	[RestResource]
	public class MonitorResource
	{
		[RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/heartbeat")]
		public IHttpContext Answer(IHttpContext context)
		{
			context.Response.SendResponse(Encoding.UTF8.GetBytes("thump thump"));

			return context;
		}
	}
}
