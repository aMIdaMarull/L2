using System.Xml.Serialization;

namespace Lab2
{
    public class Book
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public List<Author> Authors { get; set; }
        public DateOnly PublicationDate { get; set; }
        public PublishingHouse Publisher { get; set; }
        public List<string> InventoryNumbers { get; set; }

        public Book()
        {
            
        }

        public Book(int id, string title, double price, List<Author> authors, 
            DateOnly publicationDate, PublishingHouse publisher, List<string> inventoryNumbers)
        {
            if (id < 0)
            {
                throw new ArgumentException("ID cannot be negative.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }

            if (authors == null || authors.Count == 0)
            {
                throw new ArgumentException("At least one author is required.", nameof(authors));
            }

            if (publisher == null)
            {
                throw new ArgumentNullException(nameof(publisher), "Publisher cannot be null.");
            }

            if (inventoryNumbers == null)
            {
                throw new ArgumentNullException(nameof(inventoryNumbers), "Inventory numbers cannot be null.");
            }

            Id = id;
            Title = title;
            Price = price;
            Authors = authors;
            PublicationDate = publicationDate;
            Publisher = publisher;
            InventoryNumbers = inventoryNumbers;
        }

        public override string ToString()
        {
            return $"Book (Id: {Id}, Title: {Title}, Price: {Price})";
        }
    }
}
