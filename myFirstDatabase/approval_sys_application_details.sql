CREATE DATABASE  IF NOT EXISTS `approval_sys` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `approval_sys`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: approval_sys
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
-- Table structure for table `application_details`
--

DROP TABLE IF EXISTS `application_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `application_details` (
  `apply_id` bigint NOT NULL COMMENT '订单号',
  `applicant_id` bigint DEFAULT NULL COMMENT '申请人编码',
  `applicant_name` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '申请人名字',
  `sum_price` decimal(10,2) DEFAULT NULL COMMENT '设备总价',
  `apply_detail` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '申购原因',
  `dev_price` decimal(10,2) DEFAULT NULL COMMENT '设备单价',
  `dev_name` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '设备名称',
  `dev_code` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '设备型号',
  `dev_num` int DEFAULT '0' COMMENT '设备数量',
  `project_id` bigint DEFAULT NULL COMMENT '项目编码',
  `project_name` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '项目名称',
  `create_time` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `modify_time` datetime DEFAULT NULL COMMENT '修改时间',
  `complete_time` datetime DEFAULT NULL COMMENT '审批完成时间',
  `_status` tinyint DEFAULT NULL COMMENT '审批状态 0审批中 1审批通过 2审批驳回',
  PRIMARY KEY (`apply_id`) USING BTREE,
  KEY `index_work_report_create_time` (`create_time`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application_details`
--

LOCK TABLES `application_details` WRITE;
/*!40000 ALTER TABLE `application_details` DISABLE KEYS */;
INSERT INTO `application_details` VALUES (1,1000,'萧峰',10.00,'信息1',10.00,'设备1',NULL,0,NULL,NULL,NULL,NULL,NULL,0),(2,1001,'段誉',10.00,'信息2',10.00,'设备2',NULL,0,NULL,NULL,NULL,NULL,NULL,0),(3,1002,'虚竹',10.00,'信息3',10.00,'设备3',NULL,0,NULL,NULL,NULL,NULL,NULL,0),(4,1003,'张无忌',10.00,'信息4',10.00,'设备4',NULL,0,NULL,NULL,NULL,NULL,NULL,0),(5,1000,'萧峰',10.00,'信息5',10.00,'设备5',NULL,0,NULL,NULL,NULL,NULL,NULL,0),(6,1001,'段誉',10.00,'信息6',10.00,'设备6',NULL,0,NULL,NULL,NULL,NULL,NULL,0),(1002,1000,'萧峰',0.00,'原因',10.00,'设备7','设备7',10,NULL,NULL,'2021-11-07 08:13:56',NULL,NULL,0),(1003,1000,'萧峰',0.00,'1',10.00,'设备8','设备8',10,NULL,NULL,'2021-11-07 08:45:37',NULL,NULL,0);
/*!40000 ALTER TABLE `application_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-10 21:53:22
