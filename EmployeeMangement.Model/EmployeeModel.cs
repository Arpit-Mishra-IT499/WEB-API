using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class EmployeeModel
    {
        public string? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? JoiningDate { get; set; }
        public string? EmployeeProfilePic { get; set; }
        public string? ManagerId { get; set; }
        public int? ProjectId { get; set; }
        public int? StatusId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int LocationId {  get; set; }
        public string LocationName { get; set; } = null!;

        public ProjectModel? Project { get; set; }
        public StatusModel? Status { get; set; }

    }
}
