using Microsoft.AspNetCore.Mvc;
using Mission10Backend.Data;

namespace Mission10Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private EfBowlerRepository _efBowlerRepository;
        
        public BowlerController(EfBowlerRepository efBowlerRepository)
        {
            _efBowlerRepository = efBowlerRepository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            // Only retrieve bowlers from Marlins or Sharks teams
            var teamNames = new[] { "Marlins", "Sharks" };
            var bowlers = _efBowlerRepository.GetBowlersWithTeams(teamNames);
            
            var formattedBowlers = bowlers.Select(b => new BowlerDto()
            {
                BowlerId = b.BowlerId,
                BowlerName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}".Trim(),
                TeamName = b.Team?.TeamName,
                Address = b.BowlerAddress,
                City = b.BowlerCity,
                State = b.BowlerState,
                Zip = b.BowlerZip,
                Phone = b.BowlerPhoneNumber
            });
            
            return Ok(formattedBowlers);
        }
    }
}