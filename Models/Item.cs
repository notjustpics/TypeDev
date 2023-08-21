using MongoDB.Bson;

namespace TypeDevApp.Models
{
    public class Item
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
