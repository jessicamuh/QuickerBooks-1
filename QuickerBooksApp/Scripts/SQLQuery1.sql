﻿USE MASTER;  

IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'LoginDB' )  
BEGIN  
ALTER DATABASE LoginDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE  
DROP DATABASE LoginDB ;  
END  
  
  
CREATE DATABASE LoginDB  
GO  
  
USE LoginDB  
GO  