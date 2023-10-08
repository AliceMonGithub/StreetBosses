namespace Server.BusinessLogic
{
    public sealed class Notification
    {
        private string _message;

        public Notification(string message)
        {
            _message = message;
        }

        public string Message => _message;
    }
}