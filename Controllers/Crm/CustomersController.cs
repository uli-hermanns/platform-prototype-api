using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Platform.Api.Dtos.Crm;

namespace Platform.Api.Controllers.Crm
{
   [EnableQuery()]
   [ODataModel("api/crm")]
   public class CustomersController : ODataController
   {
      public IEnumerable<CustomerDto> Get()
      {
         yield return new CustomerDto { Key = "Schmitz", ParentKey = "Vater", Representative = new Dtos.Hrm.EmployeeDto { Key = "Uli" }, RepresentativeKey = "Uli" };
         yield return new CustomerDto { Key = "Müller", ParentKey = "Vater", Representative = new Dtos.Hrm.EmployeeDto { Key = "Ben" }, RepresentativeKey = "Ben" };
      }

      public CustomerDto Get(string key, string parentKey)
      {
         return this.Get().Single(dto => dto.Key == key && dto.ParentKey == parentKey);
      }

      public Dtos.Hrm.EmployeeDto GetRepresentative(string key)
      {
         return this.Get().First().Representative;
      }
   }
}