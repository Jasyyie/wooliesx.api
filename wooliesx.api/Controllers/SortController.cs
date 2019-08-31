using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wooliesx.service.services;
using wooliesx.model.models;

namespace wooliesx.api.Controllers
{
    /// <summary>
    /// Controller to manage all Wooliesx actions
    /// </summary>
    [Route("api/answers/[controller]")]
    [ApiController]
    public class SortController : Controller
    {
        private readonly IExercise2Service _exercise2Service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exercise2Service"></param>
        public SortController(IExercise2Service exercise2Service)
        {
            _exercise2Service = exercise2Service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string sortOption)
        {
            try
            {
                var response = await _exercise2Service.SortProducts(sortOption);

                return Ok(response);

            }
            catch (System.Exception ex)
            {
                // todo: exception logging & handling
            }

            return new BadRequestResult();
        }
    }
}

