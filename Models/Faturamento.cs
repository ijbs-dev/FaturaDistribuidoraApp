using System.Composition;

namespace DistribuidoraAPI.Models  // Verifique se o namespace está correto
{
   public class Faturamento
    {
        // Definir chave primária
        public int Id { get; set; }

        public DateTime Data { get; set; } 
        public double Valor { get; set; }
    }
}


