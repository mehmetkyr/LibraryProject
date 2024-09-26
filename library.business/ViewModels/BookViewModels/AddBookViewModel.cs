namespace library.business.ViewModels.BookViewModels
{
    public class AddBookViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public long ISBN { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string LocationInfo { get; set; }
    }
}
