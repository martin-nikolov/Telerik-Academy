CREATE DATABASE  IF NOT EXISTS `university` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `university`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: university
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `CourseId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Professors_ProfessorId` int(11) NOT NULL,
  `Departaments_DepartamentId` int(11) NOT NULL,
  PRIMARY KEY (`CourseId`,`Professors_ProfessorId`,`Departaments_DepartamentId`),
  KEY `fk_Courses_Professors1_idx` (`Professors_ProfessorId`),
  KEY `fk_Courses_Departaments1_idx` (`Departaments_DepartamentId`),
  CONSTRAINT `fk_Courses_Departaments1` FOREIGN KEY (`Departaments_DepartamentId`) REFERENCES `departaments` (`DepartamentId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_Professors1` FOREIGN KEY (`Professors_ProfessorId`) REFERENCES `professors` (`ProfessorId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES (1,'Introduction to Computers and Computing',1,6),(2,'Programming Concepts',1,6),(3,'Basic Drawing',2,8),(4,'Graphic Communications',3,9),(5,'History of Architecture and Urbanism',4,8),(6,'Electronic Devices and Analog Circuits',5,1),(7,'Signals and Systems',5,2);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departaments`
--

DROP TABLE IF EXISTS `departaments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departaments` (
  `DepartamentId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Faculties_FacultyId` int(11) NOT NULL,
  PRIMARY KEY (`DepartamentId`,`Faculties_FacultyId`),
  KEY `fk_Departaments_Faculties1_idx` (`Faculties_FacultyId`),
  CONSTRAINT `fk_Departaments_Faculties1` FOREIGN KEY (`Faculties_FacultyId`) REFERENCES `faculties` (`FacultyId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COMMENT='				';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departaments`
--

LOCK TABLES `departaments` WRITE;
/*!40000 ALTER TABLE `departaments` DISABLE KEYS */;
INSERT INTO `departaments` VALUES (1,'Mechanical Engineering',1),(2,'Mechanical Systems Engineering',1),(3,'Applied Chemistry',1),(4,'Environmental and Energy Chemistry',1),(5,'Information and Communications Engineering',1),(6,'Urban Design and Planning',2),(7,'Architecture',2),(8,'Architectural Design',2),(9,'Computer Science',3),(10,'Information Design',3),(11,'Innovative Mechanical Engineering',3);
/*!40000 ALTER TABLE `departaments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `FacultyId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`FacultyId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
INSERT INTO `faculties` VALUES (1,'Engineering'),(2,'Architecture'),(3,'Informatics'),(4,'Global Engineering');
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `ProfessorId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Departaments_DepartamentId` int(11) NOT NULL,
  PRIMARY KEY (`ProfessorId`,`Departaments_DepartamentId`),
  KEY `fk_Professors_Departaments1_idx` (`Departaments_DepartamentId`),
  CONSTRAINT `fk_Professors_Departaments1` FOREIGN KEY (`Departaments_DepartamentId`) REFERENCES `departaments` (`DepartamentId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
INSERT INTO `professors` VALUES (1,'Ivanov',1),(2,'Petrov',1),(3,'Georgiev',2),(4,'Penchev',4),(5,'Matev',5);
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors_titles`
--

DROP TABLE IF EXISTS `professors_titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors_titles` (
  `Professors_ProfessorId` int(11) NOT NULL,
  `Titles_TitleId` int(11) NOT NULL,
  PRIMARY KEY (`Professors_ProfessorId`,`Titles_TitleId`),
  KEY `fk_ProfessorsTitles_Titles1_idx` (`Titles_TitleId`),
  KEY `fk_ProfessorsTitles_Professors1_idx` (`Professors_ProfessorId`),
  CONSTRAINT `fk_ProfessorsTitles_Titles1` FOREIGN KEY (`Titles_TitleId`) REFERENCES `titles` (`TitleId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsTitles_Professors1` FOREIGN KEY (`Professors_ProfessorId`) REFERENCES `professors` (`ProfessorId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors_titles`
--

LOCK TABLES `professors_titles` WRITE;
/*!40000 ALTER TABLE `professors_titles` DISABLE KEYS */;
INSERT INTO `professors_titles` VALUES (1,1),(2,1),(3,2),(4,3);
/*!40000 ALTER TABLE `professors_titles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `StudentId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Faculties_FacultyId` int(11) NOT NULL,
  PRIMARY KEY (`StudentId`,`Faculties_FacultyId`),
  KEY `fk_Students_Faculties1_idx` (`Faculties_FacultyId`),
  CONSTRAINT `fk_Students_Faculties1` FOREIGN KEY (`Faculties_FacultyId`) REFERENCES `faculties` (`FacultyId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Naoya Yoshida',1),(2,'Kazuki Akamatsu',1),(3,'Tetsuo Sakamoto',2),(4,'Norimitsu Ichikawa',2),(5,'Teruo Serizawa',4);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students_courses`
--

DROP TABLE IF EXISTS `students_courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students_courses` (
  `Students_StudentId` int(11) NOT NULL,
  `Courses_CourseId` int(11) NOT NULL,
  PRIMARY KEY (`Students_StudentId`,`Courses_CourseId`),
  KEY `fk_StudentsCourses_Students1_idx` (`Students_StudentId`),
  KEY `fk_StudentsCourses_Courses1_idx` (`Courses_CourseId`),
  CONSTRAINT `fk_StudentsCourses_Courses1` FOREIGN KEY (`Courses_CourseId`) REFERENCES `courses` (`CourseId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentsCourses_Students1` FOREIGN KEY (`Students_StudentId`) REFERENCES `students` (`StudentId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students_courses`
--

LOCK TABLES `students_courses` WRITE;
/*!40000 ALTER TABLE `students_courses` DISABLE KEYS */;
INSERT INTO `students_courses` VALUES (1,1),(1,2),(1,3),(1,4),(2,1),(3,2),(4,5),(5,2);
/*!40000 ALTER TABLE `students_courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `TitleId` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(45) NOT NULL,
  PRIMARY KEY (`TitleId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
INSERT INTO `titles` VALUES (1,'Ph. D'),(2,'Academician'),(3,'Senior assistant');
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
