using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.Model;
using Nelibur.ObjectMapper;

namespace EmployeeManagement.Core.Services
{
    public class RoleDetailService : IRoleDetailService
    {
        private IRoleDataAccess roleDataAccess;
        public RoleDetailService(IRoleDataAccess _roleDataAccess) { 
            this.roleDataAccess = _roleDataAccess;
        }

        public void Build()
        {

            TinyMapper.Bind<RoleDetail, RoleDetailModel>();
            TinyMapper.Bind<RoleDetailModel, Role>();
        }
        public bool Add(RoleDetailModel roleDetail)
        {
            Build();
            Role roleData = TinyMapper.Map<Role>(roleDetail);
            return roleDataAccess.Set(roleData); 
        }

        public List<RoleDetailModel> ViewAll()
        {
            Build();
            List<Role> roleDataList =roleDataAccess.GetAll();
            List<RoleDetailModel>roles = new List<RoleDetailModel>();

            foreach (Role role in roleDataList)
            {
                roles.Add(TinyMapper.Map<RoleDetailModel>(role));
            }
            return roles;
        }
    }
}
