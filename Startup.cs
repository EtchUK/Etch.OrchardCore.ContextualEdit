using Etch.OrchardCore.ContextualEdit.Drivers;
using Etch.OrchardCore.ContextualEdit.Models;
using Etch.OrchardCore.ContextualEdit.Services;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Etch.OrchardCore.ContextualEdit
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContentPartDisplayDriver, ContextualEditPartDisplay>();

            services.AddSingleton<ContentPart, ContextualEditPart>();

            services.AddScoped<IContextualEditService, ContextualEditService>();

            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}
