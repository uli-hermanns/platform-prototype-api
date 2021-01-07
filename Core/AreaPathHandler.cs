using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Template;

namespace Platform.Api.Core
{
   public class AreaPathHandler : DefaultODataPathHandler
   {
      public override string Link(ODataPath path)
      {
         return base.Link(path);
      }

      public override ODataPath Parse(string serviceRoot, string odataPath, IServiceProvider requestContainer)
      {
         return base.Parse(serviceRoot, odataPath, requestContainer);
      }

      public override ODataPathTemplate ParseTemplate(string odataPathTemplate, IServiceProvider requestContainer)
      {
         return base.ParseTemplate(odataPathTemplate, requestContainer);
      }
   }
}