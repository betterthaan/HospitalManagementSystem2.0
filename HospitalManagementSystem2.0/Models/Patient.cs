using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Patient : CommonProps
    {
        public int PatientId { get; set; } = 0;

        public string Name { get; set; } = "";

        public string Address { get; set; } = "";

        public string Contact { get; set; } = "";

        public int Age { get; set; } = 0;

        public string Gender { get; set; } = "";

        public string BloodGroup { get; set; } = "";

        public string PCode { get; set; } = "";

        public int DoctorId { get; set; } = 0;

        public string DoctorName { get; set; } = "";
    }
}
