using Humanizer;
using MathLearnerWasmApp.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MathLearnerWasmApp.Pages
{
    public class PageBaseDetails<TEntity> : PageBase
        where TEntity : class, new()
    {
        [Parameter]
        public int? EntityId { get; set; }

        [Inject]
        public IService<TEntity>? Service { get; set; }
        protected TEntity Entity = new();
        protected bool IsPageLoading;
        protected bool IsSaved;

        protected bool IsNewEntity
        {
            get
            {
                return EntityId == null;
            }
        }

        public PageBaseDetails()
        {
            EntityName = typeof(TEntity).Name;
            PageTitle = EntityName + " Details";
        }

        protected override async Task OnInitializedAsync()
        {
            await RefreshData();
        }

        public virtual async Task RefreshData()
        {
            IsPageLoading = true;

            if (Service != null && !IsNewEntity)
            {
                Entity = await Service.GetById(EntityId.GetValueOrDefault());
            }

            IsPageLoading = false;
        }

        protected async Task InsertUpdate()
        {
            if (IsNewEntity)
            {
                var result = await Service!.Add(Entity);

                if (result != null)
                {
                    Snackbar!.Add($"Successfully saved {EntityName.ToLower()}", Severity.Success);
                    NavigationManager!.NavigateTo($"/admin/{EntityName.Pluralize().ToLower()}");
                }
            }
            else
            {
                IsSaved = await Service!.Update(Entity);

                if (IsSaved)
                {
                    Snackbar!.Add($"Successfully updated {EntityName.ToLower()}", Severity.Success);
                }
                else
                {
                    Snackbar!.Add($"There was an issue updating {EntityName.ToLower()}", Severity.Error);
                }
            }
        }

        protected bool IsActionDisabled()
        {
            return IsPageLoading;
        }
    }
}
