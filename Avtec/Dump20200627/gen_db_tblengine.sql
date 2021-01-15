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
-- Table structure for table `tblengine`
--

DROP TABLE IF EXISTS `tblengine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblengine` (
  `EngineFile` varchar(50) NOT NULL,
  `Engine Type` varchar(50) DEFAULT NULL,
  `BoreDia (mm)` varchar(50) NOT NULL,
  `Cylinder` varchar(50) DEFAULT NULL,
  `Stroke (mm)` varchar(50) NOT NULL,
  `Swept Vol(Ltrs)` varchar(50) NOT NULL,
  `spgrv` varchar(50) NOT NULL,
  `CylnHead` varchar(50) DEFAULT NULL,
  `Comp Ratio` varchar(50) DEFAULT NULL,
  `LuboilType` varchar(50) DEFAULT NULL,
  `CylnBlock` varchar(50) DEFAULT NULL,
  `Press Comp` varchar(50) DEFAULT NULL,
  `Cooling Type` varchar(50) DEFAULT NULL,
  `AirFilter` varchar(50) DEFAULT NULL,
  `FIPType` varchar(50) DEFAULT NULL,
  `FIPMake` varchar(50) DEFAULT NULL,
  `FIPNo` varchar(50) DEFAULT NULL,
  `FIP Timeing` varchar(50) DEFAULT NULL,
  `Pre Stroke` varchar(50) DEFAULT NULL,
  `Injector` varchar(50) DEFAULT NULL,
  `NozType` varchar(50) DEFAULT NULL,
  `NozNo` varchar(50) DEFAULT NULL,
  `DVRV` varchar(50) DEFAULT NULL,
  `SacSize` varchar(50) DEFAULT NULL,
  `Nozmake` varchar(50) DEFAULT NULL,
  `EleDia` varchar(50) DEFAULT NULL,
  `OpPress` varchar(50) DEFAULT NULL,
  `Comb` varchar(50) DEFAULT NULL,
  `Plunger` varchar(50) DEFAULT NULL,
  `INO` varchar(50) DEFAULT NULL,
  `TurChDetails` varchar(50) DEFAULT NULL,
  `Cylinder2` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`EngineFile`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblengine`
--

LOCK TABLES `tblengine` WRITE;
/*!40000 ALTER TABLE `tblengine` DISABLE KEYS */;
INSERT INTO `tblengine` VALUES ('eng_dw10fc','Diesel','085.000','04','088.000','1.99768','0.835','687678','**','***','***','55','Air Cooled','***','***','***','***','***','***','***','***','***','***','***','***','***','***','***','***','***','TurboEnergy',''),('eng_dynalec','Diesel','085.000','04','088.000','1.99768','0.835','687678','**','***','***','55','Air Cooled','***','***','***','***','***','***','***','***','***','***','***','***','***','***','***','***','***','TurboEnergy','');
/*!40000 ALTER TABLE `tblengine` ENABLE KEYS */;
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
