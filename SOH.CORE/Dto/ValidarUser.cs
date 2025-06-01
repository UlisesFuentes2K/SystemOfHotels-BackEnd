namespace SOH.CORE.Dto
{
    public class ValidarUser
    {
        public string Id { get; set; }
        public string token { get; set; }
        public int idTypePerson { get; set; }
        public int idPerson { get; set; }
        //
        public IList<string> Rol{ get; set; }
    }
}
