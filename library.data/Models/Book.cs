using library.data.Identity;

namespace library.data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public long ISBN { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string LocationInfo { get; set; }
        public string Status { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public string MemberId { get; set; }
        public AppUser Member { get; set; }

    }
}
