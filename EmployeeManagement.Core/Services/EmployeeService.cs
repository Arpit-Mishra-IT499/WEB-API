using EmployeeManagement.Model;
using System.Text.RegularExpressions;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.DataAccess.Entities;
using Nelibur.ObjectMapper;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Core.Services
{
    public class EmployeeService:IEmployeeService
    {
      
        private IEmployeeDataAccess employeeDataAccess;
       
        public EmployeeService(IEmployeeDataAccess _employeeDataAccess) {
            this.employeeDataAccess = _employeeDataAccess;
            
        }
        
        private List<EmployeeModel> ?employeeList;

        public void Build()
        {
            TinyMapper.Bind<Employee, EmployeeModel>(config => {
                config.Bind(src => src.RoleDetail.RoleId, dest => dest.RoleId);
                config.Bind(src => src.RoleDetail.Role.RoleName, dest => dest.RoleName);
                config.Bind(src => src.RoleDetail.DepartmentId, dest => dest.DepartmentId);
                config.Bind(src => src.RoleDetail.Department.DepartmentName, dest => dest.DepartmentName);
                config.Bind(src => src.RoleDetail.LocationId, dest => dest.LocationId);
                config.Bind(src => src.RoleDetail.Location.LocationName, dest => dest.LocationName);
            });
            TinyMapper.Bind<DepartmentModel, Department>();
        }
        public bool Add(EmployeeModel employee)
        {
           
            Employee employeeEntity = TinyMapper.Map<Employee>(employee);
            return employeeDataAccess.Set(employeeEntity); 
        }
            

        public bool Delete(string employeeNumber)
        {

            return employeeDataAccess.Delete(employeeNumber);
        }

        public bool Edit(EmployeeModel updatedEmployee,string emp)
        {

            //Employee employeeToUpdate=employeeDataAccess.GetOne(emp);
            //if (employeeToUpdate != null)
            //{
            //    TinyMapper.Map(updatedEmployee, employeeToUpdate);
            //    return employeeDataAccess.Update(employeeToUpdate);
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public  List<EmployeeModel> ViewAll()
        {
            Build();
            List <Employee> emps= employeeDataAccess.GetAll();
            List<EmployeeModel> emp = [];
            EmployeeModel employeeData= null;
            foreach(Employee employee in emps)
            {
                employeeData = TinyMapper.Map<EmployeeModel>(employee);
                emp.Add(employeeData);
            }
            return emp;
        }

        public EmployeeModel ViewOne(string employeeNumber)
        {
           
            Employee emp = employeeDataAccess.GetOne(employeeNumber);
            EmployeeModel employee = null!;
            return employee;
        }


    }
}
