namespace ProjetoGit.Model
{
    public class Produto
    {
        //Encapsulamento
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; } 


        //Construtor personalizado
        public Produto(int id,  string descricao, decimal valor)
        {
            Id = id;
            Descricao = descricao; 
            Valor = valor;
        }   

    }
}
