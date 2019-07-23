using Etch.OrchardCore.ContextualEdit.Models;
using Etch.OrchardCore.ContextualEdit.Services;
using Etch.OrchardCore.ContextualEdit.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Settings;
using System.Threading.Tasks;
using Contents = OrchardCore.Contents;

namespace Etch.OrchardCore.ContextualEdit.Drivers
{
    public class ContextualEditPartDisplay : ContentPartDisplayDriver<ContextualEditPart>
    {
        #region Dependencies

        private readonly IAuthorizationService _authorizationService;
        private readonly IContextualEditService _contextualEditService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Constructor

        public ContextualEditPartDisplay(IAuthorizationService authorizationService, IContextualEditService contextualEditService, IHttpContextAccessor httpContextAccessor)
        {
            _authorizationService = authorizationService;
            _contextualEditService = contextualEditService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Overrides

        public override async Task<IDisplayResult> DisplayAsync(ContextualEditPart part, BuildPartDisplayContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            
            if (user == null)
            {
                return null;
            }

            var contentItem = await _contextualEditService.GetContentItemForRequestAsync();

            if (contentItem == null || !await _authorizationService.AuthorizeAsync(user, Contents.Permissions.EditContent, contentItem))
            {
                return null;
            }

            return Initialize<ContextualEditPartDisplayViewModel>("ContextualEditPart", model => {
                model.ContentItem = contentItem;
            }).Location("Content:10");
        }

        #endregion
    }
}
