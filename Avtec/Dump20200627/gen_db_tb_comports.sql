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
-- Table structure for table `tb_comports`
--

DROP TABLE IF EXISTS `tb_comports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_comports` (
  `Sn` int(11) NOT NULL AUTO_INCREMENT,
  `DeviceNames` varchar(45) NOT NULL,
  `ComPorts` varchar(45) NOT NULL DEFAULT 'COM',
  `BaudRates` varchar(45) NOT NULL DEFAULT '9600',
  `Parity` varchar(45) NOT NULL DEFAULT 'None',
  `StopBit` varchar(45) NOT NULL DEFAULT '1',
  `InstID` varchar(45) NOT NULL DEFAULT '***',
  `StartAdd` varchar(45) NOT NULL DEFAULT '***',
  `NReads` varchar(45) NOT NULL DEFAULT '***',
  `State` varchar(45) NOT NULL DEFAULT 'false',
  `CH5` varchar(45) NOT NULL DEFAULT '***',
  `CH6` varchar(45) NOT NULL DEFAULT '***',
  `CH7` varchar(45) NOT NULL DEFAULT '***',
  `CH8` varchar(45) NOT NULL DEFAULT '***',
  `CH9` varchar(45) NOT NULL DEFAULT '***',
  `CH10` varchar(45) NOT NULL DEFAULT '***',
  PRIMARY KEY (`Sn`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_comports`
--

LOCK TABLES `tb_comports` WRITE;
/*!40000 ALTER TABLE `tb_comports` DISABLE KEYS */;
INSERT INTO `tb_comports` VALUES (1,'SERIAL INSTRUMRNT-1','COM','9600','None','1','N','N','N','False','***','***','***','***','***','***'),(2,'ADAM GROUP-1','COM1','9600','None','1','N','N','N','True','***','***','***','***','***','***'),(3,'ADAM GROUP-2','COM','9600','None','1','N','N','N','False','***','***','***','***','***','***'),(4,'BARCODE SCANNER','COM','9600','None','1','N','N','N','False','***','***','***','***','***','***'),(5,'SMOKE METER','COM7','19200','Odd','1','N','N','N','False','***','***','***','***','***','***'),(6,'BLOWBY METER','COM','9600','None','1','N','N','N','False','***','***','***','***','***','***'),(7,'FLOW METER','COM','9600','None','1','1','246','10','False','***','***','***','***','***','***'),(8,'PID 485 INST','COM','9600','None','1','1','138','1','False','***','***','***','***','***','***'),(9,'PID 232 INST-1','COM','9600','None','1','1','138','1','False','***','***','***','***','***','***'),(10,'PID 232 INST-2','COM','9600','None','1','2','138','1','False','***','***','***','***','***','***'),(11,'PID 232 INST-3','COM','9600','None','1','3','138','1','False','***','***','***','***','***','***'),(12,'PID 232 INST-4','COM','9600','None','1','4','138','1','False','***','***','***','***','***','***'),(13,'PID 232 INST-5','COM','9600','None','1','5','138','1','False','***','***','***','***','***','***'),(14,'SERIAL INSTRUMENTS-2','COM','9600','None','1','N','N','N','False','***','***','***','***','***','***'),(15,'SPARE-1','COM','9600','None','1','N','N','N','False','***','***','***','***','***','***');
/*!40000 ALTER TABLE `tb_comports` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:24:51
