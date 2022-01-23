using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DentalCareBackend;

namespace DentalCareFrontend
{
    public class Custom : Patient
    {
        private Patient patient;

        public Patient Patient { get => patient; set => patient = value; }
    }
}
