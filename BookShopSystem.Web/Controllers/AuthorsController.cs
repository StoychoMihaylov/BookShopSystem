﻿using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BookShopSytem.Models.Bms.Authors;
using BookShopSytem.Models.Vms.Authors;
using BookStoreSystem.Services;

namespace BookShopSystem.Web.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private AuthorsService _service;

        public AuthorsController()
        {
            this._service = new AuthorsService();
        }

        #region Get
        /// <summary>
        /// This get authors by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (!this._service.ContainsAuthor(id))
            {
                return this.NotFound();
            }

            DetailedAuthorVm vm = this._service.GetDetailedAuhor(id);
            return this.Ok(vm);
        }

        
        /// <summary>
        /// Get All books of author with relevant Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/books")]    
        public IHttpActionResult GetBooks(int id)
        {
            if (!this._service.ContainsAuthor(id))
            {
                return this.NotFound();
            }

            IEnumerable<AuthorBookVm> vms = this._service.GetBooksFor(id);
            return this.Ok(vms);
        }

        #endregion

        #region Post

        /// <summary>
        /// This Adding new author
        /// </summary>
        /// <param name="bind"></param>
        /// <returns></returns>
        [HttpPost]
        [Route]
        public IHttpActionResult Post(AddAuthorBm bind)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._service.CreateAuthor(bind);
            return this.StatusCode(HttpStatusCode.Created);
        } 
        #endregion

    }
}
