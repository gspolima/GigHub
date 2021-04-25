using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId);

            if (!exists)
            {
                var follower = new Following
                {
                    FollowerId = userId,
                    FolloweeId = dto.FolloweeId
                };

                _context.Followings.Add(follower);
                _context.SaveChanges();


                return Ok();
            }
            else
                return BadRequest("The user is already following the artist");
        }
    }
}
