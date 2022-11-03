# az-func-d-sim-sensor

Function D is an Azure Function that simulate sensors on Azure Iot Hub based on the messages from Azure Service Bus

## How to use

1. Create a new Azure Function App
2. Create a new Function
3. Deploy the code from this repository using VS Code or the Azure CLI
4. Create an Azure Service Bus (Find out more in [Function C - PublishMessage](https://github.com/asad-shmoghadam/az-func-c-publish-message))
5. Create a queue (e.g. name it `example_queue`)
6. Add Azure Service Bus connection string to function configuration with the name of `SERVICE_BUS_CONNECTION`
7. Add the name of the queue that you already created (`example_queue`) to function configuration with the name of `QUEUE_NAME`
8. Create Azure IoT Hub and add the connection string to the function configuration with the name of `DEVICE_CONNECTION_STRING`

> The function will be triggered as soon as a message released from the queue and will send the message to the IoT Hub
