#region Namespaces
using System.Collections.Generic;
#endregion

namespace SchoolApp.Models
{
    #region Department Class
    public class Department
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MgrName { get; set; } = string.Empty;
        #endregion

        #region Navigation Properties
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        #endregion
    }
    #endregion
}