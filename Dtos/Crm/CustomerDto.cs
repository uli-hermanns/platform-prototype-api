using Microsoft.OData.ModelBuilder;

namespace Platform.Api.Dtos.Crm
{
   public class CustomerDto : Dto<string>
   {
      public ContactDto[] Contacts { get; set; } = new ContactDto[0];

      public GroupDto Group { get; set; }

      public override string Id
      {
         get
         {
            return this.Key;
         }
         set
         {
            this.Key = value;
         }
      }

      [Contained]
      public Hrm.EmployeeDto Representative { get; set; }

      public string RepresentativeKey { get; set; }
   }
}