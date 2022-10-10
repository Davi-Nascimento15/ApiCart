namespace ApiCart.Models
{
     public class Carrinho
    {
        public Carrinho(int id)
        {
            this.id = id;
            Itens = new List<Produto>();
        }
        public int id { get; set; }
        public ICollection<Produto> Itens { get; set; }

        public string TotalCarrinho() {
            int quantidade = Itens.Count;
            double total = Itens.Sum(c => c.valorUnitario * c.quantidade);
            return "Quantidade de Produtos: " + quantidade + " / Total do Carrinho: " + total.ToString();
        }
    }
}
