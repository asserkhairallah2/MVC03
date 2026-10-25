using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolApp.ViewModels
{
    #region DepartmentDetailsViewModel Class
    public class DepartmentDetailsViewModel
    {
        #region Properties
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string DepartmentState { get; set; } = string.Empty;
        public List<SelectListItem> StudentsOver25 { get; set; } = new List<SelectListItem>();
        #endregion
    }
    #endregion
}