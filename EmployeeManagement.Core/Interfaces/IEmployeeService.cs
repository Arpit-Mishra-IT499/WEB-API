﻿using EmployeeManagement.Model;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeService
    {
        bool Add(EmployeeModel employee);
        bool Delete(string employeeNumber);
        bool Edit(EmployeeModel updatedEmployee);
        void GoBack();
        List<EmployeeModel> ViewAll();
        EmployeeModel ViewOne(string employeeNumber);
    }
}