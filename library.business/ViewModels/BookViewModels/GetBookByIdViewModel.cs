namespace library.business.ViewModels.BookViewModels
{
    public class GetBookByIdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public long ISBN { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string LocationInfo { get; set; }
        public string Status { get; set; } = "On the shelf";
        public DateTime? BorrowedDate { get; set; }
        public string MemberId { get; set; }
    }
}
