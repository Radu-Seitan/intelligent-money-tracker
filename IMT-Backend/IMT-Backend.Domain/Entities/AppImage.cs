namespace IMT_Backend.Domain.Entities
{
    public class AppImage
    {
       public Guid Id { get; set; }
       public byte[] Content { get; set; }
       public string Type { get; set; }
       public string StoreId { get; set; }
       public List<Store> Stores { get; set; }
    }
}
