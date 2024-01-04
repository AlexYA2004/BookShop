using BookShop.Domain.Enum;

namespace BookShop.Domain.Response
{
    public interface IBaseResponse<T>
    {
        string Description { get; }

        StatusCode StatusCode { get; }

        T Data { get; }
    }
}
