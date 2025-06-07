using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Common
{
    public static class Global
    {
        public static UserInfo UserInfo { get; set; } = new UserInfo();
    }
}
