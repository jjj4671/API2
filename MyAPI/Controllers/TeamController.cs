#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using Newtonsoft.Json;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly MyAPIDBContext _context;

        public TeamController(MyAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/team
        [HttpGet]
        public async Task<ActionResult<ApiResult<Team>>> GetTeams()
        {
            var response = new ApiResult<Team>();
            if (_context.Teams == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
                return response;
            }
            response.StatusCode = 200;
            response.StatusDescription = "Successful Response";
            response.Response = await _context.Teams.ToListAsync();

            return response;

        }
        

         // GET: api/team/5
        [HttpGet("{TeamNo}")]
        public async Task<ActionResult<Team>> GetTeam(int TeamNo)
        {
            var item = await _context.Teams.FindAsync(TeamNo);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }



        // PUT: api/team/{teamNo}
        [HttpPut("{teamNo}")]
        public async Task<ActionResult> PutTeam(int teamNo, Team team)
        {
            if (teamNo != team.TeamNo)
            {
                return BadRequest();
            }
            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("Successfully updated team attributes.");
        }


        // POST: api/team
        [HttpPost]
        public async Task<ActionResult<ApiResult<Team>>> CreateTeam(Team team)
        {
            var response = new ApiResult<Team>();
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            response.StatusCode = 201;
            response.StatusDescription = "Created";

            return response;
        }


        
    }
}
