CREATE DATABASE  IF NOT EXISTS `srcd` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `srcd`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: srcd
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `approvals`
--

DROP TABLE IF EXISTS `approvals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `approvals` (
  `application_no` int NOT NULL,
  `form_no` int NOT NULL,
  `form_name` varchar(85) NOT NULL,
  `is_Hod_Approval_Required` varchar(45) DEFAULT NULL,
  `is_SrcdDean_Approval_Required` varchar(45) DEFAULT NULL,
  `is_SrcdAssoDean_Required` varchar(45) DEFAULT NULL,
  `form_id` int unsigned NOT NULL AUTO_INCREMENT,
  `submitted_by` varchar(250) DEFAULT NULL,
  `submitted_on` varchar(250) DEFAULT NULL,
  `Hod_Approval` varchar(255) DEFAULT NULL,
  `srcd_Approval` varchar(255) DEFAULT NULL,
  `associate_dean_Approval` varchar(255) DEFAULT NULL,
  `associate_dean_Approval_time` varchar(255) DEFAULT NULL,
  `srcd_Approval_time` varchar(255) DEFAULT NULL,
  `hod_Approval_time` varchar(255) DEFAULT NULL,
  `dept_id` varchar(255) NOT NULL,
  PRIMARY KEY (`form_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `approvals`
--

