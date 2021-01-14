using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
      public static CustomerDto[] customers = new[] {
         new CustomerDto {
            Key = "Schmitz",
            Representative = new Dtos.Hrm.EmployeeDto { Key = "Uli" },
            RepresentativeKey = "Uli",
            Contacts = new [] { new ContactDto {  Key = "Ingrid", ParentKey = "Schmitz"} }
         },
         new CustomerDto {
            Key = "Müller",
            Representative = new Dtos.Hrm.EmployeeDto { Key = "Ben" }, RepresentativeKey = "Ben"
         }
      };

      [HttpGet]
      public IEnumerable<CustomerDto> Get()
      {
         return CustomersController.customers;
      }

      public CustomerDto Get(string key)
      {
         return this.Get().Single(dto => dto.Key == key);
      }

      [HttpGet]
      public ContactDto GetContactFromCustomer(string key, string contactKey)
      {
         return this.Get(key).Contacts.Where(contact => contact.Key == contactKey).Single();
      }

      [HttpGet]
      [ODataRoute("customers({key})/contacts")]
      public ContactDto[] GetContacts(string key)
      {
         return this.Get(key).Contacts;
      }

      [HttpGet]
      [ODataRoute("customers({key})/representative")]
      public Dtos.Hrm.EmployeeDto GetRepresentative(string key)
      {
         return this.Get(key).Representative;
      }
   }
}