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
-- Table structure for table `tb_endu`
--

DROP TABLE IF EXISTS `tb_endu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_endu` (
  `N` int(11) NOT NULL DEFAULT '0',
  `Cn` int(11) DEFAULT NULL,
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_endu`
--

LOCK TABLES `tb_endu` WRITE;
/*!40000 ALTER TABLE `tb_endu` DISABLE KEYS */;
INSERT INTO `tb_endu` VALUES (0,124,'Tol_Hrs','***'),(1,123,'Start_Tm','***'),(2,0,'E_Speed','r/min'),(3,1,'E_Torque','Nm'),(4,113,'F_Flow','kg/hr'),(5,64,'BlowBy','lpm'),(6,47,'P_AirInDpr','mbar'),(7,22,'P_LubOil','bar'),(8,46,'P_BIC','mbar'),(9,45,'P_AIC','mbar'),(10,32,'R_AirIntek','°C'),(11,42,'T_LubOil_2','°C'),(12,29,'R_Coolant In','°C'),(13,30,'R_Coolant Out','°C'),(14,39,'T_Exhaust','°C'),(15,38,'T_BIC','°C'),(16,40,'T_AIC','°C'),(17,26,'P_WtrIn','mbar'),(18,25,'P_WtrOut','mbar'),(19,23,'P_Ex_Back','mbar'),(20,51,'P_Exh_Mani_T3','mbar'),(21,48,'P_FuelIn','mbar'),(22,21,'P_Crancase','mbar'),(23,108,'SFC','g/kw.hr'),(24,125,'Alarm','***');
/*!40000 ALTER TABLE `tb_endu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:11
