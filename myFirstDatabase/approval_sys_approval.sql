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
-- Table structure for table `approval`
--

DROP TABLE IF EXISTS `approval`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `approval` (
  `approval_id` bigint NOT NULL AUTO_INCREMENT COMMENT '订单号',
  `applicant_id` bigint DEFAULT NULL COMMENT '申请人编码',
  `applicant_name` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '申请人名字',
  `approver_id` bigint DEFAULT NULL COMMENT '审批人编码',
  `approver_name` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '审批人名字',
  `process_id` bigint DEFAULT NULL COMMENT '审批流程编码',
  `levels` tinyint DEFAULT NULL COMMENT '等级',
  `reject_reason` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '审批驳回原因',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `modify_time` datetime DEFAULT NULL COMMENT '修改时间',
  `complete_time` datetime DEFAULT NULL COMMENT '审批完成时间',
  `_status` int DEFAULT '0' COMMENT '审批状态 0审批中 1审批通过 2审批驳回',
  PRIMARY KEY (`approval_id`) USING BTREE,
  KEY `index_approval_applicant` (`applicant_id`) USING BTREE,
  KEY `index_approval_approver` (`approver_id`) USING BTREE,
  KEY `index_approval_create_time` (`create_time`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=1114 DEFAULT CHARSET=utf8mb3 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `approval`
--

LOCK TABLES `approval` WRITE;
/*!40000 ALTER TABLE `approval` DISABLE KEYS */;
INSERT INTO `approval` VALUES (1000,1000,'萧峰',2000,'张三丰',0,1,'none','2021-11-05 19:30:17','2021-11-05 19:30:17','2021-11-05 19:30:17',1),(1001,1000,'萧峰',2000,'张三丰',0,1,'none','2021-11-05 19:30:17','2021-11-05 19:30:17','2021-11-05 19:30:17',-1),(1002,1000,'萧峰',2001,'周伯通',0,1,'none','2021-11-05 19:30:17','2021-11-05 19:30:17','2021-11-05 19:30:17',0),(1003,1001,'段誉',2001,'周伯通',0,1,'none','2021-11-05 19:30:17','2021-11-05 19:30:17','2021-11-05 19:30:17',0),(1004,1002,'虚竹',2000,'张三丰',0,1,'123','2021-11-05 19:30:17','2021-11-05 19:30:17','2021-11-05 19:30:17',2),(1005,1003,'张无忌',2001,'周伯通',0,1,'none','2021-11-05 19:30:17','2021-11-05 19:30:17','2021-11-05 19:30:17',0);
/*!40000 ALTER TABLE `approval` ENABLE KEYS */;
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
