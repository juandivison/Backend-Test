namespace BackendApi.Data
{
    using BackendApi.Data.Entities;
    using System.Linq;
              
    public interface IBookRepository : IGenericRepository<Books>
    {
        IQueryable GetAll();
    }
}
