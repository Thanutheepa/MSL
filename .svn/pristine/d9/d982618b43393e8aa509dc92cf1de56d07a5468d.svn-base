using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class Sitemap
    {
        public static async Task Generate(HttpContext context)
        {
            var pages = Assembly.GetExecutingAssembly().ExportedTypes.Where(p =>
                p.IsSubclassOf(typeof(ComponentBase)) && p.Namespace == "your namespace.Pages");

            foreach (var page in pages)
            {
                // Do whatever you want with the page components, e.g. show it's name:
                await context.Response.WriteAsync(page.FullName + "\n");

                // From here you can access most part of the static info about the         
                //component,
                // but if you want to get the page titles or similar info, you'll have to 
                //create
                // some custom attributes and decorate the pages with them.
            }
        }
    }
}
