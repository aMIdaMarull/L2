using System.Xml.Serialization;

namespace Lab2
{
    public class PublishingHouse
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        public string Name { get; set; }

        public PublishingHouse()
        {
            
        }

        public PublishingHouse(int id, string name)
        {
            if (id < 0)
            {
                throw new ArgumentException("ID cannot be negative.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Publisher (Id: {Id}, Name: {Name})";
        }
    }
}
