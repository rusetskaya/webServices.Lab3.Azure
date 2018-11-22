using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBusQueueTriggerFunction
{
    public static class ServiceBusQueueTriggeredFunction
    {
        [FunctionName("ServiceBusQueueTriggeredFunction")]
        public static void Run([ServiceBusTrigger("sortingsqueue", AccessRights.Manage, 
            Connection = "ServiceBusConnection")]string myQueueItem,
            [Queue("outqueue", Connection = "MyOutQueue")] out string outQueue,
            TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            myQueueItem = myQueueItem ?? throw new ArgumentNullException(nameof(myQueueItem));
            var arrayToSort = Parsing.ParseQueueMessage(myQueueItem);
            Sorting.MergeSort(arrayToSort);
            StringBuilder sortedString = new StringBuilder();
            foreach (var number in arrayToSort)
            {
                sortedString.Append(number);
                sortedString.Append(',');
            }
            outQueue = sortedString.ToString();
            log.Info($"Out queue message: {outQueue}");
        }
    }
}
