using System.ComponentModel.DataAnnotations;

namespace LetsTalk.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1, 5)]
        public int RateNum { get; set; }
        public string Text { get; set; }
        public DateTime GetDate { get; set; }

    }
}
