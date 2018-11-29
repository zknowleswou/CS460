using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymAppCore.Services;
using GymAppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWorkoutInformationService _informationService;
        private readonly IDesignWorkoutService _designWorkoutService;

        public ExerciseController(UserManager<IdentityUser> userManager, IWorkoutInformationService informationService, IDesignWorkoutService designWorkoutService)
        {
            _userManager = userManager;
            _informationService = informationService;
            _designWorkoutService = designWorkoutService;
        }

        // GET: api/Exercise
        [HttpGet]
        public IEnumerable<Exercise> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public Exercise Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Exercise
        [HttpPost]
        public Exercise Post([FromBody] Exercise exercise)
        {
            return _designWorkoutService.CreateExercise(exercise);
        }

        // PUT: api/Exercise/5
        [HttpPut("")]
        public Exercise Put([FromBody] Exercise exercise)
        {
            if (!User.Identity.IsAuthenticated)
                throw new Exception("ruh roh");

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _designWorkoutService.UpdateExercise(exercise, userId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{exerciseId}")]
        public void Delete(Exercise exercise)
        {
            if (!User.Identity.IsAuthenticated)
                throw new Exception("shit");

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);
        }
    }
}
