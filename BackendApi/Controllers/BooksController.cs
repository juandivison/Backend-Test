using BackendApi.Data;
using BackendApi.Helpers;
using BackendApi.Models;
using BackendApiHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class BooksController : Controller
    {

        private readonly IBookRepository bookRepository;
        private readonly IConverterHelper _converterHelper;
                
        private readonly DataContext _dataContext;

        public BooksController(
            DataContext context,
            IBookRepository bookRepository,
            IConverterHelper converterHelper)
        {
            this._dataContext = context;
            this.bookRepository = bookRepository;
            this._converterHelper = converterHelper;            
        }

        
        public IActionResult Index()
        {
            return View(this.bookRepository.GetAll());
        }
                
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("BookNotFound");
            }

            var book = await this.bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                return new NotFoundViewResult("BookNotFound");
            }

            return View(book);
        }
                
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new BookViewModel();           
            return View(model);
        }
                
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel view)
        {
            if (ModelState.IsValid)
            {               

                var _book = await this._converterHelper.ToBookAsync(view);

                await this.bookRepository.CreateAsync(_book);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("BookNotFound");
            }

            var book = await _dataContext.Books                
                .FirstOrDefaultAsync(o => o.Id == id);
            var model = _converterHelper.ToBookViewModel(book);

            return View(model);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BookViewModel book)
        {
            if (id != book.Id)
            {
                return new NotFoundViewResult("BookNotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var view = await this._converterHelper.ToBookAsync(book);
                    _dataContext.Books.Update(view);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new NotFoundViewResult("BookNotFound");
                }
            }
            return View(book);
        }
               
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("BookNotFound");
            }

            var book = await this.bookRepository.GetByIdAsync(id.Value); ;
            if (book == null)
            {
                return new NotFoundViewResult("BookNotFound");
            }

            return View(book);
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await this.bookRepository.GetByIdAsync(id);
            await this.bookRepository.UpdateAsync(book);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult BookNotFound()
        {
            return this.View();
        }
    }
}
