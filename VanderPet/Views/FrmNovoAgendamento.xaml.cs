using VanderPet.Models;

namespace VanderPet.Views
{
    public partial class FrmNovoAgendamento : ContentPage
    {
        public FrmNovoAgendamento()
        {
            InitializeComponent();
            ConfigurarLimitesData();
            CarregarHorariosDisponiveis();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarregarPets(); // Recarrega os pets sempre que a tela aparece
        }

        private void ConfigurarLimitesData()
        {
            DtAgendamento.MinimumDate = DateTime.Today.AddDays(1);
            DtAgendamento.MaximumDate = DateTime.Today.AddMonths(1);
            DtAgendamento.Date = DateTime.Today.AddDays(1);
        }

        private void CarregarPets()
        {
            var listaExibicao = App.lstPets.Select(p => p.Nome).ToList();

            // Adiciona a opção de cadastrar um novo pet no final do Picker
            listaExibicao.Add("+ Cadastrar Novo Pet");

            PckPet.ItemsSource = listaExibicao;
        }

        private async void OnPetSelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckPet.SelectedItem?.ToString() == "+ Cadastrar Novo Pet")
            {
                // Reseta a seleção para não ficar travado na opção de cadastrar
                PckPet.SelectedIndex = -1;

                // Abre a tela de cadastro de pet
                await Navigation.PushAsync(new FrmCadastroPet());
            }
        }

        private void CarregarHorariosDisponiveis()
        {
            PckHorarios.ItemsSource = new List<string>
            {
                "08:00",
                "09:30",
                "11:00",
                "13:30",
                "15:00",
                "16:30"
            };
        }

        private void OnDataSelecionada(object sender, DateChangedEventArgs e)
        {
            CarregarHorariosDisponiveis();
        }

        private async void OnConfirmarClicked(object? sender, EventArgs e)
        {
            if (PckPet.SelectedItem == null || PckPorte.SelectedItem == null || PckHorarios.SelectedItem == null)
            {
                await DisplayAlertAsync("Aviso", "Preencha todos os campos do agendamento.", "OK");
                return;
            }

            decimal valor = 40;
            string porteStr = PckPorte.SelectedItem.ToString() ?? "";
            if (porteStr.Contains("Médio")) valor = 60;
            else if (porteStr.Contains("Grande")) valor = 80;

            App.lstAgendamentos.Add(new AgendamentoModel
            {
                NomePet = PckPet.SelectedItem.ToString() ?? "",
                Porte = porteStr,
                Servico = PckServico.SelectedItem?.ToString() ?? "Banho e Tosa",
                Data = DtAgendamento.Date ?? DateTime.Today,
                Horario = PckHorarios.SelectedItem.ToString() ?? "",
                Observacao = TxtObservacao.Text,
                Valor = valor
            });

            await DisplayAlertAsync("Sucesso", "Agendamento realizado com sucesso!", "OK");

            var navegacao = Navigation.NavigationStack;
            for (int i = navegacao.Count - 2; i > 0; i--)
            {
                if (navegacao[i] is not FrmAgendamentos)
                {
                    Navigation.RemovePage(navegacao[i]);
                }
                else
                {
                    break;
                }
            }

            await Navigation.PopAsync();
        }

        private async void OnCancelarClicked(object? sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}