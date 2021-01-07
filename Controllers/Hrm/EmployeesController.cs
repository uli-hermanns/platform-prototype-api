using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.Dtos.Crm;
using Platform.Api.Dtos.Hrm;

namespace Platform.Api.Controllers.Hrm
{
   public class EmployeesController : ControllerBase
   {
      [HttpGet]
      [EnableQuery()]
      public IEnumerable<EmployeeDto> Get()
      {
         yield return new EmployeeDto { Key = "Ben" };
         yield return new EmployeeDto { Key = "Uli" };
      }

      [HttpGet]
      public EmployeeDto Get(string key)
      {
         return this.Get().Single(dto => dto.Key == key);
      }
   }
}
