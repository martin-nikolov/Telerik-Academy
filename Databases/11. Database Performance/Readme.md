## Database Performance

1. Create a table in SQL Server with 10 000 000 log entries (date + text). Search in the table by date range. Check the speed (without caching).
* Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
* Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.
* Create the same table in MySQL and partition it by date (1990, 2000, 2010). Fill 1 000 000 log entries. Compare the searching speed in all partitions (random dates) to certain partition (e.g. year 1995).
