using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Pocketpedia.Models;
using Pocketpedia.Repositories;
using System;


namespace Pocketpedia.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public NotesController(INotesRepository notesRepository, IUserProfileRepository userProfileRepository)
        {
            _notesRepository = notesRepository;
            _userProfileRepository = userProfileRepository;
        }


        // Get a user's notes
        [HttpGet("GetByUser")]
        public IActionResult GetByUser()
        {
            var user = GetCurrentUserProfile();
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var notes = _notesRepository.GetUserNotes(user.FirebaseUserId);
                return Ok(notes);
            }
        }

        // Get a notes by an Id
        [HttpGet("details/{id}")]
        public IActionResult GetById(int id)
        {
            var notes = _notesRepository.GetNotesById(id);
            if (notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }

        // Adding a new note
        [HttpPost]
        public IActionResult CreateNotes(Notes notes)
        {
            var currentUserProfile = GetCurrentUserProfile();

            notes.UserProfileId = currentUserProfile.Id;
            notes.CreateDateTime = DateTime.Now;
 
            _notesRepository.Add(notes);
            return CreatedAtAction(nameof(GetByUser), new { id = notes.Id }, notes);
        }

        // Editting a notes
        [HttpPut("{id}")]
        public IActionResult Put(int id, Notes notes)
        {
            if (id != notes.Id)
            {
                return BadRequest();
            }

            _notesRepository.UpdateNotes(notes);
            return NoContent();
        }

        // Delete an unwated notes
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _notesRepository.Delete(id);
            return NoContent();
        }

        // Get the current user
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (firebaseUserId != null)
            {
                return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
            }
            else
            {
                return null;
            }
        }
    }
}