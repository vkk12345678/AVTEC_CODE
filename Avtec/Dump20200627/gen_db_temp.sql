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
-- Table structure for table `temp`
--

DROP TABLE IF EXISTS `temp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `temp` (
  `S_Inst1` varchar(50) DEFAULT NULL,
  `S_Inst2` varchar(50) DEFAULT NULL,
  `S_Inst3` varchar(50) DEFAULT NULL,
  `S_Inst4` varchar(50) DEFAULT NULL,
  `S_Inst5` varchar(50) DEFAULT NULL,
  `S_Inst6` varchar(50) DEFAULT NULL,
  `S_Inst7` varchar(50) DEFAULT NULL,
  `S_Inst8` varchar(50) DEFAULT NULL,
  `S_Inst9` varchar(50) DEFAULT NULL,
  `S_Inst10` varchar(50) DEFAULT NULL,
  `S_Inst11` varchar(50) DEFAULT NULL,
  `S_Inst12` varchar(50) DEFAULT NULL,
  `S_Inst13` varchar(50) DEFAULT NULL,
  `S_Inst14` varchar(50) DEFAULT NULL,
  `S_Inst15` varchar(50) DEFAULT NULL,
  `S_Inst16` varchar(50) DEFAULT NULL,
  `S_Inst17` varchar(50) DEFAULT NULL,
  `S_Inst18` varchar(50) DEFAULT NULL,
  `S_Inst19` varchar(50) DEFAULT NULL,
  `S_Inst20` varchar(50) DEFAULT NULL,
  `S_Inst21` varchar(50) DEFAULT NULL,
  `S_InsT22` varchar(50) DEFAULT NULL,
  `S_Inst23` varchar(50) DEFAULT NULL,
  `S_Inst24` varchar(50) DEFAULT NULL,
  `S_Inst25` varchar(50) DEFAULT NULL,
  `ADAM11` varchar(50) DEFAULT NULL,
  `ADAM12` varchar(50) DEFAULT NULL,
  `ADAM13` varchar(50) DEFAULT NULL,
  `ADAM14` varchar(50) DEFAULT NULL,
  `ADAM15` varchar(50) DEFAULT NULL,
  `ADAM16` varchar(50) DEFAULT NULL,
  `ADAM17` varchar(50) DEFAULT NULL,
  `ADAM18` varchar(50) DEFAULT NULL,
  `ADAM21` varchar(50) DEFAULT NULL,
  `ADAM22` varchar(50) DEFAULT NULL,
  `ADAM23` varchar(50) DEFAULT NULL,
  `ADAM24` varchar(50) DEFAULT NULL,
  `ADAM25` varchar(50) DEFAULT NULL,
  `ADAM26` varchar(50) DEFAULT NULL,
  `ADAM27` varchar(50) DEFAULT NULL,
  `ADAM28` varchar(50) DEFAULT NULL,
  `ADAM31` varchar(50) DEFAULT NULL,
  `ADAM32` varchar(50) DEFAULT NULL,
  `ADAM33` varchar(50) DEFAULT NULL,
  `ADAM34` varchar(50) DEFAULT NULL,
  `ADAM35` varchar(50) DEFAULT NULL,
  `ADAM36` varchar(50) DEFAULT NULL,
  `ADAM37` varchar(50) DEFAULT NULL,
  `ADAM38` varchar(50) DEFAULT NULL,
  `ADAM41` varchar(50) DEFAULT NULL,
  `ADAM42` varchar(50) DEFAULT NULL,
  `ADAM43` varchar(50) DEFAULT NULL,
  `ADAM44` varchar(50) DEFAULT NULL,
  `ADAM45` varchar(50) DEFAULT NULL,
  `ADAM46` varchar(50) DEFAULT NULL,
  `ADAM47` varchar(50) DEFAULT NULL,
  `ADAM48` varchar(50) DEFAULT NULL,
  `ADAM51` varchar(50) DEFAULT NULL,
  `ADAM52` varchar(50) DEFAULT NULL,
  `ADAM53` varchar(50) DEFAULT NULL,
  `ADAM54` varchar(50) DEFAULT NULL,
  `ADAM55` varchar(50) DEFAULT NULL,
  `ADAM56` varchar(50) DEFAULT NULL,
  `ADAM57` varchar(50) DEFAULT NULL,
  `ADAM58` varchar(50) DEFAULT NULL,
  `Ana_1` varchar(50) DEFAULT NULL,
  `Ana_2` varchar(50) DEFAULT NULL,
  `Ana_3` varchar(50) DEFAULT NULL,
  `Ana_4` varchar(50) DEFAULT NULL,
  `Ana_5` varchar(50) DEFAULT NULL,
  `Ana_6` varchar(50) DEFAULT NULL,
  `Ana_7` varchar(50) DEFAULT NULL,
  `Ana_8` varchar(50) DEFAULT NULL,
  `Ana_9` varchar(50) DEFAULT NULL,
  `Ana_10` varchar(50) DEFAULT NULL,
  `Ana_11` varchar(50) DEFAULT NULL,
  `Ana_12` varchar(50) DEFAULT NULL,
  `Ana_13` varchar(50) DEFAULT NULL,
  `Ana_14` varchar(50) DEFAULT NULL,
  `Ana_15` varchar(50) DEFAULT NULL,
  `Ana_16` varchar(50) DEFAULT NULL,
  `Ana_17` varchar(50) DEFAULT NULL,
  `Ana_18` varchar(50) DEFAULT NULL,
  `Ana_19` varchar(50) DEFAULT NULL,
  `Ana_20` varchar(50) DEFAULT NULL,
  `Ana_21` varchar(50) DEFAULT NULL,
  `Ana_22` varchar(50) DEFAULT NULL,
  `Ana_23` varchar(50) DEFAULT NULL,
  `Ana_24` varchar(50) DEFAULT NULL,
  `Ana_25` varchar(50) DEFAULT NULL,
  `Ana_26` varchar(50) DEFAULT NULL,
  `Ana_27` varchar(50) DEFAULT NULL,
  `Ana_28` varchar(50) DEFAULT NULL,
  `Ana_29` varchar(50) DEFAULT NULL,
  `Ana_30` varchar(50) DEFAULT NULL,
  `Ana_31` varchar(50) DEFAULT NULL,
  `Ana_32` varchar(50) DEFAULT NULL,
  `Ana_33` varchar(50) DEFAULT NULL,
  `Ana_34` varchar(50) DEFAULT NULL,
  `Ana_35` varchar(50) DEFAULT NULL,
  `NotProg` varchar(50) DEFAULT NULL,
  `PCal1` varchar(50) DEFAULT NULL,
  `PCal2` varchar(50) DEFAULT NULL,
  `PCal3` varchar(50) DEFAULT NULL,
  `PCal4` varchar(50) DEFAULT NULL,
  `PCal5` varchar(50) DEFAULT NULL,
  `PCal6` varchar(50) DEFAULT NULL,
  `PCal7` varchar(50) DEFAULT NULL,
  `PCal8` varchar(50) DEFAULT NULL,
  `PCal9` varchar(50) DEFAULT NULL,
  `PCal10` varchar(50) DEFAULT NULL,
  `PCal11` varchar(50) DEFAULT NULL,
  `PCal12` varchar(50) DEFAULT NULL,
  `PCal13` varchar(50) DEFAULT NULL,
  `PCal14` varchar(50) DEFAULT NULL,
  `PCal15` varchar(50) DEFAULT NULL,
  `PCal16` varchar(50) DEFAULT NULL,
  `PCal17` varchar(50) DEFAULT NULL,
  `PCal18` varchar(50) DEFAULT NULL,
  `PCal19` varchar(50) DEFAULT NULL,
  `PCal20` varchar(50) DEFAULT NULL,
  `PCal21` varchar(50) DEFAULT NULL,
  `PCal22` varchar(50) DEFAULT NULL,
  `PCal23` varchar(50) DEFAULT NULL,
  `PCal24` varchar(50) DEFAULT NULL,
  `PCal25` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temp`
--

LOCK TABLES `temp` WRITE;
/*!40000 ALTER TABLE `temp` DISABLE KEYS */;
/*!40000 ALTER TABLE `temp` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:25:14
