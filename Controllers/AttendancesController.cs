﻿using GigHub.DTOs;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    // Architectural pattern to send objects across process
    [Authorize]
    public class AttendancesController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        /*public IHttpActionResult Attend([FromBody] int gigId) */

        public IHttpActionResult Attend(AttendanceDataTransferObject dto)
        {

            var userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))

                return BadRequest("The attendant already exists!");


            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();

        }
    }
}
