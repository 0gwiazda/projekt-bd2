CREATE DATABASE [Projekt_CLR_UDT]
GO

USE [Projekt_CLR_UDT]
GO

EXEC sp_changedbowner 'sa';
RECONFIGURE;

EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;

EXEC sp_configure 'clr enable', 1;
RECONFIGURE;

EXEC sp_configure 'clr strict security', 0;
RECONFIGURE;

