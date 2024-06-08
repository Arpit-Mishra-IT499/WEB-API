using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class RoleDetailModel
    {
        public int RoleDetailId { get; set; }
        public DepartmentModel? Department { get; set; }
        public LocationModel? Location { get; set; }
        public RoleModel? Role { get; set; }

    }
}
