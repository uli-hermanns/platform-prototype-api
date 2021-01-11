using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Platform.Api.Dtos.Hrm;

namespace Platform.Api.Controllers.Hrm
{
   [EnableQuery()]
   public class EmployeesController : ODataController
   {
      public IEnumerable<EmployeeDto> Get()
      {
         yield return new EmployeeDto { Key = "Ben" };
         yield return new EmployeeDto { Key = "Uli" };
      }

      public EmployeeDto Get(string key)
      {
         return this.Get().Single(dto => dto.Key == key);
      }
   }
}