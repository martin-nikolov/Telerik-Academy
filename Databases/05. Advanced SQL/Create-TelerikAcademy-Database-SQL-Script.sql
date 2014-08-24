-------------------------------------------------------------------
-- This script will create a sample database "TelerikAcademy" in --
-- MS SQL Server and will populate sample data in its tables.    --
-------------------------------------------------------------------

USE master
GO

CREATE DATABASE TelerikAcademy
GO

USE TelerikAcademy
GO

CREATE TABLE Towns(
  TownID int IDENTITY NOT NULL,
  Name nvarchar(50) NOT NULL,
  CONSTRAINT PK_Towns PRIMARY KEY CLUSTERED(TownID ASC)
)
GO

SET IDENTITY_INSERT Towns ON

INSERT INTO Towns (TownID, Name)
VALUES (1, 'Redmond')

INSERT INTO Towns (TownID, Name)
VALUES (2, 'Calgary')

INSERT INTO Towns (TownID, Name)
VALUES (3, 'Edmonds')

INSERT INTO Towns (TownID, Name)
VALUES (4, 'Seattle')

INSERT INTO Towns (TownID, Name)
VALUES (5, 'Bellevue')

INSERT INTO Towns (TownID, Name)
VALUES (6, 'Issaquah')

INSERT INTO Towns (TownID, Name)
VALUES (7, 'Everett')

INSERT INTO Towns (TownID, Name)
VALUES (8, 'Bothell')

INSERT INTO Towns (TownID, Name)
VALUES (9, 'San Francisco')

INSERT INTO Towns (TownID, Name)
VALUES (10, 'Index')

INSERT INTO Towns (TownID, Name)
VALUES (11, 'Snohomish')

INSERT INTO Towns (TownID, Name)
VALUES (12, 'Monroe')

INSERT INTO Towns (TownID, Name)
VALUES (13, 'Renton')

INSERT INTO Towns (TownID, Name)
VALUES (14, 'Newport Hills')

INSERT INTO Towns (TownID, Name)
VALUES (15, 'Carnation')

INSERT INTO Towns (TownID, Name)
VALUES (16, 'Sammamish')

INSERT INTO Towns (TownID, Name)
VALUES (17, 'Duvall')

INSERT INTO Towns (TownID, Name)
VALUES (18, 'Gold Bar')

INSERT INTO Towns (TownID, Name)
VALUES (19, 'Nevada')

INSERT INTO Towns (TownID, Name)
VALUES (20, 'Kenmore')

INSERT INTO Towns (TownID, Name)
VALUES (21, 'Melbourne')

INSERT INTO Towns (TownID, Name)
VALUES (22, 'Kent')

INSERT INTO Towns (TownID, Name)
VALUES (23, 'Cambridge')

INSERT INTO Towns (TownID, Name)
VALUES (24, 'Minneapolis')

INSERT INTO Towns (TownID, Name)
VALUES (25, 'Portland')

INSERT INTO Towns (TownID, Name)
VALUES (26, 'Duluth')

INSERT INTO Towns (TownID, Name)
VALUES (27, 'Detroit')

INSERT INTO Towns (TownID, Name)
VALUES (28, 'Memphis')

INSERT INTO Towns (TownID, Name)
VALUES (29, 'Ottawa')

INSERT INTO Towns (TownID, Name)
VALUES (30, 'Bordeaux')

INSERT INTO Towns (TownID, Name)
VALUES (31, 'Berlin')

INSERT INTO Towns (TownID, Name)
VALUES (32, 'Sofia')

SET IDENTITY_INSERT Towns OFF

GO

CREATE TABLE Addresses(
  AddressID int IDENTITY NOT NULL,
  AddressText nvarchar(100) NOT NULL,
  TownID int NULL,
  CONSTRAINT PK_Addresses PRIMARY KEY CLUSTERED (AddressID ASC)
)
GO

