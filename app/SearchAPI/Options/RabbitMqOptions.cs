namespace SearchAPI.Options
{
    public class RabbitMqOptions
    {


        public RabbitMqOptions()
        {
            this.Host = "localhost";
            this.Port = 5672;
        }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


    }
}