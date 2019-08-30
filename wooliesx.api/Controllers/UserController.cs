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
    public class UserController : Controller
    {
        private readonly IExercise1Service _exercise1Service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exercise1Service"></param>
        public UserController(IExercise1Service exercise1Service)
        {
            _exercise1Service = exercise1Service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _exercise1Service.GetUser();
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
