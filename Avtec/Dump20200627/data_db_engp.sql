CREATE DATABASE  IF NOT EXISTS `data_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `data_db`;
-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: data_db
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `engp`
--

DROP TABLE IF EXISTS `engp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `engp` (
  `FileName` varchar(50) DEFAULT NULL,
  `EngineType` varchar(45) DEFAULT NULL,
  `Testref` varchar(45) DEFAULT NULL,
  `FIPNo` varchar(45) DEFAULT NULL,
  `EngineNo` varchar(45) DEFAULT NULL,
  `PartNo` varchar(45) DEFAULT NULL,
  `NoCyld` varchar(45) DEFAULT NULL,
  `Operator` varchar(45) DEFAULT NULL,
  `Engineer` varchar(45) DEFAULT NULL,
  `TestCellNo` varchar(45) DEFAULT NULL,
  `SrtTm` varchar(45) DEFAULT NULL,
  `StpTm` varchar(45) DEFAULT NULL,
  `DateN` varchar(45) DEFAULT NULL,
  `Shift` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `engp`
--

LOCK TABLES `engp` WRITE;
/*!40000 ALTER TABLE `engp` DISABLE KEYS */;
INSERT INTO `engp` VALUES ('Perf_AN15PPPY8899777','Eng697','123','12345','PPPY1109','2356897812','3','jon','jake','TestCell_VII','08:12:44','9:12:56','12/31/2019','A');
/*!40000 ALTER TABLE `engp` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:17
