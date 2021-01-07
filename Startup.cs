using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter.Deserialization;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData;
using Microsoft.OData.Edm;

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
            endpoints.Select().Filter().Expand();

            endpoints.MapODataRoute("CRM", "api/crm",
              builder =>
              {
                 builder.AddService(Microsoft.OData.ServiceLifetime.Singleton, sp => this.GetCrmEdmModel());
                 builder.AddService<IEnumerable<IODataRoutingConvention>>(Microsoft.OData.ServiceLifetime.Singleton,
                     sp => ODataRoutingConventions.CreateDefaultWithAttributeRouting("CRM", endpoints.ServiceProvider));
              });

            /*
            endpoints.MapODataRoute("CRM", "api/crm", this.GetCrmEdmModel());
            */
            endpoints.MapODataRoute("HRM", "api/hrm", this.GetHrmEdmModel());
         });
      }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddRouting();
         services.AddControllers();
         services.AddOData();
      }

      public IEdmModel GetCrmEdmModel()
      {
         var builder = new ODataConventionModelBuilder();
         builder.EntitySet<Dtos.Crm.CustomerDto>("Customers");
         builder.EntitySet<Dtos.Crm.GroupDto>("Groups");

         return builder.GetEdmModel();
      }

      public IEdmModel GetHrmEdmModel()
      {
         var builder = new ODataConventionModelBuilder();
         builder.EntitySet<Dtos.Hrm.EmployeeDto>("Employees");
         builder.EntitySet<Dtos.Hrm.GroupDto>("Groups");

         return builder.GetEdmModel();
      }
   }
}