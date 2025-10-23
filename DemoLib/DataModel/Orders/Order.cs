using System.Collections.Generic;

namespace DemoLib
{
    public class Order
    {
        private List<OrderRecord> records_ = new List<OrderRecord>();

        public void AddRecord(OrderRecord record)
        {
            records_.Add(record);
        }

        public bool RemoveRecord(OrderRecord record)
        {
            return records_.Remove(record);
        }

        public bool RemoveRecordAt(int index)
        {
            if (index >= 0 && index < records_.Count)
            {
                records_.RemoveAt(index);
                return true;
            }
            return false;
        }


        public List<OrderRecord> GetRecords()
        {
            return records_;
        }
    }
}
