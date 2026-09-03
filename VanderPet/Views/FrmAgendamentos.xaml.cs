using VanderPet.Models;

namespace VanderPet.Views
{
    public partial class FrmAgendamentos : ContentPage
    {
        public FrmAgendamentos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            if (App.lstAgendamentos.Count > 0)
            {
                LayoutSemAgendamentos.IsVisible = false;
                CvAgendamentos.IsVisible = true;
                CvAgendamentos.ItemsSource = null;
                CvAgendamentos.ItemsSource = App.lstAgendamentos;
            }
            else
            {
                LayoutSemAgendamentos.IsVisible = true;
                CvAgendamentos.IsVisible = false;
            }
        }

        private async void OnCancelarAgendamentoClicked(object sender, EventArgs e)
        {
            var botao = sender as Button;
            var agendamento = botao?.CommandParameter as AgendamentoModel;

            if (agendamento != null)
            {
                bool confirmar = await DisplayAlertAsync(
                    "Cancelar Agendamento",
                    $"Deseja realmente cancelar o agendamento do {agendamento.NomePet} no dia {agendamento.Data:dd/MM/yyyy} às {agendamento.Horario}?",
                    "Sim, Cancelar",
                    "Voltar");

                if (confirmar)
                {
                    // Remove da lista estática global
                    App.lstAgendamentos.Remove(agendamento);

                    // Atualiza a tela imediatamente
                    AtualizarLista();

                    await DisplayAlertAsync("Sucesso", "Agendamento cancelado com sucesso!", "OK");
                }
            }
        }

        private async void OnNovoAgendamentoClicked(object? sender, EventArgs e)
        {
            if (App.lstPets.Count == 0)
            {
                await Navigation.PushAsync(new FrmAvisoPet());
            }
            else
            {
                await Navigation.PushAsync(new FrmNovoAgendamento());
            }
        }
    }
}