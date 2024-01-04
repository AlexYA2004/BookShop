using System.Net;
using System.Security.Claims;
using BookShop.DataBaseLogic.Interfaces;
using BookShop.Domain.Entities;
using BookShop.Domain.Enum;
using BookShop.Domain.Response;
using BookShop.Models;
using BookShop.Services.Interfaces;

namespace BookShop.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _bookRepository;

        private readonly IBaseRepository<Author> _authorRepository;

        private readonly IBaseRepository<Authorship> _authorshipRepository;

        private readonly IBaseRepository<Operation> _operationRepository;

        private readonly IBaseRepository<Operationship> _operetionshipRepository;

        private readonly ILogger<AccountService> _logger;

        public BookService(IBaseRepository<Book> bookRepository,
                            ILogger<AccountService> logger,
                            IBaseRepository<Author> authorRepository,
                            IBaseRepository<Authorship> authorshipRepository,
                            IBaseRepository<Operationship> operationshipRepository,
                            IBaseRepository<Operation> operationRepository)
        {
            _bookRepository = bookRepository;

            _logger = logger;

            _authorRepository = authorRepository;

            _authorshipRepository = authorshipRepository;

            _operetionshipRepository = operationshipRepository;

            _operationRepository = operationRepository;
        }

        public async Task BuyBookbyId(int id)
        {
            var operationFromDb = _operationRepository.GetAll().OrderBy(x => x.OperationId);

            var bookWithId = _bookRepository.GetAll().Where(x => x.BookId == id).FirstOrDefault();

            var newOperation = new Operation();

            var newOperationship = new Operationship();

            newOperation.QuantityChange = 1;

            newOperation.OperationDate = DateTime.Now;

            if (operationFromDb.Any())
                newOperation.OperationId = operationFromDb.Last().OperationId + 1;
            else
                newOperation.OperationId = 1;


            newOperationship.BookID = bookWithId.BookId;

            newOperationship.Book = bookWithId;

            newOperationship.OperationID = newOperation.OperationId;

            newOperationship.Operation = newOperation;



            await _operationRepository.Create(newOperation);

            await _operetionshipRepository.Create(newOperationship);
        }

    
    

        public void SetBookInfo(BuyBookViewModel model)
        {
            try
            {
                var booksById = _bookRepository.GetAll().ToDictionary(book => book.BookId);

                var authorsById = _authorRepository.GetAll().ToDictionary(author => author.AuthorId);

                var authorships = _authorshipRepository.GetAll();

                foreach (var item in authorships)
                {
                    if (booksById.TryGetValue(item.BookId, out var book) && authorsById.TryGetValue(item.AuthorId, out var author) && item != null)
                    {
                        var bookViewModel = new BookViewModel
                        {
                            Id = book.BookId,

                            AuthorName = author.AuthorName,

                            Name = book.BookTitle,

                            Price = book.BookPrice

                           
                        };

                        model.Books.Add(bookViewModel);
                    }
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
            }
        }


    }
}
