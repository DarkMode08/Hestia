namespace AppLogin.Models
{
    public class _User
    {
        public int id_User { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
