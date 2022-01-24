using System;
namespace Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Album Album { get; set; }
        public float Score { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
