using Microsoft.AspNetCore.Components;

namespace MathLearnerWasmApp.Shared.Templates
{
    public class TemplateBase : ComponentBase
    {
        [Parameter]
        public bool IsPageLoading { get; set; } = true;

        [Parameter]
        public string PageTitle { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment? MainContent { get; set; } = null;
    }
}
