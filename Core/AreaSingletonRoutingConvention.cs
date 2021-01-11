using Microsoft.AspNetCore.OData.Routing.Conventions;

namespace Platform.Api.Core
{
   public class AreaSingletonRoutingConvention : SingletonRoutingConvention
   {
      public override bool AppliesToController(ODataControllerActionContext context)
      {
         return context.IsValidArea() && base.AppliesToController(context);
      }
   }
}