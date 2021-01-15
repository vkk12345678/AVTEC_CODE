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
-- Table structure for table `tb_conf`
--

DROP TABLE IF EXISTS `tb_conf`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_conf` (
  `ChNo` varchar(50) NOT NULL,
  `PNo` int(11) DEFAULT '0',
  `ShortName` varchar(50) DEFAULT NULL,
  `Category` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ChNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_conf`
--

LOCK TABLES `tb_conf` WRITE;
/*!40000 ALTER TABLE `tb_conf` DISABLE KEYS */;
INSERT INTO `tb_conf` VALUES ('00',0,'E_Speed','Serial'),('01',1,'E_Torque','Serial'),('02',2,'SFC_RESET','Serial'),('03',3,'Fuel_Wt','Serial'),('04',4,'Fuel_Time','Serial'),('05',5,'A_FuelWt','Serial'),('06',6,'P_LubOil ','Serial'),('07',7,'T_LubOil','Serial'),('08',8,'T_WtrOut','Serial'),('09',9,'T_Exhaust','Serial'),('10',10,'T_Ambient','Serial'),('11',11,'P_Atms','Serial'),('12',12,'P_ExBack','Serial'),('13',13,'P_WtrInLet','Serial'),('14',14,'P_CrCase','Serial'),('15',15,'P_Fuel','Serial'),('16',16,'Rel_Hum','Serial'),('17',18,'T_WetBulb','Serial'),('18',65,'PosFb','Analog'),('19',66,'Thr_Pos','Analog'),('20',67,'Blowby','Analog'),('21',68,'Lambda','Analog'),('22',98,'Not Prog','Analog'),('23',99,'Not Prog','Analog');
/*!40000 ALTER TABLE `tb_conf` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:24:53
