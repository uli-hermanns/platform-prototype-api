using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Dtos = Platform.Api.Dtos;

namespace platform_prototype_api
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddControllers(mvcOptions => {
            // mvcOptions.EnableEndpointRouting = false;
         });
         services.AddOData();
      }

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
            endpoints.MapODataRoute("CRM", "crm", this.GetCrmEdmModel());
            endpoints.MapODataRoute("HRM", "hrm", this.GetHrmEdmModel());
         });
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
