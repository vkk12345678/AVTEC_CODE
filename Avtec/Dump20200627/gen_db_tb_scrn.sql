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
-- Table structure for table `tb_scrn`
--

DROP TABLE IF EXISTS `tb_scrn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_scrn` (
  `Pn` varchar(50) DEFAULT NULL,
  `Cn` int(11) DEFAULT '0',
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  `N` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`N`),
  UNIQUE KEY `N_UNIQUE` (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_scrn`
--

LOCK TABLES `tb_scrn` WRITE;
/*!40000 ALTER TABLE `tb_scrn` DISABLE KEYS */;
INSERT INTO `tb_scrn` VALUES ('1.1',0,'E_Speed','r/min',0),('1.2',1,'E_Torque','Nm',1),('1.3',21,'R_WtrIn','°C',2),('1.4',22,'R_wtrOut','°C',3),('1.5',23,'R_FuelIn','°C',4),('1.6',24,'T_Ambient','°C',5),('1.7',100,'Not_Prog','Unit',6),('2.1',29,'P_Vaccum','mbar',7),('2.2',30,'P_Exback','bar',8),('2.3',31,'P_FuelIn','bar',9),('2.4',69,'P_cintIn','bar',10),('2.5',32,'P_ClntOut','bar',11),('2.6',33,'P_Luboil','bar',12),('2.7',100,'Not_Prog','Unit',13),('3.1',37,'T_Exhaust','°C',14),('3.2',33,'P_Luboil','bar',15),('3.3',100,'Not_Prog','Unit',16),('3.4',100,'Not_Prog','Unit',17),('3.5',100,'Not_Prog','Unit',18),('3.6',100,'Not_Prog','Unit',19),('3.7',100,'Not_Prog','Unit',20),('4.1',100,'Not_Prog','Unit',21),('4.2',100,'Not_Prog','Unit',22),('4.3',100,'Not_Prog','Unit',23),('4.4',100,'Not_Prog','Unit',24),('4.5',100,'Not_Prog','Unit',25),('4.6',100,'Not_Prog','Unit',26),('4.7',100,'Not_Prog','Unit',27),('5.1',0,'E_Speed','r/min',28),('5.2',100,'Not_Prog','Unit',29),('5.3',100,'Not_Prog','Unit',30),('5.4',100,'Not_Prog','Unit',31),('5.5',100,'Not_Prog','Unit',32),('5.6',100,'Not_Prog','Unit',33),('5.7',100,'Not_Prog','Unit',34),('6.1',100,'Not_Prog','Unit',35),('6.2',100,'Not_Prog','Unit',36),('6.3',100,'Not_Prog','Unit',37),('6.4',100,'Not_Prog','Unit',38),('6.5',100,'Not_Prog','Unit',39),('6.6',100,'Not_Prog','Unit',40),('6.7',100,'Not_Prog','Unit',41),('7.1',100,'Not_Prog','Unit',42),('7.2',100,'Not_Prog','Unit',43),('7.3',100,'Not_Prog','Unit',44),('7.4',100,'Not_Prog','Unit',45),('7.5',100,'Not_Prog','Unit',46),('7.6',100,'Not_Prog','Unit',47),('7.7',100,'Not_Prog','Unit',48),('8.1',100,'Not_Prog','Unit',49),('8.2',100,'Not_Prog','Unit',50),('8.3',100,'Not_Prog','Unit',51),('8.4',100,'Not_Prog','Unit',52),('8.5',100,'Not_Prog','Unit',53),('8.6',100,'Not_Prog','Unit',54),('8.7',100,'Not_Prog','Unit',55),('9.1',100,'Not_Prog','Unit',56),('9.2',100,'Not_Prog','Unit',57),('9.3',100,'Not_Prog','Unit',58),('9.4',100,'Not_Prog','Unit',59),('9.5',100,'Not_Prog','Unit',60),('9.6',100,'Not_Prog','Unit',61),('9.7',100,'Not_Prog','Unit',62);
/*!40000 ALTER TABLE `tb_scrn` ENABLE KEYS */;
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
