namespace WebApplication2.Models
{
    public class Contact
    {

        [key]
        public string Name { get; set; } 
        public string NickName { get; set; }
        public string Server { get; set; }
        public List<Messege>? Messeges { get; set; }
        public Messege? LastMessege { get; set; }

    }
}
