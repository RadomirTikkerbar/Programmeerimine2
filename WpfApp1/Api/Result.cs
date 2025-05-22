
namespace KooliProjekt.WpfApp.Api
{
    public class Result<T>
    {
        public string Error { get; set; }
        public bool HasError
        { get 
            { 
            return !string.IsNullOrEmpty(Error);
            }
        }

        public List<Order>? Value { get; internal set; }
    }
}