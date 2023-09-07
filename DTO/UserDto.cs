namespace aspdotnetwebapi.DTO
{
    public class UserDto
    {
        public required string? Name { get; set; }
        public string? Email { get; set; }
        public required string? Password { get; set; }
    }
}
