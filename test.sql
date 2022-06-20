-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: bazazakupy
-- ------------------------------------------------------
-- Server version	8.0.29

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
-- Table structure for table `czy_jest_produkt`
--

DROP TABLE IF EXISTS `czy_jest_produkt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `czy_jest_produkt` (
  `id_produktu` int NOT NULL,
  `id_sklepu` int NOT NULL,
  `ilosc` int DEFAULT NULL,
  KEY `id_produktu` (`id_produktu`),
  KEY `id_sklepu` (`id_sklepu`),
  CONSTRAINT `czy_jest_produkt_ibfk_1` FOREIGN KEY (`id_produktu`) REFERENCES `produkty` (`id`),
  CONSTRAINT `czy_jest_produkt_ibfk_2` FOREIGN KEY (`id_sklepu`) REFERENCES `sklep` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `czy_jest_produkt`
--

LOCK TABLES `czy_jest_produkt` WRITE;
/*!40000 ALTER TABLE `czy_jest_produkt` DISABLE KEYS */;
INSERT INTO `czy_jest_produkt` VALUES (1,1,0),(1,2,18),(2,1,0),(2,2,0),(7,1,7),(7,2,5),(8,1,6),(8,2,5),(9,1,2),(9,2,12),(1,3,12),(2,3,0),(7,3,5),(8,3,11),(9,3,12);
/*!40000 ALTER TABLE `czy_jest_produkt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klient`
--

DROP TABLE IF EXISTS `klient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `klient` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` char(15) NOT NULL,
  `haslo` char(20) NOT NULL,
  `telefon` char(15) NOT NULL,
  `mail` char(40) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klient`
--

LOCK TABLES `klient` WRITE;
/*!40000 ALTER TABLE `klient` DISABLE KEYS */;
INSERT INTO `klient` VALUES (1,'admin','admin','111111111','admin@admin.pl'),(2,'kamil','kamil','666666666','kamil@wp.pl'),(5,'jan','jan','777777777','jan@jan.pl'),(6,'michal','michal','333222111','michal@michal.pl');
/*!40000 ALTER TABLE `klient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produkty`
--

DROP TABLE IF EXISTS `produkty`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produkty` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cena` double NOT NULL,
  `kraj` char(40) NOT NULL,
  `nazwa` char(40) NOT NULL,
  `rodzaj` char(40) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produkty`
--

LOCK TABLES `produkty` WRITE;
/*!40000 ALTER TABLE `produkty` DISABLE KEYS */;
INSERT INTO `produkty` VALUES (1,21.37,'Polska','kremówka','deser'),(2,12.5,'Hiszpania','pomidor','warzywo'),(7,12,'Polska','rzodkiewka','warzywo'),(8,2,'Polska','bułka','pieczywo'),(9,4.5,'Brazylia','kawa','uzywka');
/*!40000 ALTER TABLE `produkty` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sklep`
--

DROP TABLE IF EXISTS `sklep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sklep` (
  `id` int NOT NULL AUTO_INCREMENT,
  `adres` char(40) NOT NULL,
  `miasto` char(40) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sklep`
--

LOCK TABLES `sklep` WRITE;
/*!40000 ALTER TABLE `sklep` DISABLE KEYS */;
INSERT INTO `sklep` VALUES (1,'Ul. Sezamkowa 2','Warszawa'),(2,'Ul. Eskimosa 23','Psia Wólka'),(3,'ul. Niecala 3','Poznan');
/*!40000 ALTER TABLE `sklep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zakupy`
--

DROP TABLE IF EXISTS `zakupy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zakupy` (
  `id_produktu` int NOT NULL,
  `id_klienta` int NOT NULL,
  `ilosc` int DEFAULT NULL,
  `id_transakcji` int NOT NULL,
  KEY `id_produktu` (`id_produktu`),
  KEY `id_klienta` (`id_klienta`),
  CONSTRAINT `zakupy_ibfk_1` FOREIGN KEY (`id_produktu`) REFERENCES `produkty` (`id`),
  CONSTRAINT `zakupy_ibfk_3` FOREIGN KEY (`id_klienta`) REFERENCES `klient` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zakupy`
--

LOCK TABLES `zakupy` WRITE;
/*!40000 ALTER TABLE `zakupy` DISABLE KEYS */;
INSERT INTO `zakupy` VALUES (1,1,10,1),(2,1,15,1),(1,2,3,2),(2,2,4,2),(1,2,6,3),(2,2,9,3),(1,2,5,4),(2,2,5,4),(1,5,3,5),(2,5,4,5),(2,2,2,6),(2,2,1,7),(1,6,1,8),(2,6,1,8),(2,2,9,9),(1,6,4,10),(1,2,3,11),(2,2,4,11),(2,2,19,12),(1,2,2,13),(1,2,1,14),(2,2,4,14),(7,2,6,14),(8,2,9,14),(1,2,4,15),(7,2,1,15),(1,6,6,16),(2,6,14,16),(7,6,3,16),(8,6,4,16),(9,6,2,16);
/*!40000 ALTER TABLE `zakupy` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-20 16:13:15
