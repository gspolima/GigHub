using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Attendances
            .Any(a => a.GigId == dto.GigId && a.AttendeeId == userId);

            if (!exists)
            {
                var attendance = new Attendance
                {
                    GigId = dto.GigId,
                    AttendeeId = userId
                };

                _context.Attendances.Add(attendance);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("The attendance for this gig already exists");
            }
        }
    }
}
