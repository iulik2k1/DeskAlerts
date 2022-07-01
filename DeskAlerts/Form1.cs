using RabbitMQ.Client;
using System.Text;

namespace DeskAlerts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "acknowledge",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                string message = txtMessage.Text;
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                      routingKey: txtUser.Text,
                                      basicProperties: null,
                                      body: body);
                textBox1.AppendText("Sent to user: " + txtUser.Text + "   message: " + message + Environment.NewLine);
            }

        }


        private void GetMessages(object sender, EventArgs e)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

            }
        }
    }
}