using RecruiterApi.Models;

namespace RecruiterApi.Data.Repository
{
    public class CandidateRepository
    {
        private readonly DataContext _dataContext;

        public CandidateRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Candidate> GetAll()
        {
            return _dataContext.Candidates.ToList();
        }

        public Candidate GetById(int id) => _dataContext.Candidates.Where(c => c.Id == id).FirstOrDefault();
        

        public Candidate Add(Candidate candidate)
        {
            _dataContext.Candidates.Add(candidate);
            _dataContext.SaveChanges();
            return candidate;
        }

        public Candidate Update(int id, Candidate updatedCandidate)
        {
            var candidate = GetById(id);
            if (candidate == null)
                throw new InvalidOperationException("Candidate not found");

            candidate.Name = updatedCandidate.Name;
            candidate.Contact = updatedCandidate.Contact;
            candidate.Skills = updatedCandidate.Skills;
            candidate.IsHired = updatedCandidate.IsHired;
            candidate.HiringDate = updatedCandidate.HiringDate;
            _dataContext.Update(candidate);
            _dataContext.SaveChanges();
            return candidate;
        }

        public void Delete(int id)
        {
            var candidate = GetById(id);
            if (candidate == null)
                throw new InvalidOperationException("Candidate not found");

            _dataContext.Candidates.Remove(candidate);
            _dataContext.SaveChanges();
        }
    }
}
