namespace Platform.Api.Dtos
{
   public abstract class Dto<TKey> : Dto
   {
      public TKey Key { get; set; }
   }
}