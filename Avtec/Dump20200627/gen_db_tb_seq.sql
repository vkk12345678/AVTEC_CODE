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
-- Table structure for table `tb_seq`
--

DROP TABLE IF EXISTS `tb_seq`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_seq` (
  `StepNo` varchar(50) NOT NULL,
  `Mode` varchar(5) DEFAULT NULL,
  `SetPt1` varchar(20) DEFAULT NULL,
  `RTime1` varchar(25) DEFAULT NULL,
  `SetPt2` varchar(25) DEFAULT NULL,
  `RTime2` varchar(25) DEFAULT NULL,
  `Stime` varchar(25) DEFAULT NULL,
  `SFC` varchar(25) DEFAULT NULL,
  `StopTime` varchar(25) DEFAULT NULL,
  `Repeat` varchar(25) DEFAULT NULL,
  `PF` varchar(25) DEFAULT NULL,
  `Ev_S` varchar(25) DEFAULT NULL,
  `D10` varchar(25) DEFAULT NULL,
  `D12` varchar(25) DEFAULT NULL,
  `D13` varchar(25) DEFAULT NULL,
  `D14` varchar(25) DEFAULT NULL,
  `D15` varchar(25) DEFAULT NULL,
  `Comment` varchar(100) DEFAULT NULL,
  `FName` varchar(50) NOT NULL,
  `Lim_Id` int(11) DEFAULT '0',
  PRIMARY KEY (`StepNo`,`FName`),
  KEY `Lim_Id` (`Lim_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_seq`
--

LOCK TABLES `tb_seq` WRITE;
/*!40000 ALTER TABLE `tb_seq` DISABLE KEYS */;
INSERT INTO `tb_seq` VALUES ('001','2','2000','00.02','50.00','00.02','00.05','N00.00','N00.00 ','000N000 ','I00.00 ','N0','H','L','L','L','L','Comment for the step','N1',1),('001','3','20.00','00.02','80.00','00.02','00.05','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','N2',1),('001','2','2000','00.02','50.00','00.02','00.05','N00:00','N00:00 ','000N000 ','N00:00','N0','H','L','L','L','L','Comment for the step','NEW',1),('001','1','10.00','00:01','10.00','00:01','00:02','N00:00','N00:00','000N000','N00:00','N0','H','L','L','L','L','Comment for the step','SDF',1),('001','5','1000','00.02','00.00','00.02','06.00','N00.00','N00.00 ','000N000 ','I00.00 ','N0','H','L','L','L','L','Comment for the step','TC5556',1),('002','1','10.00','00.00','10.00','00.02','00.35','G00.00','N00.00 ','000N000 ','A00.10 ','E1','H','L','L','L','L','Comment for the step','N1',1),('002','1','10.00','00:01','10.00','00:01','00:02','N00:00','N00:00','000N000','N00:00','N0','H','L','L','L','L','Comment for the step','N2',1),('002','2','3000','00.02','50.00','00.02','00.05','N00:00','N00:00 ','000N000 ','N00:00','N0','H','L','L','L','L','Comment for the step','NEW',1),('002','6','1200.0','00.20','0150','00.20','07.00','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','TC5556',1),('003','2','3000','00.02','50.00','00.02','00.06','N00.00','N00.00 ','000N000 ','I00.05 ','N0','H','L','L','L','L','Comment for the step','N1',3),('003','6','1600.0','00.20','0250','00.20','08.00','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','TC5556',1),('004','2','3000','00.02','50.00','00.02','00.05','N00.00','S00.00','000N000 ','Y00.00','N0','C','L','L','L','L','Comment for the step','N1',1),('004','6','2000.0','00.20','0320','00.20','08.00','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','TC5556',1),('005','2','3000','00.02','50.00','00.02','04.02','N00.00','S00.00','000N000 ','A01.30 ','N0','C','L','L','L','L','Comment for the step','N1',1),('005','6','2400.0','00.20','0350','00.20','08.00','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','TC5556',1),('006','2','3000','00.02','80.00','00.02','00.05','G00.00','S00.05','003R002','N00.00','E1','C','L','L','L','L','Comment for the step','N1',1),('006','6','1200.0','00.20','0150','00.20','07.00','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','TC5556',1),('007','2','3000','00.02','30.00','00.02','00.05','N00.00','S00.00','000N000 ','N00.00','N0','C','L','L','L','L','Comment for the step','N1',1),('007','6','1200.0','00.20','0150','00.20','07.00','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','TC5556',1),('008','2','3000','00.02','50.00','00.02','00.05','N00.00','N00.00 ','000N000 ','N00.00','N0','H','L','L','L','L','Comment for the step','N1',1),('008','1','10.00','00:01','10.00','00:01','00:02','N00:00','N00:00','000N000','N00:00','N0','H','L','L','L','L','Comment for the step','TC5556',1),('009','1','10.00','00:01','10.00','00:01','00:02','N00:00','N00:00','000N000','N00:00','N0','H','L','L','L','L','Comment for the step','N1',1);
/*!40000 ALTER TABLE `tb_seq` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:05
