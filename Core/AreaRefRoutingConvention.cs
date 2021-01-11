using Microsoft.AspNetCore.OData.Routing.Conventions;

namespace Platform.Api.Core
{
   public class AreaRefRoutingConvention : RefRoutingConvention
   {
      public override bool AppliesToController(ODataControllerActionContext context)
      {
         return context.IsArea() && base.AppliesToController(context);
      }
   }
}