using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BantrAPI.Models.Subfields
{
    [BsonIgnoreExtraElements]
    public class Contact
    {
        [BsonElement("phoneNum")]
        public string phoneNum { get; set; }

        [BsonElement("givenName")]
        public string givenName { get; set; }

        [BsonElement("familyName")]
        public string familyName { get; set; }

        [BsonElement("email")]
        public string email { get; set; }
    }
}