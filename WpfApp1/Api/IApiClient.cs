namespace KooliProjekt.WpfApp.Api
{
    public interface IApiClient
    {
        Task<Result<List<Order>>> List();
        Task Save(Order list);
        Task Delete(int id);
    }
}