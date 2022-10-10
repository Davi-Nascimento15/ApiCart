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
            int quantidade=0;
            double total = 0;
            foreach (Produto produto in Itens)
            {
                quantidade += produto.quantidade;
                total += produto.quantidade * produto.valorUnitario;
            }
            return "Quantidade: "+ quantidade + " /Total do Carrinho: "+total.ToString();
        }

    }
}
