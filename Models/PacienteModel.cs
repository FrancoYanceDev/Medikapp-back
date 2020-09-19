using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class PacienteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int id_doctor { get; set; }
        public string nombre { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }
    }
}