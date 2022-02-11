namespace Backend.WebApi.Data
{
    using Backend.WebApi.Data.Entities;
    using System.Linq;
              
    public interface IBookRepository : IGenericRepository<Books>
    {
        IQueryable GetAll();
    }
}
