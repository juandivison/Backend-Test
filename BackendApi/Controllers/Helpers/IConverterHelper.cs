using BackendApi.Data.Entities;
using BackendApi.Models;
using System.Threading.Tasks;

namespace BackendApi.Helpers
{
    public interface IConverterHelper
    {
        Task<Books> ToBookAsync(BookViewModel view);
        BookViewModel ToBookViewModel(Books bookCobro);
    }
}