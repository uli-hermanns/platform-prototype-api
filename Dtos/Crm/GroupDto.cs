using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Api.Dtos.Crm
{
   public class GroupDto : Dto<string>
   {
      [Key]
      public override string Key { get; set; }
   }
}
