namespace VanderPet.Models
{
    public class PetModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public string Raca { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; } = string.Empty;
    }

    public class AgendamentoModel
    {
        public string NomePet { get; set; } = string.Empty;
        public string Porte { get; set; } = string.Empty;
        public string Servico { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Horario { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}