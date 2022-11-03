using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace CCPS.Function
{
    public static class ServiceBusQueueTriggerToIoTHub
    {
        [FunctionName("ServiceBusQueueTriggerToIoTHub")]
        public static async Task Run([ServiceBusTrigger("vdqqueue_01", Connection = "SERVICE_BUS_CONNECTION")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            var queueItemJson = JObject.Parse(myQueueItem);
            var deviceId = queueItemJson["DeviceID"].ToString();
            var iotHubConnectionString = Environment.GetEnvironmentVariable("DEVICE_CONNECTION_STRING");
            string gatewayHost = null;

            var device = new VdqDevice(deviceId, iotHubConnectionString, gatewayHost);

            await device.RunDeviceAsync(myQueueItem, log);
        }
    }
}
