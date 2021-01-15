CREATE DATABASE  IF NOT EXISTS `seq_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `seq_db`;
-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: seq_db
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
-- Table structure for table `seq_dynalec`
--

DROP TABLE IF EXISTS `seq_dynalec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `seq_dynalec` (
  `StepNo` int(11) NOT NULL,
  `MD` varchar(2) DEFAULT NULL,
  `SetPt1` varchar(8) DEFAULT NULL,
  `RTime1` varchar(6) DEFAULT NULL,
  `SetPt2` varchar(5) DEFAULT NULL,
  `RTime2` varchar(6) DEFAULT NULL,
  `StabTime` varchar(6) DEFAULT NULL,
  `SteadyTime` varchar(6) DEFAULT NULL,
  `StopTime` varchar(6) DEFAULT NULL,
  `RepeatLoop` varchar(7) DEFAULT NULL,
  `LogData` varchar(6) DEFAULT NULL,
  `SMKEvents` tinyint(4) DEFAULT NULL,
  `PassLim` tinyint(4) DEFAULT NULL,
  `ReadSFC` tinyint(4) DEFAULT NULL,
  `Comments` varchar(30) DEFAULT NULL,
  `Tm_Step` varchar(8) DEFAULT NULL,
  `D12` tinyint(4) DEFAULT NULL,
  `D13` tinyint(4) DEFAULT NULL,
  `D14` tinyint(4) DEFAULT NULL,
  `Speed` varchar(10) DEFAULT NULL,
  `Torque` varchar(10) DEFAULT NULL,
  `F_Rate` varchar(10) DEFAULT NULL,
  `T_Luboil` varchar(10) DEFAULT NULL,
  `P_Luboil` varchar(10) DEFAULT NULL,
  `P_ExBk` varchar(10) DEFAULT NULL,
  `BlowBy` varchar(10) DEFAULT NULL,
  `Smoke` varchar(10) DEFAULT NULL,
  `Spare1` varchar(10) DEFAULT NULL,
  `Spare2` varchar(10) DEFAULT NULL,
  `limfile` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`StepNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seq_dynalec`
--

LOCK TABLES `seq_dynalec` WRITE;
/*!40000 ALTER TABLE `seq_dynalec` DISABLE KEYS */;
INSERT INTO `seq_dynalec` VALUES (1,'1','00.00','00.01','00.00','00.10','00.01','00.08','N00.00','000N000','Y00.00',0,0,0,'COMMENT','19',0,0,0,'00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','lim_dynalec'),(2,'1','32.85','00.01','00.00','00.10','00.05','01.10','N00.00','000N000','Y00.00',0,0,0,'COMMENT','85',0,0,0,'00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','lim_dynalec'),(3,'1','00.00','00.01','00.00','00.10','00.10','00.10','N00.00','000N000','Y00.00',0,0,0,'COMMENT','30',0,0,0,'00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','00-1000','lim_dynalec');
/*!40000 ALTER TABLE `seq_dynalec` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:24
