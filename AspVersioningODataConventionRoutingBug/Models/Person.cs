namespace AspVersioningODataConventionRoutingBug.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Child> Children { get; set; }
    }
}
