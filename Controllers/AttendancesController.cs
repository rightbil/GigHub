using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context= new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int gigId)
        {

            /*
            var userId = User.Identity.GetUserId();
            if(_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId))
                
                return BadRequest("The attendant already exists!");
            

            var attendance = new Attendance()
            {
                GigId = gigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            */

            return Ok();

        }
    }
}
