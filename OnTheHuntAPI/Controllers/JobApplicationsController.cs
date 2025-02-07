using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnTheHunt.Data;
using OnTheHunt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheHunt.Controllers
{
    [Route("api/[controller]")] // [controller] will be replaced with the name of the controller, in this case, JobApplications
    [ApiController]
    public class JobApplicationsController : ControllerBase 
    {
        private readonly ApplicationDbContext _context; // Database context

        public JobApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/jobapplications (Get all job applications)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetJobApplications()
        {
            return await _context.JobApplications.ToListAsync();
        }

        // ✅ GET: api/jobapplications/{id} (Get a specific job application by ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetJobApplication(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            return jobApplication;
        }

        // ✅ POST: api/jobapplications (Create a new job application)
        [HttpPost]
        public async Task<ActionResult<JobApplication>> CreateJobApplication(JobApplication jobApplication)
        {
            _context.JobApplications.Add(jobApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobApplication), new { id = jobApplication.JobID }, jobApplication);
        }

        // ✅ PUT: api/jobapplications/{id} (Update an existing job application)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobApplication(int id, JobApplication jobApplication)
        {
            if (id != jobApplication.JobID)
            {
                return BadRequest();
            }

            _context.Entry(jobApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.JobApplications.Any(e => e.JobID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // ✅ DELETE: api/jobapplications/{id} (Delete a job application)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobApplication(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            _context.JobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
