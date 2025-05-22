using System.Diagnostics.CodeAnalysis;

namespace KooliProjekt.Data
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        [ExcludeFromCodeCoverage]
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}