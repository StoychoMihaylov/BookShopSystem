using BookStoreSystem.Services;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BookShopSytem.Models.Bms.Books;
using BookShopSytem.Models.Vms.Books;

namespace BookShopSystem.Web.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BooksService _service;

        public BooksController()
        {
            this._service = new BooksService();
        }

        #region Get

        [HttpGet, Route]
        public IHttpActionResult Get(string search)
        {
            if (search == null)
            {
                return this.NotFound();
            }

            IEnumerable<ShortBookVm> vms = this._service.GetBookByTitle(search);
            return this.Ok(vms);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (!this._service.ContainsBook(id))
            {
                return this.NotFound();
            }

            DetailedBookVm vm = this._service.GetBook(id);
            return this.Ok(vm);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (!this._service.ContainsBook(id))
            {
                return this.NotFound();
            }

            this._service.DeleteBook(id);
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        #endregion

        #region PUT

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id, EditBookBm bind)
        {
            if (!this._service.ContainsBook(id))
            {
                return this.NotFound();
            }

            bool isValid;
            this._service.EditBook(id, bind, out isValid);
            if (!isValid)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }

            return this.Ok();
        }

        #endregion

        [HttpPost, Route]
        public IHttpActionResult Post(AddBookBm bind)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this._service.Add(bind);
            return this.StatusCode(HttpStatusCode.Created);
        }                                   
    }
}

