using KooliProjekt.WinFormsApp.Api;
using Moq;

namespace KooliProjekt.WinFormsApp.UnitTests
{
    public class UnitTest1
    {
        private Mock<IApiClient> _apiClientMock;
        private Mock<IApiClient> _apiCliaentMock;
        private OrderPresenter _presenter;
        private object _persenter;

        public UnitTest1()
        {
            _apiCliaentMock = new Mock<IApiClient>();
            _presenter = new OrderPresenter(_apiCliaentMock.Object);
        }

        [Fact]
        public async Task Test1()
        {
            _presenter.NewCommand.Execute(null);
            _ = _presenter.SelectedItem.Id == 0;
        }

        [Fact]
        public async Task Test2()
        {
            _presenter.SaveCommand.Execute(null);
            _ = _persenter.SelectedItem.Id == 0;
        }

        [Fact]
        public async Task Test3()
        {
            _presenter.DeleteCommand.Execute(null);
            _ = _presenter.SelectedItem.Id == 0;
        }
    }
}