using MINT_WebAPI.Managers;
using MINT_WebAPI.Managers.BrandManaging;
using MINT_WebAPI.Managers.CategoryManaging;


namespace MINT_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IBrandManager, BrandManager>();
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}