using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class RegisterCommand : IRequest<Nothing>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public RegisterCommand(string email, string password, string name, string imageSource)
        {
            Email = email;
            Password = password;
            Name = name;
            ImageSource = imageSource;
        }
    }
}
