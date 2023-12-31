
namespace Test.Models;

public class Contact : IContact
{
    public string? Firstname { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Lastname { get; set; } = null!;
    public string? Address { get; set; } = null!;
    public string? Phonenumber { get; set; } = null!;
}
