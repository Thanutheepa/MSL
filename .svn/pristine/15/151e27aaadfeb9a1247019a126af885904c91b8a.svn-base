using BlazorServerApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppinCart.DataStore;
using ShoppingCart.UseCases.CartScreen;
using ShoppingCart.UseCases.LoginScreen;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using ShoppingCart.UseCases.SearchProductScreen;
using ShoppingCart.UseCases.ViewProductScreen;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.UseCases.RegisterScreen;
using Radzen;
using ShoppingCart.UseCases.FavProductScreen;

namespace BlazorServerApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        string testApi = "";
        string liveApi = "";
        string apiType = "";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            testApi = Configuration.GetValue<string>("ApiLinks:test");
            liveApi = Configuration.GetValue<string>("ApiLinks:live");
            apiType = Configuration.GetValue<string>("ApiLinks:type");
        }

        public string GetAPI()
        {
            if(apiType == "live")
                return liveApi;
            else
                return testApi;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.Configure<AppSettings>(Configuration.GetSection(AppSettings.sectionName));
            services.Configure<AppSettingsUSD>(Configuration.GetSection(AppSettingsUSD.sectionName));
            services.Configure<AppSettingsApi>(Configuration.GetSection(AppSettingsApi.sectionName));
            services.Configure<AppSettingsEmail>(Configuration.GetSection(AppSettingsEmail.sectionName));
            services.AddScoped<AppState>();
            services.AddHttpClient<IPaymentService, PaymentService>();
            services.AddHttpClient<IApiService, ApiService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });
            services.AddHttpClient<IProductService, ProductService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });
            services.AddHttpClient<ICategoryService, CategoryService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });
            services.AddHttpClient<IOutletService, OutletService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });
            services.AddScoped<ICartService, CartService>();
            services.AddBlazoredLocalStorage();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IFavProductRepository, FavProductRepository>();

            services.AddTransient<ISearchProduct, SearchProduct>();
            services.AddTransient<IViewProduct, ViewProduct>();
            services.AddTransient<ICart, Cart>();
            services.AddTransient<IFavProduct, FavProduct>();
            services.AddTransient<ISendEmails, SendEmails>();
            services.AddTransient<Security>();
            // services.AddTransient<ILogin, Login>();

            // services.AddTransient<IRegister, Register>();
            services.AddScoped<IRegister, Register>();
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<PostFormService>();

            services.AddHttpClient<IRegisterService, RegisterService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });

            services.AddScoped<ILogin, Login>();

            services.AddHttpClient<IProfileService, ProfileService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });

            services.AddHttpClient<ISupportUsService,SupportUsService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

           // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/sitemap.xml", async context => {
                    await Sitemap.Generate(context);
                });

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
