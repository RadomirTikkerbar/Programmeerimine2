using KooliProjekt.WinFormsApp.Api;

namespace KooliProjekt.WinFormsApp
{
    public interface IOrderView
    {
        IList<Order> Order { get; set; }
        Order SelectedItem { get; set; }
        string Title { get; set; }
        int Id { get; set; }
        OrderPresenter Presenter { get; set; }
    }
}
