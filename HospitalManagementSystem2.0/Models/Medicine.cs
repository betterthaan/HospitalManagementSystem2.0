using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Medicine : CommonProps
    {
        public int MedicineId { get; set; } = 0;

        public string MedicineName { get; set; } = "";

        public int DianosisId { get; set; } = 0;

        public int PatientId {  get; set; } = 0;
    }
}