LOCK TABLES `approvals` WRITE;
/*!40000 ALTER TABLE `approvals` DISABLE KEYS */;
INSERT INTO `approvals` VALUES (6,1,'Cover letter for new proposal','yes','yes','yes',6,'Raksha','07-11-2021 17:51:11','Approved','Approved','Approved','12-11-2021 21:14:31','12-11-2021 21:13:51','07-11-2021 18:08:39','1'),(7,1,'Cover letter for new proposal','yes','yes','yes',7,'Raksha','07-11-2021 17:52:00','Approved','Pending','Pending',NULL,NULL,'07-11-2021 18:08:39','2'),(8,1,'Cover letter for new proposal','yes','yes','yes',8,'Raksha','07-11-2021 18:08:02','Approved','Pending','Pending',NULL,NULL,'07-11-2021 18:08:39','1'),(9,1,'Cover letter for new proposal','yes','yes','yes',9,'Raksha','07-11-2021 18:10:50','Approved','Approved','Approved','13-11-2021 11:37:35','07-11-2021 18:44:28','07-11-2021 18:11:13','2'),(10,1,'Cover letter for new proposal','yes','yes','yes',10,'Raksha','07-11-2021 19:04:04','Approved','Approved','Approved','07-11-2021 19:06:48','07-11-2021 19:06:24','07-11-2021 19:05:56','1'),(11,1,'Cover letter for new proposal','yes','yes','yes',11,'Raksha','13-11-2021 11:23:15','Approved','Approved','Pending',NULL,'13-11-2021 11:24:05','13-11-2021 11:23:31','2'),(12,1,'Cover letter for new proposal','yes','yes','yes',12,'Raksha','13-11-2021 11:35:49','Approved','Approved','Approved','13-11-2021 11:37:27','13-11-2021 11:37:19','13-11-2021 11:36:03','1'),(13,1,'Cover letter for new proposal','yes','yes','yes',13,'Raksha','13-11-2021 12:20:28','Approved','Pending','Pending',NULL,NULL,'13-11-2021 12:22:44','2'),(14,1,'Cover letter for new proposal','yes','yes','yes',14,'Raksha','13-11-2021 15:08:11','Approved','Pending','Pending',NULL,NULL,'13-11-2021 15:08:33','1'),(18,1,'Cover letter for new proposal','yes','yes','yes',15,'yash@pilani.bits-pilani.ac.in\'','13-11-2021 16:24:18','Approved','Pending','Pending',NULL,NULL,'13-11-2021 16:40:31','1'),(19,1,'Cover letter for new proposal','yes','yes','yes',16,'yash@pilani.bits-pilani.ac.in','16-11-2021 13:41:15','Pending','Pending','Pending',NULL,NULL,NULL,'1'),(1,2,'Performa for peer review','no','no','no',17,'yash@pilani.bits-pilani.ac.in','17-11-2021 14:02:45','N/A','N/A','N/A',NULL,NULL,NULL,'1');
/*!40000 ALTER TABLE `approvals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dept`
--

DROP TABLE IF EXISTS `dept`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dept` (
  `dept_id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dept_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `dept_email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `hod` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`dept_id`)
) ENGINE=InnoDB DEFAULT CHARSET=geostd8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dept`
--

LOCK TABLES `dept` WRITE;
/*!40000 ALTER TABLE `dept` DISABLE KEYS */;
INSERT INTO `dept` VALUES ('1','CS','hod.csis@pilani.bits-pilani.ac.in','Sudeept Mohan'),('2','EEE','hod.eee@pilani.bits-pilani.ac.in','Hitesh Datt Mathur');
/*!40000 ALTER TABLE `dept` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculty`
--

DROP TABLE IF EXISTS `faculty`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `faculty` (
  `email_id` varchar(255) NOT NULL,
  `dept_id` varchar(255) DEFAULT NULL,
  `faculty_name` varchar(255) DEFAULT NULL,
  `faculty_dept` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`email_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculty`
--

LOCK TABLES `faculty` WRITE;
/*!40000 ALTER TABLE `faculty` DISABLE KEYS */;
INSERT INTO `faculty` VALUES ('khari@pilani.bits-pilani.ac.in','1','Hari Babu','CS'),('meetha.shenoy@pilani.bits-pilani.ac.in','2','Meetha V Shenoy','EEE'),('yash@pilani.bits-pilani.ac.in','1','Yashvardhan Sharma','CS');
/*!40000 ALTER TABLE `faculty` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `form1`
--

DROP TABLE IF EXISTS `form1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `form1` (
  `Application_No` int NOT NULL AUTO_INCREMENT,
  `Email_Id` varchar(250) NOT NULL,
  `Investigator_Name` varchar(999) NOT NULL,
  `Funding_Agency_Scheme` varchar(999) NOT NULL,
  `Title_Of_The_Proposal` varchar(250) NOT NULL,
  `PI_And_CI_Details` varchar(999) NOT NULL,
  `Address_Of_The_Funding_Agency` varchar(250) NOT NULL,
  `Number_Of_Final_Hard_And_Soft_Copies` int NOT NULL,
  `Last_Date` varchar(25) NOT NULL,
  `Investigator_submission_timing` varchar(250) NOT NULL,
  `Department_Of_investigator` varchar(250) NOT NULL,
  `Hod_Approval` varchar(45) DEFAULT 'Pending',
  `Hod_Approval_timing` varchar(45) DEFAULT NULL,
  `Name_Of_Reviewer1` varchar(250) DEFAULT NULL,
  `Name_Of_Reviewer2` varchar(250) DEFAULT NULL,
  `srcd_dean_approval` varchar(45) DEFAULT 'Pending',
  `srcd_dean_approval_timing` varchar(45) DEFAULT NULL,
  `srcd_associate_dean_approval` varchar(45) DEFAULT 'Pending',
  `srcd_associate_dean_approval_timing` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Application_No`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `form1`
--

LOCK TABLES `form1` WRITE;
/*!40000 ALTER TABLE `form1` DISABLE KEYS */;
INSERT INTO `form1` VALUES (1,'rakshachoudhary1198@gmail.com','Raksha','Agency1','The Great Project','saoni','dhtfh',2,'2021-11-25','02-11-2021 18:57:18','1','Approved','null','test1','2','Pending','null','Pending','null'),(2,'rakshachoudhary1198@gmail.com','Raksha','Agency11','The Great Project','saoni','hsdgskhdd',2,'2021-11-25','02-11-2021 19:08:19','1','Pending','null','null','null','Pending','null','Pending','null'),(3,'rakshachoudhary1198@gmail.com','Raksha','Shahid','abcd','abcd, abcd','abc',7,'2021-11-16','04-11-2021 19:02:31','1','Approved','null','Test 1','Test 2','Pending','null','Pending','null'),(4,'rakshachoudhary1198@gmail.com','Raksha','Shahid','abcd','abcd, abcd','abc',7,'2021-11-16','04-11-2021 19:02:37','1','Pending','null','Saoni','Saoni','Pending','null','Pending','null'),(5,'rakshachoudhary1198@gmail.com','Raksha','abcd','abcd','qwer','zxcv',3,'2021-11-15','07-11-2021 17:33:43','1','Pending','null','null','null','Pending','null','Pending','null'),(6,'rakshachoudhary1198@gmail.com','Raksha','abcd','qwe','jll','RYU',3,'2021-11-17','07-11-2021 17:51:11','1','Approved','null','Raksha','Saoni','Approved','null','Approved','null'),(7,'rakshachoudhary1198@gmail.com','Raksha','abcd','qwe','jll','RYU',3,'2021-11-17','07-11-2021 17:52:00','1','Approved','null','Shahid','Saoni','Pending','null','Pending','null'),(8,'rakshachoudhary1198@gmail.com','Raksha','ABCD','ABCD','ABCD','ABCD',3,'2021-11-16','07-11-2021 18:08:02','1','Approved','null','Shahid','Shahid','Pending','null','Pending','null'),(9,'rakshachoudhary1198@gmail.com','Raksha','QWER','QWR','QWER','QWER',7,'2021-11-24','07-11-2021 18:10:50','1','Approved','null','Shahid','Shahid','Approved','null','Approved','null'),(10,'rakshachoudhary1198@gmail.com','Raksha','Test','Test','Test','Test',2,'2021-11-16','07-11-2021 19:04:04','1','Approved','null','Abc','Abc','Approved','null','Approved','null'),(11,'rakshachoudhary1198@gmail.com','Raksha','ATCG','ATCG','ATGD','ASTG',3,'2021-11-09','13-11-2021 11:23:14','1','Approved','null','inha','aina','Approved','null','Pending','null'),(12,'rakshachoudhary1198@gmail.com','Raksha','qwer','qwer','qwrr','qwr',7,'2021-11-10','13-11-2021 11:35:49','1','Approved','null','urio','wuwi','Approved','null','Approved','null'),(13,'rakshachoudhary1198@gmail.com','Raksha','qwewe','wqweqwe','werwerq','werwer',2,'2021-11-16','13-11-2021 12:20:28','1','Approved','null','werwer','wern','Pending','null','Pending','null'),(14,'rakshachoudhary1198@gmail.com','Raksha','lsdksfkl','SLDFMSLDFM','SLKDMFSLKDF','SDLKFMSDKLF',8,'2021-11-02','13-11-2021 15:08:10','1','Approved','null','mdlkfm','lskdmfkl','Pending','null','Pending','null'),(15,'yash@pilani.bits-pilani.ac.in','Yashvardhan Sharma','kdlj','lsdkfkl','lksdmflks','lskdsmf',7,'2021-11-10','13-11-2021 16:18:51','1','Pending','null','null','null','Pending','null','Pending','null'),(16,'yash@pilani.bits-pilani.ac.in','Yashvardhan Sharma','kdlj','lsdkfkl','lksdmflks','lskdsmf',7,'2021-11-10','13-11-2021 16:21:54','1','Pending','null','null','null','Pending','null','Pending','null'),(17,'yash@pilani.bits-pilani.ac.in','Yashvardhan Sharma','asdasd','aksndaks','lkasmd','lkasmd',7,'2021-11-30','13-11-2021 16:23:07','1','Pending','null','null','null','Pending','null','Pending','null'),(18,'yash@pilani.bits-pilani.ac.in','Yashvardhan Sharma','sdfsd','lkmaskldm','klamsdkl','alksdm',9,'2021-11-18','13-11-2021 16:24:18','1','Approved','null','klfklmsld','lsdmflksdm','Pending','null','Pending','null'),(19,'yash@pilani.bits-pilani.ac.in','Yashvardhan Sharma','gvjh','hghj','jhhg','hbj',6,'2021-11-24','16-11-2021 13:41:15','1','Pending','null','null','null','Pending','null','Pending','null');
/*!40000 ALTER TABLE `form1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `form2`
--

DROP TABLE IF EXISTS `form2`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `form2` (
  `Application_No` int NOT NULL AUTO_INCREMENT,
  `Email_Id` varchar(255) DEFAULT NULL,
  `Name_Of_PI` varchar(255) DEFAULT NULL,
  `Name_Of_funding_Agency` varchar(255) DEFAULT NULL,
  `Comments` varchar(450) DEFAULT NULL,
  `Objectives` varchar(450) DEFAULT NULL,
  `Supporting_Elements` varchar(450) DEFAULT NULL,
  `Alternating_Strategies` varchar(450) DEFAULT NULL,
  `Relevance_Applicability` varchar(450) DEFAULT NULL,
  `Comments_Budget` varchar(450) DEFAULT NULL,
  `Suggestions` varchar(450) DEFAULT NULL,
  `Reviewer_Name` varchar(255) DEFAULT NULL,
  `Department` varchar(450) DEFAULT NULL,
  `Submission_Timing` varchar(455) DEFAULT NULL,
  PRIMARY KEY (`Application_No`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `form2`
--

LOCK TABLES `form2` WRITE;
/*!40000 ALTER TABLE `form2` DISABLE KEYS */;
INSERT INTO `form2` VALUES (1,'yash@pilani.bits-pilani.ac.in','nmnm','b bn','','mbhnm','nbn','bnbn','bmhhn n','bnnm','mbmn','m m','csis','17-11-2021 14:02:44');
/*!40000 ALTER TABLE `form2` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'srcd'
--

--
-- Dumping routines for database 'srcd'
--
/*!50003 DROP PROCEDURE IF EXISTS `Approval_Summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Approval_Summary`(
_application_no int , 
_form_no int ,
_form_name varchar(85),
_is_Hod_Approval_Required varchar(45) ,
_is_SrcdDean_Approval_Required varchar(45) ,
_is_SrcdAssoDean_Required varchar(45),
_submitted_by varchar(250),
_submitted_on varchar(250),
_Hod_Approval varchar(250),
_srcd_Approval varchar(250),
_associate_dean_Approval varchar(250),
_dept_id varchar(255)
)
BEGIN
    INSERT into approvals(application_no,
form_no,
form_name,
is_Hod_Approval_Required , 
is_SrcdDean_Approval_Required,
is_SrcdAssoDean_Required,
submitted_by,
submitted_on,
Hod_Approval,
srcd_Approval,
associate_dean_Approval,
dept_id
)
    values(
    _application_no , 
_form_no  ,
_form_name,
_is_Hod_Approval_Required  ,
_is_SrcdDean_Approval_Required ,
_is_SrcdAssoDean_Required,
_submitted_by,
_submitted_on,
_Hod_Approval,
_srcd_Approval,
_associate_dean_Approval,
_dept_id
 );
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `form1_associate_dean_add` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `form1_associate_dean_add`(
_application_no int,
_associate_dean_approval_time varchar(250)
)
BEGIN
	UPDATE form1
	SET srcd_associate_dean_approval="Approved" 
	WHERE Application_No=_application_no;
    
    UPDATE approvals
	SET associate_dean_Approval="Approved",  associate_dean_Approval_time=_associate_dean_approval_time 
	WHERE form_name="Cover letter for new proposal" and application_no=_application_no;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `form1_faculty_add` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `form1_faculty_add`(
_Email_Id varchar(250),
_Investigator_Name varchar(999),
_Funding_Agency_Scheme varchar(999),
_Title_Of_The_Proposal varchar(250),
_PI_And_CI_Details varchar(999) ,
_Address_Of_The_Funding_Agency varchar(250),
_Number_Of_Final_Hard_And_Soft_Copies INT,
_Last_Date varchar(25),
_Investigator_submission_timing varchar(250),
_Department_Of_investigator varchar(250)


)
BEGIN
	
    INSERT into form1(
Email_Id,
Investigator_Name ,
Funding_Agency_Scheme,
Title_Of_The_Proposal,
PI_And_CI_Details, 
Address_Of_The_Funding_Agency,
Number_Of_Final_Hard_And_Soft_Copies,
Last_Date,
Investigator_submission_timing,
Department_Of_investigator,
Hod_Approval_timing ,
Name_Of_Reviewer1 ,
Name_Of_Reviewer2  ,
srcd_dean_approval_timing ,
srcd_associate_dean_approval_timing)
    values(_Email_Id ,
_Investigator_Name,
_Funding_Agency_Scheme ,
_Title_Of_The_Proposal ,
_PI_And_CI_Details,
_Address_Of_The_Funding_Agency,
_Number_Of_Final_Hard_And_Soft_Copies,
_Last_Date ,
_Investigator_submission_timing ,
_Department_Of_investigator,
'null','null','null','null','null'

);
    
  
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `form1_faculy_add` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `form1_faculy_add`(
_Email_Id varchar(250),
_Investigator_Name varchar(999),
_Funding_Agency_Scheme varchar(999),
_Title_Of_The_Proposal varchar(250),
_PI_And_CI_Details varchar(999) ,
_Address_Of_The_Funding_Agency varchar(250),
_Number_Of_Final_Hard_And_Soft_Copies INT,
_Last_Date varchar(25),
_Investigator_submission_timing varchar(250),
_Department_Of_investigator varchar(250)


)
BEGIN
	
    INSERT into product(
Email_Id,
Investigator_Name ,
Funding_Agency_Scheme,
Title_Of_The_Proposal,
PI_And_CI_Details, 
Address_Of_The_Funding_Agency,
Number_Of_Final_Hard_And_Soft_Copies,
Last_Date,
Investigator_submission_timing,
Department_Of_investigator,
Hod_Approval_timing ,
Name_Of_Reviewer1 ,
Name_Of_Reviewer2  ,
srcd_dean_approval_timing ,
srcd_associate_dean_approval_timing)
    values(_Email_Id ,
_Investigator_Name,
_Funding_Agency_Scheme ,
_Title_Of_The_Proposal ,
_PI_And_CI_Details  ,
_Address_Of_The_Funding_Agency,
_Number_Of_Final_Hard_And_Soft_Copies,
_Last_Date ,
_Investigator_submission_timing ,
_Department_Of_investigator,
'null','null','null','null','null','null'

);
    
  
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `form1_hod_add` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `form1_hod_add`(
_application_no int,
_hod_approval_time varchar(250),
_reviewer1 varchar(250),
_reviewer2 varchar(250)
)
BEGIN
	UPDATE form1
	SET Name_Of_Reviewer1=_reviewer1, Name_Of_Reviewer2=_reviewer2, Hod_Approval="Approved" 
	WHERE Application_No=_application_no;
    
    UPDATE approvals
	SET Hod_Approval="Approved",  hod_Approval_time=_hod_Approval_time 
	WHERE form_name="Cover letter for new proposal" and application_no=_application_no;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `form1_srcd_add` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `form1_srcd_add`(
_application_no int,
_srcd_approval_time varchar(250)
)
BEGIN
	UPDATE form1
	SET srcd_dean_approval="Approved" 
	WHERE Application_No=_application_no;
    
    UPDATE approvals
	SET srcd_Approval="Approved",  srcd_Approval_time=_srcd_approval_time 
	WHERE form_name="Cover letter for new proposal" and application_no=_application_no;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `form2_add` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `form2_add`(

_Email_Id varchar(255), 
_Name_Of_PI varchar(255) ,
_Name_Of_funding_Agency varchar(255), 
_Comments varchar(450) ,
_Objectives varchar(450), 
_Supporting_Elements varchar(450) ,
_Alternating_Strategies varchar(450) ,
_Relevance_Applicability varchar(450) ,
_Comments_Budget varchar(450) ,
_Suggestions varchar(450) ,
_Reviewer_Name varchar(255), 
_Department varchar(450) ,
_Submission_Timing varchar(455))
BEGIN
INSERT into form2( 
Email_Id ,
 
Name_Of_PI ,
Name_Of_funding_Agency ,
Comments ,
Objectives ,
Supporting_Elements,
Alternating_Strategies,
Relevance_Applicability ,
Comments_Budget , 
Suggestions, 
Reviewer_Name ,
Department , 
Submission_Timing )
    values(_Email_Id , 

_Name_Of_PI  ,
_Name_Of_funding_Agency , 
_Comments  ,
_Objectives , 
_Supporting_Elements  ,
_Alternating_Strategies,
_Relevance_Applicability,
_Comments_Budget ,
_Suggestions  ,
_Reviewer_Name , 
_Department  ,
_Submission_Timing);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-11-22 11:12:56
