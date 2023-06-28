namespace MessengerApp
{
    public partial class MainWindow
    {
        public enum Status { Online, Offile }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Status status;


            public override string ToString()
            {
                return $"{Name} ({Age}) - {status}";
            }
        }
    }
    
}
