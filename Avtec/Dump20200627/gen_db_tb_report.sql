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
-- Table structure for table `tb_report`
--

DROP TABLE IF EXISTS `tb_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_report` (
  `N` int(11) NOT NULL DEFAULT '0',
  `Cn` int(11) DEFAULT '0',
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_report`
--

LOCK TABLES `tb_report` WRITE;
/*!40000 ALTER TABLE `tb_report` DISABLE KEYS */;
INSERT INTO `tb_report` VALUES (0,0,'E_Speed','rpm'),(1,1,'E_Torque','Nm'),(2,1,'Torque','Nm'),(3,4,'SFC_Time','sec'),(4,5,'F_Weight','g'),(5,21,'P_Crancase','mbar'),(6,22,'P_LubOil','bar'),(7,23,'P_Ex_Back','mbar'),(8,24,'P_Ambient','mbar'),(9,25,'P_WtrOut','mbar'),(10,26,'P_WtrIn','mbar'),(11,100,'Not_Prog','Unit'),(12,28,'RelHum','%'),(13,29,'R_Coolant In','°C'),(14,30,'R_Coolant Out','°C'),(15,31,'R_Fuel','°C'),(16,32,'R_AirIntek','°C'),(17,37,'T_LubOil','°C'),(18,38,'T_BIC','°C'),(19,39,'T_Exhaust','°C'),(20,40,'T_AIC','°C'),(21,41,'T_ExManiF','°C'),(22,46,'P_BIC','mbar'),(23,45,'P_AIC','mbar'),(24,47,'P_Vaccume','mbar'),(25,48,'P_FuelIn','mbar'),(26,52,'P_Fuel_Out','mbar'),(27,51,'P_Exh_Mani_T3','mbar'),(28,61,'BlowBy','lpm'),(29,105,'C_Factor','***'),(30,31,'R_Fuel','°C'),(31,119,'bmep','bar'),(32,123,'Start_Tm','***'),(33,100,'Not_Prog','Unit'),(34,0,NULL,NULL),(35,0,NULL,NULL),(36,0,NULL,NULL),(37,0,NULL,NULL),(38,0,NULL,NULL);
/*!40000 ALTER TABLE `tb_report` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:24:59
