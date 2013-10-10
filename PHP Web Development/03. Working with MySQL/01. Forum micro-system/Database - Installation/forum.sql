-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Oct 08, 2013 at 06:18 PM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `forum`
--
CREATE DATABASE IF NOT EXISTS `forum` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `forum`;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COMMENT='Contains categories created by users.' AUTO_INCREMENT=26 ;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `category`) VALUES
(1, 'News'),
(2, 'Books'),
(3, 'Social'),
(4, 'Political'),
(5, 'Sport'),
(17, 'Education');

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE IF NOT EXISTS `posts` (
  `postID` int(11) NOT NULL AUTO_INCREMENT,
  `subject` varchar(50) NOT NULL,
  `message` varchar(250) NOT NULL,
  `author` varchar(30) NOT NULL,
  `created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `category` varchar(30) NOT NULL,
  PRIMARY KEY (`postID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COMMENT='Archives all messages posted by users.' AUTO_INCREMENT=84 ;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`postID`, `subject`, `message`, `author`, `created`, `category`) VALUES
(65, 'Facebook slips in social log-in dominance', 'A noticeably smaller percentage of people logged into Web sites and apps with their Facebook accounts in the past three months, compared with the same period last year, according to data published by Janrain, a provider of user management services.', 'facebook', '2013-10-06 20:17:14', 'Social'),
(31, 'Political, popular obstacles block pension changes', 'Detroit''s bankruptcy is casting a shadow over a long list of cities across the U.S. and giving mayors new urgency in the search for solutions to the greatest challenge to face America''s cities in a generation.', 'admin', '2013-10-06 19:34:08', 'Political'),
(29, 'Trying to save the heat-seeking bushmaster', 'It''s easy to campaign to save endangered species like pandas and woolly spider monkeys because they''re fluffy and cute. But what about venomous snakes?', 'telerik', '2013-10-06 19:31:44', 'News'),
(20, 'Free Software Engineering Education | Telerik', 'Telerik Academy is an initiative by the leading technology company Telerik. Established in 2009, in just a few years Telerik Academy became the #1...', 'telerik', '2013-10-06 13:37:08', 'Education'),
(19, 'Books - The New York Times', 'Find book reviews & news about authors, new books, best sellers, fiction & non-fiction, literature, biographies, memoirs, children?s books, the Pulitzer Prizes and ...', 'admin', '2013-10-06 13:25:07', 'Books'),
(18, 'Pirates held at home by Esperance', 'Orlando Pirates held to a goalless draw at home by Esperance in Champions League semi-final after Coton Sport versus Al Ahly is abandoned.', 'admin', '2013-10-06 13:19:58', 'Sport'),
(75, 'Хамилтън сравни Фетел с времето на Шумахер', 'Люис Хамилтън се страхува, че доминацията на Себастиан Фетел във Формула 1 напомня на тази на Михаел Шумахер преди около десет години. \r\n\r\nБританецът смята, че телевизиите по целия свят обръщат огромно внимание единствено на световния шампион Фетел.', 'admin', '2013-10-08 17:48:09', 'Sport');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COMMENT='Contains information about the users.' AUTO_INCREMENT=26 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`) VALUES
(1, 'admin', '12345'),
(23, 'facebook', 'facebook'),
(22, 'telerik', 'telerik');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
