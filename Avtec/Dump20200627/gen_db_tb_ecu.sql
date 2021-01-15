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
-- Table structure for table `tb_ecu`
--

DROP TABLE IF EXISTS `tb_ecu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_ecu` (
  `ParameterNo` int(11) NOT NULL DEFAULT '0',
  `ParameterName` varchar(50) DEFAULT NULL,
  `Addresshex` varchar(20) DEFAULT NULL,
  `MultFactor` varchar(20) DEFAULT NULL,
  `Unit` varchar(20) DEFAULT NULL,
  `ShortName` varchar(50) DEFAULT NULL,
  `Marked` tinyint(1) DEFAULT NULL,
  `Minip` varchar(50) DEFAULT NULL,
  `Maxip` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ParameterNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_ecu`
--

LOCK TABLES `tb_ecu` WRITE;
/*!40000 ALTER TABLE `tb_ecu` DISABLE KEYS */;
INSERT INTO `tb_ecu` VALUES (0,'ECU Parameter','0x00','1','r/min','Eng_Speed',1,'50','10000'),(1,'ECU Parameter','0x0A','1','°C','T_ClntIn',1,'0','10000'),(2,'ECU Parameter','0x0D','1','°C','T_Clnt_SetPt',0,'0','10000'),(3,'ECU Parameter','0x11','1','°C','T_InManf',1,'0','10000'),(4,'ECU Parameter','0x14','1','°C','T_Raw_Out',1,'0','10000'),(5,'ECU Parameter','0x15','1','°C','T_ClntRaw',1,'0','10000'),(6,'ECU Parameter','0x2A','0.0625','°C','T_Fuel',1,'0','10000'),(7,'ECU Parameter','0x7D','0.0625','°C','T_Eng_Oil',1,'0','10000'),(8,'ECU Parameter','0x29','0.0078125','bar','P_Eng_Oil',1,'0','10000'),(9,'ECU Parameter','0x45','1','bar','P_Rail_SetPt',0,'0','10000'),(10,'ECU Parameter','0x46','1','bar','P_Rail',1,'0','10000'),(11,'ECU Parameter','0x64','0.001','bar','P_Oil_SetPt',0,'0','10000'),(12,'ECU Parameter','0x65','1','mbar','P_Atms',1,'0','10000'),(13,'ECU Parameter','0xD9','1','mbar','P_AirIn',1,'0','10000'),(14,'ECU Parameter','0x60','0.0078125','%','Thr_PosSetPt',0,'0','10000'),(15,'ECU Parameter','0x61','0.0078125','%','Thr_Pos',1,'0','10000'),(16,'ECU Parameter','0x88','0.1','mg','AirMassFlow',0,'0','10000'),(17,'ECU Parameter','0xEF','0.1125','kg/hr','AirMassFlow',1,'0','10000'),(18,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','10000'),(19,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','10000'),(20,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(21,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','250.0'),(22,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','10'),(23,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(24,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1200'),(25,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','2500'),(26,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','2500'),(27,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','10.00'),(28,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','100.0'),(29,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','200.0'),(30,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','200.0'),(31,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','200.0'),(32,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','200.0'),(33,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(34,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(35,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(36,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(37,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(38,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(39,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(40,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(41,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(42,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(43,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(44,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(45,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(46,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(47,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(48,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(49,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(50,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(51,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(52,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(53,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','1000'),(54,'ECU Parameter','0x00','1','unit','ECUPara',0,'0','100.0'),(55,'ECU Parameter','0x00','1','Unit','ECUPara',0,'0','100.0');
/*!40000 ALTER TABLE `tb_ecu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:24:49
