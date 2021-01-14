namespace Platform.Api.Dtos
{
   public abstract class Dto<TKey>
   {
      public abstract TKey Key { get; set; }
   }
}