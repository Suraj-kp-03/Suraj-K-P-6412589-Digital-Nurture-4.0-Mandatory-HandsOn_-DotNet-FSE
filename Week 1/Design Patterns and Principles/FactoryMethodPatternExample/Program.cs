using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPatternExample
{
    public interface DocumentInterface
    {
        void open();
        void close();
        void save();
        void print();

    }
    public class WordDocument : DocumentInterface
    {
        public void open()
        {
            Console.WriteLine("Opening word document. ");
        }
        public void close()
        {
            Console.WriteLine("Closing word document. ");
        }   
        public void save()
        {
            Console.WriteLine("Saving word document. ");
        }
        public void print()
        {
            Console.WriteLine("Printing word document. ");
        }   
    }
    public class PdfDocument : DocumentInterface
    {
        public void open()
        {
            Console.WriteLine("Opening pdf document. ");
        }
        public void close()
        {
            Console.WriteLine("Closing pdf document. ");
        }   
        public void save()
        {
            Console.WriteLine("Saving pdf document. ");
        }
        public void print()
        {
            Console.WriteLine("Printing pdf document. ");
        }
    }
    public class ExcelDocument : DocumentInterface
    {
        public void open()
        {
            Console.WriteLine("Opening excel document. ");
        }
        public void close()
        {
            Console.WriteLine("Closing excel document. ");
        }   
        public void save()
        {
            Console.WriteLine("Saving excel document. ");
        }
        public void print()
        {
            Console.WriteLine("Printing excel document. ");
        }
    }
    public abstract class DocumentFactory // This is the FactoryClass used to create the DocumentInterface objects. CreateDocument() is an abstract method that will be overridden in the derived classes of DocumentFactory, that can acces the DocumentInterface methods through the CreateDocument() method which returns a DocumentInterface objects.
    {
        public abstract DocumentInterface CreateDocument();
        public void PrintPreview() // This is used to show the encapsulation of the DocumentInterface which was under the Create Document method. When they use PrintPreview, they only can see open and print methods.
        {
            DocumentInterface doc = CreateDocument();
            doc.open();
            doc.print();
        }
    }
    public class WordDocumentFactory : DocumentFactory
    {
        public override DocumentInterface CreateDocument()
        {
            return new WordDocument();
        }
    }
    public class PdfDocumentFactory : DocumentFactory
    {
        public override DocumentInterface CreateDocument()
        {
            return new PdfDocument();
        }
    }
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override DocumentInterface CreateDocument()
        {
            return new ExcelDocument();
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory Method Deminstration\n");
            Console.WriteLine("Enter the type of Document to test(word,pdf,excel):");
            string documentName = Console.ReadLine().ToLower(); // Used to convert input to lowercase for comparing the document type to be created.
            DocumentFactory factory = null;
            if (documentName == "word")
            {
                factory = new WordDocumentFactory();
                factory.CreateDocument();
            }
            else if (documentName == "pdf")
            {
                factory = new PdfDocumentFactory();
                factory.CreateDocument();
            }
            else if (documentName == "excel")
            {
                factory = new ExcelDocumentFactory();
                factory.CreateDocument();
            }
            else
            {
                Console.WriteLine("Invalid Document Type Entered");
            }
            // Calling alll the methods of the DocumentInterface to show that the Factory Method Pattern is implemented successfully.
            DocumentInterface docType = factory.CreateDocument();
            docType.open();
            docType.save();
            docType.print();
            docType.close();

            Console.WriteLine("Factory Method Patern Example was Implemented Successfully");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); // Wait for user input before closing the console window
        }

    }
}
