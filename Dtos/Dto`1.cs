using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Api.Dtos
{
   public abstract class Dto<TKey>
   {
      public abstract TKey Key { get; set; }
   }
}
