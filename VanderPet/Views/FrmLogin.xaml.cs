namespace VanderPet.Views
{
    public partial class FrmLogin : ContentPage
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        // Entrar -> Navega direto para a tela de Agendamentos (simulando login com sucesso)
        private async void OnEntrarClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmAgendamentos());
        }

        // Cadastrar -> Abre a tela visual de Cadastro
        private async void OnCadastrarClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrmCadastro());
        }

        private async void OnEsqueciSenhaClicked(object? sender, EventArgs e)
        {
            await DisplayAlertAsync("Esqueci minha senha", "Instruções enviadas para o e-mail cadastrado.", "OK");
        }
    }
}