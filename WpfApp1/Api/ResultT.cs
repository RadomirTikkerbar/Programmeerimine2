using KooliProjekt.WpfApp.Api;

namespace KooliProject.WpfApp.Api
{
    public class Result <T> : Result
    {
        public T Value { get; set; }
    }
}
