namespace KooliProjekt.WpfApp.Api
{
    public interface IApiClient
    {
        Task<IList<TodoList>> List();
        Task Save(TodoList list);
        Task Delete(int id);
    }
}