SET IDENTITY_INSERT Addresses ON

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (1, '108 Lakeside Court', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (2, '1343 Prospect St', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (3, '1648 Eastgate Lane', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (4, '2284 Azalea Avenue', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (5, '2947 Vine Lane', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (6, '3067 Maya', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (7, '3197 Thornhill Place', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (8, '3284 S. Blank Avenue', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (9, '332 Laguna Niguel', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (10, '3454 Bel Air Drive', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (11, '3670 All Ways Drive', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (12, '3708 Montana', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (13, '3711 Rollingwood Dr', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (14, '3919 Pinto Road', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (15, '4311 Clay Rd', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (16, '4777 Rockne Drive', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (17, '5678 Clear Court', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (18, '5863 Sierra', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (19, '6058 Hill Street', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (20, '6118 Grasswood Circle', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (21, '620 Woodside Ct.', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (22, '6307 Greenbelt Way', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (23, '6448 Castle Court', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (24, '6774 Bonanza', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (25, '6968 Wren Ave.', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (26, '7221 Peachwillow Street', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (27, '7270 Pepper Way', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (28, '7396 Stratton Circle', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (29, '7808 Brown St.', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (30, '7902 Grammercy Lane', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (31, '8668 Via Neruda', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (32, '8684 Military East', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (33, '8751 Norse Drive', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (34, '9320 Teakwood Dr.', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (35, '9435 Breck Court', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (36, '9745 Bonita Ct.', 5)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (37, 'Pascalstr 951', 31)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (38, '94, rue Descartes', 30)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (39, '1226 Shoe St.', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (40, '1399 Firestone Drive', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (41, '1902 Santa Cruz', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (42, '1970 Napa Ct.', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (43, '250 Race Court', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (44, '5672 Hale Dr.', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (45, '5747 Shirley Drive', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (46, '6387 Scenic Avenue', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (47, '6872 Thornwood Dr.', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (48, '7484 Roundtree Drive', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (49, '8157 W. Book', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (50, '9539 Glenside Dr', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (51, '9833 Mt. Dias Blv.', 8)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (52, '10203 Acorn Avenue', 2)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (53, '3997 Via De Luna', 23)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (54, 'Downshire Way', 23)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (55, '1411 Ranch Drive', 15)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (56, '3074 Arbor Drive', 15)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (57, '390 Ridgewood Ct.', 15)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (58, '9666 Northridge Ct.', 15)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (59, '9752 Jeanne Circle', 15)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (60, '8154 Via Mexico', 27)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (61, '80 Sunview Terrace', 26)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (62, '1825 Corte Del Prado', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (63, '2598 La Vista Circle', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (64, '3421 Bouncing Road', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (65, '3977 Central Avenue', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (66, '5086 Nottingham Place', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (67, '5379 Treasure Island Way', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (68, '8209 Green View Court', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (69, '8463 Vista Avenue', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (70, '9693 Mellowood Street', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (71, '991 Vista Verde', 17)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (72, '1061 Buskrik Avenue', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (73, '172 Turning Dr.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (74, '2038 Encino Drive', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (75, '2046 Las Palmas', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (76, '2059 Clay Rd', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (77, '207 Berry Court', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (78, '2080 Sycamore Drive', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (79, '2466 Clearland Circle', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (80, '2687 Ridge Road', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (81, '2812 Mazatlan', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (82, '3026 Anchor Drive', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (83, '3281 Hillview Dr.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (84, '3632 Bank Way', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (85, '371 Apple Dr.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (86, '504 O St.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (87, '5423 Champion Rd.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (88, '6057 Hill Street', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (89, '6870 D Bel Air Drive', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (90, '7338 Green St.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (91, '7511 Cooper Dr.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (92, '8152 Claudia Dr.', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (93, '8411 Mt. Orange Place', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (94, '9277 Country View Lane', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (95, '9784 Mt Etna Drive', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (96, '9825 Coralie Drive', 3)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (97, '1185 Dallas Drive', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (98, '1362 Somerset Place', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (99, '181 Gaining Drive', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (100, '1962 Cotton Ct.', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (101, '2176 Apollo Way', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (102, '2294 West 39th St.', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (103, '3238 Laguna Circle', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (104, '3385 Crestview Drive', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (105, '3665 Oak Creek Ct.', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (106, '3928 San Francisco', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (107, '475 Santa Maria', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (108, '5242 Marvelle Ln.', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (109, '5452 Corte Gilberto', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (110, '6629 Polson Circle', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (111, '7640 First Ave.', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (112, '7883 Missing Canyon Court', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (113, '8624 Pepper Way', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (114, '9241 St George Dr.', 7)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (115, '213 Stonewood Drive', 18)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (116, '2425 Notre Dame Ave', 18)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (117, '3884 Beauty Street', 18)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (118, '8036 Summit View Dr.', 18)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (119, '9605 Pheasant Circle', 18)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (120, '1245 Clay Road', 10)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (121, '1748 Bird Drive', 10)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (122, '310 Winter Lane', 10)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (123, '3127 El Camino Drive', 10)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (124, '3514 Sunshine', 10)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (125, '1144 Paradise Ct.', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (126, '1921 Ranch Road', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (127, '3333 Madhatter Circle', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (128, '342 San Simeon', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (129, '3848 East 39th Street', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (130, '5256 Chickpea Ct.', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (131, '5979 El Pueblo', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (132, '6580 Poor Ridge Court', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (133, '7435 Ricardo', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (134, '7691 Benedict Ct.', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (135, '7772 Golden Meadow', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (136, '8585 Los Gatos Ct.', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (137, '9314 Icicle Way', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (138, '9530 Vine Lane', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (139, '989 Crown Ct', 6)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (140, '25 95th Ave NE', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (141, '4095 Cooper Dr.', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (142, '4155 Working Drive', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (143, '463 H Stagecoach Rd.', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (144, '5050 Mt. Wilson Way', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (145, '5203 Virginia Lane', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (146, '5458 Gladstone Drive', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (147, '5553 Cash Avenue', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (148, '5669 Ironwood Way', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (149, '6697 Ridge Park Drive', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (150, '7048 Laurel', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (151, '8192 Seagull Court', 20)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (152, '350 Pastel Drive', 22)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (153, '34 Waterloo Road', 21)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (154, '8291 Crossbow Way', 28)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (155, '5678 Lakeview Blvd.', 24)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (156, '1356 Grove Way', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (157, '158 Walnut Ave', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (158, '1792 Belmont Rd.', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (159, '2275 Valley Blvd.', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (160, '3747 W. Landing Avenue', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (161, '3841 Silver Oaks Place', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (162, '4566 La Jolla', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (163, '4734 Sycamore Court', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (164, '5030 Blue Ridge Dr.', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (165, '5734 Ashford Court', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (166, '7726 Driftwood Drive', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (167, '8310 Ridge Circle', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (168, '896 Southdale', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (169, '9652 Los Angeles', 12)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (170, '2487 Riverside Drive', 19)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (171, '1397 Paradise Ct.', 14)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (172, '1400 Gate Drive', 14)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (173, '3030 Blackburn Ct.', 14)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (174, '4350 Minute Dr.', 14)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (175, '8967 Hamilton Ave.', 14)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (176, '9297 Kenston Dr.', 14)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (177, '9687 Shakespeare Drive', 14)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (178, '9100 Sheppard Avenue North', 29)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (179, '636 Vine Hill Way', 25)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (180, '101 Candy Rd.', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (181, '1275 West Street', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (182, '2137 Birchwood Dr', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (183, '2383 Pepper Drive', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (184, '2427 Notre Dame Ave.', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (185, '2482 Buckingham Dr.', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (186, '3066 Wallace Dr.', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (187, '3397 Rancho View Drive', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (188, '3768 Door Way', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (189, '4909 Poco Lane', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (190, '6369 Ellis Street', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (191, '6891 Ham Drive', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (192, '7297 RisingView', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (193, '8000 Crane Court', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (194, '8040 Hill Ct', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (195, '8467 Clifford Court', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (196, '9006 Woodside Way', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (197, '9322 Driving Drive', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (198, '9863 Ridge Place', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (199, '9882 Clay Rde', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (200, '9906 Oak Grove Road', 1)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (201, '1378 String Dr', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (202, '1803 Olive Hill', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (203, '2176 Brown Street', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (204, '2266 Greenwood Circle', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (205, '2598 Breck Court', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (206, '2736 Scramble Rd', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (207, '4312 Cambridge Drive', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (208, '5009 Orange Street', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (209, '5670 Bel Air Dr.', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (210, '5980 Icicle Circle', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (211, '6510 Hacienda Drive', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (212, '6937 E. 42nd Street', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (213, '7165 Brock Lane', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (214, '7559 Worth Ct.', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (215, '7985 Center Street', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (216, '9495 Limewood Place', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (217, '9533 Working Drive', 13)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (218, '177 11th Ave', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (219, '1962 Ferndale Lane', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (220, '2473 Orchard Way', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (221, '4096 San Remo', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (222, '4310 Kenston Dr.', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (223, '4444 Pepper Way', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (224, '4525 Benedict Ct.', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (225, '5263 Etcheverry Dr', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (226, '535 Greendell Pl', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (227, '6871 Thornwood Dr.', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (228, '6951 Harmony Way', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (229, '7086 O St.', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (230, '7145 Matchstick Drive', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (231, '7820 Bird Drive', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (232, '7939 Bayview Court', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (233, '8316 La Salle St.', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (234, '9104 Mt. Sequoia Ct.', 16)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (235, '1234 Seaside Way', 9)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (236, '5725 Glaze Drive', 9)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (237, '1064 Slow Creek Road', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (238, '1102 Ravenwood', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (239, '1220 Bradford Way', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (240, '1349 Steven Way', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (241, '136 Balboa Court', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (242, '137 Mazatlan', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (243, '1398 Yorba Linda', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (244, '1619 Stillman Court', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (245, '2144 San Rafael', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (246, '2354 Frame Ln.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (247, '2639 Anchor Court', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (248, '3029 Pastime Dr', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (249, '3243 Buckingham Dr.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (250, '426 San Rafael', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (251, '4598 Manila Avenue', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (252, '4948 West 4th St', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (253, '502 Alexander Pl.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (254, '5025 Holiday Hills', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (255, '5125 Cotton Ct.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (256, '5375 Clearland Circle', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (257, '5376 Catanzaro Way', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (258, '5407 Cougar Way', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (259, '5666 Hazelnut Lane', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (260, '5802 Ampersand Drive', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (261, '6498 Mining Rd.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (262, '6578 Woodhaven Ln.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (263, '6657 Sand Pointe Lane', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (264, '6843 San Simeon Dr.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (265, '7126 Ending Ct.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (266, '7127 Los Gatos Court', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (267, '7166 Brock Lane', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (268, '7403 N. Broadway', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (269, '7439 Laguna Niguel', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (270, '7594 Alexander Pl.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (271, '7616 Honey Court', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (272, '77 Birchwood', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (273, '7765 Sunsine Drive', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (274, '7842 Ygnacio Valley Road', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (275, '8290 Margaret Ct.', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (276, '8656 Lakespring Place', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (277, '874 Olivera Road', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (278, '931 Corte De Luna', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (279, '9537 Ridgewood Drive', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (280, '9964 North Ridge Drive', 4)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (281, '1285 Greenbrier Street', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (282, '2115 Passing', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (283, '2601 Cambridge Drive', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (284, '3114 Notre Dame Ave.', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (285, '3280 Pheasant Circle', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (286, '4231 Spar Court', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (287, '4852 Chaparral Court', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (288, '5724 Victory Lane', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (289, '591 Merriewood Drive', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (290, '7230 Vine Maple Street', 11)

INSERT INTO Addresses (AddressID, AddressText, TownID)
VALUES (291, '163 Nishava Str, ent A, apt. 1', 32)

SET IDENTITY_INSERT Addresses OFF

GO

CREATE TABLE Projects(
  ProjectID int IDENTITY NOT NULL,
  Name nvarchar(50) NOT NULL,
  Description ntext NULL,
  StartDate smalldatetime NOT NULL,
  EndDate smalldatetime NULL,
  CONSTRAINT PK_Projects PRIMARY KEY CLUSTERED (ProjectID ASC)
)
GO

SET IDENTITY_INSERT Projects ON

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (1, 'Classic Vest', 'Research, design and development of Classic Vest. Light-weight, wind-resistant, packs to fit into a pocket.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (2, 'Cycling Cap', 'Research, design and development of Cycling Cap. Traditional style with a flip-up brim; one-size fits all.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (3, 'Full-Finger Gloves', 'Research, design and development of Full-Finger Gloves. Synthetic palm, flexible knuckles, breathable mesh upper. Worn by the AWC team riders.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (4, 'Half-Finger Gloves', 'Research, design and development of Half-Finger Gloves. Full padding, improved finger flex, durable palm, adjustable closure.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (5, 'HL Mountain Frame', 'Research, design and development of HL Mountain Frame. Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (6, 'HL Road Frame', 'Research, design and development of HL Road Frame. Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.', '19980502', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (7, 'HL Touring Frame', 'Research, design and development of HL Touring Frame. The HL aluminum frame is custom-shaped for both good looks and strength; it will withstand the most rigorous challenges of daily riding. Men''s version.', '20050516 16:34:00', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (8, 'LL Mountain Frame', 'Research, design and development of LL Mountain Frame. Our best value utilizing the same, ground-breaking frame technology as the ML aluminum frame.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (9, 'LL Road Frame', 'Research, design and development of LL Road Frame. The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (10, 'LL Touring Frame', 'Research, design and development of LL Touring Frame. Lightweight butted aluminum frame provides a more upright riding position for a trip around town.  Our ground-breaking design provides optimum comfort.', '20050516 16:34:00', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (11, 'Long-Sleeve Logo Jersey', 'Research, design and development of Long-Sleeve Logo Jersey. Unisex long-sleeve AWC logo microfiber cycling jersey', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (12, 'Men''s Bib-Shorts', 'Research, design and development of Men''s Bib-Shorts. Designed for the AWC team with stay-put straps, moisture-control, chamois padding, and leg grippers.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (19, 'Mountain-100', 'Research, design and development of Mountain-100. Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (20, 'Mountain-200', 'Research, design and development of Mountain-200. Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.', '20020601', '20040311 10:32:00')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (21, 'Mountain-300', 'Research, design and development of Mountain-300. For true trail addicts.  An extremely durable bike that will go anywhere and keep you in control on challenging terrain - without breaking your budget.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (22, 'Mountain-400-W', 'Research, design and development of Mountain-400-W. This bike delivers a high-level of performance on a budget. It is responsive and maneuverable, and offers peace-of-mind when you decide to go off-road.', '20060222', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (23, 'Mountain-500', 'Research, design and development of Mountain-500. Suitable for any type of riding, on or off-road. Fits any budget. Smooth-shifting with a comfortable ride.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (24, 'Racing Socks', 'Research, design and development of Racing Socks. Thin, lightweight and durable with cuffs that stay up.', '20051122', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (25, 'Road-150', 'Research, design and development of Road-150. This bike is ridden by race winners. Developed with the Adventure Works Cycles professional race team, it has a extremely light heat-treated aluminum frame, and steering that allows precision control.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (26, 'Road-250', 'Research, design and development of Road-250. Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (27, 'Road-350-W', 'Research, design and development of Road-350-W. Cross-train, race, or just socialize on a sleek, aerodynamic bike designed for a woman.  Advanced seat technology provides comfort all day.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (28, 'Road-450', 'Research, design and development of Road-450. A true multi-sport bike that offers streamlined riding and a revolutionary design. Aerodynamic design lets you ride with the pros, and the gearing will conquer hilly roads.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (29, 'Road-550-W', 'Research, design and development of Road-550-W. Same technology as all of our Road series bikes, but the frame is sized for a woman.  Perfect all-around bike for road or racing.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (30, 'Road-650', 'Research, design and development of Road-650. Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we''re famous for.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (31, 'Road-750', 'Research, design and development of Road-750. Entry level adult bike; offers a comfortable ride cross-country or down the block. Quick-release hubs and rims.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (32, 'Short-Sleeve Classic Jersey', 'Research, design and development of Short-Sleeve Classic Jersey. Short sleeve classic breathable jersey with superior moisture control, front zipper, and 3 back pockets.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (33, 'Sport-100', 'Research, design and development of Sport-100. Universal fit, well-vented, lightweight , snap-on visor.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (34, 'Touring-1000', 'Research, design and development of Touring-1000. Travel in style and comfort. Designed for maximum comfort and safety. Wide gear range takes on all hills. High-tech aluminum alloy construction provides durability without added weight.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (35, 'Touring-2000', 'Research, design and development of Touring-2000. The plush custom saddle keeps you riding all day,  and there''s plenty of space to add panniers and bike bags to the newly-redesigned carrier.  This bike has stability when fully-loaded.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (36, 'Touring-3000', 'Research, design and development of Touring-3000. All-occasion value bike with our basic comfort and safety features. Offers wider, more stable tires for a ride around town or weekend trip.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (37, 'Women''s Mountain Shorts', 'Research, design and development of Women''s Mountain Shorts. Heavy duty, abrasion-resistant shorts feature seamless, lycra inner shorts with anti-bacterial chamois for comfort.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (38, 'Women''s Tights', 'Research, design and development of Women''s Tights. Warm spandex tights for winter riding; seamless chamois construction eliminates pressure points.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (39, 'Mountain-400', 'Research, design and development of Mountain-400. Suitable for any type of off-road trip. Fits any budget.', '20010601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (40, 'Road-550', 'Research, design and development of Road-550. Same technology as all of our Road series bikes.  Perfect all-around bike for road or racing.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (41, 'Road-350', 'Research, design and development of Road-350. Cross-train, race, or just socialize on a sleek, aerodynamic bike.  Advanced seat technology provides comfort all day.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (42, 'LL Mountain Front Wheel', 'Research, design and development of LL Mountain Front Wheel. Replacement mountain wheel for entry-level rider.', '20021120 09:57:00', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (43, 'Touring Rear Wheel', 'Research, design and development of Touring Rear Wheel. Excellent aerodynamic rims guarantee a smooth ride.', '20050516 16:34:00', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (44, 'Touring Front Wheel', 'Research, design and development of Touring Front Wheel. Aerodynamic rims for smooth riding.', '20050516 16:34:00', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (45, 'ML Mountain Front Wheel', 'Research, design and development of ML Mountain Front Wheel. Replacement mountain wheel for the casual to serious rider.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (46, 'HL Mountain Front Wheel', 'Research, design and development of HL Mountain Front Wheel. High-performance mountain replacement wheel.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (47, 'LL Touring Handlebars', 'Research, design and development of LL Touring Handlebars. Unique shape reduces fatigue for entry level riders.', '20050516 16:34:00', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (48, 'HL Touring Handlebars', 'Research, design and development of HL Touring Handlebars. A light yet stiff aluminum bar for long distance riding.', '20050516 16:34:00', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (49, 'LL Road Front Wheel', 'Research, design and development of LL Road Front Wheel. Replacement road front wheel for entry-level cyclist.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (50, 'ML Road Front Wheel', 'Research, design and development of ML Road Front Wheel. Sturdy alloy features a quick-release hub.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (51, 'HL Road Front Wheel', 'Research, design and development of HL Road Front Wheel. Strong wheel with double-walled rim.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (52, 'LL Mountain Handlebars', 'Research, design and development of LL Mountain Handlebars. All-purpose bar for on or off-road.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (53, 'Touring Pedal', 'Research, design and development of Touring Pedal. A stable pedal for all-day riding.', '20050516 16:34:00', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (54, 'ML Mountain Handlebars', 'Research, design and development of ML Mountain Handlebars. Tough aluminum alloy bars for downhill.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (55, 'HL Mountain Handlebars', 'Research, design and development of HL Mountain Handlebars. Flat bar strong enough for the pro circuit.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (56, 'LL Road Handlebars', 'Research, design and development of LL Road Handlebars. Unique shape provides easier reach to the levers.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (57, 'ML Road Handlebars', 'Research, design and development of ML Road Handlebars. Anatomically shaped aluminum tube bar will suit all riders.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (58, 'HL Road Handlebars', 'Research, design and development of HL Road Handlebars. Designed for racers; high-end anatomically shaped bar from aluminum alloy.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (59, 'LL Headset', 'Research, design and development of LL Headset. Threadless headset provides quality at an economical price.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (60, 'ML Headset', 'Research, design and development of ML Headset. Sealed cartridge keeps dirt out.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (61, 'HL Headset', 'Research, design and development of HL Headset. High-quality 1" threadless headset with a grease port for quick lubrication.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (77, 'ML Road Rear Wheel', 'Research, design and development of ML Road Rear Wheel. Aluminum alloy rim with stainless steel spokes; built for speed.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (78, 'HL Road Rear Wheel', 'Research, design and development of HL Road Rear Wheel. Strong rear wheel with double-walled rim.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (79, 'LL Mountain Seat/Saddle 2', 'Research, design and development of LL Mountain Seat/Saddle 2. Synthetic leather. Features gel for increased comfort.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (80, 'ML Mountain Seat/Saddle 2', 'Research, design and development of ML Mountain Seat/Saddle 2. Designed to absorb shock.', '20030601', '20040311 10:32:00')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (104, 'LL Fork', 'Research, design and development of LL Fork. Stout design absorbs shock and offers more precise steering.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (105, 'ML Fork', 'Research, design and development of ML Fork. Composite road fork with an aluminum steerer tube.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (106, 'HL Fork', 'Research, design and development of HL Fork. High-performance carbon road fork with curved legs.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (107, 'Hydration Pack', 'Research, design and development of Hydration Pack. Versatile 70 oz hydration pack offers extra storage, easy-fill access, and a waist belt.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (108, 'Taillight', 'Research, design and development of Taillight. Affordable light for safe night riding - uses 3 AAA batteries', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (109, 'Headlights - Dual-Beam', 'Research, design and development of Headlights - Dual-Beam. Rechargeable dual-beam headlight.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (110, 'Headlights - Weatherproof', 'Research, design and development of Headlights - Weatherproof. Rugged weatherproof headlight.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (111, 'Water Bottle', 'Research, design and development of Water Bottle. AWC logo water bottle - holds 30 oz; leak-proof.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (112, 'Mountain Bottle Cage', 'Research, design and development of Mountain Bottle Cage. Tough aluminum cage holds bottle securly on tough terrain.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (113, 'Road Bottle Cage', 'Research, design and development of Road Bottle Cage. Aluminum cage is lighter than our mountain version; perfect for long distance trips.', '20040221', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (114, 'Patch kit', 'Research, design and development of Patch kit. Includes 8 different size patches, glue and sandpaper.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (115, 'Cable Lock', 'Research, design and development of Cable Lock. Wraps to fit front and rear tires, carrier and 2 keys included.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (116, 'Minipump', 'Research, design and development of Minipump. Designed for convenience. Fits in your pocket. Aluminum barrel. 160psi rated.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (117, 'Mountain Pump', 'Research, design and development of Mountain Pump. Simple and light-weight. Emergency patches stored in handle.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (118, 'Hitch Rack - 4-Bike', 'Research, design and development of Hitch Rack - 4-Bike. Carries 4 bikes securely; steel construction, fits 2" receiver hitch.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (119, 'Bike Wash', 'Research, design and development of Bike Wash. Washes off the toughest road grime; dissolves grease, environmentally safe. 1-liter bottle.', '20050801', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (120, 'Touring-Panniers', 'Research, design and development of Touring-Panniers. Durable, water-proof nylon construction with easy access. Large enough for weekend trips.', '20020601', '20030601')

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (121, 'Fender Set - Mountain', 'Research, design and development of Fender Set - Mountain. Clip-on fenders fit most mountain bikes.', '20030601', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (122, 'All-Purpose Bike Stand', 'Research, design and development of All-Purpose Bike Stand. Perfect all-purpose bike stand for working on your bike at home. Quick-adjusting clamps and steel construction.', '20050901', NULL)

INSERT INTO Projects (ProjectID, Name, Description, StartDate, EndDate)
VALUES (127, 'Rear Derailleur', 'Research, design and development of Rear Derailleur. Wide-link design.', '20030601', NULL)

GO

SET IDENTITY_INSERT Projects OFF

CREATE TABLE EmployeesProjects(
  EmployeeID int NOT NULL,
  ProjectID int NOT NULL,
  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
)
GO

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (1, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (1, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (1, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (1, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (3, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (3, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (3, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (3, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (4, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (4, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (4, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (4, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (5, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (5, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (5, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (5, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (7, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (7, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (7, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (7, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (8, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (8, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (8, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (8, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (9, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (9, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (9, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (9, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (10, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (10, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (10, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (10, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (11, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (11, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (11, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (11, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (12, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (12, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (12, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (12, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (13, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (13, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (13, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (13, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (14, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (14, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (14, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (14, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (15, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (15, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (15, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (15, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (16, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (16, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (16, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (16, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (17, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (17, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (17, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (17, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (18, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (18, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (18, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (18, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (19, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (19, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (19, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (19, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (20, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (20, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (20, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (20, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (21, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (21, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (21, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (21, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (22, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (22, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (22, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (22, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (23, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (23, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (23, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (23, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (24, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (24, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (24, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (24, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (25, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (25, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (25, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (25, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (26, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (26, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (26, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (26, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (27, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (27, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (27, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (29, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (29, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (29, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (29, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (30, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (30, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (30, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (31, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (31, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (31, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (31, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (32, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (32, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (32, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (32, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (33, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (33, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (33, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (33, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (36, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (36, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (36, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (36, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (37, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (37, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (37, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (37, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (38, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (38, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (38, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (38, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (39, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (39, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (39, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (39, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (40, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (40, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (40, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (40, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (41, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (41, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (41, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (41, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (42, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (42, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (42, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (42, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (43, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (43, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (43, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (44, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (44, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (44, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (44, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (45, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (45, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (45, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (45, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (48, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (48, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (48, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (48, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (49, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (49, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (49, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (49, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (50, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (50, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (50, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (50, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (51, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (51, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (51, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (51, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (52, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (52, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (52, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (53, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (53, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (53, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (53, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (54, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (54, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (54, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (54, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (55, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (55, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (55, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (55, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (56, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (56, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (56, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (56, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (57, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (57, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (57, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (57, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (58, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (58, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (58, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (58, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (60, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (60, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (60, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (60, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (61, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (61, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (61, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (61, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (62, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (62, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (62, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (62, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (63, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (63, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (63, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (63, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (64, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (64, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (64, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (64, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (65, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (65, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (65, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (65, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (66, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (66, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (66, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (66, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (67, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (67, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (67, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (67, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (68, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (68, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (68, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (68, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (69, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (69, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (69, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (69, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (70, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (70, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (70, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (73, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (73, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (73, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (73, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (74, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (74, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (74, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (74, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (75, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (75, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (75, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (75, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (76, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (76, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (76, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (76, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (77, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (77, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (77, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (77, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (78, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (78, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (78, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (78, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (79, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (79, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (79, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (79, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (80, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (80, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (80, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (80, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (81, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (81, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (81, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (81, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (83, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (83, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (83, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (83, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (84, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (84, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (84, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (84, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (86, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (86, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (86, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (86, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (87, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (87, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (87, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (87, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (88, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (88, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (88, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (88, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (89, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (89, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (89, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (89, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (90, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (90, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (90, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (90, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (91, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (91, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (91, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (92, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (92, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (92, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (92, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (93, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (93, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (93, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (93, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (95, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (95, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (95, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (95, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (96, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (96, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (96, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (96, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (97, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (97, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (97, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (97, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (98, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (98, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (98, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (98, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (99, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (99, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (99, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (99, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (100, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (100, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (100, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (100, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (101, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (101, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (101, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (101, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (102, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (102, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (102, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (102, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (103, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (103, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (103, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (103, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (104, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (104, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (104, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (104, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (105, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (105, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (105, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (105, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (107, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (107, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (107, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (107, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (108, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (108, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (108, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (108, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (110, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (110, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (110, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (110, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (111, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (111, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (111, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (112, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (112, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (112, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (112, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (113, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (113, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (113, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (113, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (114, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (114, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (114, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (114, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (115, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (115, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (115, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (115, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (116, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (116, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (116, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (116, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (118, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (118, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (118, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (118, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (120, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (120, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (120, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (120, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (122, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (122, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (122, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (122, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (123, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (123, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (123, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (123, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (124, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (124, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (124, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (124, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (125, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (125, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (125, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (125, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (126, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (126, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (126, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (126, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (127, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (127, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (127, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (127, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (129, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (129, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (129, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (129, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (131, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (131, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (131, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (131, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (132, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (132, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (132, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (132, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (133, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (133, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (133, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (133, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (134, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (134, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (134, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (134, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (135, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (135, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (135, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (135, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (136, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (136, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (136, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (136, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (137, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (137, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (137, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (137, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (138, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (138, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (138, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (138, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (141, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (141, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (141, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (141, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (142, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (142, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (142, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (142, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (143, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (143, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (143, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (144, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (144, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (144, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (144, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (145, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (145, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (145, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (145, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (146, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (146, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (146, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (146, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (147, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (147, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (147, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (147, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (148, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (148, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (148, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (148, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (149, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (149, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (149, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (149, 112)
INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (151, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (151, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (151, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (152, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (152, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (152, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (152, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (153, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (153, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (153, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (153, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (154, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (154, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (154, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (154, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (155, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (155, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (155, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (155, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (156, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (156, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (156, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (156, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (157, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (157, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (157, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (157, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (158, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (158, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (158, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (158, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (159, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (159, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (159, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (159, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (160, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (160, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (160, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (160, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (161, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (161, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (161, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (161, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (162, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (162, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (162, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (162, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (163, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (163, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (163, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (163, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (165, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (165, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (165, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (165, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (167, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (167, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (167, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (167, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (168, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (168, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (168, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (168, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (169, 5)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (169, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (169, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (169, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (170, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (170, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (170, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (170, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (171, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (171, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (171, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (171, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (172, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (172, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (172, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (172, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (173, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (173, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (173, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (173, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (174, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (174, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (174, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (174, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (175, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (175, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (175, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (175, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (176, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (176, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (176, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (176, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (177, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (177, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (177, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (177, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (179, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (179, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (179, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (179, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (180, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (180, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (180, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (180, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (181, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (181, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (181, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (181, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (182, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (182, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (182, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (182, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (183, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (183, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (183, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (183, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (184, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (184, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (184, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (184, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (185, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (185, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (185, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (185, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (186, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (186, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (186, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (186, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (187, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (187, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (187, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (187, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (189, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (189, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (189, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (189, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (190, 28)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (190, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (190, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (190, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (191, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (191, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (191, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (191, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (192, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (192, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (192, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (192, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (193, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (193, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (193, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (193, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (194, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (194, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (194, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (194, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (196, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (196, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (196, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (196, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (197, 2)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (197, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (197, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (197, 50)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (199, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (199, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (199, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (199, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (200, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (200, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (200, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (200, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (202, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (202, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (202, 46)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (202, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (204, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (204, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (204, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (204, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (205, 25)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (205, 39)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (205, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (205, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (206, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (206, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (206, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (206, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (207, 19)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (207, 33)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (207, 47)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (207, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (208, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (208, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (208, 48)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (208, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (209, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (209, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (209, 49)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (209, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (210, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (210, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (210, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (210, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (211, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (211, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (211, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (211, 52)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (212, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (212, 51)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (212, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (212, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (213, 9)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (213, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (213, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (213, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (214, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (214, 30)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (214, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (214, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (215, 11)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (215, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (215, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (215, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (217, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (217, 45)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (217, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (218, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (218, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (218, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (218, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (219, 53)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (220, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (220, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (220, 54)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (221, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (221, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (221, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (221, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (222, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (222, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (222, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (224, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (224, 44)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (224, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (225, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (225, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (225, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (226, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (226, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (226, 38)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (226, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (227, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (228, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (228, 40)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (228, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (229, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (229, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (229, 41)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (229, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (230, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (230, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (230, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (232, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (232, 43)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (232, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (234, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (234, 34)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (234, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (234, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (235, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (235, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (235, 35)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (235, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (236, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (236, 36)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (236, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (237, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (237, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (237, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (237, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (239, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (239, 32)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (239, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (239, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (240, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (240, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (243, 31)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (243, 106)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (243, 120)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (245, 20)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (245, 57)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (245, 109)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (245, 127)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (246, 1)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (246, 21)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (246, 58)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (246, 110)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (247, 22)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (247, 59)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (247, 111)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (248, 3)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (248, 23)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (248, 60)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (248, 112)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (249, 4)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (249, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (249, 61)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (249, 113)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (250, 77)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (250, 114)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (252, 12)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (252, 55)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (252, 107)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (252, 121)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (253, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (253, 42)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (253, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (254, 26)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (254, 78)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (254, 115)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (255, 7)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (255, 27)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (255, 79)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (255, 116)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (256, 8)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (256, 80)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (256, 117)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (257, 29)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (257, 104)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (257, 118)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (258, 10)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (258, 105)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (258, 119)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (262, 56)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (262, 108)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (262, 122)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (263, 24)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (267, 37)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
VALUES (267, 80)

GO

CREATE TABLE Departments(
  DepartmentID int IDENTITY NOT NULL,
  Name nvarchar(50) NOT NULL,
  ManagerID int NOT NULL,
  CONSTRAINT PK_Departments PRIMARY KEY CLUSTERED (DepartmentID ASC)
)
GO

SET IDENTITY_INSERT Departments ON

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (1, 'Engineering', 12)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (2, 'Tool Design', 4)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (3, 'Sales', 273)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (4, 'Marketing', 46)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (5, 'Purchasing', 6)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (6, 'Research and Development', 42)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (7, 'Production', 148)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (8, 'Production Control', 21)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (9, 'Human Resources', 30)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (10, 'Finance', 3)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (11, 'Information Services', 42)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (12, 'Document Control', 90)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (13, 'Quality Assurance', 274)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (14, 'Facilities and Maintenance', 218)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (15, 'Shipping and Receiving', 85)

INSERT INTO Departments (DepartmentID, Name, ManagerID)
VALUES (16, 'Executive', 109)

SET IDENTITY_INSERT Departments OFF

GO

CREATE TABLE Employees(
  EmployeeID int IDENTITY NOT NULL,
  FirstName nvarchar(50) NOT NULL,
  LastName nvarchar(50) NOT NULL,
  MiddleName nvarchar(50) NULL,
  JobTitle nvarchar(50) NOT NULL,
  DepartmentID int NOT NULL,
  ManagerID int NULL,
  HireDate smalldatetime NOT NULL,
  Salary money NOT NULL,
  AddressID int NULL,
  CONSTRAINT PK_Employees PRIMARY KEY CLUSTERED (EmployeeID ASC)
)
GO

SET IDENTITY_INSERT Employees ON

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (1, 'Guy', 'Gilbert', 'R', 'Production Technician', 7, 16, '19980731', 12500, 166)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (2, 'Kevin', 'Brown', 'F', 'Marketing Assistant', 4, 6, '19990226', 13500, 102)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (3, 'Roberto', 'Tamburello', NULL, 'Engineering Manager', 1, 12, '19991212', 43300, 193)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (4, 'Rob', 'Walters', NULL, 'Senior Tool Designer', 2, 3, '20000105', 29800, 155)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (5, 'Thierry', 'D''Hers', 'B', 'Tool Designer', 2, 263, '20000111', 25000, 40)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (6, 'David', 'Bradley', 'M', 'Marketing Manager', 5, 109, '20000120', 37500, 199)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (7, 'JoLynn', 'Dobney', 'M', 'Production Supervisor', 7, 21, '20000126', 25000, 275)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (8, 'Ruth', 'Ellerbrock', 'Ann', 'Production Technician', 7, 185, '20000206', 13500, 108)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (9, 'Gail', 'Erickson', 'A', 'Design Engineer', 1, 3, '20000206', 32700, 22)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (10, 'Barry', 'Johnson', 'K', 'Production Technician', 7, 185, '20000207', 13500, 285)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (11, 'Jossef', 'Goldberg', 'H', 'Design Engineer', 1, 3, '20000224', 32700, 214)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (12, 'Terri', 'Duffy', 'Lee', 'Vice President of Engineering', 1, 109, '20000303', 63500, 209)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (13, 'Sidney', 'Higa', 'M', 'Production Technician', 7, 185, '20000305', 13500, 73)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (14, 'Taylor', 'Maxwell', 'R', 'Production Supervisor', 7, 21, '20000311', 25000, 82)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (15, 'Jeffrey', 'Ford', 'L', 'Production Technician', 7, 185, '20000323', 13500, 156)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (16, 'Jo', 'Brown', 'A', 'Production Supervisor', 7, 21, '20000330', 25000, 70)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (17, 'Doris', 'Hartwig', 'M', 'Production Technician', 7, 185, '20000411', 13500, 144)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (18, 'John', 'Campbell', 'T', 'Production Supervisor', 7, 21, '20000418', 25000, 245)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (19, 'Diane', 'Glimp', 'R', 'Production Technician', 7, 185, '20000429', 13500, 184)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (20, 'Steven', 'Selikoff', 'T', 'Production Technician', 7, 173, '20010102', 9500, 104)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (21, 'Peter', 'Krebs', 'J', 'Production Control Manager', 8, 148, '20010102', 24500, 11)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (22, 'Stuart', 'Munson', 'V', 'Production Technician', 7, 197, '20010103', 10000, 36)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (23, 'Greg', 'Alderson', 'F', 'Production Technician', 7, 197, '20010103', 10000, 18)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (24, 'David', 'Johnson', 'N', 'Production Technician', 7, 184, '20010103', 9500, 142)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (25, 'Zheng', 'Mu', 'W', 'Production Supervisor', 7, 21, '20010104', 25000, 278)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (26, 'Ivo', 'Salmre', 'William', 'Production Technician', 7, 108, '20010105', 14000, 165)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (27, 'Paul', 'Komosinski', 'B', 'Production Technician', 7, 87, '20010105', 15000, 32)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (28, 'Ashvini', 'Sharma', 'R', 'Network Administrator', 11, 150, '20010105', 32500, 133)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (29, 'Kendall', 'Keil', 'C', 'Production Technician', 7, 14, '20010106', 11000, 257)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (30, 'Paula', 'Barreto de Mattos', 'M', 'Human Resources Manager', 9, 140, '20010107', 27100, 2)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (31, 'Alejandro', 'McGuel', 'E', 'Production Technician', 7, 210, '20010107', 15000, 274)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (32, 'Garrett', 'Young', 'R', 'Production Technician', 7, 184, '20010108', 9500, 283)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (33, 'Jian Shuo', 'Wang', NULL, 'Production Technician', 7, 135, '20010108', 9500, 160)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (34, 'Susan', 'Eaton', 'W', 'Stocker', 15, 85, '20010108', 9000, 204)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (35, 'Vamsi', 'Kuppa', 'N', 'Shipping and Receiving Clerk', 15, 85, '20010108', 9500, 51)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (36, 'Alice', 'Ciccu', 'O', 'Production Technician', 7, 38, '20010108', 11000, 284)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (37, 'Simon', 'Rapier', 'D', 'Production Technician', 7, 7, '20010109', 12500, 64)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (38, 'Jinghao', 'Liu', 'K', 'Production Supervisor', 7, 21, '20010109', 25000, 55)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (39, 'Michael', 'Hines', 'T', 'Production Technician', 7, 182, '20010110', 14000, 168)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (40, 'Yvonne', 'McKay', 'S', 'Production Technician', 7, 159, '20010110', 10000, 107)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (41, 'Peng', 'Wu', 'J', 'Quality Assurance Supervisor', 13, 200, '20010110', 21600, 39)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (42, 'Jean', 'Trenary', 'E', 'Information Services Manager', 11, 109, '20010112', 50500, 194)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (43, 'Russell', 'Hunter', NULL, 'Production Technician', 7, 74, '20010113', 11000, 258)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (44, 'A. Scott', 'Wright', NULL, 'Master Scheduler', 8, 148, '20010113', 23600, 172)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (45, 'Fred', 'Northup', 'T', 'Production Technician', 7, 210, '20010113', 15000, 282)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (46, 'Sariya', 'Harnpadoungsataya', 'E', 'Marketing Specialist', 4, 6, '20010113', 14400, 106)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (47, 'Willis', 'Johnson', 'T', 'Recruiter', 9, 30, '20010114', 18300, 99)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (48, 'Jun', 'Cao', 'T', 'Production Technician', 7, 38, '20010115', 11000, 197)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (49, 'Christian', 'Kleinerman', 'E', 'Maintenance Supervisor', 14, 218, '20010115', 20400, 118)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (50, 'Susan', 'Metters', 'A', 'Production Technician', 7, 184, '20010115', 9500, 224)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (51, 'Reuben', 'D''sa', 'H', 'Production Supervisor', 7, 21, '20010116', 25000, 249)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (52, 'Kirk', 'Koenigsbauer', 'J', 'Production Technician', 7, 123, '20010116', 10000, 250)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (53, 'David', 'Ortiz', 'J', 'Production Technician', 7, 18, '20010116', 12500, 267)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (54, 'Tengiz', 'Kharatishvili', 'N', 'Control Specialist', 12, 90, '20010117', 16800, 129)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (55, 'Hanying', 'Feng', 'P', 'Production Technician', 7, 143, '20010117', 14000, 182)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (56, 'Kevin', 'Liu', 'H', 'Production Technician', 7, 210, '20010118', 15000, 259)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (57, 'Annik', 'Stahl', 'O', 'Production Technician', 7, 16, '20010118', 12500, 262)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (58, 'Suroor', 'Fatima', 'R', 'Production Technician', 7, 38, '20010118', 11000, 86)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (59, 'Deborah', 'Poe', 'E', 'Accounts Receivable Specialist', 10, 139, '20010119', 19000, 103)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (60, 'Jim', 'Scardelis', 'H', 'Production Technician', 7, 74, '20010120', 11000, 88)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (61, 'Carole', 'Poland', 'M', 'Production Technician', 7, 173, '20010120', 9500, 72)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (62, 'George', 'Li', 'Z', 'Production Technician', 7, 184, '20010122', 9500, 58)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (63, 'Gary', 'Yukish', 'W', 'Production Technician', 7, 87, '20010123', 15000, 80)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (64, 'Cristian', 'Petculescu', 'K', 'Production Supervisor', 7, 21, '20010123', 25000, 276)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (65, 'Raymond', 'Sam', 'K', 'Production Technician', 7, 143, '20010124', 14000, 75)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (66, 'Janaina', 'Bueno', 'Barreiro Gambaro', 'Application Specialist', 11, 42, '20010124', 27400, 131)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (67, 'Bob', 'Hohman', 'N', 'Production Technician', 7, 14, '20010125', 11000, 44)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (68, 'Shammi', 'Mohamed', 'G', 'Production Technician', 7, 210, '20010125', 15000, 4)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (69, 'Linda', 'Moschell', 'K', 'Production Technician', 7, 38, '20010126', 11000, 5)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (70, 'Mindy', 'Martin', 'C', 'Benefits Specialist', 9, 30, '20010126', 16600, 171)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (71, 'Wendy', 'Kahn', 'Beth', 'Finance Manager', 10, 140, '20010126', 43300, 232)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (72, 'Kim', 'Ralls', 'T', 'Stocker', 15, 85, '20010127', 9000, 42)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (73, 'Sandra', 'Reategui Alayo', NULL, 'Production Technician', 7, 135, '20010127', 9500, 255)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (74, 'Kok-Ho', 'Loh', 'T', 'Production Supervisor', 7, 21, '20010128', 25000, 10)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (75, 'Douglas', 'Hite', 'B', 'Production Technician', 7, 159, '20010128', 10000, 57)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (76, 'James', 'Kramer', 'D', 'Production Technician', 7, 7, '20010128', 12500, 162)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (77, 'Sean', 'Alexander', 'P', 'Quality Assurance Technician', 13, 41, '20010129', 10600, 210)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (78, 'Nitin', 'Mirchandani', 'S', 'Production Technician', 7, 182, '20010129', 14000, 231)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (79, 'Diane', 'Margheim', 'L', 'Research and Development Engineer', 6, 158, '20010130', 40900, 111)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (80, 'Rebecca', 'Laszlo', 'A', 'Production Technician', 7, 16, '20010130', 12500, 6)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (81, 'Rajesh', 'Patel', 'M', 'Production Technician', 7, 210, '20010201', 15000, 81)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (82, 'Vidur', 'Luthra', 'X', 'Recruiter', 9, 30, '20010202', 18300, 176)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (83, 'John', 'Evans', 'P', 'Production Technician', 7, 38, '20010202', 11000, 253)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (84, 'Nancy', 'Anderson', 'A', 'Production Technician', 7, 7, '20010203', 12500, 227)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (85, 'Pilar', 'Ackerman', 'G', 'Shipping and Receiving Supervisor', 15, 21, '20010203', 19200, 269)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (86, 'David', 'Yalovsky', 'A', 'Production Technician', 7, 184, '20010203', 9500, 241)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (87, 'David', 'Hamilton', 'P', 'Production Supervisor', 7, 21, '20010204', 25000, 150)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (88, 'Laura', 'Steele', 'C', 'Production Technician', 7, 123, '20010204', 10000, 62)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (89, 'Margie', 'Shoop', 'W', 'Production Technician', 7, 16, '20010205', 12500, 92)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (90, 'Zainal', 'Arifin', 'T', 'Document Control Manager', 12, 200, '20010205', 17800, 128)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (91, 'Lorraine', 'Nay', 'O', 'Production Technician', 7, 210, '20010205', 15000, 94)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (92, 'Fadi', 'Fakhouri', 'K', 'Production Technician', 7, 143, '20010205', 14000, 281)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (93, 'Ryan', 'Cornelsen', 'L', 'Production Technician', 7, 51, '20010206', 15000, 228)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (94, 'Candy', 'Spoon', 'L', 'Accounts Receivable Specialist', 10, 139, '20010207', 19000, 122)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (95, 'Nuan', 'Yu', NULL, 'Production Technician', 7, 74, '20010207', 11000, 12)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (96, 'William', 'Vong', 'S', 'Scheduling Assistant', 8, 44, '20010208', 16000, 35)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (97, 'Bjorn', 'Rettig', 'M', 'Production Technician', 7, 173, '20010208', 9500, 268)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (98, 'Scott', 'Gode', 'R', 'Production Technician', 7, 197, '20010209', 10000, 256)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (99, 'Michael', 'Rothkugel', 'L', 'Production Technician', 7, 87, '20010211', 15000, 93)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (100, 'Lane', 'Sacksteder', 'M', 'Production Technician', 7, 143, '20010212', 14000, 239)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (101, 'Pete', 'Male', 'C', 'Production Technician', 7, 14, '20010212', 11000, 273)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (102, 'Dan', 'Bacon', 'K', 'Application Specialist', 11, 42, '20010212', 27400, 126)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (103, 'David', 'Barber', 'M', 'Assistant to the Chief Financial Officer', 10, 140, '20010213', 13500, 173)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (104, 'Lolan', 'Song', 'B', 'Production Technician', 7, 74, '20010213', 11000, 77)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (105, 'Paula', 'Nartker', 'R', 'Production Technician', 7, 210, '20010213', 15000, 247)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (106, 'Mary', 'Gibson', 'E', 'Marketing Specialist', 4, 6, '20010213', 14400, 110)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (107, 'Mindaugas', 'Krapauskas', 'J', 'Production Technician', 7, 38, '20010214', 11000, 74)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (108, 'Eric', 'Gubbels', NULL, 'Production Supervisor', 7, 21, '20010215', 25000, 85)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (109, 'Ken', 'Sanchez', 'J', 'Chief Executive Officer', 16, NULL, '20010215', 125500, 177)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (110, 'Jason', 'Watters', 'M', 'Production Technician', 7, 135, '20010215', 9500, 21)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (111, 'Mark', 'Harrington', 'L', 'Quality Assurance Technician', 13, 41, '20010216', 10600, 139)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (112, 'Janeth', 'Esteves', 'M', 'Production Technician', 7, 159, '20010216', 10000, 163)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (113, 'Marc', 'Ingle', 'J', 'Production Technician', 7, 184, '20010217', 9500, 230)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (114, 'Gigi', 'Matthew', 'N', 'Research and Development Engineer', 6, 158, '20010217', 40900, 23)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (115, 'Paul', 'Singh', 'R', 'Production Technician', 7, 108, '20010218', 14000, 16)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (116, 'Frank', 'Lee', 'T', 'Production Technician', 7, 210, '20010218', 15000, 263)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (117, 'Francois', 'Ajenstat', 'P', 'Database Administrator', 11, 42, '20010218', 38500, 127)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (118, 'Diane', 'Tibbott', 'H', 'Production Technician', 7, 14, '20010219', 11000, 140)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (119, 'Jill', 'Williams', 'A', 'Marketing Specialist', 4, 6, '20010219', 14400, 114)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (120, 'Angela', 'Barbariol', 'W', 'Production Technician', 7, 38, '20010221', 11000, 91)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (121, 'Matthias', 'Berndt', 'T', 'Shipping and Receiving Clerk', 15, 85, '20010221', 9500, 201)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (122, 'Bryan', 'Baker', NULL, 'Production Technician', 7, 7, '20010222', 12500, 166)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (123, 'Jeff', 'Hay', 'V', 'Production Supervisor', 7, 21, '20010222', 25000, 113)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (124, 'Eugene', 'Zabokritski', 'R', 'Production Technician', 7, 184, '20010222', 9500, 226)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (125, 'Barbara', 'Decker', 'S', 'Production Technician', 7, 182, '20010223', 14000, 219)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (126, 'Chris', 'Preston', 'T', 'Production Technician', 7, 123, '20010223', 10000, 279)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (127, 'Sean', 'Chai', 'N', 'Document Control Assistant', 12, 90, '20010223', 10300, 138)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (128, 'Dan', 'Wilson', 'B', 'Database Administrator', 11, 42, '20010223', 38500, 30)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (129, 'Mark', 'McArthur', 'K', 'Production Technician', 7, 16, '20010224', 12500, 186)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (130, 'Bryan', 'Walton', 'A', 'Accounts Receivable Specialist', 10, 139, '20010225', 19000, 175)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (131, 'Houman', 'Pournasseh', 'N', 'Production Technician', 7, 74, '20010226', 11000, 185)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (132, 'Sairaj', 'Uddin', 'L', 'Scheduling Assistant', 8, 44, '20010227', 16000, 190)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (133, 'Michiko', 'Osada', 'F', 'Production Technician', 7, 173, '20010227', 9500, 229)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (134, 'Benjamin', 'Martin', 'R', 'Production Technician', 7, 184, '20010228', 9500, 286)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (135, 'Cynthia', 'Randall', 'S', 'Production Supervisor', 7, 21, '20010228', 25000, 147)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (136, 'Kathie', 'Flood', 'E', 'Production Technician', 7, 197, '20010228', 10000, 100)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (137, 'Britta', 'Simon', 'L', 'Production Technician', 7, 16, '20010302', 12500, 95)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (138, 'Brian', 'Lloyd', 'T', 'Production Technician', 7, 210, '20010302', 15000, 288)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (139, 'David', 'Liu', 'J', 'Accounts Manager', 10, 140, '20010303', 34700, 119)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (140, 'Laura', 'Norman', 'F', 'Chief Financial Officer', 16, 109, '20010304', 60100, 215)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (141, 'Michael', 'Patten', 'W', 'Production Technician', 7, 38, '20010304', 11000, 96)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (142, 'Andy', 'Ruth', 'M', 'Production Technician', 7, 135, '20010304', 9500, 1)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (143, 'Yuhong', 'Li', 'L', 'Production Supervisor', 7, 21, '20010305', 25000, 242)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (144, 'Robert', 'Rounthwaite', 'J', 'Production Technician', 7, 159, '20010306', 10000, 280)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (145, 'Andreas', 'Berglund', 'T', 'Quality Assurance Technician', 13, 41, '20010306', 10600, 208)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (146, 'Reed', 'Koch', 'T', 'Production Technician', 7, 184, '20010306', 9500, 191)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (147, 'Linda', 'Randall', 'A', 'Production Technician', 7, 143, '20010307', 14000, 260)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (148, 'James', 'Hamilton', 'R', 'Vice President of Production', 7, 109, '20010307', 84100, 158)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (149, 'Ramesh', 'Meyyappan', 'V', 'Application Specialist', 11, 42, '20010307', 27400, 130)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (150, 'Stephanie', 'Conroy', 'A', 'Network Manager', 11, 42, '20010308', 39700, 136)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (151, 'Samantha', 'Smith', 'H', 'Production Technician', 7, 108, '20010308', 14000, 14)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (152, 'Tawana', 'Nusbaum', 'G', 'Production Technician', 7, 210, '20010309', 15000, 237)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (153, 'Denise', 'Smith', 'H', 'Production Technician', 7, 14, '20010309', 11000, 143)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (154, 'Hao', 'Chen', 'O', 'Human Resources Administrative Assistant', 9, 30, '20010310', 13900, 135)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (155, 'Alex', 'Nayberg', 'M', 'Production Technician', 7, 123, '20010312', 10000, 174)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (156, 'Eugene', 'Kogan', 'O', 'Production Technician', 7, 7, '20010312', 12500, 71)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (157, 'Brandon', 'Heidepriem', 'G', 'Production Technician', 7, 16, '20010312', 12500, 189)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (158, 'Dylan', 'Miller', 'A', 'Research and Development Manager', 6, 3, '20010312', 50500, 141)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (159, 'Shane', 'Kim', 'S', 'Production Supervisor', 7, 21, '20010312', 25000, 20)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (160, 'John', 'Chen', 'Y', 'Production Technician', 7, 182, '20010313', 14000, 65)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (161, 'Karen', 'Berge', 'R', 'Document Control Assistant', 12, 90, '20010313', 10300, 123)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (162, 'Jose', 'Lugo', 'R', 'Production Technician', 7, 16, '20010314', 12500, 271)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (163, 'Mandar', 'Samant', 'H', 'Production Technician', 7, 74, '20010314', 11000, 63)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (164, 'Mikael', 'Sandberg', 'Q', 'Buyer', 5, 274, '20010314', 18300, 50)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (165, 'Sameer', 'Tejani', 'A', 'Production Technician', 7, 74, '20010315', 11000, 66)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (166, 'Dragan', 'Tomic', 'K', 'Accounts Payable Specialist', 10, 139, '20010315', 19000, 115)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (167, 'Carol', 'Philips', 'M', 'Production Technician', 7, 173, '20010316', 9500, 45)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (168, 'Rob', 'Caron', 'T', 'Production Technician', 7, 87, '20010317', 15000, 161)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (169, 'Don', 'Hall', 'L', 'Production Technician', 7, 38, '20010317', 11000, 59)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (170, 'Alan', 'Brewer', 'J', 'Scheduling Assistant', 8, 44, '20010317', 16000, 151)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (171, 'David', 'Lawrence', 'Oliver', 'Production Technician', 7, 184, '20010318', 9500, 167)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (172, 'Baris', 'Cetinok', 'F', 'Production Technician', 7, 87, '20010319', 15000, 244)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (173, 'Michael', 'Ray', 'Sean', 'Production Supervisor', 7, 21, '20010319', 25000, 277)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (174, 'Steve', 'Masters', 'F', 'Production Technician', 7, 18, '20010319', 12500, 252)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (175, 'Suchitra', 'Mohan', 'O', 'Production Technician', 7, 16, '20010320', 12500, 31)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (176, 'Karen', 'Berg', 'A', 'Application Specialist', 11, 42, '20010320', 27400, 132)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (177, 'Terrence', 'Earls', 'W', 'Production Technician', 7, 143, '20010320', 14000, 34)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (178, 'Barbara', 'Moreland', 'C', 'Accountant', 10, 139, '20010322', 26400, 254)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (179, 'Chad', 'Niswonger', 'W', 'Production Technician', 7, 38, '20010322', 11000, 46)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (180, 'Rostislav', 'Shabalin', 'E', 'Production Technician', 7, 135, '20010323', 9500, 9)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (181, 'Belinda', 'Newman', 'M', 'Production Technician', 7, 197, '20010324', 10000, 43)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (182, 'Katie', 'McAskill-White', 'L', 'Production Supervisor', 7, 21, '20010324', 25000, 240)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (183, 'Russell', 'King', 'M', 'Production Technician', 7, 184, '20010325', 9500, 3)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (184, 'Jack', 'Richins', 'S', 'Production Supervisor', 7, 21, '20010325', 25000, 169)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (185, 'Andrew', 'Hill', 'R', 'Production Supervisor', 7, 21, '20010326', 25000, 97)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (186, 'Nicole', 'Holliday', 'B', 'Production Technician', 7, 87, '20010326', 15000, 238)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (187, 'Frank', 'Miller', 'T', 'Production Technician', 7, 14, '20010327', 11000, 289)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (188, 'Peter', 'Connelly', 'I', 'Network Administrator', 11, 150, '20010327', 32500, 137)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (189, 'Anibal', 'Sousa', 'T', 'Production Technician', 7, 108, '20010327', 14000, 183)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (190, 'Ken', 'Myer', 'L', 'Production Technician', 7, 210, '20010328', 15000, 105)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (191, 'Grant', 'Culbertson', 'N', 'Human Resources Administrative Assistant', 9, 30, '20010329', 13900, 117)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (192, 'Michael', 'Entin', 'T', 'Production Technician', 7, 38, '20010329', 11000, 195)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (193, 'Lionel', 'Penuchot', 'C', 'Production Technician', 7, 159, '20010330', 10000, 261)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (194, 'Thomas', 'Michaels', 'R', 'Production Technician', 7, 7, '20010330', 12500, 78)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (195, 'Jimmy', 'Bischoff', 'T', 'Stocker', 15, 85, '20010330', 9000, 206)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (196, 'Michael', 'Vanderhyde', 'T', 'Production Technician', 7, 135, '20010330', 9500, 90)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (197, 'Lori', 'Kane', 'A', 'Production Supervisor', 7, 21, '20010330', 25000, 198)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (198, 'Arvind', 'Rao', 'B', 'Buyer', 5, 274, '20010401', 18300, 212)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (199, 'Stefen', 'Hesse', 'A', 'Production Technician', 7, 182, '20010401', 14000, 68)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (200, 'Hazem', 'Abolrous', 'E', 'Quality Assurance Manager', 13, 148, '20010401', 28800, 148)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (201, 'Janet', 'Sheperdigian', 'L', 'Accounts Payable Specialist', 10, 139, '20010402', 19000, 218)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (202, 'Elizabeth', 'Keyser', 'I', 'Production Technician', 7, 74, '20010403', 11000, 152)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (203, 'Terry', 'Eminhizer', 'J', 'Marketing Specialist', 4, 6, '20010403', 14400, 19)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (204, 'John', 'Frum', 'N', 'Production Technician', 7, 184, '20010404', 9500, 112)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (205, 'Merav', 'Netz', 'A', 'Production Technician', 7, 173, '20010404', 9500, 270)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (206, 'Brian', 'LaMee', 'P', 'Scheduling Assistant', 8, 44, '20010404', 16000, 109)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (207, 'Kitti', 'Lertpiriyasuwat', 'H', 'Production Technician', 7, 38, '20010405', 11000, 272)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (208, 'Jay', 'Adams', 'G', 'Production Technician', 7, 18, '20010406', 12500, 157)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (209, 'Jan', 'Miksovsky', 'S', 'Production Technician', 7, 184, '20010406', 9500, 101)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (210, 'Brenda', 'Diaz', 'M', 'Production Supervisor', 7, 21, '20010406', 25000, 251)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (211, 'Andrew', 'Cencini', 'M', 'Production Technician', 7, 123, '20010407', 10000, 233)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (212, 'Chris', 'Norred', 'K', 'Control Specialist', 12, 90, '20010407', 16800, 125)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (213, 'Chris', 'Okelberry', 'O', 'Production Technician', 7, 16, '20010408', 12500, 188)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (214, 'Shelley', 'Dyck', 'N', 'Production Technician', 7, 143, '20010408', 14000, 164)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (215, 'Gabe', 'Mares', 'B', 'Production Technician', 7, 210, '20010409', 15000, 87)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (216, 'Mike', 'Seamans', 'K', 'Accountant', 10, 139, '20010409', 26400, 120)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (217, 'Michael', 'Raheem', NULL, 'Research and Development Manager', 6, 158, '20010604', 42500, 236)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (218, 'Gary', 'Altman', 'E.', 'Facilities Manager', 14, 148, '20020103', 24000, 203)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (219, 'Charles', 'Fitzgerald', 'B', 'Production Technician', 7, 18, '20020104', 12500, 223)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (220, 'Ebru', 'Ersan', 'N', 'Production Technician', 7, 25, '20020107', 13500, 225)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (221, 'Sylvester', 'Valdez', 'A', 'Production Technician', 7, 108, '20020112', 14000, 25)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (222, 'Brian', 'Goldstein', 'Richard', 'Production Technician', 7, 51, '20020112', 15000, 48)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (223, 'Linda', 'Meisner', 'P', 'Buyer', 5, 274, '20020118', 18300, 28)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (224, 'Betsy', 'Stadick', 'A', 'Production Technician', 7, 64, '20020119', 13500, 47)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (225, 'Magnus', 'Hedlund', 'E', 'Facilities Administrative Assistant', 14, 218, '20020122', 9800, 211)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (226, 'Karan', 'Khanna', 'R', 'Production Technician', 7, 18, '20020123', 12500, 248)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (227, 'Mary', 'Baker', 'R', 'Production Technician', 7, 25, '20020126', 13500, 246)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (228, 'Kevin', 'Homer', 'M', 'Production Technician', 7, 25, '20020126', 13500, 29)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (229, 'Mihail', 'Frintu', 'U', 'Production Technician', 7, 51, '20020130', 15000, 89)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (230, 'Bonnie', 'Kearney', 'N', 'Production Technician', 7, 185, '20020202', 13500, 287)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (231, 'Fukiko', 'Ogisu', 'J', 'Buyer', 5, 274, '20020205', 18300, 17)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (232, 'Hung-Fu', 'Ting', 'T', 'Production Technician', 7, 108, '20020207', 14000, 220)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (233, 'Gordon', 'Hee', 'L', 'Buyer', 5, 274, '20020212', 18300, 15)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (234, 'Kimberly', 'Zimmerman', 'B', 'Production Technician', 7, 64, '20020213', 13500, 266)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (235, 'Kim', 'Abercrombie', 'B', 'Production Technician', 7, 16, '20020217', 12500, 56)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (236, 'Sandeep', 'Kaliyath', 'P', 'Production Technician', 7, 51, '20020218', 15000, 234)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (237, 'Prasanna', 'Samarawickrama', 'E', 'Production Technician', 7, 108, '20020223', 14000, 187)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (238, 'Frank', 'Pellow', 'S', 'Buyer', 5, 274, '20020224', 18300, 213)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (239, 'Min', 'Su', 'G', 'Production Technician', 7, 108, '20020225', 14000, 24)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (240, 'Eric', 'Brown', 'L', 'Production Technician', 7, 51, '20020225', 15000, 67)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (241, 'Eric', 'Kurjan', 'S', 'Buyer', 5, 274, '20020228', 18300, 207)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (242, 'Pat', 'Coleman', 'H', 'Janitor', 14, 49, '20020228', 9300, 116)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (243, 'Maciej', 'Dusza', 'W', 'Production Technician', 7, 18, '20020301', 12500, 83)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (244, 'Erin', 'Hagens', 'M', 'Buyer', 5, 274, '20020303', 18300, 8)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (245, 'Patrick', 'Wedge', 'C', 'Production Technician', 7, 64, '20020304', 13500, 7)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (246, 'Frank', 'Martinez', 'R', 'Production Technician', 7, 51, '20020308', 15000, 290)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (247, 'Ed', 'Dudenhoefer', 'R', 'Production Technician', 7, 16, '20020308', 12500, 243)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (248, 'Christopher', 'Hill', 'E', 'Production Technician', 7, 25, '20020311', 13500, 41)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (249, 'Patrick', 'Cook', 'M', 'Production Technician', 7, 51, '20020315', 15000, 264)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (250, 'Krishna', 'Sunkammurali', NULL, 'Production Technician', 7, 108, '20020316', 14000, 79)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (251, 'Lori', 'Penor', 'K', 'Janitor', 14, 49, '20020319', 9300, 124)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (252, 'Danielle', 'Tiedt', 'C', 'Production Technician', 7, 64, '20020323', 13500, 146)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (253, 'Sootha', 'Charncherngkha', 'T', 'Quality Assurance Technician', 13, 41, '20020326', 10600, 149)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (254, 'Michael', 'Zwilling', 'J', 'Production Technician', 7, 18, '20020326', 12500, 76)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (255, 'Randy', 'Reeves', 'T', 'Production Technician', 7, 18, '20020326', 12500, 84)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (256, 'John', 'Kane', 'T', 'Production Technician', 7, 25, '20020330', 13500, 69)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (257, 'Jack', 'Creasey', 'T', 'Production Technician', 7, 51, '20020403', 15000, 265)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (258, 'Olinda', 'Turner', 'C', 'Production Technician', 7, 108, '20020404', 14000, 33)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (259, 'Stuart', 'Macrae', 'J', 'Janitor', 14, 49, '20020405', 9300, 205)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (260, 'Jo', 'Berry', 'L', 'Janitor', 14, 49, '20020407', 9300, 121)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (261, 'Ben', 'Miller', 'T', 'Buyer', 5, 274, '20020409', 18300, 192)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (262, 'Tom', 'Vande Velde', 'M', 'Production Technician', 7, 64, '20020410', 13500, 98)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (263, 'Ovidiu', 'Cracium', 'V', 'Senior Tool Designer', 2, 3, '20030105', 28800, 145)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (264, 'Annette', 'Hill', 'L', 'Purchasing Assistant', 5, 274, '20030106', 12800, 181)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (265, 'Janice', 'Galvin', 'M', 'Tool Designer', 2, 263, '20030123', 25000, 200)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (266, 'Reinout', 'Hillmann', 'N', 'Purchasing Assistant', 5, 274, '20030125', 12800, 27)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (267, 'Michael', 'Sullivan', 'I', 'Senior Design Engineer', 1, 3, '20030130', 36100, 217)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (268, 'Stephen', 'Jiang', 'Y', 'North American Sales Manager', 3, 273, '20030204', 48100, 196)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (269, 'Wanida', 'Benshoof', 'M', 'Marketing Assistant', 4, 6, '20030207', 13500, 221)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (270, 'Sharon', 'Salavaria', 'B', 'Design Engineer', 1, 3, '20030218', 32700, 216)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (271, 'John', 'Wood', 'L', 'Marketing Specialist', 4, 6, '20030310', 14400, 180)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (272, 'Mary', 'Dempsey', 'A', 'Marketing Assistant', 4, 6, '20030317', 13500, 26)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (273, 'Brian', 'Welcker', 'S', 'Vice President of Sales', 3, 109, '20030318', 72100, 134)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (274, 'Sheela', 'Word', 'H', 'Purchasing Manager', 13, 71, '20030328', 30000, 222)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (275, 'Michael', 'Blythe', 'G', 'Sales Representative', 3, 268, '20030701', 23100, 60)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (276, 'Linda', 'Mitchell', 'C', 'Sales Representative', 3, 268, '20030701', 23100, 170)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (277, 'Jillian', 'Carson', NULL, 'Sales Representative', 3, 268, '20030701', 23100, 61)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (278, 'Garrett', 'Vargas', 'R', 'Sales Representative', 3, 268, '20030701', 23100, 52)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (279, 'Tsvi', 'Reiter', 'Michael', 'Sales Representative', 3, 268, '20030701', 23100, 154)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (280, 'Pamela', 'Ansman-Wolfe', 'O', 'Sales Representative', 3, 268, '20030701', 23100, 179)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (281, 'Shu', 'Ito', 'K', 'Sales Representative', 3, 268, '20030701', 23100, 235)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (282, 'Jose', 'Saraiva', 'Edvaldo', 'Sales Representative', 3, 268, '20030701', 23100, 178)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (283, 'David', 'Campbell', 'R', 'Sales Representative', 3, 268, '20030701', 23100, 13)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (284, 'Amy', 'Alberts', 'E', 'European Sales Manager', 3, 273, '20040518', 48100, 202)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (285, 'Jae', 'Pak', 'B', 'Sales Representative', 3, 284, '20040701', 23100, 54)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (286, 'Ranjit', 'Varkey Chudukatil', 'R', 'Sales Representative', 3, 284, '20040701', 23100, 38)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (287, 'Tete', 'Mensa-Annan', 'A', 'Sales Representative', 3, 268, '20041101', 23100, 53)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (288, 'Syed', 'Abbas', 'E', 'Pacific Sales Manager', 3, 273, '20050415', 48100, 49)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (289, 'Rachel', 'Valdez', 'B', 'Sales Representative', 3, 284, '20050701', 23100, 37)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (290, 'Lynn', 'Tsoflias', 'N', 'Sales Representative', 3, 288, '20050701', 23100, 153)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (291, 'Svetlin', 'Nakov', 'Ivanov', 'Independent Software Development  Consultant', 6, NULL, '20050301', 48000, 291)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (292, 'Martin', 'Kulov', NULL, 'Independent .NET Consultant', 6, NULL, '20050301', 48000, 291)

INSERT INTO Employees (EmployeeID, FirstName, LastName, MiddleName, JobTitle, DepartmentID, ManagerID, HireDate, Salary, AddressID)
VALUES (293, 'George', 'Denchev', NULL, 'Independent Java Consultant', 6, NULL, '20050301', 48000, 291)

SET IDENTITY_INSERT Employees OFF

GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Addresses FOREIGN KEY(AddressID)
REFERENCES Addresses(AddressID)
GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Departments FOREIGN KEY(DepartmentID)
REFERENCES Departments(DepartmentID)
GO

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Employees FOREIGN KEY(ManagerID)
REFERENCES Employees(EmployeeID)
GO

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID)
GO

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY(ProjectID)
REFERENCES Projects(ProjectID)
GO

ALTER TABLE Departments
ADD CONSTRAINT FK_Departments_Employees FOREIGN KEY(ManagerID)
REFERENCES Employees(EmployeeID)
GO

ALTER TABLE Addresses
ADD CONSTRAINT FK_Addresses_Towns FOREIGN KEY(TownID)
REFERENCES Towns(TownID)
GO
