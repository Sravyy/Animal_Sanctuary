-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jan 11, 2018 at 11:21 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `animalSanc_test`
--
CREATE DATABASE IF NOT EXISTS `animalSanc_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `animalSanc_test`;

-- --------------------------------------------------------

--
-- Table structure for table `Animals`
--

CREATE TABLE `Animals` (
  `AnimalId` int(11) NOT NULL,
  `HabitatType` longtext,
  `MedicalEmergency` bit(1) NOT NULL,
  `Name` longtext,
  `Sex` longtext,
  `Species` longtext,
  `VeterinarianId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Animals`
--

INSERT INTO `Animals` (`AnimalId`, `HabitatType`, `MedicalEmergency`, `Name`, `Sex`, `Species`, `VeterinarianId`) VALUES
(1, 'forest', b'0', 'Test Animal', 'female', 'NajaNaja', 1),
(2, 'forest', b'0', 'Test Animal', 'female', 'NajaNaja', 1);

-- --------------------------------------------------------

--
-- Table structure for table `Veterinarians`
--

CREATE TABLE `Veterinarians` (
  `VeterinarianId` int(11) NOT NULL,
  `Name` longtext,
  `Specialty` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Veterinarians`
--

INSERT INTO `Veterinarians` (`VeterinarianId`, `Name`, `Specialty`) VALUES
(1, 'Jay', 'Sleeping');

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20180110173037_Initial', '1.1.2');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Animals`
--
ALTER TABLE `Animals`
  ADD PRIMARY KEY (`AnimalId`),
  ADD KEY `IX_Animals_VeterinarianId` (`VeterinarianId`);

--
-- Indexes for table `Veterinarians`
--
ALTER TABLE `Veterinarians`
  ADD PRIMARY KEY (`VeterinarianId`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Animals`
--
ALTER TABLE `Animals`
  MODIFY `AnimalId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `Veterinarians`
--
ALTER TABLE `Veterinarians`
  MODIFY `VeterinarianId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `Animals`
--
ALTER TABLE `Animals`
  ADD CONSTRAINT `FK_Animals_Veterinarians_VeterinarianId` FOREIGN KEY (`VeterinarianId`) REFERENCES `Veterinarians` (`VeterinarianId`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
