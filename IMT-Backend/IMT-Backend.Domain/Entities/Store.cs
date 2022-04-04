namespace IMT_Backend.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid? ImageId { get; set; }
        public AppImage Image { get; set; }
    }
}
