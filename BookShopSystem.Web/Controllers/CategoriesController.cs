using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BookShopSytem.Models.Bms.Categories;
using BookShopSytem.Models.Vms.Categories;
using BookStoreSystem.Services;

namespace BookShopSystem.Web.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private CategoriesService _service;

        public CategoriesController()
        {
            this._service = new CategoriesService();
        }

        [HttpGet, Route]
        public IHttpActionResult Get()
        {
            IEnumerable<CategoryVm> vms = this._service.GetAll();
            return this.Ok(vms);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (!this._service.CategoryExists(id))
            {
                return this.NotFound();
            }

            CategoryVm vm = this._service.Get(id);
            return this.Ok(vm);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (!this._service.CategoryExists(id))
            {
                return this.NotFound();
            }

            this._service.Delete(id);
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Put(int id, EditCategoryBm bind)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (!this._service.CategoryExists(id))
            {
                return this.NotFound();
            }

            if (this._service.CategoryNameExists(bind.Name))
            {
                return this.BadRequest();
            }

            this._service.Edit(id, bind.Name);
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost, Route]
        public IHttpActionResult Post(AddCategoryBm bind)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (this._service.CategoryNameExists(bind.Name))
            {
                return this.BadRequest();
            }

            this._service.AddCategory(bind);
            return this.StatusCode(HttpStatusCode.Created);
        } 
    }
}
