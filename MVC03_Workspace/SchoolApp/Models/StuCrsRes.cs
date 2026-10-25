namespace SchoolApp.Models
{
    #region StuCrsRes Class
    public class StuCrsRes
    {
        #region Properties
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }
        #endregion

        #region Navigation Properties
        public Student? Student { get; set; }
        public Course? Course { get; set; }
        #endregion
    }
    #endregion
}