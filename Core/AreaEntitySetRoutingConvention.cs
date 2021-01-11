using Microsoft.AspNetCore.OData.Routing.Conventions;

namespace Platform.Api.Core
{
   public class AreaEntitySetRoutingConvention : EntitySetRoutingConvention
   {
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