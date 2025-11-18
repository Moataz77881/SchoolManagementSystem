using SchoolManagementSystem.Domain.Entities.AuthEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Domain.Entities
{
	public class Department
    {
        [Key]
        public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		[ForeignKey("ApplicationUser")]
		public Guid HeadOfDepartmentId { get; set; }
		public ApplicationUser? ApplicationUser { get; set; }
		public DateTime CreatedDare { get; set; }
		public DateTime? UpdateDate { get; set; }
		public ICollection<Course> Courses { get; set; }
	}
}
