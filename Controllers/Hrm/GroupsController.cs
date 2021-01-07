using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.Dtos.Hrm;

namespace Platform.Api.Controllers.Hrm
{
   public class GroupsController : ControllerBase
   {
      [HttpGet]
      [EnableQuery()]
      public IEnumerable<GroupDto> Get()
      {
         yield return new GroupDto { Key = "Hrm" };
      }
   }
}