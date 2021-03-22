using Microsoft.AspNetCore.Http;
using OrchardCore.ContentManagement;
using OrchardCore.Settings;
using System.Threading.Tasks;

namespace Etch.OrchardCore.ContextualEdit.Services
{
    public class ContextualEditService : IContextualEditService
    {
        #region Dependencies

        private readonly IContentHandleProvider _contentHandleProvider;
        private readonly IContentManager _contentManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISiteService _siteService;

        #endregion

        #region Constructor

        public ContextualEditService(IContentHandleProvider contentHandleProvider, IContentManager contentManager, IHttpContextAccessor httpContextAccessor, ISiteService siteService)
        {
            _contentHandleProvider = contentHandleProvider;
            _contentManager = contentManager;
            _httpContextAccessor = httpContextAccessor;
            _siteService = siteService;
        }

        #endregion

        #region Implementation

        public async Task<ContentItem> GetContentItemForRequestAsync()
        {
            var path = _httpContextAccessor.HttpContext.Request.Path.ToString();

            if (path == string.Empty || path == "/")
            {
                return await GetHomepageAsync();
            }

            var contentItemId = await _contentHandleProvider.GetContentItemIdAsync($"slug:{path}");

            if (string.IsNullOrEmpty(contentItemId))
            {
                return null;
            }

            return await _contentManager.GetAsync(contentItemId, VersionOptions.Latest);
        }

        #endregion

        #region Helper Methods

        public async Task<ContentItem> GetHomepageAsync()
        {
            var site = await _siteService.GetSiteSettingsAsync();
            var homeRoute = site.HomeRoute;
            var contentItemId = homeRoute["contentItemId"].ToString();

            return await _contentManager.GetAsync(contentItemId, VersionOptions.Latest);
        }

        #endregion
    }

    public interface IContextualEditService
    {
        Task<ContentItem> GetContentItemForRequestAsync();
    }
}
