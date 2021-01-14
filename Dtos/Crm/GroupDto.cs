namespace Platform.Api.Dtos.Crm
{
   public class GroupDto : Dto<string>
   {
      public override string Id
      {
         get
         {
            return this.Key;
         }
         set
         {
            this.Key = value;
         }
      }
   }
}