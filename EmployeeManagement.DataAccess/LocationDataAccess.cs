﻿using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess
{
    public class LocationDataAccess:ILocationDataAccess
    {
        
        public List<Location> GetAll()
        {

            List<Location> locs = [];
            using (EmployeeDbContext context=new EmployeeDbContext())
            {
                context.Database.EnsureCreated();
                locs=context.Locations.ToList();
                context.SaveChanges();
            }

             return locs;

        }

        public bool Set(Location location)
        {
            
            using (EmployeeDbContext context = new EmployeeDbContext())
            {
                context.Database.EnsureCreated();
                context.Locations.Add(location);
                context.SaveChanges();

            }

               
            return true;
        } 
    }
}
