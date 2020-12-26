namespace signalr_test_tools.Models
{
    public class Message
    {
        public string MethodName { get; set; }
        public System.Text.Json.JsonDocument Data
        {
            get
            {
                System.Text.Json.JsonDocument json = null;
                try
                {
                    json = System.Text.Json.JsonDocument.Parse(DataText);
                    return json;
                }
                catch 
                {
                    return json;
                }
            }
        }
        public string DataText { get; set; }
    }
}