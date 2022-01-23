using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCareBackend
{
    public class Slot : ISlot
    {
        private string dateTime;

        public const int MaxCount = 9;

        public string DateTime { get => dateTime; set => dateTime = value; }
    }
}
