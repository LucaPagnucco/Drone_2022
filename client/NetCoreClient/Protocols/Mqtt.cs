using System;
using System.Net;
using System.IO;
using System.Text;
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
        private const string TOPIC_PREFIX = "drone_1/";
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

        public async void Subscribe(string topic)
        {
            await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(TOPIC_PREFIX + topic).Build());

            Console.WriteLine("Iscritto al topic: " + TOPIC_PREFIX + topic);

            mqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine($"Data received: {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            });
        }
        
        public async void Send(string data, string sensor)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(TOPIC_PREFIX + sensor)
                .WithPayload(data)
                .WithExactlyOnceQoS()
                .WithRetainFlag()
                .Build();

            await mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}
