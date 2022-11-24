using System;
using System.Net;
using System.IO;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Connecting;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreClient.Protocols
{
    class Mqtt : IProtocolInterface
    {
        private const string TOPIC_PREFIX = "iot2022test/";
        private IMqttClient mqttClient;
        private string endpoint;

        public Mqtt(string endpoint)
        {
            this.endpoint = endpoint;

            Connect().GetAwaiter().GetResult();
        }

        private async Task<MqttClientConnectResult> Connect()
        {
            var factory = new MqttFactory();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(this.endpoint)
                .Build();

            mqttClient = factory.CreateMqttClient();

            return await mqttClient.ConnectAsync(options, CancellationToken.None);
        }

        public async void Send(string data, string sensor)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(TOPIC_PREFIX + sensor)
                .WithPayload(data)
                .WithExactlyOnceQoS()
                .Build();

            await mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}
