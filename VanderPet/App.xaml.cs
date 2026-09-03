using Microsoft.Extensions.DependencyInjection;
using VanderPet.Models;

namespace VanderPet
{
    public partial class App : Application
    {
        // Listas globais com dados pré-cadastrados para testes
        public static List<PetModel> lstPets = new List<PetModel>
        {
            new PetModel
            {
                Nome = "Thor",
                Especie = "Cachorro",
                Raca = "Golden Retriever",
                DataNascimento = new DateTime(2022, 5, 10),
                Sexo = "Macho"
            }
        };

        public static List<AgendamentoModel> lstAgendamentos = new List<AgendamentoModel>
        {
            new AgendamentoModel
            {
                NomePet = "Thor",
                Porte = "Grande Porte - R$ 80,00",
                Servico = "Banho e Tosa (Completo)",
                Data = DateTime.Today.AddDays(2),
                Horario = "14:00",
                Observacao = "Pet amigável, cuidado com as orelhas.",
                Valor = 80
            }
        };

        public List<Servicos> lstServicos = new List<Servicos>
        {
            new Servicos() { Id = 1, Servico = "Banho pequeno", Preco = 40, Tempo = 30m },
            new Servicos() { Id = 2, Servico = "Banho médio", Preco = 60, Tempo = 45m },
            new Servicos() { Id = 3, Servico = "Banho grande", Preco = 80, Tempo = 60m },
        };

        public List<Especies> lstEspecies = new List<Especies>
        {
            new Especies() { Id = 1, Especie = "Mamifero" },
            new Especies() { Id = 2, Especie = "Ave" },
            new Especies() { Id = 3, Especie = "Reptil" },
        };

        public List<Racas> lstRacas = new List<Racas>
        {
            new Racas() { Id = 1, Raca = "Cachorro", EspecieId = 1 },
            new Racas() { Id = 2, Raca = "Gato", EspecieId = 1 },
            new Racas() { Id = 3, Raca = "Papagaio", EspecieId = 2 },
            new Racas() { Id = 4, Raca = "Tartaruga", EspecieId = 3 },
        };

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.FrmLogin());
        }

        protected override Microsoft.Maui.Controls.Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 375;
            window.Height = 812;
            return window;
        }
    }
}