using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCareBackend
{
    public enum PatientType
    {
        RootCanalPatient,
        BracesPatient,
        FillingCleaningPatient,
        ExtractionPatient
    }

    public class Patient : IPatient
    {
        private string id;
        private string name;
        private string gender;
        private int age;
        private string apptTime;
        private string creditCardNum;
        private int nextCheckInDays;
        private List<string> morbidity;
        private PatientType patientType;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public string ApptTime { get => apptTime; set => apptTime = value; }
        public string CreditCardNum { get => creditCardNum; set => creditCardNum = value; }
        public int NextCheckInDays { get => nextCheckInDays; set => nextCheckInDays = value; }
        public List<string> Morbidity { get => morbidity; set => morbidity = value; }
        public PatientType PatientType { get => patientType; set => patientType = value; }

        public override string ToString()
        {
            return "";
        }
    }
}
