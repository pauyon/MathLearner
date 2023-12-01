using Humanizer;
using MathLearnerWasmApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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
            EntityName = typeof(TEntity).Name;
            PageTitle = EntityName.Pluralize();
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

        public virtual async Task DeleteEntity(TEntity entity)
        {
            var isDeleted = await Service!.Delete(entity);

            if (isDeleted)
            {
                Snackbar!.Add($"Successfully deleted {EntityName.ToLower()}", Severity.Success);
                await RefreshData();
            }
            else
            {
                Snackbar!.Add($"There was an error deleting {EntityName.ToLower()}", Severity.Error);
            }
        }

        protected bool IsActionDisabled()
        {
            return IsGridLoading || IsPageLoading;
        }
    }
}
