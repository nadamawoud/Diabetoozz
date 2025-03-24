using Diabetes.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Diabetes.APIs
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Configure Services  Add services to the container
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion


            var app = builder.Build();

            #region Update-Database
            //FinalContext dbcontext = new FinalContext();//invalid
            // await dbcontext.Database.MigrateAsync();

            using var Scope = app.Services.CreateScope();
            //group of services lifetime scoped
            var Services = Scope.ServiceProvider;
            //Services its self

            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
               
                var DbContext = Services.GetRequiredService<StoreContext>();
                //ASK for creating obj from dbcontext explicilty
                await DbContext.Database.MigrateAsync();//uplode-database
            }
            catch (Exception ex) 
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "an error occured during appling the migration");
            }


            #endregion


            #region Configure - Configure the HTTP request pipeline
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion
            app.Run();
        }



    }
}
