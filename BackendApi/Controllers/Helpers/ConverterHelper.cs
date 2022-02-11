namespace BackendApi.Helpers
{
    using System.Threading.Tasks;
    using Data.Entities;
    using Data;
    using Models;

    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        
        public ConverterHelper(
            DataContext dataContext
            )
        {
            _dataContext = dataContext;
            
        }
        public async Task<Books> ToBookAsync(BookViewModel view)
        {            
            Books book = null;
            try
            {
                book = new Books
                {
                    Id = view.Id,
                    Title= view.Title,                    
                    Description = view.Description,
                    PageCount = view.PageCount,
                    Excerpt = view.Excerpt,
                    PublishDate = view.PublishDate == null ? System.DateTime.Now: view.PublishDate,                                        
                };

                return book;
            }
            catch (System.Exception)
            {
         
            }
            return book;
        }
        public BookViewModel ToBookViewModel(Books book)
        {
            BookViewModel dView = null;
            dView  = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Excerpt = book.Excerpt,
                PublishDate = book.PublishDate
            };            
            return dView;
        }
    }
}
