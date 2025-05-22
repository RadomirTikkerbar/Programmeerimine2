using KooliProjekt.WpfApp;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.UnitTests
{
    public class MainWindowViewModelITests
    {
        private Mock<IApiClient> _apiCliaentMock;
        private MainWindowViewModel _viewModel;

        public MainWindowViewModelITests()
        {
            _apiCliaentMock = new Mock<IApiClient>();
            _viewModel = new MainWindowViewModel(_apiCliaentMock.Object);
        }
        [Fact]
        public async Task Test1()
        {
            _viewModel.NewCommand.Execute(null);
            _ = _viewModel.SelectedItem.Id == 0;
        }

        [Fact]
        public async Task Test2()
        {
            _viewModel.SaveCommand.Execute(null);
            _ = _viewModel.SelectedItem.Id == 0;
        }

        [Fact]
        public async Task Test3()
        {
            _viewModel.DeleteCommand.Execute(null);
            _ = _viewModel.SelectedItem.Id == 0;
        }
    }

}