using System;

namespace Platform.Api.Dtos
{
   public abstract class Dto<TParentKey, TKey> : Dto<TKey>
   {
      public TParentKey ParentKey { get; set; }
   }
}