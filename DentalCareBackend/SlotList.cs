using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCareBackend
{
    public class SlotList : IDisposable, IEnumerable<ISlot>
    {
        private List<ISlot> slotList = null;

        public SlotList()
        {
            slotList = new List<ISlot>();
        }

        public void Add(ISlot slot)
        {
            slotList.Add(slot);
        }

        public void Remove(ISlot slot)
        {
            slotList.Remove(slot);
        }

        public void RemoveAt(int index)
        {
            slotList.RemoveAt(index);
        }

        public int Count()
        {
            return slotList.Count();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ISlot this[int i]
        {
            get { return slotList[i]; }
        }

        public void Sort()
        {
            slotList.Sort();
        }

        public IEnumerator<ISlot> GetEnumerator()
        {
            return ((IEnumerable<ISlot>)slotList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ISlot>)slotList).GetEnumerator();
        }
    }
}
