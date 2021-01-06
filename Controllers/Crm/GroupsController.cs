using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.Dtos.Crm;

namespace Platform.Api.Controllers.Crm
{
   [Area("Crm")]
   public class GroupsController : ControllerBase
   {
      [HttpGet]
      [EnableQuery()]
      // [ODataRoute("Crm/Groups")]
      public IEnumerable<GroupDto> Get()
      {
         yield return new GroupDto { Key = "Crm" };
      }

   }
}
