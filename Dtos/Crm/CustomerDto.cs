﻿using System.ComponentModel.DataAnnotations;
using Microsoft.OData.ModelBuilder;

namespace Platform.Api.Dtos.Crm
{
   public class CustomerDto : Dto<string>
   {
      public GroupDto Group { get; set; }

      [Key]
      public override string Key { get; set; }

      [Key]
      public string ParentKey { get; set; }

      [Contained]
      public Hrm.EmployeeDto Representative { get; set; }

      public string RepresentativeKey { get; set; }
   }
}