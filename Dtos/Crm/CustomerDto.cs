using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Platform.Api.Dtos.Hrm;

namespace Platform.Api.Dtos.Crm
{
   public class CustomerDto : Dto<string>
   {
      [Key]
      public override string Key { get; set; }

      public GroupDto Group { get; set; }

      public EmployeeDto Representative { get; set; }
   }
}
