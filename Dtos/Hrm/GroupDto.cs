using System.ComponentModel.DataAnnotations;

namespace Platform.Api.Dtos.Hrm
{
   public class GroupDto : Dto<string>
   {
      [Key]
      public override string Key { get; set; }
   }
}