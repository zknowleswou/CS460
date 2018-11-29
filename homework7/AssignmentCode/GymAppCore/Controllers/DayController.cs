using GymAppCore.Services;
using GymAppData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GymAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWorkoutInformationService _informationService;
        private readonly IDesignWorkoutService _designWorkoutService;

        public DayController(IWorkoutInformationService informationService, IDesignWorkoutService designWorkoutService, UserManager<IdentityUser> userManager)
        {
            _informationService = informationService;
            _designWorkoutService = designWorkoutService;
            _userManager = userManager;
        }

        // GET: api/Day
        [HttpGet]
        public IEnumerable<Day> Get()
        {
            return new Day[] { };
        }

        // GET: api/Day/5
        [HttpGet("{dayId}")]
        public Day Get(int dayId)
        {
            return _informationService.GetDay(dayId);
        }


        // POST: api/Day
        [HttpPost]
        public Day Post([FromBody] Day day)
        {
            if (!User.Identity.IsAuthenticated)
                throw new Exception("uh oh");

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);
            return _designWorkoutService.CreateDay(day);
        }

        // PUT: api/Day/5
        [HttpPut]
        public Day Put([FromBody]Day day)
        {
            if (!User.Identity.IsAuthenticated)
                throw new Exception("uh oh");

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);
            return _designWorkoutService.UpdateDay(day, userId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{dayId}")]
        public void Delete(int dayId)
        {
            if (!User.Identity.IsAuthenticated)
                throw new Exception("uh oh");

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);
            //_designWorkoutService.DeleteDay(dayId, userId);
        }
    }
}
