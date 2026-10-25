using System.Collections.Generic;

namespace SchoolApp.Models
{
    #region Student Class
    public class Student
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        #endregion

        #region Navigation Properties
        public Department? Department { get; set; }
        public ICollection<StuCrsRes> StuCrsRes { get; set; } = new List<StuCrsRes>();
        #endregion
    }
    #endregion
}