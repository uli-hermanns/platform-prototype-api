using System.ComponentModel.DataAnnotations;

namespace Platform.Api.Dtos.Hrm
{
   public class EmployeeDto : Dto<string>
   {
      public GroupDto Group { get; set; }

      [Key]
      public override string Key { get; set; }
   }
}