using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Platform.Api.Dtos.Crm;

namespace Platform.Api.Controllers.Crm
{
   [EnableQuery()]
   public class CustomersController : ODataController
   {
      public IEnumerable<CustomerDto> Get()
      {
         yield return new CustomerDto { Key = "Schmitz", Representative = new Dtos.Hrm.EmployeeDto { Key = "Uli" }, RepresentativeKey = "Uli" };
         yield return new CustomerDto { Key = "Müller", Representative = new Dtos.Hrm.EmployeeDto { Key = "Ben" }, RepresentativeKey = "Ben" };
      }

      public CustomerDto Get(string key)
      {
         return this.Get().Single(dto => dto.Key == key);
      }

      public Dtos.Hrm.EmployeeDto GetRepresentative(string key)
      {
         return this.Get(key).Representative;
      }
   }
}