using Humanizer;
using MathLearnerWasmApp.Services;
using Microsoft.AspNetCore.Components;

namespace MathLearnerWasmApp.Pages
{
    public class PageBaseGrid<TEntity> : PageBase 
        where TEntity : class
    {
        [Inject]
        public IService<TEntity>? Service { get; set; }
        protected IEnumerable<TEntity>? Items; 
        protected bool IsGridLoading;
        protected bool IsPageLoading {
            get { return Items == null; }
        }

        public PageBaseGrid()
        {
            PageTitle = typeof(TEntity).Name.Pluralize();
        }

        protected override async Task OnInitializedAsync()
        {
            await RefreshData();
        }

        public virtual async Task RefreshData()
        {
            IsGridLoading = true;

            if (Service != null)
            {
                Items = await Service.GetAll();
            }

            IsGridLoading = false;
        }

        protected bool IsActionDisabled()
        {
            return IsGridLoading || IsPageLoading;
        }
    }
}
