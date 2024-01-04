using BookShop.Domain.Entities;
using BookShop.Models;

namespace BookShop.Services.Interfaces
{
    public interface IBookService
    {
        void SetBookInfo(BuyBookViewModel model);

        Task BuyBookbyId(int id);
    }
}
