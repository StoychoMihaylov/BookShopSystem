using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookShopSytem.Models.Bms.Authors;
using BookShopSytem.Models.Entities;
using BookShopSytem.Models.Vms.Authors;
using BookStoreSystem.Services.Contracts;

namespace BookStoreSystem.Services
{
    public class AuthorsService : Service, IAuthorsService
    {
        public bool ContainsAuthor(int id)
        {
            return this.Context.Authors.Find(id) != null;
        }

        public DetailedAuthorVm GetDetailedAuhor(int id)
        {
            Author model = this.Context.Authors.Find(id);
            DetailedAuthorVm vm =
                Mapper.Instance.Map<Author, DetailedAuthorVm>(model);
            return vm;
        }

        public void CreateAuthor(AddAuthorBm bind)
        {
            Author author = Mapper.Instance.Map<AddAuthorBm, Author>(bind);
            this.Context.Authors.Add(author);
            this.Context.SaveChanges();
        }

        public IEnumerable<AuthorBookVm> GetBooksFor(int id)
        {
            IEnumerable<Book> models = this.Context.Authors.Find(id).Books.AsQueryable();
            IEnumerable<AuthorBookVm> vms =
                Mapper.Instance
                .Map<IEnumerable<Book>, IEnumerable<AuthorBookVm>>(models);
            return vms;
        }
    }
}
