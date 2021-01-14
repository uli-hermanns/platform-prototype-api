namespace Platform.Api.Dtos.Hrm
{
   public class EmployeeDto : Dto<string>
   {
      public GroupDto Group { get; set; }

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