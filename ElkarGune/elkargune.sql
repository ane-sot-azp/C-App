-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: elkargune
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `abisuak`
--

DROP TABLE IF EXISTS `abisuak`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `abisuak` (
  `idAbisuak` int NOT NULL AUTO_INCREMENT,
  `mezua` mediumtext,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idAbisuak`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `abisuak`
--

LOCK TABLES `abisuak` WRITE;
/*!40000 ALTER TABLE `abisuak` DISABLE KEYS */;
INSERT INTO `abisuak` VALUES (1,'kaixo','2025-03-26 07:32:39'),(4,'Programak ondo funtzionatzen du!','2025-04-02 07:59:13');
/*!40000 ALTER TABLE `abisuak` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bazkidea`
--

DROP TABLE IF EXISTS `bazkidea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bazkidea` (
  `idBazkidea` int NOT NULL AUTO_INCREMENT,
  `nan` varchar(10) DEFAULT NULL,
  `izena` varchar(45) DEFAULT NULL,
  `abizenak` varchar(45) DEFAULT NULL,
  `erabiltzailea` varchar(45) DEFAULT NULL,
  `pasahitza` varchar(45) DEFAULT NULL,
  `telefonoZkia` varchar(45) DEFAULT NULL,
  `postaElektronikoa` varchar(45) DEFAULT NULL,
  `kontuKorronteZkia` varchar(45) DEFAULT NULL,
  `admin` tinyint DEFAULT NULL,
  `inskripzioData` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idBazkidea`)
) ENGINE=InnoDB AUTO_INCREMENT=908 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bazkidea`
--

LOCK TABLES `bazkidea` WRITE;
/*!40000 ALTER TABLE `bazkidea` DISABLE KEYS */;
INSERT INTO `bazkidea` VALUES (827,'12345678A','Juan','Pérez','juanperez','juanperez123','612345678','juanperez@example.com','ES12345678901234567890',1,'2025-01-09 23:00:00'),(828,'23456789B','María','López','marialopez','marialopez123','622345679','marialopez@example.com','ES23456789012345678901',0,'2025-01-10 23:00:00'),(829,'34567890C','Carlos','González','carlosgonzalez','carlosgonzalez123','633456780','carlosgonzalez@example.com','ES34567890123456789012',0,'2025-01-11 23:00:00'),(830,'45678901D','Ana','Martínez','anamartinez','anamartinez123','644567891','anamartinez@example.com','ES45678901234567890123',0,'2025-01-12 23:00:00'),(831,'56789012E','Luis','Rodríguez','luisrodriguez','luisrodriguez123','655678902','luisrodriguez@example.com','ES56789012345678901234',0,'2025-01-13 23:00:00'),(832,'67890123F','Laura','Sánchez','laurasanchez','laurasanchez123','666789013','laurasanchez@example.com','ES67890123456789012345',0,'2025-01-14 23:00:00'),(833,'78901234G','David','Ramírez','davidramirez','davidramirez123','677890124','davidramirez@example.com','ES78901234567890123456',0,'2025-01-15 23:00:00'),(834,'89012345H','Marta','Torres','martatorres','martatorres123','688901235','martatorres@example.com','ES89012345678901234567',0,'2025-01-16 23:00:00'),(835,'90123456I','Pedro','Fernández','pedrofernandez','pedrofernandez123','699012346','pedrofernandez@example.com','ES90123456789012345678',0,'2025-01-17 23:00:00'),(836,'01234567J','Sofia','García','sofiagarcia','sofiagarcia123','600123457','sofiagarcia@example.com','ES01234567890123456789',0,'2025-01-18 23:00:00'),(837,'12345678K','Miguel','Álvarez','miguelalvarez','miguelalvarez123','611234568','miguelalvarez@example.com','ES12345678901234567890',0,'2025-01-19 23:00:00'),(838,'23456789L','Carmen','Hernández','carmenhernandez','carmenhernandez123','622345679','carmenhernandez@example.com','ES23456789012345678901',0,'2025-01-20 23:00:00'),(839,'34567890M','Juan','Paredes','juanparedes','juanparedes123','633456780','juanparedes@example.com','ES34567890123456789012',0,'2025-01-21 23:00:00'),(840,'45678901N','Sara','Jiménez','sarajimenez','sara123','644567891','sara@example.com','ES45678901234567890123',0,'2025-01-22 23:00:00'),(841,'56789012O','Raúl','Méndez','raulmendez','raulmendez123','655678902','raulmendez@example.com','ES56789012345678901234',0,'2025-01-23 23:00:00'),(842,'67890123P','Elena','Serrano','elenaserrano','elenaserrano123','666789013','elenaserrano@example.com','ES67890123456789012345',0,'2025-01-24 23:00:00'),(843,'78901234Q','Felipe','Vázquez','felipevazquez','felipevazquez123','677890124','felipevazquez@example.com','ES78901234567890123456',0,'2025-01-25 23:00:00'),(844,'89012345R','Inés','González','inesgonzalez','inesgonzalez123','688901235','inesgonzalez@example.com','ES89012345678901234567',0,'2025-01-26 23:00:00'),(845,'90123456S','Alberto','Romero','albertoromero','albertoromero123','699012346','albertoromero@example.com','ES90123456789012345678',0,'2025-01-27 23:00:00'),(846,'01234567T','Eva','Moreno','evamoreno','evamoreno123','600123457','evamoreno@example.com','ES01234567890123456789',0,'2025-01-28 23:00:00'),(847,'12345678U','José','Jiménez','josejimenez','josejimenez123','611234568','josejimenez@example.com','ES12345678901234567890',0,'2025-01-31 23:00:00'),(848,'23456789V','Marcos','Sánchez','marcossanchez','marcossanchez123','622345679','marcossanchez@example.com','ES23456789012345678901',0,'2025-02-01 23:00:00'),(849,'34567890W','Beatriz','Ramírez','beatrizramirez','beatrizramirez123','633456780','beatrizramirez@example.com','ES34567890123456789012',0,'2025-02-02 23:00:00'),(850,'45678901X','José Luis','García','joseluisgarcia','joseluisgarcia123','644567891','joseluisgarcia@example.com','ES45678901234567890123',0,'2025-02-03 23:00:00'),(851,'56789012Y','Raquel','Torres','raqueltorres','raqueltorres123','655678902','raqueltorres@example.com','ES56789012345678901234',0,'2025-02-04 23:00:00'),(852,'67890123Z','Antonio','Álvarez','antonioalvarez','antonioalvarez123','666789013','antonioalvarez@example.com','ES67890123456789012345',0,'2025-02-05 23:00:00'),(853,'78901234A1','Mónica','Gómez','monicagomez','monicagomez123','677890124','monicagomez@example.com','ES78901234567890123456',0,'2025-02-06 23:00:00'),(854,'89012345B2','Rosa','Molina','rosamolina','rosamolina123','688901235','rosamolina@example.com','ES89012345678901234567',0,'2025-02-07 23:00:00'),(855,'90123456C3','Felipe','Vega','felipevega','felipevega123','699012346','felipevega@example.com','ES90123456789012345678',0,'2025-02-08 23:00:00'),(856,'01234567D4','Carlos','Blanco','carlosblanco','carlosblanco123','600123457','carlosblanco@example.com','ES01234567890123456789',0,'2025-02-09 23:00:00'),(857,'12345678E5','Alba','Díaz','albadiaz','albadiaz123','611234568','albadiaz@example.com','ES12345678901234567890',0,'2025-02-10 23:00:00'),(858,'23456789F6','Iker','Ruiz','ikerruiz','ikerruiz123','622345679','ikerruiz@example.com','ES23456789012345678901',0,'2025-02-11 23:00:00'),(859,'34567890W','Beatriz','Ramírez','beatrizramirez','beatrizramirez123','633456780','beatrizramirez@example.com','ES34567890123456789012',0,'2025-02-02 23:00:00'),(860,'45678901X','José Luis','García','joseluisgarcia','joseluisgarcia123','644567891','joseluisgarcia@example.com','ES45678901234567890123',0,'2025-02-03 23:00:00'),(861,'56789012Y','Raquel','Torres','raqueltorres','raqueltorres123','655678902','raqueltorres@example.com','ES56789012345678901234',0,'2025-02-04 23:00:00'),(862,'67890123Z','Antonio','Álvarez','antonioalvarez','antonioalvarez123','666789013','antonioalvarez@example.com','ES67890123456789012345',0,'2025-02-05 23:00:00'),(863,'78901234A1','Mónica','Gómez','monicagomez','monicagomez123','677890124','monicagomez@example.com','ES78901234567890123456',0,'2025-02-06 23:00:00'),(864,'89012345B2','Rosa','Molina','rosamolina','rosamolina123','688901235','rosamolina@example.com','ES89012345678901234567',0,'2025-02-07 23:00:00'),(865,'90123456C3','Felipe','Vega','felipevega','felipevega123','699012346','felipevega@example.com','ES90123456789012345678',0,'2025-02-08 23:00:00'),(866,'01234567D4','Carlos','Blanco','carlosblanco','carlosblanco123','600123457','carlosblanco@example.com','ES01234567890123456789',0,'2025-02-09 23:00:00'),(867,'12345678E5','Alba','Díaz','albadiaz','albadiaz123','611234568','albadiaz@example.com','ES12345678901234567890',0,'2025-02-10 23:00:00'),(868,'23456789F6','Iker','Ruiz','ikerruiz','ikerruiz123','622345679','ikerruiz@example.com','ES23456789012345678901',0,'2025-02-11 23:00:00'),(869,'34567890G7','Begoña','Castro','begonacastro','begonacastro123','633456780','begonacastro@example.com','ES34567890123456789012',0,'2025-02-12 23:00:00'),(870,'45678901H8','José Antonio','Moreno','joseantoniomoreno','joseantoniomoreno123','644567891','joseantoniomoreno@example.com','ES45678901234567890123',0,'2025-02-13 23:00:00'),(871,'56789012I9','Ángel','Crespo','angelcrespo','angelcrespo123','655678902','angelcrespo@example.com','ES56789012345678901234',0,'2025-02-14 23:00:00'),(872,'67890123J0','Olga','González','olgagonzalez','olgagonzalez123','666789013','olgagonzalez@example.com','ES67890123456789012345',0,'2025-02-15 23:00:00'),(873,'78901234K1','Rafael','López','rafaellopez','rafaellopez123','677890124','rafaellopez@example.com','ES78901234567890123456',0,'2025-02-16 23:00:00'),(874,'89012345L2','David','Gómez','davidgomez','davidgomez123','688901236','davidgomez@example.com','ES89012345678901234567',0,'2025-02-17 23:00:00'),(875,'90123456M3','Sandra','Ramírez','sandraramirez','sandraramirez123','699012347','sandraramirez@example.com','ES90123456789012345678',0,'2025-02-18 23:00:00'),(876,'01234567N4','Oscar','Pérez','oscarperez','oscarperez123','600123458','oscarperez@example.com','ES01234567890123456789',0,'2025-02-19 23:00:00'),(877,'12345678O5','Esther','Torres','esthertorres','esthertorres123','611234569','esthertorres@example.com','ES12345678901234567890',0,'2025-02-20 23:00:00'),(878,'23456789P6','Javier','Gutiérrez','javiergutierrez','javiergutierrez123','622345680','javiergutierrez@example.com','ES23456789012345678901',0,'2025-02-21 23:00:00'),(879,'34567890Q7','Elena','Blanco','elenablanco','elenablanco123','633456781','elenablanco@example.com','ES34567890123456789012',0,'2025-02-22 23:00:00'),(880,'45678901R8','Fernando','Vázquez','fernandovazquez','fernandovazquez123','644567892','fernandovazquez@example.com','ES45678901234567890123',0,'2025-02-23 23:00:00'),(881,'56789012S9','Raquel','Jiménez','raqueljimenez','raqueljimenez123','655678903','raqueljimenez@example.com','ES56789012345678901234',0,'2025-02-24 23:00:00'),(882,'67890123T0','Víctor','Moreno','victormoreno','victormoreno123','666789014','victormoreno@example.com','ES67890123456789012345',0,'2025-02-25 23:00:00'),(883,'78901234U1','Berta','López','bertalopez','bertalopez123','677890125','bertalopez@example.com','ES78901234567890123456',0,'2025-02-26 23:00:00'),(884,'89012345V2','Luis','González','luisgonzalez','luisgonzalez123','688901237','luisgonzalez@example.com','ES89012345678901234567',0,'2025-02-27 23:00:00'),(885,'90123456W3','Raúl','Serrano','raulserrano','raulserrano123','699012348','raulserrano@example.com','ES90123456789012345678',0,'2025-02-28 23:00:00'),(886,'01234567X4','Javier','Ramírez','javierramirez','javierramirez123','600123459','javierramirez@example.com','ES01234567890123456789',0,'2025-03-01 23:00:00'),(887,'12345678Y5','Cristina','Martínez','cristinamartinez','cristinamartinez123','611234570','cristinamartinez@example.com','ES12345678901234567890',0,'2025-03-02 23:00:00'),(888,'23456789Z6','Álvaro','Hernández','alvarohernandez','alvarohernandez123','622345681','alvarohernandez@example.com','ES23456789012345678901',0,'2025-03-03 23:00:00'),(889,'34567890A7','Patricia','Gómez','patriciagomez','patriciagomez123','633456782','patriciagomez@example.com','ES34567890123456789012',0,'2025-03-04 23:00:00'),(890,'45678901B8','Pedro','Sánchez','pedrosanchez','pedrosanchez123','644567893','pedrosanchez@example.com','ES45678901234567890123',0,'2025-03-05 23:00:00'),(891,'56789012C9','Carla','Vega','carlavega','carlavega123','655678904','carlavega@example.com','ES56789012345678901234',0,'2025-03-06 23:00:00'),(892,'67890123D0','Samuel','Castro','samuelcastro','samuelcastro123','666789015','samuelcastro@example.com','ES67890123456789012345',0,'2025-03-07 23:00:00'),(893,'78901234E1','Nerea','Romero','nerearomero','nerearomero123','677890126','nerearomero@example.com','ES78901234567890123456',0,'2025-03-08 23:00:00'),(894,'89012345F2','Carlos','Pérez','carlosperez','carlosperez123','688901238','carlosperez@example.com','ES89012345678901234567',0,'2025-03-09 23:00:00'),(895,'90123456G3','Andrea','Torres','andreatorres','andreatorres123','699012349','andreatorres@example.com','ES90123456789012345678',0,'2025-03-10 23:00:00'),(896,'01234567H4','Juan Carlos','Álvarez','juancarlosalvarez','juancarlosalvarez123','600123460','juancarlosalvarez@example.com','ES01234567890123456789',0,'2025-03-11 23:00:00'),(897,'12345678I5','Sonia','García','soniagarcia','soniagarcia123','611234571','soniagarcia@example.com','ES12345678901234567890',1,'2025-03-12 23:00:00'),(904,'73030336T','Beñat','Martin','bmartin','bmartin123','637553126','b.martin.ulanga@gmail.com','0000000002',0,'2025-03-28 07:38:12'),(906,'72607162A','Ane','Soto','asoto','asoto123','630960766','ane_sot_azp@goierrieskola.org','1213541486861486148',1,'2025-03-30 22:00:00'),(907,'2','Aratz','2','Aratz','2','2','2','2',2,'2025-04-03 08:27:23');
/*!40000 ALTER TABLE `bazkidea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `erreserba`
--

DROP TABLE IF EXISTS `erreserba`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `erreserba` (
  `idErreserba` int NOT NULL AUTO_INCREMENT,
  `idBazkidea` int NOT NULL,
  `mota` tinyint DEFAULT NULL,
  `data` date DEFAULT NULL,
  `komentsalak` int DEFAULT NULL,
  PRIMARY KEY (`idErreserba`),
  KEY `erreserba_bazkidea_idx` (`idBazkidea`),
  CONSTRAINT `erreserba_bazkidea` FOREIGN KEY (`idBazkidea`) REFERENCES `bazkidea` (`idBazkidea`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `erreserba`
--

LOCK TABLES `erreserba` WRITE;
/*!40000 ALTER TABLE `erreserba` DISABLE KEYS */;
INSERT INTO `erreserba` VALUES (2,895,1,'2025-03-28',12),(6,827,1,'2025-04-01',8),(7,906,1,'2025-04-01',8),(8,897,1,'2025-04-05',6),(10,906,1,'2025-04-05',6),(11,904,1,'2025-03-30',6),(13,904,1,'2025-04-04',12),(14,906,0,'2025-04-03',14),(15,907,0,'2025-04-04',NULL),(16,907,1,'2025-04-04',8),(17,906,1,'2025-04-04',8),(19,827,0,'2025-04-07',12),(20,827,1,'2025-04-07',12),(21,904,1,'2025-04-08',40);
/*!40000 ALTER TABLE `erreserba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `erreserbaelementua`
--

DROP TABLE IF EXISTS `erreserbaelementua`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `erreserbaelementua` (
  `idErreserbaElementua` int NOT NULL AUTO_INCREMENT,
  `idErreserba` int DEFAULT NULL,
  `idEspazioa` int DEFAULT NULL,
  PRIMARY KEY (`idErreserbaElementua`),
  KEY `saskia_espazioa_idx` (`idEspazioa`),
  KEY `erreElem_erreserba_idx` (`idErreserba`),
  CONSTRAINT `erreElem_erreserba` FOREIGN KEY (`idErreserba`) REFERENCES `erreserba` (`idErreserba`),
  CONSTRAINT `erreElem_espazioa` FOREIGN KEY (`idEspazioa`) REFERENCES `espazioa` (`idEspazioa`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `erreserbaelementua`
--

LOCK TABLES `erreserbaelementua` WRITE;
/*!40000 ALTER TABLE `erreserbaelementua` DISABLE KEYS */;
INSERT INTO `erreserbaelementua` VALUES (12,6,1),(13,7,11),(14,7,2),(16,8,8),(17,8,13),(18,8,11),(19,8,19),(23,10,7),(26,13,4),(27,13,5),(28,14,13),(29,14,1),(32,15,1),(33,16,1),(34,17,2),(35,17,15),(36,14,4),(37,19,4),(38,19,5),(39,20,4),(40,20,5),(41,21,4),(42,21,5),(43,21,11),(44,21,13),(45,21,2),(46,21,6),(47,21,7),(48,21,3);
/*!40000 ALTER TABLE `erreserbaelementua` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `espazioa`
--

DROP TABLE IF EXISTS `espazioa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `espazioa` (
  `idEspazioa` int NOT NULL,
  `izena` varchar(45) DEFAULT NULL,
  `gaitasuna` int DEFAULT NULL,
  `egoera` tinyint DEFAULT NULL,
  PRIMARY KEY (`idEspazioa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `espazioa`
--

LOCK TABLES `espazioa` WRITE;
/*!40000 ALTER TABLE `espazioa` DISABLE KEYS */;
INSERT INTO `espazioa` VALUES (1,'1 Mahaia',8,0),(2,'2 Mahaia',8,1),(3,'3 Mahaia',8,1),(4,'4 Mahaia',6,1),(5,'5 Mahaia',6,1),(6,'6 Mahaia',6,1),(7,'7 Mahaia',6,1),(8,'8 Mahaia',6,1),(9,'9 Mahaia',6,1),(10,'10 Mahaia',6,1),(11,'1 Parrilla',0,1),(12,'2 Parrilla',0,1),(13,'1 Sukaldea',0,1),(14,'2 Sukaldea',0,1),(15,'3 Sukaldea',0,1),(16,'4 Sukaldea',0,1),(17,'5 Sukaldea',0,0),(18,'6 Sukaldea',0,1),(19,'1 Labea',0,1),(20,'2 Labea',0,1),(21,'3 Labea',0,1);
/*!40000 ALTER TABLE `espazioa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fakturak`
--

DROP TABLE IF EXISTS `fakturak`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fakturak` (
  `idFaktura` int NOT NULL AUTO_INCREMENT,
  `idBazkidea` int DEFAULT NULL,
  `erreserbaZkia` varchar(45) DEFAULT NULL,
  `data` date DEFAULT NULL,
  `totala` float DEFAULT NULL,
  `egoera` tinyint DEFAULT NULL,
  `fakturaPDF` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idFaktura`),
  KEY `fakturak_bazkidea_idx` (`idBazkidea`),
  CONSTRAINT `fakturak_bazkidea` FOREIGN KEY (`idBazkidea`) REFERENCES `bazkidea` (`idBazkidea`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fakturak`
--

LOCK TABLES `fakturak` WRITE;
/*!40000 ALTER TABLE `fakturak` DISABLE KEYS */;
INSERT INTO `fakturak` VALUES (1,827,'1','2025-03-26',NULL,1,NULL),(2,827,'1','2025-03-28',NULL,NULL,NULL),(3,906,'1','2025-03-31',29.5,1,NULL),(4,906,'1','2025-03-31',25.5,1,NULL),(5,906,'1','2025-03-31',5.2,1,NULL),(6,906,'1','2025-03-31',65,1,NULL),(7,906,'1','2025-03-31',3.5,1,NULL),(8,906,'1','2025-03-31',NULL,1,NULL),(9,897,'1','2025-04-01',86,1,NULL),(10,897,'1','2025-04-01',NULL,1,NULL),(11,904,'1','2025-04-03',NULL,1,NULL),(12,906,'1','2025-04-03',13,1,NULL),(13,906,'1','2025-04-03',57.2,1,NULL),(14,906,'1','2025-04-07',16,1,NULL),(15,904,'1','2025-04-07',2.5,1,NULL),(16,904,'1','2025-04-07',7.5,1,NULL),(17,904,'1','2025-04-07',18.9,NULL,NULL),(18,904,'1','2025-04-07',NULL,NULL,NULL);
/*!40000 ALTER TABLE `fakturak` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hornitzailea`
--

DROP TABLE IF EXISTS `hornitzailea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hornitzailea` (
  `idHornitzailea` int NOT NULL AUTO_INCREMENT,
  `izena` varchar(45) DEFAULT NULL,
  `nif` varchar(9) DEFAULT NULL,
  `helbidea` varchar(45) DEFAULT NULL,
  `telefonoZkia` varchar(9) DEFAULT NULL,
  `postaElektronikoa` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idHornitzailea`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hornitzailea`
--

LOCK TABLES `hornitzailea` WRITE;
/*!40000 ALTER TABLE `hornitzailea` DISABLE KEYS */;
INSERT INTO `hornitzailea` VALUES (1,'Bebidas del Norte','A12345678','Calle de la Cerveza 12, Madrid','912345678','bebidasnorte@example.com'),(2,'Distribuciones Refrescos S.A.','B23456789','Avenida de los Jugos 34, Barcelona','933456789','distribucionesrefrescos@example.com'),(3,'Licores Internacionales','C34567890','Calle de la Licorería 56, Valencia','961234567','licoresinternacionales@example.com'),(4,'Bebidas Refrescantes','D45678901','Calle de los Refrescos 78, Bilbao','944567890','bebidasrefrescantes@example.com'),(5,'Vinos y Cavas del Sur','E56789012','Avenida del Vino 101, Sevilla','954678901','vinosycaas@example.com'),(6,'Bebidas Premium','F67890123','Calle de la Premium 23, Zaragoza','976789012','bebidaspremium@example.com'),(7,'Cerveza Artesana','G78901234','Calle de la Cerveza 45, Alicante','965456780','cervezaartesana@example.com'),(8,'Jugo Natural S.L.','H89012345','Calle del Fruto 67, Málaga','952345679','jugonatural@example.com'),(9,'Vinos del Valle','I90123456','Calle del Vino 89, Córdoba','957567891','vinosdelvalle@example.com'),(10,'Bebidas Especiales','J01234567','Avenida de las Bebidas 12, Madrid','912345678','bebidasespeciales@example.com'),(11,'Sodas Internacionales','K12345678','Calle del Refresco 34, Barcelona','933789013','sodasinternacionales@example.com'),(12,'Licor y Cocteles','L23456789','Calle del Licor 56, Bilbao','944012345','licorycocteles@example.com'),(13,'Refrescos del País','M34567890','Avenida Refrescos 23, Sevilla','954123456','refrescosdelpais@example.com'),(14,'Licores Exquisitos','N45678901','Calle del Licor 67, Zaragoza','976234567','licoresexquisitos@example.com'),(15,'Bebidas de Autor','O56789012','Calle de la Creación 101, Madrid','912345679','bebidasdeautor@example.com'),(16,'Vinos y Licores del Este','P67890123','Avenida del Este 45, Málaga','965789012','vinosylicoresdeste@example.com'),(17,'Sistemas de Bebidas','Q78901234','Calle del Sistema 89, Valencia','944567892','sistemasdebebidas@example.com'),(18,'Bebidas Lujosas','R89012345','Calle de la Elegancia 12, Barcelona','933901234','bebidaslujosas@example.com'),(19,'Refrescos del Mundo','S90123456','Avenida Mundial 34, Bilbao','944678903','refrescosdelmundo@example.com'),(20,'Licor del Valle','T01234567','Calle del Valle 78, Sevilla','952345680','licordelvalle@example.com'),(21,'Cerveza del Sur','U12345678','Calle de la Cerveza 101, Zaragoza','976123457','cervezadelsur@example.com'),(22,'Cultura del Vino','V23456789','Avenida del Vino 23, Madrid','912345680','culturadelvino@example.com'),(23,'Vinos del Mar','W34567890','Calle de las Olas 67, Málaga','965456781','vinosdelmar@example.com'),(24,'Cerveza y Licores','X45678901','Calle del Lúpulo 12, Barcelona','933456781','cervezaylicores@example.com'),(25,'Bebidas Naturales','Y56789012','Calle de la Naturaleza 45, Valencia','961789015','bebidasnaturales@example.com'),(26,'Bebidas del Mundo','Z67890123','Avenida Global 34, Bilbao','944567893','bebidasdelmundo@example.com'),(27,'Licor del Cielo','A78901234','Calle del Licor 56, Sevilla','954678904','licordelcielo@example.com'),(28,'Elixir Natural','B89012345','Calle de los Elixires 67, Zaragoza','976789014','elixirinatural@example.com'),(29,'Bebidas del Campo','C90123456','Calle del Campo 12, Madrid','912345681','bebidasdelcampo@example.com'),(30,'Licores del Río','D01234567','Avenida del Río 34, Málaga','952678901','licoresdelrio@example.com'),(31,'Refrescos Premium','E12345678','Calle Premium 56, Valencia','965890123','refrescospremium@example.com'),(32,'El Vino y Su Arte','F23456789','Avenida del Arte 12, Barcelona','933789014','elvinoysuarte@example.com'),(33,'Bebidas Gasificadas','G34567890','Calle de la Gaseosa 45, Bilbao','944012346','bebidasgasificadas@example.com'),(34,'Cerveza de Calidad','H45678901','Calle de la Calidad 67, Sevilla','954123457','cervezadecalidad@example.com'),(35,'Vinos del Sol','I56789012','Calle del Sol 89, Zaragoza','976234568','vinosdelsol@example.com');
/*!40000 ALTER TABLE `hornitzailea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kontsumizioak`
--

DROP TABLE IF EXISTS `kontsumizioak`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kontsumizioak` (
  `idKontsumizioa` int NOT NULL AUTO_INCREMENT,
  `erreserbaZkia` varchar(45) DEFAULT NULL,
  `idFaktura` int DEFAULT NULL,
  `idProduktua` int DEFAULT NULL,
  `kopurua` int DEFAULT NULL,
  `prezioa` float DEFAULT NULL,
  `totala` float DEFAULT ((`kopurua` * `prezioa`)),
  PRIMARY KEY (`idKontsumizioa`),
  KEY `kontsumizioa_faktura_idx` (`idFaktura`),
  KEY `kontsumizioa_bodega_idx` (`idProduktua`),
  CONSTRAINT `kontsumizioa_bodega` FOREIGN KEY (`idProduktua`) REFERENCES `produktua` (`idProduktua`),
  CONSTRAINT `kontsumizioa_faktura` FOREIGN KEY (`idFaktura`) REFERENCES `fakturak` (`idFaktura`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kontsumizioak`
--

LOCK TABLES `kontsumizioak` WRITE;
/*!40000 ALTER TABLE `kontsumizioak` DISABLE KEYS */;
INSERT INTO `kontsumizioak` VALUES (5,NULL,3,1,2,13,26),(6,NULL,3,22,1,3.5,3.5),(7,NULL,4,2,1,12.5,12.5),(8,NULL,4,1,1,13,13),(9,NULL,5,7,1,3.2,3.2),(10,NULL,5,4,1,2,2),(11,NULL,6,1,5,13,65),(13,NULL,7,22,1,3.5,3.5),(14,NULL,9,3,5,16,64),(15,NULL,9,40,1,14,14),(16,NULL,9,19,1,8,8),(17,NULL,12,1,2,13,13),(18,NULL,13,21,4,7.8,31.2),(19,NULL,13,1,2,13,26),(20,NULL,14,19,2,8,16),(21,NULL,15,9,1,2.5,2.5),(22,NULL,16,9,3,2.5,7.5),(23,NULL,17,3,2,9.45,18.9);
/*!40000 ALTER TABLE `kontsumizioak` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mezuak`
--

DROP TABLE IF EXISTS `mezuak`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mezuak` (
  `idMezua` int NOT NULL AUTO_INCREMENT,
  `idBazkidea` int DEFAULT NULL,
  `mezua` mediumtext,
  `data` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idMezua`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mezuak`
--

LOCK TABLES `mezuak` WRITE;
/*!40000 ALTER TABLE `mezuak` DISABLE KEYS */;
INSERT INTO `mezuak` VALUES (4,864,'kaixo','2025-03-26 11:54:38'),(7,898,'Kaixo Ane!','2025-04-02 08:03:50'),(8,906,'Kaixo Ane!','2025-04-02 08:05:27'),(9,904,'Kaixo Beñat!','2025-04-02 09:46:31');
/*!40000 ALTER TABLE `mezuak` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produktua`
--

DROP TABLE IF EXISTS `produktua`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produktua` (
  `idProduktua` int NOT NULL AUTO_INCREMENT,
  `idProduktuMota` int DEFAULT NULL,
  `izena` varchar(45) DEFAULT NULL,
  `erosketaPrezioa` float DEFAULT NULL,
  `salmentaPrezioa` float DEFAULT NULL,
  `stock` int DEFAULT NULL,
  `idHornitzailea` int DEFAULT NULL,
  `irudia` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idProduktua`),
  KEY `bodega_hornitzailea_idx` (`idHornitzailea`),
  KEY `bodega_prodMota_idx` (`idProduktuMota`),
  CONSTRAINT `bodega_hornitzailea` FOREIGN KEY (`idHornitzailea`) REFERENCES `hornitzailea` (`idHornitzailea`),
  CONSTRAINT `bodega_prodMota` FOREIGN KEY (`idProduktuMota`) REFERENCES `produktumota` (`idproduktuMota`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produktua`
--

LOCK TABLES `produktua` WRITE;
/*!40000 ALTER TABLE `produktua` DISABLE KEYS */;
INSERT INTO `produktua` VALUES (1,1,'Chardonnay Castillo de Monjardin',6,9.55,6,1,'PRODUKTUAK\\ARDOAK\\ARDOA CASTILLO DE MONJARDIN.png'),(2,1,'Verdejo Legaris',5.8,7.45,17,2,'PRODUKTUAK\\ARDOAK\\ARDOA LEGARIS.png'),(3,1,'Rioja Crianza Viña Pomal',7.5,9.45,8,3,'PRODUKTUAK\\ARDOAK\\ARDOA VIÑA POMAL.png'),(4,2,'Coca Cola',0.8,1.8,49,4,'PRODUKTUAK\\FRESKAGARRIAK\\COCA COLA.png'),(5,2,'Tonica Schweppes',0.75,1.1,40,4,'PRODUKTUAK\\FRESKAGARRIAK\\SCHWEPPES.png'),(6,2,'Tonica Nordic',0.9,1.1,30,5,'PRODUKTUAK\\FRESKAGARRIAK\\NORDIC.png'),(7,3,'Keler',0.35,1,34,6,'PRODUKTUAK\\GARAGARDOAK\\KELER.png'),(8,3,'San Miguel',1,1,40,6,'PRODUKTUAK\\GARAGARDOAK\\SAN MIGUEL.png'),(9,3,'Voll Damm',1.4,1,34,7,'PRODUKTUAK\\GARAGARDOAK\\VOLL DAMM.png'),(10,3,'Free Damm',1.2,1.5,25,7,'PRODUKTUAK\\GARAGARDOAK\\FREE DAMM.png'),(11,4,'Patxaran La Navarra kopa',1.5,2.5,15,8,'PRODUKTUAK\\LIKOREAK\\PACHARAN LA NAVARRA.png'),(12,4,'Baileys kopa',1.8,2.5,12,9,'PRODUKTUAK\\LIKOREAK\\BAILEYS.png'),(13,4,'Ruavieja kopa',1.2,2.5,18,10,'PRODUKTUAK\\LIKOREAK\\RUAVIEJA.png'),(14,4,'Cognac Hennessy kopa',2,2.5,10,11,'PRODUKTUAK\\LIKOREAK\\COGNAC HENNESSY.png'),(15,4,'Gin Beefeater kopa',1.2,2.5,14,12,'PRODUKTUAK\\LIKOREAK\\GIN BEEFEATER.png'),(16,4,'Gin Tanqueray kopa',1.2,3,12,12,'PRODUKTUAK\\LIKOREAK\\GIN TANQUERAY.png'),(17,4,'Gin Bombay Sapphire kopa',1.2,3,10,13,'PRODUKTUAK\\LIKOREAK\\GIN BOMBAY.png'),(18,4,'Vodka Absolut kopa',1,2.5,15,14,'PRODUKTUAK\\LIKOREAK\\ABSOLUT VODKA.png'),(19,5,'Sagardo Zapiain',1,2.5,16,15,'PRODUKTUAK\\SAGARDOAK\\SAGARDOA ZAPIAIN.png'),(20,5,'Sagardo Petritegi',1,2.5,18,15,'PRODUKTUAK\\SAGARDOAK\\SAGARDOA PETRITEGI.png'),(21,5,'Sagardo Isastegi',1,2.5,11,16,'PRODUKTUAK\\SAGARDOAK\\SAGARDOA ISASTEGI.png'),(22,6,'Kafe hutsa',0,1.1,28,17,'PRODUKTUAK\\KAFEAK\\HUTSA.png'),(23,6,'Kafe hutsa deskafeinatua',0,1.1,30,17,'PRODUKTUAK\\KAFEAK\\HUTSA D.png'),(24,6,'Kafe ebakia',0,1.5,25,17,'PRODUKTUAK\\KAFEAK\\EBAKIA.png'),(25,6,'Kafe ebakia deskafeinatua',0,1.5,25,17,'PRODUKTUAK\\KAFEAK\\EBAKIA D.png'),(26,6,'Kafesnea',0,2,20,17,'PRODUKTUAK\\KAFEAK\\KAFESNEA.png'),(27,6,'Kafesne deskafeinatua',0,2,20,17,'PRODUKTUAK\\KAFEAK\\KAFESNEA D.png'),(28,1,'Rioja Crianza Cune',7,15.5,12,3,'PRODUKTUAK\\ARDOAK\\ARDOA CUNE.png'),(29,1,'Iñurrieta Orchidea',7.5,16,10,3,'PRODUKTUAK\\ARDOAK\\ARDOA ORCHIDEA.png'),(30,2,'Kas Limoia',0.85,2,35,4,'PRODUKTUAK\\FRESKAGARRIAK\\KAS LIMON.png'),(31,2,'Kas Laranja',0.85,2,33,5,'PRODUKTUAK\\FRESKAGARRIAK\\KAS NARANJA.png'),(32,1,'Cava Codorníu Brut',8,6.5,20,6,'PRODUKTUAK\\ARDOAK\\CAVA CODORNIU BRUT.png'),(33,1,'Cava Anna de Codorníu Blanc de Blancs',7.5,11,18,7,'PRODUKTUAK\\ARDOAK\\CAVA ANNA BLANC DE BLANCS.png'),(34,4,'Whisky Macallan kopa',2.1,4,10,8,'PRODUKTUAK\\LIKOREAK\\WHISKEY MACALLAN.png'),(35,4,'Ron Barceló kopa',1.5,3,12,9,'PRODUKTUAK\\LIKOREAK\\RON BARCELÓ.png'),(36,5,'Sagardo Bereziartua',1,2.5,10,15,'PRODUKTUAK\\SAGARDOAK\\SAGARDOA BEREZIARTUA.png'),(37,5,'Sagardo Gartziategi',1,2.5,15,16,'PRODUKTUAK\\SAGARDOAK\\SAGARDOA GARTZIATEGI.png'),(38,2,'Red Bull',1.5,2,25,5,'PRODUKTUAK\\FRESKAGARRIAK\\RED BULL.png'),(39,1,'Cava Anna de Codorníu',9,9.9,20,7,'PRODUKTUAK\\ARDOAK\\CAVA ANNA DE CODORNIU.png'),(40,1,'Txakoli Txomin Etxaniz',6.5,10,17,2,'PRODUKTUAK\\ARDOAK\\TXAKOLI TXOMIN ETXANIZ.png');
/*!40000 ALTER TABLE `produktua` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produktumota`
--

DROP TABLE IF EXISTS `produktumota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produktumota` (
  `idproduktuMota` int NOT NULL,
  `kategoria` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idproduktuMota`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produktumota`
--

LOCK TABLES `produktumota` WRITE;
/*!40000 ALTER TABLE `produktumota` DISABLE KEYS */;
INSERT INTO `produktumota` VALUES (1,'Ardoak'),(2,'Freskagarriak'),(3,'Garagardoak'),(4,'Likoreak'),(5,'Sagardoa'),(6,'Kafeak');
/*!40000 ALTER TABLE `produktumota` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-09  9:02:01
