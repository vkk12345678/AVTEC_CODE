CREATE DATABASE  IF NOT EXISTS `lim_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `lim_db`;
-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: lim_db
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
-- Table structure for table `lim_dynalec`
--

DROP TABLE IF EXISTS `lim_dynalec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `lim_dynalec` (
  `Pn` float NOT NULL,
  `ParameterName` varchar(30) DEFAULT NULL,
  `Lower1` varchar(8) DEFAULT NULL,
  `Low1` varchar(8) DEFAULT NULL,
  `High1` varchar(8) DEFAULT NULL,
  `Higher1` varchar(8) DEFAULT NULL,
  `MinV` varchar(8) DEFAULT NULL,
  `MaxV` varchar(8) DEFAULT NULL,
  `Unit` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Pn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lim_dynalec`
--

LOCK TABLES `lim_dynalec` WRITE;
/*!40000 ALTER TABLE `lim_dynalec` DISABLE KEYS */;
INSERT INTO `lim_dynalec` VALUES (0,'E_Speed','N','N','A2000','N','000','10000','r/min'),(1,'Torque','N','N','N','N','-5','195','Nm'),(2,'Not_Prog','N','N','N','N','0','1000','Unit'),(3,'Not_Prog','N','N','N','N','799','1199','Unit'),(4,'Not_Prog','N','N','N','N','0','1000','Unit'),(5,'Not_Prog','N','N','N','N','-10','2500','Unit'),(6,'Not_Prog','N','N','N','N','0','1000','Unit'),(7,'Not_Prog','N','N','N','N','0','1000','Unit'),(8,'Not_Prog','N','N','N','N','0','1000','Unit'),(9,'Not_Prog','N','N','N','N','0','1000','Unit'),(10,'Not_Prog','N','N','N','N','0','1000','Unit'),(11,'Not_Prog','N','N','N','N','0','1000','Unit'),(12,'Not_Prog','N','N','N','N','0','1000','Unit'),(13,'Not_Prog','N','N','N','N','0','1000','Unit'),(14,'Not_Prog','N','N','N','N','0','1000','Unit'),(15,'Not_Prog','N','N','N','N','0','1000','Unit'),(16,'Not_Prog','N','N','N','N','0','1000','Unit'),(17,'Not_Prog','N','N','N','N','0','1000','Unit'),(18,'Not_Prog','N','N','N','N','0','1000','Unit'),(19,'Not_Prog','N','N','N','N','0','1000','Unit'),(20,'Not_Prog','N','N','N','N','0','1000','Unit'),(21,'R_WtrIn','N','N','N','N','0','200.0','°C'),(22,'R_wtrOut','N','N','N','N','0','200.0','°C'),(23,'R_FuelIn','N','N','N','N','0','200.0','°C'),(24,'T_Ambient','N','N','N','N','0','200.0','°C'),(25,'Not_Prog','N','N','N','N','0','2500','Unit'),(26,'Not-Prog','N','N','N','N','-10','2500','Unit'),(27,'Not_Prog','N','N','N','N','0','10.00','Unit'),(28,'Not_Prog','N','N','N','N','0','100.0','Unit'),(29,'P_Vaccum','N','N','N','N','-100.00','100.0','mbar'),(30,'P_Exback','N','N','N','N','0','1000','mbar'),(31,'P_FuelIn','N','N','N','N','0','10.00','bar'),(32,'P_ClntOut','N','N','N','N','0','2.000','bar'),(33,'P_Luboil','N','A01.80','N','N','0','10.00','bar'),(34,'Not_Prog','N','N','N','N','0','1000','Unit'),(35,'Not_Prog','N','N','N','N','0','1000','Unit'),(36,'Not_Prog','N','N','N','N','0','1000','Unit'),(37,'T_Exhaust','N','N','N','N','0','1000','°C'),(38,'Not_Prog','N','N','N','N','0','1000','°C'),(39,'Not_Prog','N','N','N','N','0','1000','°C'),(40,'Not_Prog','N','N','N','N','0','1000','°C'),(41,'Not_Prog','N','N','N','N','0','1000','°C'),(42,'T_LubOil_2','N','N','N','N','0','1000','°C'),(43,'Not_Prog','N','N','N','N','0','1000','Unit'),(44,'Not_Prog','N','N','N','N','0','1000','Unit'),(45,'T_Exhaust','N','N','N','N','0','1000','°C'),(46,'Not_Prog','N','N','N','N','0','1000','Unit'),(47,'Not_Prog','N','N','N','N','0','1000','Unit'),(48,'Not_Prog','N','N','N','N','0','1000','Unit'),(49,'Not_Prog','N','N','N','N','0','1000','Unit'),(50,'Not_Prog','N','N','N','N','0','1000','Unit'),(51,'Not_Prog','N','N','N','N','0','1000','***'),(52,'Not_Prog','N','N','N','N','0','1000','***'),(53,'Not_Prog','N','N','N','N','0','1000','***'),(54,'Not_Prog','N','N','N','N','0','100.0','***'),(55,'Not_Prog','N','N','N','N','0','100.0','***'),(56,'Not_Prog','N','N','N','N','0','100.0','***'),(57,'Not_Prog','N','N','N','N','0','75.00','***'),(58,'Not_Prog','N','N','N','N','0','10.00','Unit'),(59,'Not_Prog','N','N','N','N','0','100.0','unit'),(60,'Not_Prog','N','N','N','N','0','100.0','unit'),(61,'Not_Prog','N','N','N','N','0','100.0','lpm'),(62,'Not_Prog','N','N','N','N','0','100.0','Unit'),(63,'Not_Prog','N','N','N','N','0','150.0','lpm'),(64,'BlowBy','N','N','N','N','0','150.0','lpm'),(65,'Not_Prog','N','N','N','N','0','100.0','Unit'),(66,'Not_Prog','N','N','N','N','0','100.0','Unit'),(67,'Not_Prog','N','N','N','N','0','100.0','Unit'),(68,'Not_Prog','N','N','N','N','0','100.0','Unit'),(69,'P_ClntIn','N','N','N','N','0','2.000','bar'),(70,'Not_Prog','N','N','N','N','0','1000','Unit'),(71,'Not_Prog','N','N','N','N','0','1000','Unit'),(72,'Not_Prog','N','N','N','N','0','1000','Unit'),(73,'Not_Prog','N','N','N','N','0','1000','Unit'),(74,'Not_Prog','N','N','N','N','0','1000','Unit'),(75,'Not_Prog','N','N','N','N','0','100.0','Unit'),(76,'Not_Prog','N','N','N','N','0','100.0','Unit'),(77,'Not_Prog','N','N','N','N','0','100.0','Unit'),(78,'Not_Prog','N','N','N','N','0','100.0','Unit'),(79,'Not_Prog','N','N','N','N','0','100','unit'),(80,'Not_Prog','N','N','N','N','0','100','Unit'),(81,'Not_Prog','N','N','N','N','0','100','Unit'),(82,'Not_Prog','N','N','N','N','0','100','Unit'),(83,'Not_Prog','N','N','N','N','0','100','Unit'),(84,'Not_Prog','N','N','N','N','0','100','Unit'),(85,'Not_Prog','N','N','N','N','0','100','Unit'),(86,'Not_Prog','N','N','N','N','0','100','Unit'),(87,'Not_Prog','N','N','N','N','0','100','Unit'),(88,'Not_Prog','N','N','N','N','0','100','Unit'),(89,'Not_Prog','N','N','N','N','0','100','Unit'),(90,'Not_Prog','N','N','N','N','0','100','Unit'),(91,'Not_Prog','N','N','N','N','0','100','Unit'),(92,'Not_Prog','N','N','N','N','0','100','Unit'),(93,'Not_Prog','N','N','N','N','0','100','Unit'),(94,'Not_Prog','N','N','N','N','0','100','Unit'),(95,'Not_Prog','N','N','N','N','0','100','Unit'),(96,'Not_Prog','N','N','N','N','0','100','Unit'),(97,'Not_Prog','N','N','N','N','0','100','Unit'),(98,'Not_Prog','N','N','N','N','0','100','Unit');
/*!40000 ALTER TABLE `lim_dynalec` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:22
