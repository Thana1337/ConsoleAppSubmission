namespace Test.Models
{
    public interface IContact
    {
        string? Address { get; set; }
        string? Email { get; set; }
        string? Firstname { get; set; }
        string? Lastname { get; set; }
        string? Phonenumber { get; set; }
    }
}