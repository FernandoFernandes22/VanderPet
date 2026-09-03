namespace VanderPet.Views
{
    public partial class FrmConfirmacao : ContentPage
    {
        public FrmConfirmacao()
        {
            InitializeComponent();
        }

        private async void OnOkClicked(object? sender, EventArgs e)
        {
            // Retorna para a tela inicial de Agendamentos
            await Navigation.PopToRootAsync();
        }
    }
}