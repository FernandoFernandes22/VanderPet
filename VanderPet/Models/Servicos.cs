using System;
using System.Collections.Generic;
using System.Text;

namespace VanderPet.Models
{
    public class Servicos
    {

        public int Id { get; set; }

        public string Servico { get; set; } = string.Empty;

        public decimal Preco { get; set; } = decimal.Zero;

        public decimal Tempo {  get; set; } = decimal.Zero;
    }
}
