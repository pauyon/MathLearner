using Humanizer;

namespace MathLearnerWasmApp.Pages
{
    public class PageBaseGrid<TEntity> : PageBase where TEntity : class
    {
        protected IEnumerable<TEntity>? Items; 
        protected bool IsGridLoading;
        protected bool IsPageLoading {
            get { return Items == null; }
        }

        public PageBaseGrid()
        {
            PageTitle = typeof(TEntity).Name.Pluralize();
        }
    }
}
