using System.ComponentModel.DataAnnotations;

namespace DTOCore.Model
{
    public class Ret
    {
        public Ret(int id, String navn, int antalmennesker) 
        {
            Id = id;
            Navn = navn;
            AntalMennesker = antalmennesker;
            //Link = link;
        }

        public int Id { get; set; }
        [Required]
        public String Navn { get; set; }
        public int AntalMennesker { get; set; }
        public String Link { get; set; }

    }
}