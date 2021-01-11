using System.Linq;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Abstracts;
using Microsoft.AspNetCore.OData.Routing.Conventions;

namespace Platform.Api.Core
{
   public static class Conventions
   {
      public static bool IsArea(this ODataControllerActionContext context)
      {
         var entityNamespace = context.EntityType?.Namespace.Split('.').Last();
         var controllerNamespace = context.Controller.ControllerType.Namespace.Split('.').Last();
         return string.Equals(entityNamespace, controllerNamespace, System.StringComparison.OrdinalIgnoreCase);
      }

      public static IODataBuilder RemoveConvention<TConvention>(this IODataBuilder builder)
         where TConvention : class, IODataControllerActionConvention
      {
         var serviceType = builder.Services.Single(descriptor => descriptor.ImplementationType?.Equals(typeof(TConvention)) ?? false);
         builder.Services.Remove(serviceType);
         return builder;
      }

      public static IODataBuilder ReplaceConvention<TSource, TTarget>(this IODataBuilder builder)
         where TSource : class, IODataControllerActionConvention
         where TTarget : class, IODataControllerActionConvention
      {
         return builder.RemoveConvention<TSource>().AddConvention<TTarget>();
      }

      public static IODataBuilder ReplaceDefaultConventions(this IODataBuilder builder)
      {
         return builder
            .ReplaceConvention<ActionRoutingConvention, AreaActionRoutingConvention>()
            .ReplaceConvention<EntityRoutingConvention, AreaEntityRoutingConvention>()
            .ReplaceConvention<EntitySetRoutingConvention, AreaEntitySetRoutingConvention>()
            .ReplaceConvention<FunctionRoutingConvention, AreaFunctionRoutingConvention>()
            .ReplaceConvention<NavigationRoutingConvention, AreaNavigationRoutingConvention>()
            .ReplaceConvention<OperationImportRoutingConvention, AreaOperationImportRoutingConvention>()
            .ReplaceConvention<RefRoutingConvention, AreaRefRoutingConvention>()
            .ReplaceConvention<PropertyRoutingConvention, AreaPropertyRoutingConvention>()
            .ReplaceConvention<SingletonRoutingConvention, AreaSingletonRoutingConvention>();
      }
   }
}