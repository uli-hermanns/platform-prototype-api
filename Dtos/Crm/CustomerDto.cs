using System.ComponentModel.DataAnnotations;
using Microsoft.OData.ModelBuilder;
using Platform.Api.Dtos.Hrm;

namespace Platform.Api.Dtos.Crm
{
   public class CustomerDto : Dto<string>
   {
      public GroupDto Group { get; set; }

      [Key]
      public override string Key { get; set; }

      [Contained]
      public EmployeeDto Representative { get; set; }

      public string RepresentativeKey { get; set; }
   }
}