namespace BasicCRUD.Domain.DTOs.User
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
    }
}
