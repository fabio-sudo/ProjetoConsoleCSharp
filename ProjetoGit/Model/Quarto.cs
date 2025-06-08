
namespace ProjetoGit.Model
{
    public class Quarto
    {
        public int Id { get; set; }
        public short Status { get; set; }

        public Quarto() { }

        public Quarto(int Id, short Status)
        {
            this.Id = Id;
            this.Status = Status;
        }

    }

   
}
