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
   // [Area("Crm")]
   public class CustomersController : ControllerBase
   {
      [HttpGet]
      [EnableQuery()]
      public IEnumerable<CustomerDto> Get()
      {
         yield return new CustomerDto { Key = "Schmitz", Representative = new Dtos.Hrm.EmployeeDto { Key = "Uli" } };
         yield return new CustomerDto { Key = "Müller", Representative = new Dtos.Hrm.EmployeeDto { Key = "Ben" } };
      }

      [HttpGet]
      [EnableQuery()]
      public CustomerDto Get(string key)
      {
         return this.Get().Single(dto => dto.Key == key);
      }
   }
}