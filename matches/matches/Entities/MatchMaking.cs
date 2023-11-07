namespace matches
{
    public enum Status { single, widow, divorcee };
    public class MatchMaking
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public double age { get; set; }
        public bool isChoen { get; set; }
        public Status status { get; set; }

}
}
