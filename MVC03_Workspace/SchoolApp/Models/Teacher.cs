using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Models
{
    #region Teacher Class
    public class Teacher
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        public string Address { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        #endregion

        #region Navigation Properties
        public Department? Department { get; set; }
        public Course? Course { get; set; }
        #endregion
    }
    #endregion
}