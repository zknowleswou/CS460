using GymAppCore.Services;
using GymAppData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymAppCore.Controllers
{
    [Authorize]
    [Route("api/workoutsession")]
    public class WorkoutSessionController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRecordWorkoutService _recordWorkoutService;

        public WorkoutSessionController(IRecordWorkoutService recordWorkoutService, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _recordWorkoutService = recordWorkoutService;
        }

        [HttpGet("manifest")]
        public List<WorkoutSession> GetManifestSessions()
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _recordWorkoutService.GetIncompleteSessions(userId);
        }

        [HttpGet("{workoutSessionId}")]
        public List<SetRecord> Get(int workoutSessionId)
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _recordWorkoutService.GetWorkoutSession(workoutSessionId, userId);
        }

        [HttpPost("{id}")]
        public WorkoutSession Post(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var userId = new Guid(User.Claims.Single(c => c.Type == "id").Value);

            return _recordWorkoutService.CreateWorkoutSession(id, userId);
        }

        [HttpPut]
        public WorkoutSession Put([FromBody]WorkoutSession workoutSession)
        {
            return _recordWorkoutService.UpdateWorkoutSession(workoutSession);
        }
    }
}