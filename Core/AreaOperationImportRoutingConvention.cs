using Microsoft.AspNetCore.OData.Routing.Conventions;

namespace Platform.Api.Core
{
   public class AreaOperationImportRoutingConvention : OperationImportRoutingConvention
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