namespace FamilyTasks.Dto.Users
{
    public class CreateUserDto
    {
        private readonly string _displayName;
        private readonly string _email;
        private readonly string _phone;
        private readonly string _password;

        public CreateUserDto(string displayName, string email, string phone, string password)
        {
            _displayName = displayName;
            _email = email;
            _phone = phone;
            _password = password;
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string Phone
        {
            get { return _phone; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
