using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MathLearnerWasmApp.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        [Inject]
        protected ISnackbar? Snackbar { get; set; }
        
        protected string EntityName = string.Empty;
        protected string PageTitle = string.Empty;
        protected string PageArea = string.Empty;
    }
}
