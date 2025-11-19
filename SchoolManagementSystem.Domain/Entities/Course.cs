using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
	public class Course
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string code { get; set; }
		public string? Description { get; set; }
		public int DepartmentId { get; set; }
		public Department? Department { get; set; }
		public int Credits { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }

	}
}
