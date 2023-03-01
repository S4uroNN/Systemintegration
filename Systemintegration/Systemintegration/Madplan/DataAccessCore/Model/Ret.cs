namespace DataAccessCore.Model
{
    internal class Ret
    {
        
        public int Id { get; set; }
        public String Navn { get; set; }
        public int AntalMennesker { get; set; }
        //public String Link { get; set; }


        public Ret() { }
        public Ret(int id, string navn, int antalmennesker)
        {
            Id = id;
            Navn = navn;
            AntalMennesker = antalmennesker;

        }
        //public Ret(int id, string navn, int antalmennesker, string link)
        //{
        //    Id = id;
        //    Navn = navn;
        //    AntalMennesker = antalmennesker;
        //    Link = link;
        //}


    }
}