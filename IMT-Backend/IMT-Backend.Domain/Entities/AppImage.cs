namespace IMT_Backend.Domain.Entities
{
    public class AppImage
    {
       public Guid Id { get; set; }
       public byte[] Content { get; set; }
       public string Type { get; set; }
       public string UserId { get; set; }
       public List<User> Users { get; set; }
    
    }
}
