## ASP.NET Web API

1. Using ASP.NET Web API create REST services for the Student System demo from Code First presentation in the Databases course. Use high-quality code, use Repository pattern and create services for all available models. Do not use scaffolding.
2. Using ASP.NET Web API and Entity Framework (database first or code first) create a database and web services with full CRUD (create, read, update, delete) operations for hierarchy of following classes:
    * Artists (Name, Country, DateOfBirth, etc.)
    * Albums (Title, Year, Producer, etc.)
    * Songs (Title, Year, Genre, etc.)
    * Every album has a list of artists
    * Every song has artist
    * Every album has list of songs
3. Create console application and demonstrate the use of all service operations using the HttpClient class (with both JSON and XML)
4. * Create JavaScript-based single page application and consume the service to display user interface for:
    * Creating, updating and deleting artists, songs and albums (with cascade deleting)
    * Show pageable, sortable and filterable artists, songs and albums using OData
