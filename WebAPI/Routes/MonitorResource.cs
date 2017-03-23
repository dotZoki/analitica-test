using System;
using System.Text;
using Grapevine;
using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;

namespace WebAPI
{
	[RestResource]
	public class MonitorResource
	{
		[RestRoute]
		public IHttpContext Answer(IHttpContext context)
		{
			context.Response.SendResponse(Encoding.UTF8.GetBytes("thump thump"));

			return context;
		}
	}
}
