using KooliProjekt.WinFormsApp.Api;

namespace KooliProjekt.WinFormsApp
{
    public partial class Form1 : Form, IOrderView
    {
        public IList<Order> Order
        {
            get => (IList<Order>)OrderGrid.DataSource;
            set
            {
                OrderGrid.DataSource = value;
            }
        }

        public Order SelectedItem { get; set; }

        public OrderPresenter Presenter { get; set; }

        public string Title
        {
            get
            {
                return TitleField.Text; ;
            }
            set
            {
                TitleField.Text = value;
            }
        }

        public int Id
        {
            get
            {
                return int.Parse(IdField.Text);
            }
            set
            {
                IdField.Text = value.ToString();
            }
        }

        public Form1()
        {
            InitializeComponent();

            OrderGrid.AutoGenerateColumns = true;
            OrderGrid.SelectionChanged += TodoListsGrid_SelectionChanged;

            NewButton.Click += AddButton_Click;
            SaveButton.Click += SaveButton_Click;
            DeleteButton.Click += DeleteButton_Click;

            Load += Form1_Load;
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            // Kutsu presenteri Delete meetodi
            // Lae andmed uuesti
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            // Kutsu presenteri Save meetodi
            // Lae andmed uuesti
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            // Kutsu presenteri UpdateView meetodi
        }

        private void TodoListsGrid_SelectionChanged(object? sender, EventArgs e)
        {
            if (OrderGrid.SelectedRows.Count == 0)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = (Order)OrderGrid.SelectedRows[0].DataBoundItem;
            }

            Presenter.UpdateView(SelectedItem);
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            await Presenter.Load();
        }

        private void IdField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
