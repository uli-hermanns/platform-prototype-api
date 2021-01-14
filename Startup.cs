using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Platform.Api
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddRouting();
         services.AddOData(options =>
         {
            options
               .Filter().Select().OrderBy().Count().SkipToken().Expand()
               .AddModel("api/crm", this.GetCrmEdmModel())
               .AddModel("api/hrm", this.GetHrmEdmModel());
         });
      }

      public IEdmModel GetCrmEdmModel()
      {
         var builder = new ODataConventionModelBuilder();
         builder.EntitySet<Dtos.Crm.CustomerDto>("Customers");
         builder.EntitySet<Dtos.Crm.GroupDto>("Groups");
         // builder.EnableLowerCamelCase();

         return builder.GetEdmModel();
      }

      public IEdmModel GetHrmEdmModel()
      {
         var builder = new ODataConventionModelBuilder();
         builder.EntitySet<Dtos.Hrm.EmployeeDto>("Employees");
         builder.EntitySet<Dtos.Hrm.GroupDto>("Groups");
         // builder.EnableLowerCamelCase();

         return builder.GetEdmModel();
      }
   }
}