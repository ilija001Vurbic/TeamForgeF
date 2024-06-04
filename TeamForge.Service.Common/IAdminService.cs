﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamForge.Model;

namespace TeamForge.Service.Common
{
    public interface IAdminService
    {
        Admin GetAdminById(Guid adminId);
        IEnumerable<Admin> GetAllAdmins();
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Guid adminId);
    }
}
