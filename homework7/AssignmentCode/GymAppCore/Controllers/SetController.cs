using System;
using System.Collections.Generic;
using System.Linq;
using GymAppCore.Services;
using GymAppData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWorkoutInformationService _informationService;
        private readonly IDesignWorkoutService _designWorkoutService;

        public SetController(UserManager<IdentityUser> userManager, IWorkoutInformationService informationService, IDesignWorkoutService designWorkoutService)
        {
            _userManager = userManager;
            _informationService = informationService;
            _designWorkoutService = designWorkoutService;
        }

        // GET: api/Set
        [HttpGet]
        public IEnumerable<Set> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Set/5
        [HttpGet("{id}", Name = "Get")]
        public Set Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Set
        [HttpPost]
        public Set Post([FromBody] Set set)
        {
            return _designWorkoutService.CreateSet(set);
        }

        // PUT: api/Set/5
        [HttpPut("")]
        public Set Put([FromBody] Set set)
        {
            if (!User.Identity.IsAuthenticated)
                throw new Exception("ruh roh");

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _designWorkoutService.UpdateSet(set, userId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("")]
        public void Delete(Set set)
        {
            if (!User.Identity.IsAuthenticated)
                throw new Exception("ruh roh");

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            _designWorkoutService.DeleteSet(set, userId);
        }
    }
}
