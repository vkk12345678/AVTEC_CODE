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
-- Table structure for table `tb_calpar`
--

DROP TABLE IF EXISTS `tb_calpar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_calpar` (
  `Pn` varchar(50) DEFAULT '0',
  `Cn` varchar(50) DEFAULT NULL,
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  `N` int(11) NOT NULL,
  PRIMARY KEY (`N`),
  UNIQUE KEY `N_UNIQUE` (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_calpar`
--

LOCK TABLES `tb_calpar` WRITE;
/*!40000 ALTER TABLE `tb_calpar` DISABLE KEYS */;
INSERT INTO `tb_calpar` VALUES ('1.1','101','Smoke','FSN',0),('1.2','102','Blowby','lpm',1),('1.3','103','SFC_Wt','g',2),('1.4','104','F_Time','sec',3),('1.5','105','C_Factor','***',4),('1.6','108','SFC','g/kw.hr',5),('1.7','107','Power','kW',6),('2.1','108','SFC','g/kw.hr',7),('2.2','109','Inj_Qty','mm³/str/Cyln',8),('2.3','110','C_torque','Nm',9),('2.4','111','C_Power','kW',10),('2.5','112','C_SFC','ho/kw.hr',11),('2.6','113','F_Flow','kg/hr',12),('2.7','114','F_Flow','l/hr',13),('3.1','115','Power','hp',14),('3.2','116','C_Power','hp',15),('3.3','117','SFC','g/hp.hr',16),('3.4','118','C_SFC','g/hp.hr',17),('3.5','119','bmep','bar',18),('3.6','120','Rel_hum','%',19),('3.7','121','C_bmep','bar',20),('4.1','122','Log_Tm','***',21),('4.2','123','Start_Tm','***',22),('4.3','124','Tol_Hrs','***',23),('4.4','100','Not_Prog','Unit',24),('4.5','100','Not_Prog','Unit',25),('4.6','100','Not_Prog','Unit',26),('4.7','100','Not_Prog','Unit',27);
/*!40000 ALTER TABLE `tb_calpar` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-27 18:24:50
