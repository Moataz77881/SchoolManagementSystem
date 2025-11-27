using SchoolManagementSystem.Application.DTOs.AssignmentDTOs;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface IAssingmentService
    {
        public Task<ServiceResponse> GetAssignmentsByClassIdServiceAsync(int pageNumber, int pageSize);
        public Task<ServiceResponse> CreateNewAssignmentServiceAsync(List<AssignmentRequestDto> assignmentRequestDto);
    }
}
