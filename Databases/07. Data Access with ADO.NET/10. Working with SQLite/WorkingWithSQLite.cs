namespace DatabaseConnections
{
    using System;
    using System.Data.SQLite;
    using System.Linq;
    using DatabaseConnectionsAdoNet;

    public class WorkingWithSQLite
    {
        private static readonly BookLibrary bookLibrary = new BookLibrary();
        private static SQLiteConnection mySqlConnection;

        public static void Main()
        {
            // IMPORTANT: Find folders with names "x86" and "x64" in the project directory and move them into "bin/Debug"
            Console.WriteLine("-> IMPORTANT: Find folders with names 'x86' and 'x64' in the project directory and move them into 'bin/Debug'...\n");

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

            SQLiteCommand mySqlCommand = new SQLiteCommand(@"INSERT INTO Books (Title, Author, PublishDate, ISBN)
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

            SQLiteCommand mySqlCommand = new SQLiteCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                             FROM Books
                                                             WHERE CHARINDEX(@substring, Title)", mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@substring", substring);

            using (SQLiteDataReader reader = mySqlCommand.ExecuteReader())
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

            SQLiteCommand mySqlCommand = new SQLiteCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                             FROM Books", mySqlConnection);
                
            using (SQLiteDataReader reader = mySqlCommand.ExecuteReader())
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

            SQLiteCommand mySqlCommand = new SQLiteCommand(@"DELETE FROM Books
                                                             WHERE BookId > 0", mySqlConnection);

            var queryResult = mySqlCommand.ExecuteNonQuery();

            Console.WriteLine("    ({0} row(s) affected)\n", queryResult);
        }

        private static void ConnectToDatabase()
        {
            mySqlConnection = new SQLiteConnection(Settings.Default.DbConnection);
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