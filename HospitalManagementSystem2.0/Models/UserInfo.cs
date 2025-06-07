using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class UserInfo : CommonProps
    {
        public int UserId { get; set; } = 0;

        public string UserName { get; set; } = "";

        public string UserPassword { get; set; } = "";

        public int UserType { get; set; } = 0;

        public int DoctorId { get; set; } = 0;
    }
}
