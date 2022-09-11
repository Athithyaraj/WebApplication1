using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }
    }
}
