using GymAppCore.Services;
using GymAppData.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "ApiUser")]
    public class WorkoutController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWorkoutInformationService _informationService;
        private readonly IDesignWorkoutService _designWorkoutService;

        public WorkoutController(UserManager<IdentityUser> userManager, IWorkoutInformationService informationService, IDesignWorkoutService designWorkoutService)
        {
            _userManager = userManager;
            _informationService = informationService;
            _designWorkoutService = designWorkoutService;
        }

        [HttpGet]
        public List<Workout> Get()
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _informationService.GetWorkouts(userId);
        }

        [HttpGet("{workoutId}/active")]
        public Workout GetActiveWorkout(int workoutId)
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _informationService.GetWorkoutForSession(workoutId, userId);
        }

        [HttpGet("{workoutId}")]
        public Workout Get(int workoutId)
        {
            return _informationService.GetWorkout(workoutId);
        }

        // POST: api/Program
        [HttpPost]
        public Workout Post([FromBody] Workout workout)
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _designWorkoutService.CreateNewWorkout(workout, userId);
        }

        // PUT: api/Program/5
        [HttpPut("")]
        public Workout Put([FromBody] Workout workout)
        {
            return _designWorkoutService.UpdateWorkout(workout);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
