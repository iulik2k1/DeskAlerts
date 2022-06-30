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
            if (txtUser.Text.Length > 0 & txtMessage.Text.Length > 0)
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
                    channel.BasicPublish(exchange: "exchange",
                                          routingKey: txtUser.Text,
                                          basicProperties: null,
                                          body: body);
                   
                    textBox1.AppendText("Sent to: " + txtUser.Text + " message: " + txtMessage.Text + Environment.NewLine);

                }

                lblStatus.Text = "OK";
            }
            else
            {
                lblStatus.Text = "Empty boxes, please fill!";
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