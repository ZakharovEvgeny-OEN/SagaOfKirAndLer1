using SagaOfKirAndLer.DataBase.Context;
using SagaOfKirAndLer.DataBase.Controller;
using SagaOfKirAndLer.Service;

namespace SagaOfKirAndLer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();
            
            builder.Services.AddSingleton<DbGameContext>();
            builder.Services.AddSingleton<DbController>();
            builder.Services.AddSingleton<ServiceGame>();

            builder.Services.AddSession();
            // Add services to the container.
           
           

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();
            app.Use(
                async (context, next) =>
                {
                    if (context.Request.Path == "/")
                    {
                        context.Response.Redirect("Registration/RegistrationPage");
                        return;
                    }
                    await next.Invoke();
                }
                );

            app.Run();
        }
    }
}
