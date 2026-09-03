using VanderPet.Models;

namespace VanderPet.Views
{
    public partial class FrmCadastroPet : ContentPage
    {
        public FrmCadastroPet()
        {
            InitializeComponent();
        }

        private async void OnCadastrarClicked(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNomePet.Text))
            {
                await DisplayAlertAsync("Aviso", "Por favor, informe o nome do Pet.", "OK");
                return;
            }

            // Adiciona o novo Pet na lista global
            App.lstPets.Add(new PetModel
            {
                Nome = TxtNomePet.Text,
                Especie = PckEspecie.SelectedItem?.ToString() ?? "Cachorro",
                Raca = TxtRaca.Text,
                DataNascimento = DtNascimento.Date ?? DateTime.Today,
                Sexo = PckSexo.SelectedItem?.ToString() ?? "Macho"
            });

            await DisplayAlertAsync("Sucesso", "Pet cadastrado com sucesso!", "OK");

            // Abre a tela de Novo Agendamento
            await Navigation.PushAsync(new FrmNovoAgendamento());
        }

        private async void OnCancelarClicked(object? sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}