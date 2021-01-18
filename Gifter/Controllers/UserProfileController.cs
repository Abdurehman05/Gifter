using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using Gifter.Data;
using Gifter.Models;
using Gifter.Repositories;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using System.Security.Claims;
=======
>>>>>>> 707a90d (Firebase Authentication implemented)
=======
using System.Security.Claims;
>>>>>>> fec22dd (get current user)
=======
using System.Security.Claims;
>>>>>>> ac310e542d4b179d20451732051a910ad814a200

namespace Gifter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileRepository _userProfileRepository;
        public UserProfileController(ApplicationDbContext context)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> ac310e542d4b179d20451732051a910ad814a200
        {
            _userProfileRepository = new UserProfileRepository(context);
        }

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUserProfile(string firebaseUserId)
        {
<<<<<<< HEAD
=======
        {
            _userProfileRepository = new UserProfileRepository(context);
        }

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUserProfile(string firebaseUserId)
        {
>>>>>>> 707a90d (Firebase Authentication implemented)
=======
>>>>>>> ac310e542d4b179d20451732051a910ad814a200
            return Ok(_userProfileRepository.GetByFirebaseUserId(firebaseUserId));
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            userProfile.DateCreated = DateTime.Now;
            _userProfileRepository.Add(userProfile);
            return Ok(userProfile);
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> fec22dd (get current user)
=======
>>>>>>> ac310e542d4b179d20451732051a910ad814a200
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
<<<<<<< HEAD
=======
>>>>>>> 707a90d (Firebase Authentication implemented)
=======
>>>>>>> fec22dd (get current user)
    }
}