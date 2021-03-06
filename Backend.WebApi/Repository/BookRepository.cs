namespace Backend.WebApi.Data
{
    using Backend.WebApi.Data.Entities;
    using System.Linq;

    public class BookRepository : GenericRepository<Books>, IBookRepository
    {
        private readonly DataContext context;

        public BookRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAll()
        {
            return this.context.Books;
        }
    }
}
