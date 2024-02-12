using BusinessLogicalLayer.Base;
using BusinessLogicalLayer.Errors;
using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Services.Base;
using Contracts.Requests;
using Contracts.Responses;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    internal class ProblemService : ITaskService
    {
        private const string PROBLEMS = "Problems";
        private const string PROBLEM_ = "Problem_";
        
        private readonly TaskTrackerContext _context;
        private readonly IMemoryCache _cache;
        
        public ProblemService(TaskTrackerContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }


        public async Task<IEnumerable<TaskResponse>> GetAll()
        {
            if (_cache.TryGetValue(PROBLEMS, out IEnumerable<TaskResponse> response))
            {
                return response;
            }
            
            var problems = await _context.Problems.Include(p => p.StatusEntity).AsNoTracking().ToListAsync();
            response = problems.ToResponse();
            _cache.Set(PROBLEMS, response);

            return response;
        }

        public async Task<TaskResponse> GetById(TaskGetByIdRequest request)
        {
            if (_cache.TryGetValue(PROBLEM_ + request.Id, out TaskResponse response))
            {
                return response;
            }

            var problem = await _context.Problems.Include(p => p.StatusEntity).AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.Id);
            response = problem.ToResponse();
            _cache.Set(PROBLEM_ + request.Id, response);
            return response;
        }

        public async Task<Result<dynamic>> Create(TaskCreateRequest request)
        {
            if (await _context.Problems.AnyAsync(p => p.Name == request.Name))
            {
                return new AlreadyExist(request.Name);
            }

            var problem = request.ToEntity();
            problem.StatusEntity = await _context.States.FirstOrDefaultAsync(s => s.Status == Status.Created);
            await _context.Problems.AddAsync(problem);
            await _context.SaveChangesAsync();
            _cache.Remove(PROBLEMS);
            return problem.Id;
        }

        public async Task<Result<dynamic>> UpdateDescription(TaskUpdateDescriptionRequest request)
        {
            var problem = await _context.Problems.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (problem is null)
            {
                return new NotFound(request.Id);
            }

            problem.Description = request.Description;
            await _context.SaveChangesAsync();

            _cache.Remove(PROBLEMS);
            _cache.Remove(PROBLEM_ + request.Id);

            return Result<dynamic>.Success();
        }

        public async Task<Result<dynamic>> UpdateName(TaskUpdateNameRequest request)
        {
            if (await _context.Problems.AnyAsync(p => p.Name == request.Name))
            {
                return new AlreadyExist(request.Name);
            }

            var problem = await _context.Problems.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (problem is null)
            {
                return new NotFound(request.Id);
            }

            problem.Name = request.Name;
            await _context.SaveChangesAsync();

            _cache.Remove(PROBLEMS);
            _cache.Remove(PROBLEM_ + request.Id);

            return Result<dynamic>.Success();
        }


        public async Task<Result<dynamic>> UpdateStatus(TaskUpdateStatusRequest request)
        {
            var problem = await _context.Problems.Include(p=>p.StatusEntity).FirstOrDefaultAsync(p => p.Id == request.Id);
            if (problem is null)
            {
                return new NotFound(request.Id);
            }



            switch (problem.StatusEntity.Status)
            {
                case Status.Created: problem.StatusEntity = await _context.States.FirstOrDefaultAsync(s => s.Status == Status.InProgress); break;
                case Status.InProgress: problem.StatusEntity = await _context.States.FirstOrDefaultAsync(s => s.Status == Status.Resolved);  break;
                case Status.Resolved: return new AlreadyResolve(problem.Name);
            }
            await _context.SaveChangesAsync();

            _cache.Remove(PROBLEMS);
            _cache.Remove(PROBLEM_ + request.Id);

            return Result<dynamic>.Success();
        }

        public async Task<Result<dynamic>> Delete(TaskDeleteRequest request)
        {
            var problem = await _context.Problems.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (problem is null)
            {
                return new NotFound(request.Id);
            }

            _context.Problems.Remove(problem);

            await _context.SaveChangesAsync();

            _cache.Remove(PROBLEMS);
            _cache.Remove(PROBLEM_ + request.Id);

            return Result<dynamic>.Success();
        }
    }
}
