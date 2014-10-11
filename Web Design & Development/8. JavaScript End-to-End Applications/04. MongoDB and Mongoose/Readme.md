## MongoDB and Mongoose

1. Create a modules for Chat, that keep the data into a local MongoDB instance
    * The module should have the following functionality:

```js
    var chatDb = require('chat-db');

    // Inserts a new user records into the DB
    chatDb.registerUser({user: 'DonchoMinkov', pass: '123456q'});

    // Inserts a new message record into the DB
    // the message has two references to users (from and to)
    chatDb.sendMessage({
        from: 'DonchoMinkov',
        to: 'NikolayKostov',
        text: 'Hey, Niki!'
    });

    // Returns an array with all messages between two users
    chatDb.getMessages({
        with: 'DonchoMinkov',
        and: 'NikolayKostov'
    });
```
