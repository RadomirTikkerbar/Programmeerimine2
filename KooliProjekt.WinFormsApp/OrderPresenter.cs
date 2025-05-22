using KooliProjekt.WinFormsApp.Api;

namespace KooliProjekt.WinFormsApp
{
    public class OrderPresenter
    {
        private readonly IApiClient _apiClient;
        private readonly IOrderView _orderView;
        private object @object;

        public object NewCommand { get; set; }
        public object SelectedItem { get; set; }
        public object SaveCommand { get; set; }
        public object DeleteCommand { get; set; }

        public OrderPresenter(IOrderView orderView, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _orderView = orderView;

            orderView.Presenter = this;
        }

        public OrderPresenter(object @object)
        {
            this.@object = @object;
        }

        public void UpdateView(Order list)
        {
            if (list == null)
            {
                _orderView.Title = string.Empty;
                _orderView.Id = 0;
            }
            else
            {
                _orderView.Id = list.Id;
                _orderView.Title = list.Title;
            }
        }

        public async Task Load()
        {
            var orderLists = await _apiClient.List();

            _orderView.Order = orderLists.Value;
        }
    }
}