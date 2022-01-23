using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCareBackend
{
    public interface IPatient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ApptTime { get; set; }
        public string CreditCardNum { get; set; }
        public int NextCheckInDays { get; set; }
        public List<string> Morbidity { get; set; }
        public PatientType PatientType { get; set; }
    }
}
