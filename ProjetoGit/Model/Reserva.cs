using System.Security.Cryptography.X509Certificates;

namespace ProjetoGit.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public string NomeDoHospede { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Email { get; set; } = "";
        public int Quarto { get; set; }
        public DateTime? DataCheckin { get; set; }
        public DateTime? DataCheckout { get; set; }

        public Reserva()
        {
            
        }

        public Reserva(int Quarto, string NomeDoHospede, string Telefone, string Email)
        {
            this.Quarto = Quarto;
            this.NomeDoHospede = NomeDoHospede;
            this.Telefone = Telefone;
            this.Email = Email;
        }
    
    }
}
