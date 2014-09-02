## MongoDB and using MongoDB with .NET

1. Research how to create a MongoDB database in [MongoLab](http://mongolab.com)
2. Create a chat database in MongoLab
  * The database should keep messages
  * Each message has a text, date and an embedded field user
  * Users have username
3. Create a Chat client, using the Chat MongoDB database
  * When the client starts, it asks for username
    * Without password
  * Logged-in users can see 
    * All posts, since they have logged in
    * History of all posts
  * Logged-in users can post message
  * Create a simple WPF application for the client
