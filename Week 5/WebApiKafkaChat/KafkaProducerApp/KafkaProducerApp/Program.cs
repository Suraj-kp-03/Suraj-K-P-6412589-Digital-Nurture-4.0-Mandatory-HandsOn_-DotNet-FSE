using System;
using System.Threading.Tasks;
using Confluent.Kafka;

class Program
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

         var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.WriteLine("Enter messages to send : Kafka topic 'chat-room-2'. Type 'exit' to quit.");

        string input;
        while ((input = Console.ReadLine()) != "exit")
        {
            try
            {
                var deliveryResult = await producer.ProduceAsync("chat-room-2", new Message<Null, string> { Value = input });
                Console.WriteLine($"Message was Sent Successfully: '{deliveryResult.Value}' to partition {deliveryResult.Partition}, offset {deliveryResult.Offset}");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Message Not Sent: {e.Message}");
            }
        }
        producer.Dispose();
    }
}
