using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace Lab2
{
    public class Program
    {

        private static (List<Author>, List<PublishingHouse>, List<Book>) Init()
        {
            var author1 = new Author(1, "John", "Doe");
            var author2 = new Author(2, "Jane", "Smith");
            var author3 = new Author(3, "Michael", "Johnson");
            var author4 = new Author(4, "Emily", "Brown");
            var author5 = new Author(5, "David", "Williams");
            var author6 = new Author(6, "Olivia", "Davis");
            var author7 = new Author(7, "James", "Miller");

            var authors = new List<Author>() { author1, author2, author3, author4, author5, author6, author7 };

            var publisher1 = new PublishingHouse(1, "Horizon Press");
            var publisher2 = new PublishingHouse(2, "Noble Publications");
            var publisher3 = new PublishingHouse(3, "Starlight Books");
            var publisher4 = new PublishingHouse(4, "Grand Central Publishing");
            var publisher5 = new PublishingHouse(5, "Beacon House Books");
            var publisher6 = new PublishingHouse(6, "Moonstone Publishers");
            var publisher7 = new PublishingHouse(7, "Sunflower Press");

            var publishers = new List<PublishingHouse>() { publisher1, publisher2, publisher3, publisher4,
                publisher5, publisher6, publisher7 };

            var book1 = new Book(1, "The Lost World", 19.99, new List<Author> { author1 }, new DateOnly(1954, 1, 15), publisher1, new List<string> { "ABC12345", "XYZ78900" });
            var book2 = new Book(2, "A Tale of Two Cities", 24.95, new List<Author> { author2 }, new DateOnly(1965, 4, 30), publisher2, new List<string> { "DEF45678" });
            var book3 = new Book(3, "The Catcher in the Rye", 14.50, new List<Author> { author3 }, new DateOnly(1978, 8, 10), publisher3, new List<string> { "GHI12345", "OPQ67890" });
            var book4 = new Book(4, "To Kill a Mockingbird", 29.99, new List<Author> { author4 }, new DateOnly(1983, 12, 5), publisher4, new List<string> { "JKL23456", "RST34567", "UVW45678" });
            var book5 = new Book(5, "Pride and Prejudice", 9.99, new List<Author> { author5 }, new DateOnly(1992, 6, 20), publisher5, new List<string> { "XYZ56789" });
            var book6 = new Book(6, "The Great Gatsby", 39.95, new List<Author> { author6 }, new DateOnly(2005, 9, 8), publisher6, new List<string> { "ABC23456", "XYZ78901" });
            var book7 = new Book(7, "Moby-Dick", 12.99, new List<Author> { author7 }, new DateOnly(2010, 3, 17), publisher7, new List<string> { "DEF34567", "LMN89012" });
            var book8 = new Book(8, "Harry Potter", 17.50, new List<Author> { author1, author5 }, new DateOnly(2015, 7, 22), publisher1, new List<string> { "GHI45678", "OPQ90123" });
            var book9 = new Book(9, "The Hobbit", 22.75, new List<Author> { author3, author4 }, new DateOnly(2020, 11, 12), publisher2, new List<string> { "JKL56789", "RST01234" });
            var book10 = new Book(10, "1984", 8.49, new List<Author> { author2, author7 }, new DateOnly(2023, 2, 28), publisher3, new List<string> { "UVW67890", "XYZ01234" });
            var book11 = new Book(11, "The Da Vinci Code", 15.99, new List<Author> { author1 }, new DateOnly(2003, 3, 18), publisher4, new List<string> { "ABC98765" });
            var book12 = new Book(12, "Brave New World", 12.75, new List<Author> { author5 }, new DateOnly(1932, 7, 14), publisher5, new List<string> { "XYZ34567" });
            var book13 = new Book(13, "The Lord of the Rings", 29.99, new List<Author> { author6 }, new DateOnly(1954, 7, 29), publisher6, new List<string> { "DEF23456", "LMN78901" });
            var book14 = new Book(14, "Crime and Punishment", 18.49, new List<Author> { author6, author1 }, new DateOnly(1866, 1, 14), publisher7, new List<string> { "GHI67890" });
            var book15 = new Book(15, "The Shining", 21.99, new List<Author> { author5, author2 }, new DateOnly(1977, 1, 28), publisher1, new List<string> { "OPQ23456" });
            var book16 = new Book(16, "One Hundred Years of Solitude", 16.95, new List<Author> { author3, author4 }, new DateOnly(1967, 5, 30), publisher2, new List<string> { "RST67890" });
            var book17 = new Book(17, "The Odyssey", 13.75, new List<Author> { author1, author7, author5 }, new DateOnly(2008, 4, 23), publisher3, new List<string> { "UVW12345" });
            var book18 = new Book(18, "The Road", 11.99, new List<Author> { author6, author2, author4 }, new DateOnly(2006, 9, 26), publisher4, new List<string> { "JKL90123" });
            var book19 = new Book(19, "The Hunger Games", 14.50, new List<Author> { author3 }, new DateOnly(2008, 9, 14), publisher5, new List<string> { "GHI56789" });
            var book20 = new Book(20, "The Alchemist", 12.99, new List<Author> { author5 }, new DateOnly(1988, 8, 15), publisher6, new List<string> { "XYZ01234" });

            var books = new List<Book>() { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10,
            book11, book12, book13, book14, book15, book16, book17, book18, book19, book20 };

            return (authors, publishers, books);
        }

        public static void CreateDocument(string name)
        {
            var authors = new List<Author>();
            var publishers = new List<PublishingHouse>();
            var books = new List<Book>();

            (authors, publishers, books) = Init();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\n";

            using (XmlWriter writer = XmlWriter.Create(name, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Books");

                foreach (var book in books)
                {
                    writer.WriteStartElement("Book");
                    writer.WriteAttributeString("Id", book.Id.ToString());

                    writer.WriteElementString("Title", book.Title);
                    writer.WriteElementString("Price", book.Price.ToString());

                    writer.WriteStartElement("Authors");
                    foreach (var author in book.Authors)
                    {
                        writer.WriteStartElement("Author");
                        writer.WriteAttributeString("Id", author.Id.ToString());
                        writer.WriteElementString("FirstName", author.FirstName);
                        writer.WriteElementString("LastName", author.LastName);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteElementString("PublicationDate", book.PublicationDate.ToString("yyyy-MM-dd"));
                    writer.WriteStartElement("Publisher");
                    writer.WriteAttributeString("Id", book.Publisher.Id.ToString());
                    writer.WriteElementString("Name", book.Publisher.Name);
                    writer.WriteEndElement();

                    writer.WriteStartElement("InventoryNumbers");
                    foreach (var inventoryNumber in book.InventoryNumbers)
                    {
                        writer.WriteElementString("InventoryNumber", inventoryNumber);
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }

        public static (bool, List<string>?) Check(string xsdPath, string xmlPath)
        {

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, xsdPath);

            XDocument xmlDocument = XDocument.Load(xmlPath);

            bool validationErrors = false;
            var errors = new List<string>();

            xmlDocument.Validate(schemaSet, (o, e) =>
            {
                errors.Add(e.Message);
                validationErrors = true;
            });

            if (!validationErrors)
            {
                return (true, null);
            }

            return (false, errors);
        }

        public static void OutputXmlToConsole(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"File '{filename}' not found.");
            }

            // Load the XML document from the file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            // Create a StringWriter to capture the XML output
            using (StringWriter stringWriter = new StringWriter())
            {
                // Create an XmlTextWriter to format the output
                using (XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;

                    // Write the XML document to the XmlTextWriter
                    xmlDoc.WriteTo(xmlWriter);

                    // Output the XML to the console
                    Console.WriteLine(stringWriter.ToString());
                }
            }
        }

        public static List<Book> ReadWithSerializer(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"File '{filename}' not found.");
            }

            var books = new List<Book>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("Books"));
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                books = (List<Book>)serializer.Deserialize(stream);
            }

            return books;
        }

        public static List<Book> ReadWithXmlDocument(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"File '{filename}' not found.");
            }

            var books = new List<Book>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            XmlNodeList bookNodes = xmlDoc.SelectNodes("Books/Book");

            foreach (XmlNode bookNode in bookNodes)
            {
                Book book = new Book
                {
                    Id = int.Parse(bookNode.Attributes["Id"].Value),
                    Title = bookNode.SelectSingleNode("Title").InnerText,
                    Price = double.Parse(bookNode.SelectSingleNode("Price").InnerText),
                    Authors = new List<Author>(),
                    PublicationDate = DateOnly.Parse(bookNode.SelectSingleNode("PublicationDate").InnerText),
                    Publisher = new PublishingHouse
                    {
                        Id = int.Parse(bookNode.SelectSingleNode("Publisher").Attributes["Id"].Value),
                        Name = bookNode.SelectSingleNode("Publisher/Name").InnerText
                    },
                    InventoryNumbers = new List<string>()
                };

                XmlNodeList authorNodes = bookNode.SelectNodes("Authors/Author");
                foreach (XmlNode authorNode in authorNodes)
                {
                    Author author = new Author
                    {
                        Id = int.Parse(authorNode.Attributes["Id"].Value),
                        FirstName = authorNode.SelectSingleNode("FirstName").InnerText,
                        LastName = authorNode.SelectSingleNode("LastName").InnerText
                    };
                    book.Authors.Add(author);
                }

                XmlNodeList inventoryNodes = bookNode.SelectNodes("InventoryNumbers/InventoryNumber");
                foreach (XmlNode inventoryNode in inventoryNodes)
                {
                    book.InventoryNumbers.Add(inventoryNode.InnerText);
                }

                books.Add(book);
            }

            return books;
        }

        public static void Queries(string filename)
        {
            XDocument xml = XDocument.Load(filename);
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Query 1: Get all books available");
            Console.WriteLine();

            var q1 = xml.Descendants("Book")
            .Select(book => book.Element("Title").Value);


            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 2: Get all unique authors");
            Console.WriteLine();

            var q2 = xml.Descendants("Author")
                .Select(author => author.Element("FirstName").Value + " " + author.Element("LastName").Value)
                .Distinct();


            foreach (var item in q2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 3: Get all unique publishers");
            Console.WriteLine();

            var q3 = xml.Descendants("Publisher")
                .Select(publisher =>
                new
                {
                    Id = publisher.Attribute("Id").Value,
                    Name = publisher.Element("Name").Value
                })
                .Distinct();


            foreach (var item in q3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 4: Get all books cheaper than 15$");
            Console.WriteLine();

            var q4 = xml.Descendants("Book")
                .Where(book => Convert.ToDouble(book.Element("Price").Value) < 15)
                .Select(book =>
                    new
                    {
                        Title = book.Element("Title").Value,
                        Price = Convert.ToDouble(book.Element("Price").Value)
                    });


            foreach (var item in q4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            Console.WriteLine("Query 5: Display all books with more than 1 author");
            Console.WriteLine();

            var q5 = xml.Descendants("Book")
            .Where(book => book.Element("Authors").Elements("Author").Count() > 1)
            .Select(book =>
                new
                {
                    Title = book.Element("Title").Value,
                    AuthorCount = book.Element("Authors").Elements("Author").Count()
                });


            foreach (var item in q5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 6: Display all books published after 2005, ordered by publication date");
            Console.WriteLine();

            var q6 = xml.Descendants("Book")
            .Where(book => DateOnly.Parse(book.Element("PublicationDate").Value) > new DateOnly(2005, 1, 1))
            .OrderBy(book => DateOnly.Parse(book.Element("PublicationDate").Value))
            .Select(book =>
                new
                {
                    Title = book.Element("Title").Value,
                    PublicationDate = DateOnly.Parse(book.Element("PublicationDate").Value)
                });


            foreach (var item in q6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 7: Display average book price");
            Console.WriteLine();

            var q7 = xml.Descendants("Book")
                .Average(book => double.Parse(book.Element("Price").Value));



            Console.WriteLine(Math.Round(q7, 3));
            Console.WriteLine();

            Console.WriteLine("Query 8: Display count for each book in library");
            Console.WriteLine();

            var q8 = xml.Descendants("Book")
                .Select(book =>
                    new
                    {
                        Title = book.Element("Title").Value,
                        InventoryCount = book.Elements("InventoryNumbers").Elements("InventoryNumber").Count()
                    });


            foreach (var item in q8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 9: Display author along with count of books he wrote");
            Console.WriteLine();

            var q9 = xml.Descendants("Book")
                .SelectMany(book => book.Descendants("Author"))
                .GroupBy(author => int.Parse(author.Attribute("Id").Value))
                .Select(group =>
                new
                {
                    AuthorId = group.Key,
                    AuthorName = group.First().Elements("FirstName").First().Value + " " + 
                        group.First().Elements("LastName").First().Value,
                    BookCount = group.Count()
                });


            foreach (var item in q9)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 10: Display books published by \"Moonstone Publishers\", ordered by price descending");
            Console.WriteLine();

            var q10 = xml.Descendants("Book")
                .Where(book => book.Element("Publisher").Element("Name").Value == "Moonstone Publishers")
                .OrderByDescending(book => double.Parse(book.Element("Price").Value))
                .Select(book =>
                new
                {
                    Title = book.Element("Title").Value,
                    Price = double.Parse(book.Element("Price").Value)
                });


            foreach (var item in q10)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 11: Display id and name of authors whose name starts on j");
            Console.WriteLine();

            var q11 = xml.Descendants("Author")
                .Where(author => author.Element("FirstName").Value.StartsWith("J"))
                .Select(author =>
                new
                {
                    Id = int.Parse(author.Attribute("Id").Value),
                    Name = author.Element("FirstName").Value + " " + author.Element("LastName").Value
                })
                .Distinct();


            foreach (var item in q11)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 12: Display average book price for each publisher");
            Console.WriteLine();

            var q12 = xml.Descendants("Book")
                .GroupBy(book => new
                {
                    PublisherId = book.Element("Publisher").Attribute("Id").Value,
                    PublisherName = book.Element("Publisher").Element("Name").Value
                })
                .Select(group =>
                {
                    var publisherId = group.Key.PublisherId;
                    var publisherName = group.Key.PublisherName;
                    var averagePrice = group.Select(book => double.Parse(book.Element("Price").Value)).Average();
                    return new { PublisherId = publisherId, PublisherName = publisherName, AveragePrice = Math.Round(averagePrice, 3) };
                });


            foreach (var item in q12)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Query 13: Display all inventory numbers ");
            Console.WriteLine();

            var q13 = xml.Descendants("InventoryNumber")
                .Select(inventoryNumber => inventoryNumber.Value)
                .OrderBy(x => x);
                


            foreach (var item in q13)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            Console.WriteLine("Query 14: Display publisher with most expensive book  ");
            Console.WriteLine();

            var q14 = xml.Descendants("Book")
                .Select(book => new
                {
                    PublisherId = (string)book.Element("Publisher").Attribute("Id"),
                    PublisherName = (string)book.Element("Publisher").Element("Name"),
                    BookPrice = double.Parse(book.Element("Price").Value)
                })
                .GroupBy(publisher => new { publisher.PublisherId, publisher.PublisherName })
                .Select(group =>
                {
                    var publisherId = group.Key.PublisherId;
                    var publisherName = group.Key.PublisherName;
                    var mostExpensiveBookPrice = group.Max(book => book.BookPrice);
                    return new { PublisherId = publisherId, PublisherName = publisherName, MostExpensiveBookPrice = mostExpensiveBookPrice };
                })
                .OrderByDescending(result => result.MostExpensiveBookPrice)
                .First();



            
            Console.WriteLine(q14);
            
            Console.WriteLine();

            Console.WriteLine("Query 15: Display all books written by James Miller ");
            Console.WriteLine();

            var q15 = xml.Descendants("Book")
                .Where(book => book.Elements("Authors")
                    .Elements("Author")
                    .Any(author =>
                        (string)author.Element("FirstName") == "James" &&
                        (string)author.Element("LastName") == "Miller"
                    ))
                .Select(book => new
                {
                    Title = (string)book.Element("Title"),
                    Price = double.Parse(book.Element("Price").Value)
                });



            foreach (var item in q15)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


        }

        static void Main(string[] args)
        {
            //CreateDocument("books.xml");

            bool val;
            List<string>? errors;

            (val, errors) = Check("schema.xsd", "books.xml");

            if (val)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("XML file is valid according to the schema!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();

                Queries("books.xml");
            }
            else
            {
                if (errors is not null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var item in errors)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }

            

        }
    }
}