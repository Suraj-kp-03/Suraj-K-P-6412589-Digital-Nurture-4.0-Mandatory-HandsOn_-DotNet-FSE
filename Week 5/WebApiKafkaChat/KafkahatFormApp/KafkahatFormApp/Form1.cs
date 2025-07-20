using System;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkahatFormApp
{
    public partial class Form1 : Form
    {
        private readonly string topicName = "chat-room-2"; 
        private readonly string bootstrapServers = "localhost:9092";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            var config = new ProducerConfig { BootstrapServers = bootstrapServers };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var deliveryResult = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
                    MessageBox.Show($" Message sent to Kafka:\n'{message}'\nPartition: {deliveryResult.Partition}, Offset: {deliveryResult.Offset}");
                    txtMessage.Clear();
                }
                catch (ProduceException<Null, string> ex)
                {
                    MessageBox.Show($"Kafka produce error: {ex.Message}");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
