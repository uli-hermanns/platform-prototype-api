using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.Dtos.Crm;

namespace Platform.Api.Controllers.Crm
{
   [EnableQuery()]
   [ODataRoutePrefix("api/crm")]
   public class GroupsController : ControllerBase
   {
      [ODataRoute(RouteName = "CRM")]
      [HttpGet]
      public IEnumerable<GroupDto> Get()
      {
         yield return new GroupDto { Key = "Crm" };
      }
   }
}