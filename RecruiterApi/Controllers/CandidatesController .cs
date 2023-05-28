using Microsoft.AspNetCore.Mvc;
using RecruiterApi.Data.Repository;
using RecruiterApi.Models;

namespace RecruiterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateRepository _candidateRepository;

        public CandidatesController(CandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        // GET: api/candidates
        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> GetAll()
        {
            return Ok(_candidateRepository.GetAll());
        }

        // GET: api/candidates/{id}
        [HttpGet("{id}")]
        public ActionResult<Candidate> Get(int id)
        {
            var candidate = _candidateRepository.GetById(id);
            if (candidate == null)
                return NotFound();

            return Ok(candidate);
        }

        // POST: api/candidates
        [HttpPost]
        public ActionResult<Candidate> Post([FromBody] Candidate candidate)
        {
            var entity = _candidateRepository.Add(candidate);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        // PUT: api/candidates/{id}
        [HttpPut("{id}")]
        public ActionResult<Candidate> Put(int id, [FromBody] Candidate updatedCandidate)
        {
            var entity = _candidateRepository.Update(id, updatedCandidate);
            
            return Ok(entity);
        }

        // DELETE: api/candidates/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _candidateRepository.Delete(id);
            return NoContent();
        }
    }
}

