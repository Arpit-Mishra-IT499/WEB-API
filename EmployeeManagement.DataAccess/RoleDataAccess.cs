﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;

namespace EmployeeManagement.DataAccess
{
    public class RoleDataAccess:IRoleDataAccess
    {

        private EmployeeDbContext context;
        public RoleDataAccess(EmployeeDbContext _context)
        {
            this.context = _context;
        }

        public List<Role> GetAll()
        {

           
            // Initialize the list
            List<Role>roleDataList= new List<Role>();
            
                context.Database.EnsureCreated();
                roleDataList=context.Roles.ToList();

              
                context.SaveChanges();

            
            return roleDataList;
        }


        public bool Set(Role role)
        {
           
                context.Database.EnsureCreated();
                context.Roles.Add(role);
                context.SaveChanges();

            
                return true;
        }

    }
}
