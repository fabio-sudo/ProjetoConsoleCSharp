using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGit.Model
{
    public class Hardware
    {
        //Encapsulamento
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Tipo { get; set; }

        public string Marca { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }
    

    public Hardware(int id, string nome, string tipo, string marca, string descricao, decimal preco)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            Marca = marca;
            Descricao = descricao;
            Preco = preco;

        }
    }
}
