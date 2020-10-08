-- phpMyAdmin SQL Dump
-- version 3.4.10.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 30, 2012 at 03:21 AM
-- Server version: 5.1.52
-- PHP Version: 5.2.9

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `azertypr_cruisedev`
--

-- --------------------------------------------------------

--
-- Table structure for table `uc_users`
--

CREATE TABLE IF NOT EXISTS `uc_users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `nickname` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT 'Undetected',
  `cash` int(11) NOT NULL,
  `bankbalance` int(11) NOT NULL,
  `licence` int(11) NOT NULL,
  `cars` char(255) COLLATE utf8_bin NOT NULL,
  `totaldistance` int(11) NOT NULL,
  `totalhealth` int(11) NOT NULL,
  `totaljobsdone` int(11) NOT NULL,
  `giux` int(11) NOT NULL,
  `giuy` int(11) NOT NULL,
  `giux2` int(11) NOT NULL,
  `giuy2` int(11) NOT NULL,
  `guistyle` int(11) NOT NULL,
  `goods1` int(11) NOT NULL,
  `goods2` int(11) NOT NULL,
  `member` int(11) NOT NULL,
  `officer` int(11) NOT NULL,
  `cadet` int(11) NOT NULL,
  `towtruck` int(11) NOT NULL,
  `raffle` int(11) NOT NULL,
  `lotto` int(11) NOT NULL,
  `panel` int(11) NOT NULL,
  `renting` int(11) NOT NULL,
  `rented` int(11) NOT NULL,
  `renter` char(255) COLLATE utf8_bin NOT NULL,
  `renterr` char(255) COLLATE utf8_bin NOT NULL,
  `rentee` char(255) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=119 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
