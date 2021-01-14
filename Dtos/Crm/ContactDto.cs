using System;
using System.ComponentModel.DataAnnotations;

namespace Platform.Api.Dtos.Crm
{
   public class ContactDto : Dto<string, string>
   {
      public override string Id
      {
         get
         {
            return string.Concat(Uri.EscapeDataString(this.Key), "@", Uri.EscapeDataString(this.ParentKey));
         }
         set
         {
            var keys = value.Split("@");
            this.Key = keys[0];
            this.ParentKey = keys[1];
         }
      }
   }
}