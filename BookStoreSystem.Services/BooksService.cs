using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookShopSytem.Models.Bms.Books;
using BookShopSytem.Models.Entities;
using BookShopSytem.Models.Vms.Books;
using BookStoreSystem.Services.Contracts;

namespace BookStoreSystem.Services
{
    public class BooksService : Service, IBooksService
    {
        public IEnumerable<ShortBookVm> GetBookByTitle(string search)
        {
            IEnumerable<Book> models = this.Context.Books
                .Where(book => book.Title.Contains(search))
                .Take(10)
                .OrderBy(book => book.Title);
            IEnumerable<ShortBookVm> vms = Mapper.Map
                <IEnumerable<Book>, IEnumerable<ShortBookVm>>(models);

            return vms;
        }

        public bool ContainsBook(int id)
        {
            return this.Context.Books.Find(id) != null;
        }

        public void DeleteBook(int id)
        {
            Book model = this.Context.Books.Find(id);
            this.Context.Books.Remove(model);
            this.Context.SaveChanges();
        }

        public void EditBook(int id, EditBookBm bind, out bool isValid)
        {
            isValid = true;
            Book model = this.Context.Books.Find(id);
            model.Title = bind.Title;
            model.AgeRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), bind.AgeRestriction);
            model.EditionType = (EditionType)Enum.Parse(typeof(EditionType), bind.EditionType);
            model.ReleaseDate = DateTime.ParseExact(bind.ReleaseDate, "dd-MM-yyyy", null);
            if (this.Context.Authors.Find(bind.AuthorId) == null)
            {
                isValid = false;
                return;
            }

            model.Author = this.Context.Authors.Find(bind.AuthorId);
            model.Copies = bind.Copies;
            model.Description = bind.Description;
            model.Price = bind.Price;
            this.Context.SaveChanges();
        }

        public DetailedBookVm GetBook(int id)
        {
            Book model = this.Context.Books.Find(id);
            DetailedBookVm vm = Mapper.Map<Book, DetailedBookVm>(model);
            return vm;
        }

        public void Add(AddBookBm bind)
        {
            Book book = Mapper.Map<AddBookBm, Book>(bind);
            List<Category> categories = new List<Category>();
            var categoryNames = bind.Categories.Split();
            foreach (var categoryName in categoryNames)
            {
                Category currentCategory =
                    this.Context.Categories
                    .FirstOrDefault(category => category.Name == categoryName);

                if (currentCategory != null)
                {
                    categories.Add(currentCategory);
                }
            }

            book.Categories = categories;
            this.Context.Books.Add(book);
            this.Context.SaveChanges();
        }
    }
}
