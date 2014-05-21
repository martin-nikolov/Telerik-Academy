-- Without partitioning
CREATE SCHEMA `simpledatabase`;

CREATE TABLE `simpledatabase`.`logs` (
  `LogId` INT NOT NULL AUTO_INCREMENT,
  `Message` TEXT NOT NULL,
  `PublishDate` DATETIME NOT NULL,
  PRIMARY KEY (`LogId`));

-- With partitioning
CREATE SCHEMA `simpledatabase`;

CREATE TABLE `simpledatabase`.`logs` (
  `LogId` INT NOT NULL AUTO_INCREMENT,
  `Message` nvarchar(300) NOT NULL,
  `PublishDate` DATETIME NOT NULL,
  PRIMARY KEY (`LogId`, `PublishDate`)
) PARTITION BY RANGE(YEAR(PublishDate)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010),
    PARTITION p3 VALUES LESS THAN MAXVALUE
);

-- EXPLAIN PARTITIONS SELECT * FROM Logs;