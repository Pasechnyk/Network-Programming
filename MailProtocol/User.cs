namespace MailProtocol
{
    public partial class MainWindow
    {
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }

            public override string ToString()
            {
                return Login;
            }

        }
    }
}
