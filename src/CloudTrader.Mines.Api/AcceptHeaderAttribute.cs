using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Api
{
    public class AcceptHeaderAttribute : ActionMethodSelectorAttribute
    {
        private readonly string _acceptType;
        public AcceptHeaderAttribute(string acceptType)
        {
            _acceptType = acceptType;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            if (!routeContext.HttpContext.Request.Headers.ContainsKey("Accept")) return false;

            var accept = routeContext.HttpContext.Request.Headers["Accept"].ToString();

            return accept == _acceptType;
        }
    }
}
