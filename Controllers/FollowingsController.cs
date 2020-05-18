using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebSockets;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Follow(FollowingDataToObject dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.FolloweeId== userId && f.FolloweeId == dto.FolloweeId))
            
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId= dto.FolloweeId

            };

            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }
    }

    public class FollowingDataToObject
    {
        public string FolloweeId { get; set; }
        public string FollowerId { get; set; }
    }
}
