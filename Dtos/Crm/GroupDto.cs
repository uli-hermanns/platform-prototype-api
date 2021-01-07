using System.ComponentModel.DataAnnotations;

namespace Platform.Api.Dtos.Crm
{
   public class GroupDto : Dto<string>
   {
      [Key]
      public override string Key { get; set; }
   }
}