namespace WebApplication2.Models
{
    public class Messege
    {
        public int Id { get; set; } 
        public string Content { get; set; }    
        public DateTime Created { get; set; }
        public bool Sent { get; set; }

    }
}
