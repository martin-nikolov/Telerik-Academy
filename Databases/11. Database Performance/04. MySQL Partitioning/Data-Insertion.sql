DELIMITER $$
CREATE PROCEDURE InsertRandomLogs(IN NumRows INT)
    BEGIN
        DECLARE i INT;
        SET i = 1;
        START TRANSACTION;
        WHILE i <= NumRows DO
            INSERT INTO `logs`(`Message`, `PublishDate`)
            VALUES (conv(floor(rand() * 99999999999999), 20, 36), FROM_UNIXTIME(RAND() * 2147483647));
            SET i = i + 1;
        END WHILE;
        COMMIT;
    END$$
DELIMITER ;

CALL InsertRandomLogs(1000000);

-- SELECT COUNT(*) FROM Logs;