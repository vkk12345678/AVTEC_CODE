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
-- Table structure for table `tb_std`
--

DROP TABLE IF EXISTS `tb_std`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_std` (
  `ParameterNo` int(11) NOT NULL DEFAULT '0',
  `ParameterName` varchar(50) DEFAULT NULL,
  `MinVal` varchar(10) DEFAULT NULL,
  `MaxVal` varchar(10) DEFAULT NULL,
  `Unit` varchar(20) DEFAULT NULL,
  `ShortName` varchar(50) DEFAULT NULL,
  `Marked` tinyint(1) DEFAULT NULL,
  `DUnit` varchar(50) DEFAULT NULL,
  `Minip` varchar(45) DEFAULT NULL,
  `Maxip` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ParameterNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_std`
--

LOCK TABLES `tb_std` WRITE;
/*!40000 ALTER TABLE `tb_std` DISABLE KEYS */;
INSERT INTO `tb_std` VALUES (0,'Engine Revolutions','000','10000','r/min','E_Speed',1,'r/min','0','10000'),(1,'Serial Instrument','-5','195','Nm','Torque',1,'kgm','00.00','20.39'),(2,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(3,'Serial Instrument','799','1199','Unit','Not_Prog',0,'Unit','0','1000'),(4,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(5,'Serial Instrument','-10','2500','Unit','Not_Prog',0,'Unit','0','1000'),(6,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(7,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(8,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(9,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(10,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(11,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(12,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(13,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(14,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(15,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(16,'Serial Instrument','0','10000','Unit','Not_Prog',0,'Unit','0','1000'),(17,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(18,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(19,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(20,'Serial Instrument','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(21,'ADAM Module -1.1','0','200.0','°C','R_WtrIn',1,'bar','0','200.0'),(22,'ADAM Module -1.2','0','200.0','°C','R_wtrOut',1,'kPa','0','200.0'),(23,'ADAM Module -1.3','0','200.0','°C','R_FuelIn',1,'mmHg','0','200.0'),(24,'ADAM Module -1.4','0','200.0','°C','T_Ambient',1,'mbar','0','200.0'),(25,'ADAM Module -1.5','0','2500','Unit','Not_Prog',0,'mbar','0','2500'),(26,'ADAM Module -1.6','-10','2500','Unit','Not-Prog',0,'mbar','0','2500'),(27,'ADAM Module -1.7','0','10.00','Unit','Not_Prog',0,'Unit','0','10.00'),(28,'ADAM Module -1.8','0','100.0','Unit','Not_Prog',0,'%','0','100.0'),(29,'ADAM Module -2.1','-100.00','100.0','mbar','P_Vaccum',1,'°C','-100.00','100.0'),(30,'ADAM Module -2.2','0','1000','mbar','P_Exback',1,'°C','0','1000'),(31,'ADAM Module -2.3','0','10.00','bar','P_FuelIn',1,'°C','0','10.00'),(32,'ADAM Module -2.4','0','2.000','bar','P_ClntOut',1,'°C','0','2.000'),(33,'ADAM Module -2.5','0','10.00','bar','P_Luboil',1,'Unit','0','10.00'),(34,'ADAM Module -2.6','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(35,'ADAM Module -2.7','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(36,'ADAM Module -2.8','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(37,'ADAM Module -3.1','0','1000','°C','T_Exhaust',1,'°C','0','1000'),(38,'ADAM Module -3.2','0','1000','°C','Not_Prog',0,'°C','0','1000'),(39,'ADAM Module -3.3','0','1000','°C','Not_Prog',0,'°C','0','1000'),(40,'ADAM Module -3.4','0','1000','°C','Not_Prog',0,'°C','0','1000'),(41,'ADAM Module -3.5','0','1000','°C','Not_Prog',0,'°C','0','1000'),(42,'ADAM Module -3.6','0','1000','°C','T_LubOil_2',1,'°C','0','1000'),(43,'ADAM Module -3.7','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(44,'ADAM Module -3.8','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(45,'ADAM Module -4.1','0','1000','°C','T_Exhaust',1,'Unit','0','1000'),(46,'ADAM Module -4.2','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(47,'ADAM Module -4.3','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(48,'ADAM Module -4.4','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(49,'ADAM Module -4.5','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(50,'ADAM Module -4.6','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(51,'ADAM Module -4.7','0','1000','***','Not_Prog',0,'Unit','0','1000'),(52,'ADAM Module -4.8','0','1000','***','Not_Prog',0,'Unit','0','1000'),(53,'ADAM Module -5.1','0','1000','***','Not_Prog',0,'Unit','0','1000'),(54,'ADAM Module -5.2','0','100.0','***','Not_Prog',0,'Unit','0','100.0'),(55,'ADAM Module -5.3','0','100.0','***','Not_Prog',0,'Unit','0','100.0'),(56,'ADAM Module -5.4','0','100.0','***','Not_Prog',0,'Unit','0','100.0'),(57,'ADAM Module -5.5','0','75.00','***','Not_Prog',0,'Unit','0','75.00'),(58,'ADAM Module -5.6','0','10.00','Unit','Not_Prog',0,'Unit','0','10.00'),(59,'ADAM Module -5.7','0','100.0','unit','Not_Prog',0,'Unit','0','100.0'),(60,'ADAM Module -5.8','0','100.0','unit','Not_Prog',0,'Unit','0','100.0'),(61,'Analog Input-0','0','100.0','lpm','Not_Prog',1,'lpm','0','100.0'),(62,'Analog Input-1','0','100.0','Unit','Not_Prog',0,'Unit','0','100.0'),(63,'Analog Input-2','0','150.0','lpm','Not_Prog',0,'Unit','0','150.0'),(64,'Analog Input-3','0','150.0','lpm','BlowBy',0,'Unit','0','150.0'),(65,'Analog Input-4','0','100.0','Unit','Not_Prog',0,'Unit','0','100.0'),(66,'Analog Input-5','0','100.0','Unit','Not_Prog',0,'Unit','0','100.0'),(67,'Analog Input-6','0','100.0','Unit','Not_Prog',0,'Unit','0','100.0'),(68,'Analog Input-7','0','100.0','Unit','Not_Prog',0,'Unit','0','100.0'),(69,'Mod Bus-0','0','2.000','bar','P_ClntIn',1,'Unit','0','2.000'),(70,'Mod Bus-1','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(71,'Mod Bus-2','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(72,'Mod Bus-3','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(73,'Mod Bus-4','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(74,'Mod Bus-5','0','1000','Unit','Not_Prog',0,'Unit','0','1000'),(75,'Mod Bus-6','0','100.0','Unit','Not_Prog',0,'Unit','0','10'),(76,'Mod Bus-7','0','100.0','Unit','Not_Prog',0,'Unit','0','10'),(77,'Not_Prog','0','100.0','Unit','Not_Prog',0,'Unit','0','10'),(78,'Not_Prog','0','100.0','Unit','Not_Prog',0,'Unit','0','10'),(79,'Not_Prog','0','100','unit','Not_Prog',0,'Unit','0','10'),(80,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(81,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(82,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(83,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(84,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(85,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(86,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(87,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(88,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(89,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(90,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(91,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(92,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(93,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(94,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(95,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(96,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(97,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(98,'Not_Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(99,'Not Prog','0','100','Unit','Not_Prog',0,'Unit','0','10'),(100,'Not Prog','0','100','Unit','Not_Prog',0,'Unit','00','10'),(101,'Calculated Parameter','0','100','FSN','Smoke',1,'fsn','0','10'),(102,'Calculated Parameter','0','100','lpm','Blowby',1,'lpm','0','10'),(103,'Calculated Parameter','0','100','g','SFC_Wt',1,'g','0','10'),(104,'Calculated Parameter','0','100','sec','F_Time',1,'s','0','10'),(105,'Calculated Parameter','0','100','***','C_Factor',1,'***','0','10'),(106,'Calculated Parameter','0','100','Nm','Avg_Trq',1,'kgm','0','10'),(107,'Calculated Parameter','0','100','kW','Power',1,'kW','0','10'),(108,'Calculated Parameter','0','100','g/kw.hr','SFC',1,'g/kw.hr','0','10'),(109,'Calculated Parameter','0','100','mm³/str/Cyln','Inj_Qty',1,'mm³/str/Cyln','0','10'),(110,'Calculated Parameter','0','100','Nm','C_torque',1,'Nm','0','10'),(111,'Calculated Parameter','0','100','kW','C_Power',1,'kW','0','10'),(112,'Calculated Parameter','0','100','g/kw.hr','C_SFC',1,'g/kw.hr0','0','10'),(113,'Calculated Parameter','0','100','kg/hr','F_Flow',1,'0kg/hr','0','10'),(114,'Calculated Parameter','0','100','l/hr','F_Flow',1,'l/h','0','10'),(115,'Calculated Parameter','0','100','hp','Power',1,'hp','0','10'),(116,'Calculated Parameter','0','100','hp','C_Power',1,'hp','0','10'),(117,'Calculated Parameter','0','100','g/hp.hr','SFC',1,'g/hp.hr','0','10'),(118,'Calculated Parameter','0','100','g/hp.hr','C_SFC',1,'g/hp.hr','0','10'),(119,'Calculated Parameter','0','100','bar','bmep',1,'bmep','0','10'),(120,'Calculated Parameter','0','100','%','Rel_hum',1,'%','0','10'),(121,'Calculated Parameter','0','100','***','Trst_Type',1,'***','0','10'),(122,'Calculated Parameter','0','100','***','Log_Tm',1,'***','0','10'),(123,'Calculated Parameter','0','100','***','Start_Tm',1,'***','0','10'),(124,'Calculated Parameter','0','100','***','Tol_Hrs',1,'***','0','10'),(125,'Calculated Parameter','0','100','***','Alarm',1,'***','0','10');
/*!40000 ALTER TABLE `tb_std` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:24:48
