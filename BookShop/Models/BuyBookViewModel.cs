namespace BookShop.Models
{
    public class BuyBookViewModel
    {
        public List<BookViewModel> Books { get; set; }
     

        public BuyBookViewModel()
        {
            Books = new List<BookViewModel>();
        }
    }
}
