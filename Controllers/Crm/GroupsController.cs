using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Platform.Api.Dtos.Crm;

namespace Platform.Api.Controllers.Crm
{
   [EnableQuery()]
   public class GroupsController : ODataController
   {
      [HttpGet]
      public IEnumerable<GroupDto> Get()
      {
         yield return new GroupDto { Key = "Crm" };
      }

      public GroupDto Get(string key)
      {
         return this.Get().Single(dto => dto.Key == key);
      }
   }
}