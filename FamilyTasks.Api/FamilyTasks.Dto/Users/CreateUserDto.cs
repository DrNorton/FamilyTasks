namespace FamilyTasks.Dto.Users
{
    public class CreateUserDto
    {
      
        private readonly string _phone;
        private readonly string _password;

        public CreateUserDto(string phone, string password)
        {
            _phone = phone;
            _password = password;
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
