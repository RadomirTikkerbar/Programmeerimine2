using KooliProjekt.WpfApp.Api;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KooliProjekt.WpfApp
{
    public class MainWindowViewModel : IDisposable
    {
        private readonly IApiClient _apiClient;
        
        public ObservableCollection<TodoList> Lists { get; private set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public Predicate<TodoList> ConfirmDelete { get; set; }

        public MainWindowViewModel() : this(new ApiClient())
        { }

        public MainWindowViewModel(IApiClient apiClient)
        {
            _apiClient = apiClient;

            Lists = new ObservableCollection<TodoList>();
            SaveCommand = new RelayCommand<TodoList>(async list =>
            {
                // Execute method
                await _apiClient.Save(SelectedList);
            },list =>
            {
                // CanExecute method

                return SelectedList != null;
            });
            DeleteCommand = new RelayCommand<TodoList>(async _ =>
            {
                // Execute method
                if(ConfirmDelete != null)
                {
                    var result = ConfirmDelete(SelectedList);
                    if(!result)
                    {
                        return;
                    }
                }

                await _apiClient.Delete(SelectedList.Id);
                Lists.Remove(SelectedList);
            });
        }

        public async Task Load()
        {
            var lists = await _apiClient.List();
            foreach(var list in lists)
            {
                Lists.Add(list);
            }
        }

        public TodoList SelectedList 
        { 
            get; 
            set; 
        }

        public void Dispose()
        {
            if(_apiClient is IDisposable)
            {
                (_apiClient as IDisposable).Dispose();
            }
        }
    }
}
