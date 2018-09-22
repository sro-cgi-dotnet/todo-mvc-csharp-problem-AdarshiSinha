using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using helloworld.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace helloworld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // public async Task<IActionResult> Index()
        // {
        //     using (var context = new efmodel())
        //     {
        //         var model = await context.Authors.AsNoTracking().ToListAsync();
        //         return View(model);
        //     }
            
        // }  
        IRepo Repo = null ;
        // intialise this repo with a dependency injection
        public NotesController(IRepo _ListRepo){
            this.Repo = _ListRepo;
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var getnotes= Repo.GetAllNotes();
            if(getnotes.Count>0)
                return Ok(getnotes);
            else
                return NotFound("No Data Found");

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var getbyid =Repo.GetNotesById(id);
            if(getbyid !=null)
                return Ok(getbyid);
            else
                return NotFound($"Notes with id: {id} not found");
        }

        [HttpGet("{label}")]
        public IActionResult GetByLabels(string label,[FromQuery]string type)
        {
            var getbylabel=Repo.GetNotesByLabelortitle(label,type);
            if(getbylabel.Count>0)
            
                return Ok(getbylabel);
            else
                return NotFound($"Notes with given label or title {label} not found");
                

        }

        [HttpGet("{pinned:bool}")]

        public IActionResult GetByPinned(bool pinned)
        {
            var getbypinned=Repo.GetNotesByPinned(pinned);
            if(getbypinned !=null)
                return Ok(getbypinned);
            else    
                return NotFound($"Notes with given pinned value {pinned} not found");

        }

        [HttpPost]
        public IActionResult Post([FromBody]Notes notes)
        {
            var post = Repo.PostNotes(notes);
            if(post)
            {
                return Ok("Note created.");
            }
            else
                return BadRequest($"Your request cannot be entertained.Try again later.");
        }
        [HttpPut("{id}")]
        public  IActionResult Create(int id,[FromBody] Notes notes)
        {
            
            bool result=Repo.PutNotes(id,notes);
            if(result)
                return Ok($"Notes with id:{id} Updated successfully");
            else
                return BadRequest("Can't be resolved .Try again");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result= Repo.DeleteNotes(id);
            if (result)
                return Ok($"Person with id:{id} deleted");
            else
                return NotFound($"Unable to delete. Person with id:{id} not found");
        }
    }
}