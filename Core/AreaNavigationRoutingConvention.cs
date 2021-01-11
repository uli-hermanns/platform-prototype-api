using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.Extensions.Logging;

namespace Platform.Api.Core
{
   public class AreaNavigationRoutingConvention : NavigationRoutingConvention
   {
      public AreaNavigationRoutingConvention(ILogger<NavigationRoutingConvention> logger) : base(logger)
      {
      }

      public override bool AppliesToAction(ODataControllerActionContext context)
      {
         return context.IsValidArea() && base.AppliesToAction(context);
      }

      public override bool AppliesToController(ODataControllerActionContext context)
      {
         return context.IsValidArea() && base.AppliesToController(context);
      }
   }
}