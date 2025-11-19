using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Interfaces.Repositories;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Repositories
{
    public class StudentClassRepository : GenericRepository<StudentClass>, IStudentClassRepository
    {
        public StudentClassRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
