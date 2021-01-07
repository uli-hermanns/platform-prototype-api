using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.Dtos.Hrm;

namespace Platform.Api.Controllers.Hrm
{
   [EnableQuery()]
   [ODataRoutePrefix("api/hrm")]
   public class GroupsController : ControllerBase
   {
      [ODataRoute(RouteName = "HRM")]
      [HttpGet]
      public IEnumerable<GroupDto> Get()
      {
         yield return new GroupDto { Key = "Hrm" };
      }
   }
}