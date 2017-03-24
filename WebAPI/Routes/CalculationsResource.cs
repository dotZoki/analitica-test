using System;
using System.Collections.Generic;
using System.Text;
using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;

namespace WebAPI
{
	//private Dictionary date;


	[RestResource]
	public class CalulationsResource
	{
		[RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/calculations")]
		public IHttpContext RepeatMe(IHttpContext context)
		{
			context.Response.SendResponse(Encoding.UTF8.GetBytes("Calculation from server that runs on port " + MainClass.Port));
			return context;
		}
	}
}
