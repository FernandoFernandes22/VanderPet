namespace VanderPet.Views
{
    public partial class FrmCadastro : ContentPage
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private async void OnCadastrarClicked(object? sender, EventArgs e)
        {
            await DisplayAlertAsync("Sucesso", "Cadastro realizado com sucesso!", "OK");
            await Navigation.PopAsync();
        }

        private async void OnVoltarClicked(object? sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}