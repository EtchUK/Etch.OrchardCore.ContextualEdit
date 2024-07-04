using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Recipes.Services;
using System.Threading.Tasks;

namespace Etch.OrchardCore.ContextualEdit
{
    public class Migrations : DataMigration
    {
        #region Dependencies

        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IRecipeMigrator _recipeMigrator;

        #endregion

        #region Constructor

        public Migrations(IContentDefinitionManager contentDefinitionManager, IRecipeMigrator recipeMigrator)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _recipeMigrator = recipeMigrator;
        }

        #endregion

        public async Task<int> CreateAsync()
        {
            #region Contextual Edit Part

            await _contentDefinitionManager.AlterPartDefinitionAsync("ContextualEditPart", part => part
                .WithDescription("When authorised, displays edit control for current page.")
                .WithDisplayName("Contextual Edit"));

            #endregion

            #region Run Recipe

            await _recipeMigrator.ExecuteAsync("create.recipe.json", this);

            #endregion

            return 1;
        }
    }
}
