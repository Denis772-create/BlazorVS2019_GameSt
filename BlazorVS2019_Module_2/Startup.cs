using BlazorVS2019_Module_2.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorVS2019_Module_2.Data.Propository;
using Tewr.Blazor.FileReader;

namespace BlazorVS2019_Module_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor(options =>
            {
                options.DetailedErrors = false;                                      // Отправка подробных сообщений об исключениях в JavaScript
                options.DisconnectedCircuitMaxRetained = 100;                        // Максимальное число отключенных каналов, которые сервер удерживает в памяти за один раз.
                options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);// Максимальное время, в течение которого отключенный канал удерживается в памяти,
                options.MaxBufferedUnacknowledgedRenderBatches = 10;                 // Максимальное число неподтвержденных пакетов преобразования для просмотра
                options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);       // Максимальное время ожидания сервера до истечения времени ожидания асинхронного вызова функции JavaScript.
            })
                .AddHubOptions(options =>
                {
                    options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
                    options.EnableDetailedErrors = false;
                    options.HandshakeTimeout = TimeSpan.FromSeconds(15);
                    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
                    options.MaximumParallelInvocationsPerClient = 1;
                    options.MaximumReceiveMessageSize = 32 * 1024;
                    options.StreamBufferCapacity = 10; 
                });
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<IRepository, GameRepository>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
