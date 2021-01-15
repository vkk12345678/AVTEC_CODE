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
-- Table structure for table `engdetails`
--

DROP TABLE IF EXISTS `engdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `engdetails` (
  `CoName` varchar(50) DEFAULT NULL,
  `Dep` varchar(50) DEFAULT NULL,
  `TestDate` varchar(50) DEFAULT NULL,
  `Shift` varchar(50) DEFAULT NULL,
  `Engr` varchar(50) DEFAULT NULL,
  `Oper` varchar(50) DEFAULT NULL,
  `BedNo` varchar(50) DEFAULT NULL,
  `Project` varchar(50) DEFAULT NULL,
  `ENGModel` varchar(50) DEFAULT NULL,
  `EngNo` varchar(50) DEFAULT NULL,
  `FIPNo` varchar(50) DEFAULT NULL,
  `InjTiming` varchar(50) DEFAULT NULL,
  `NOP` varchar(50) DEFAULT NULL,
  `InjDetails` varchar(50) DEFAULT NULL,
  `TestType` varchar(50) DEFAULT NULL,
  `ExhaustSystem` varchar(50) DEFAULT NULL,
  `Fan` varchar(50) DEFAULT NULL,
  `ACS` varchar(50) DEFAULT NULL,
  `DynoType` varchar(50) DEFAULT NULL,
  `DynoConstant` varchar(50) DEFAULT NULL,
  `LowIdle` varchar(50) DEFAULT NULL,
  `HighIdle` varchar(50) DEFAULT NULL,
  `SweptVol` varchar(50) DEFAULT NULL,
  `Atms Pressure` varchar(50) DEFAULT NULL,
  `Fuel Type` varchar(50) DEFAULT NULL,
  `Specific Gravity` varchar(50) DEFAULT NULL,
  `J O Reference` varchar(50) DEFAULT NULL,
  `Test Reference` varchar(50) DEFAULT NULL,
  `EngHrs` varchar(50) DEFAULT NULL,
  `BoreDia` varchar(50) DEFAULT NULL,
  `Cylinders` varchar(50) DEFAULT NULL,
  `Stroke` varchar(50) DEFAULT NULL,
  `FType` varchar(50) DEFAULT NULL,
  `HPipe` varchar(50) DEFAULT NULL,
  `StrtTime` varchar(50) DEFAULT NULL,
  `StopTime` varchar(50) DEFAULT NULL,
  `Remark` varchar(50) DEFAULT NULL,
  `TC` varchar(50) DEFAULT NULL,
  `DBT` varchar(50) DEFAULT NULL,
  `WBT` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `engdetails`
--

LOCK TABLES `engdetails` WRITE;
/*!40000 ALTER TABLE `engdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `engdetails` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:19
