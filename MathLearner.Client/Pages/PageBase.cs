using Microsoft.AspNetCore.Components;

namespace MathLearnerWasmApp.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager? NavigationManager { get; set; }
        protected string PageTitle = string.Empty;
    }
}
