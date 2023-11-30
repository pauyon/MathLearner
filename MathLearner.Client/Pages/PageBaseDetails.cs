using MathLearnerWasmApp.Services;
using Microsoft.AspNetCore.Components;

namespace MathLearnerWasmApp.Pages
{
    public class PageBaseDetails<TEntity> : PageBase
        where TEntity : class, new()
    {
        [Parameter]
        public int EntityId { get; set; }

        [Inject]
        public IService<TEntity>? Service { get; set; }
        protected TEntity? Entity;
        protected bool IsPageLoading;

        public PageBaseDetails()
        {
            PageTitle = typeof(TEntity).Name + " Details";
        }

        protected override async Task OnInitializedAsync()
        {
            await RefreshData();
        }

        public virtual async Task RefreshData()
        {
            IsPageLoading = true;

            if (Service != null)
            {
                Entity = await Service.GetById(EntityId);
            }

            IsPageLoading = false;
        }

        protected bool IsActionDisabled()
        {
            return IsPageLoading;
        }
    }
}
