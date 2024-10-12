namespace AppLogin.Models
{
    public class _Employees
    {
        public int ID_Employees { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public required string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public required string City { get; set; }
        public required string Email { get; set; }
        public required string Status { get; set; }

    }
}
