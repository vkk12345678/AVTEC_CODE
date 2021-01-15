CREATE DATABASE  IF NOT EXISTS `gen_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `gen_db`;
-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: gen_db
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
-- Table structure for table `tblproject`
--

DROP TABLE IF EXISTS `tblproject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblproject` (
  `ProjectFile` varchar(50) NOT NULL,
  `EngFile` varchar(50) DEFAULT NULL,
  `ProgFile` varchar(50) DEFAULT NULL,
  `LimitFile` varchar(50) DEFAULT NULL,
  `CorrFile` varchar(50) DEFAULT NULL,
  `Test_Type` varchar(50) DEFAULT NULL,
  `R_power` varchar(50) DEFAULT NULL,
  `R_rpm` varchar(50) DEFAULT NULL,
  `MT_Torque` varchar(50) DEFAULT NULL,
  `MT_rpm` varchar(50) DEFAULT NULL,
  `Fly_rpm` varchar(50) DEFAULT NULL,
  `Idle_rpm` varchar(50) DEFAULT NULL,
  `E_Strpm` varchar(50) DEFAULT NULL,
  `T_Crank` varchar(50) DEFAULT NULL,
  `C_Time` varchar(50) DEFAULT NULL,
  `PM_Log` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ProjectFile`),
  KEY `Idle_rpm` (`Idle_rpm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblproject`
--

LOCK TABLES `tblproject` WRITE;
/*!40000 ALTER TABLE `tblproject` DISABLE KEYS */;
INSERT INTO `tblproject` VALUES ('Prj_DW10FC','eng_dw10fc','seq_dw10fc','lim_dw10fc','CF_DIN','PERFORMANCE','075.0','1900','165.0','1400','2250','600','551','2','0000.02','02'),('Prj_DYNALEC','eng_dw10fc','seq_dw10fc','lim_dw10fc','CF_DIN','PERFORMANCE','075.0','1900','165.0','1400','2250','600','551','2','0000.02','02');
/*!40000 ALTER TABLE `tblproject` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:09
