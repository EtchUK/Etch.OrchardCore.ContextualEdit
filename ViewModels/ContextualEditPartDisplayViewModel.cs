using OrchardCore.ContentManagement;

namespace Etch.OrchardCore.ContextualEdit.ViewModels
{
    public class ContextualEditPartDisplayViewModel
    {
        private ContentItem _contentItem { get; set; }

        public ContentItem ContentItem
        {
            get { return _contentItem; }
            set { _contentItem = value; }
        }
    }
}
