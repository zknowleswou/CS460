using GymAppCore.Services;
using GymAppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GymAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetRecordController : ControllerBase
    {
        private readonly IRecordWorkoutService _recordWorkoutService;

        public SetRecordController(IRecordWorkoutService recordWorkoutService)
        {
            _recordWorkoutService = recordWorkoutService;
        }

        // GET: api/SetRecord
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SetRecord/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SetRecord
        [HttpPost]
        public SetRecord Post([FromBody] SetRecord setRecord)
        {
            return _recordWorkoutService.CreateOrUpdateSetRecord(setRecord);
        }

        // PUT: api/SetRecord/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
