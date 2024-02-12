using Contracts.Requests;
using Contracts.Responses;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicalLayer.Extensions
{
    public static class ProblemExtensions
    {
        public static TaskResponse ToResponse(this TaskEntity problem)
            => new TaskResponse()
            {
                Id = problem.Id,
                Name = problem.Name,
                Description = problem.Description,
                Status = problem.StatusEntity.Status.ToString()
            };

        public static IEnumerable<TaskResponse> ToResponse(this IEnumerable<TaskEntity> problems)
            => problems.Select(p => p.ToResponse());

        public static TaskEntity ToEntity(this TaskCreateRequest request)
            => new TaskEntity()
            {
                Name = request.Name,
                Description = request.Description,
                StatusId = 0
            };

    }
}
