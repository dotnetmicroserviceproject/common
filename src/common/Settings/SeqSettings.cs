namespace common.Settings
{
    public class SeqSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string ServerUrl
        {
            get { return $"http://{Host}:{Port}"; }
        }
    }
}
