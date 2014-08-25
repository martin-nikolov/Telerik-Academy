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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
