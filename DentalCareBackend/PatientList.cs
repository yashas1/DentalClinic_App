using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DentalCareBackend
{
    [XmlRoot("PatientList")]
    [XmlInclude(typeof(RootCanalPatient))]
    [XmlInclude(typeof(BracesPatient))]
    [XmlInclude(typeof(FillingCleaningPatient))]
    [XmlInclude(typeof(ExtractionPatient))]
    public class PatientList : IDisposable, IEnumerable<Patient>
    {
        private List<Patient> patients = null;

        [XmlArray("Patients")]
        [XmlArrayItem("Patient", typeof(Patient))]
        public List<Patient> Patients { get => patients; set => patients = value; }

        public PatientList()
        {
            patients = new List<Patient>();
        }

        public void Add(Patient patient)
        {
            patients.Add(patient);
        }

        public void Remove(Patient patient)
        {
            patients.Remove(patient);
        }

        public int Count()
        {
            return patients.Count();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Patient this[int i]
        {
            get { return patients[i]; }
        }

        public void Sort()
        {
            patients.Sort();
        }

        public IEnumerator<Patient> GetEnumerator()
        {
            return ((IEnumerable<Patient>)patients).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Patient>)patients).GetEnumerator();
        }
    }
}
