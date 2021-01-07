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
      public GroupDto Group { get; set; }

      [Key]
      public override string Key { get; set; }

      public string RepresentativeKey { get; set; }

      [Contained]
      public EmployeeDto Representative { get; set; }
   }
}