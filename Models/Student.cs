namespace CrudUsingADO.NET.Models
{
    public class Student
    {
        public string? RefNo { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
