namespace Platform.Api.Dtos.Hrm
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