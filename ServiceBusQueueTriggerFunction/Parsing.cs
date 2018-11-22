using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusQueueTriggerFunction
{
    public static class Parsing
    {
        public static int[] ParseQueueMessage(string queueMessage)
        {
            List<int> array = new List<int>();
            foreach (var number in queueMessage.Split(','))
            {
                array.Add(Int32.Parse(number));
            }

            return array.ToArray();
        }
    }
}
