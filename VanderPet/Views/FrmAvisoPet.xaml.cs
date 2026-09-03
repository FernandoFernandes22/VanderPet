namespace VanderPet.Views
{
    public partial class FrmAvisoPet : ContentPage
    {
        public FrmAvisoPet()
        {
            InitializeComponent();
        }

        private async void OnCadastrarPetClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmCadastroPet());
        }

        private async void OnVoltarClicked(object? sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}