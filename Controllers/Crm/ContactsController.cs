using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
   public class ContactsController : ODataController
   {
      [HttpDelete]
      public void Delete(string key)
      {
      }

      [HttpGet]
      public IEnumerable<ContactDto> Get()
      {
         return
            from customerDto in CustomersController.customers
            from contactDto in customerDto.Contacts
            select contactDto;
      }

      [HttpGet]
      public ContactDto Get(string key)
      {
         var keys = key.Split("@");
         return CustomersController.customers.Where(customer => customer.Key == keys[1]).Single().Contacts.Where(contact => contact.Id == key).Single();
      }

      [HttpPost]
      public ContactDto Post([FromBody] ContactDto contact)
      {
         return contact;
      }
   }
}