/*
 * 9. Download and install MySQL database, MySQL Connector/Net 
 * (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool. 
 * Create a MySQL database to store Books (title, author, publish date and ISBN). 
 * Write methods for listing all books, finding a book by name and adding a book.
 */

namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Linq;
    using MySql.Data.MySqlClient;

    public class WorkingWithMySql
    {
        private static readonly BookLibrary bookLibrary = new BookLibrary();
        private static MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.DbConnection);

        public static void Main()
        {
            // You must change Pw value (Password) in Settings.settings

            try
            {
                ConnectToDatabase();

                AddBooks();
                FindBooksByName("Christmas");
                ListingAllBooks();
                DeleteAllRecords();
            }
            finally
            {
                DisconnectFromDatabase();
            }
        }

        private static void AddBooks()
        {
            Console.WriteLine("Adding books: ");

            MySqlCommand mySqlCommand = new MySqlCommand(@"INSERT INTO Books (Title, Author, PublishDate, ISBN)
                                                           VALUES (@title, @author, @publishDate, @isbn)", mySqlConnection);

            foreach (var book in bookLibrary.Books)
            {
                var title = book.Title;
                var author = book.Author;
                var publishDate = book.PublishDate;
                var isbn = book.ISBN;

                mySqlCommand.Parameters.AddWithValue("@title", title);
                mySqlCommand.Parameters.AddWithValue("@author", author);
                mySqlCommand.Parameters.AddWithValue("@publishDate", publishDate);
                mySqlCommand.Parameters.AddWithValue("@isbn", isbn);

                var queryResult = mySqlCommand.ExecuteNonQuery();
                mySqlCommand.Parameters.Clear();

                Console.WriteLine("    ({0} row(s) affected)", queryResult);
            }
        }

        private static void FindBooksByName(string substring)
        {
            Console.WriteLine("\nFinding books by name '{0}':", substring);

            MySqlCommand mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM Books
                                                           WHERE LOCATE(@substring, Title)", mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@substring", substring);

            using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = (DateTime)reader["PublishDate"];
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book()
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        ISBN = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void ListingAllBooks()
        {
            Console.WriteLine("Listing all books: ");

            MySqlCommand mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM Books", mySqlConnection);

            using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = (DateTime)reader["PublishDate"];
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book()
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        ISBN = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void DeleteAllRecords()
        {
            Console.WriteLine("Deleting all books: ");

            MySqlCommand mySqlCommand = new MySqlCommand(@"DELETE FROM Books
                                                           WHERE BookId > 0", mySqlConnection);

            var queryResult = mySqlCommand.ExecuteNonQuery();

            Console.WriteLine("    ({0} row(s) affected)\n", queryResult);
        }

        private static void ConnectToDatabase()
        {
            mySqlConnection = new MySqlConnection(Settings.Default.DbConnection);
            mySqlConnection.Open();
        }

        private static void DisconnectFromDatabase()
        {
            if (mySqlConnection != null)
            {
                mySqlConnection.Close();
            }
        }
    }
}