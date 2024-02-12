using Contracts.Requests;
using Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicalLayer.Base;


namespace BusinessLogicalLayer.Services.Base
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponse>> GetAll();
        Task<TaskResponse> GetById(TaskGetByIdRequest request);
        Task<Result<dynamic>> Create(TaskCreateRequest request);
        Task<Result<dynamic>> UpdateName(TaskUpdateNameRequest request);
        Task<Result<dynamic>> UpdateDescription(TaskUpdateDescriptionRequest request);
        Task<Result<dynamic>> UpdateStatus(TaskUpdateStatusRequest request);
        Task<Result<dynamic>> Delete(TaskDeleteRequest request);

    }
}
