using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCart.Models
{
    public class Produto
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public double valorUnitario { get; set; }
        public int quantidade { get; set; }
        public Produto(int Codigo, string nome, double valorUnitario, int quantidade)
        {
            this.codigo = Codigo;
            this.nome = nome;
            this.valorUnitario = valorUnitario;
            this.quantidade = quantidade;
        }
    }
}
