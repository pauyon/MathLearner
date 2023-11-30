using MathLearnerWasmApp.Services;
using Microsoft.AspNetCore.Components;

namespace MathLearnerWasmApp.Pages
{
    public class PageBaseDetails<TEntity> : PageBase
        where TEntity : class, new()
    {
        [Parameter]
        public int? EntityId { get; set; }

        [Inject]
        public IService<TEntity>? Service { get; set; }
        protected TEntity? Entity;
        protected bool IsPageLoading;
        protected bool IsNewEntity
        {
            get
            {
                return EntityId == null;
            }
        }

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

            if (Service != null && !IsNewEntity)
            {
                Entity = await Service.GetById(EntityId.GetValueOrDefault());
            }

            IsPageLoading = false;
        }

        public virtual async Task InsertUpdate(TEntity entity)
        {
            if (IsNewEntity)
            {
                await Service!.Add(entity);
            }
            else
            {
                await Service!.Update(entity);
            }
        }

        protected bool IsActionDisabled()
        {
            return IsPageLoading;
        }
    }
}
