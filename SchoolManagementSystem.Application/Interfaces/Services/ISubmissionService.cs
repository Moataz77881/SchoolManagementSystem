using SchoolManagementSystem.Application.DTOs.SubmissionDTOs;
using SchoolManagementSystem.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Services
{
    public interface ISubmissionService
    {
        Task<ServiceResponse> SubmitAssignmentServiceAsync(SubmissionRequestDto submissionRequestDto);
        Task<ServiceResponse> ViewSubmissionAssignmentServiceAsync();
        Task<ServiceResponse> GradeStudentAssignment(int submissionId,SubmissionUpdateDto submissionUpdateDto);
    }
}
