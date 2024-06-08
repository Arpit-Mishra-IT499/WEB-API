﻿using System.Data;
using System.Data.SqlClient;
using System.Text;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
namespace EmployeeManagement.DataAccess
{
    public class EmployeeDataAccess:IEmployeeDataAccess
    {
        private EmployeeDbContext context;

        public EmployeeDataAccess(EmployeeDbContext _context) {
            this.context = _context;
        }
        
       
        public  List<Employee> GetAll()
        {
          
            using (context)
                {
                context.Database.EnsureCreated();

                List<Employee> emp =  context.Employees
              .Include(e => e.RoleDetail)
                  .ThenInclude(rd => rd.Department)
              .Include(e => e.RoleDetail)
                  .ThenInclude(rd => rd.Location)
              .Include(e => e.RoleDetail)
                  .ThenInclude(rd => rd.Role)
              .Include(e => e.Project)
              .Include(e => e.Status).ToList();
                return emp;

            }
                 
            }



            
            
       

        public Employee GetOne(string employeeNumber)
        {

          
            using (context)
            {
                context.Database.EnsureCreated();

                Employee emp =context.Employees.FirstOrDefault(e => e.EmployeeId == employeeNumber)!;
                

                return emp ;

            }


        }

        public bool Update(Employee updatedEmployee)
        {
             
             using (context)
            {
                  context.Database.EnsureCreated();

                 
                if (updatedEmployee != null)
                  {
                 
                 context.Entry(updatedEmployee).State = EntityState.Modified;
                 context.SaveChanges();

                }

                return true;

            }

        }

        public bool Delete(string employeeNumber)
        {
         
             using (context)
            {
                var employeeToDelete = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeNumber);
                 context.Database.EnsureCreated();

                if (employeeToDelete != null)
                {
                    context.Remove(employeeToDelete!);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }


            
        }
        public bool Set(Employee employee)
        {
           
            using (context)
            {
                 
                 context.Employees.Add(employee);
                context.SaveChanges();

                return true;

            }

            
        }
    }
}