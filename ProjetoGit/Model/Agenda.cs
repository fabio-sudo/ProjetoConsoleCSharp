using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGit.Model
{
    public class Agenda
    {
        //Encapsulamento
        public int Id { get; set; }

        public string NomePessoa { get; set; }

        public string Celular { get; set; }

        public Agenda(int id, string nomePessoa, string celular)
        {
            Id = id;
            NomePessoa = nomePessoa;
            Celular = celular;
        }
    }
}