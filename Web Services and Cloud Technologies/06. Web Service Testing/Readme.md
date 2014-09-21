## Web Service Testing

1. Develop a REST API for a BugLogger app
 * Bugs have status:
   * fixed, assigned, for-testing, pending
 * Bugs have __text__ and __logDate__
 * Newly added bugs always have status __"pending"__
 * Bugs can be queried – get all bugs, get bugs after a date, get only pending bugs, etc ...
2. Develop a database in MS SQL Server that keeps the data of the bugs
3. Create repositories to work with the bugs database
4. Provide a REST API to work with the bugs
 * Using WebAPI
 * Provide the following actions:
    * Log new bug `POST .../bugs`
    * Get all bugs `GET .../bugs`
    * Get bugs after a specific date: `GET .../bugs?date=22-06-2014`
    * Get bugs by status `GET .../bugs?type=pending`
    * Change bug status `PUT .../bugs/{id}`
5. Write unit tests to test the BugLogger
 * Use a mocking framework
6. Write integration tests to test the BugLogger
