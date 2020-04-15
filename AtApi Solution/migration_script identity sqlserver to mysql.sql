-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: AmericanTeacher
-- Source Schemata: AmericanTeacher
-- Created: Mon Apr 13 14:01:28 2020
-- Workbench Version: 8.0.19
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema AmericanTeacher
-- ----------------------------------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `AmericanTeacher` ;

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.__EFMigrationsHistory
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`__EFMigrationsHistory` (
  `MigrationId` VARCHAR(150) CHARACTER SET 'utf8mb4' NOT NULL,
  `ProductVersion` VARCHAR(32) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`MigrationId`));

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.AspNetRoles
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`AspNetRoles` (
  `Id` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `ConcurrencyStamp` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `Name` VARCHAR(256) CHARACTER SET 'utf8mb4' NULL,
  `NormalizedName` VARCHAR(256) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Id`(255)),
  INDEX `RoleNameIndex` (`NormalizedName`(255) ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.AspNetUserTokens
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`AspNetUserTokens` (
  `UserId` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `LoginProvider` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `Name` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `Value` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`UserId`(255), `LoginProvider`(255), `Name`(255)));

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.AspNetUsers
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`AspNetUsers` (
  `Id` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `AccessFailedCount` INT NOT NULL,
  `ConcurrencyStamp` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `Email` VARCHAR(256) CHARACTER SET 'utf8mb4' NULL,
  `EmailConfirmed` TINYINT(1) NOT NULL,
  `LockoutEnabled` TINYINT(1) NOT NULL,
  `LockoutEnd` DATETIME(6) NULL,
  `NormalizedEmail` VARCHAR(256) CHARACTER SET 'utf8mb4' NULL,
  `NormalizedUserName` VARCHAR(256) CHARACTER SET 'utf8mb4' NULL,
  `PasswordHash` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `PhoneNumber` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `PhoneNumberConfirmed` TINYINT(1) NOT NULL,
  `SecurityStamp` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `TwoFactorEnabled` TINYINT(1) NOT NULL,
  `UserName` VARCHAR(256) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Id`(255)),
  INDEX `EmailIndex` (`NormalizedEmail`(255) ASC) VISIBLE,
  UNIQUE INDEX `UserNameIndex` (`NormalizedUserName`(255) ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.AspNetRoleClaims
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`AspNetRoleClaims` (
  `Id` INT NOT NULL,
  `ClaimType` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `ClaimValue` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `RoleId` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_AspNetRoleClaims_RoleId` (`RoleId`(255) ASC) VISIBLE
);

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.AspNetUserClaims
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`AspNetUserClaims` (
  `Id` INT NOT NULL,
  `ClaimType` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `ClaimValue` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `UserId` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_AspNetUserClaims_UserId` (`UserId`(255) ASC) VISIBLE
);

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.AspNetUserLogins
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`AspNetUserLogins` (
  `LoginProvider` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `ProviderKey` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `ProviderDisplayName` LONGTEXT CHARACTER SET 'utf8mb4' NULL,
  `UserId` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`LoginProvider`(255), `ProviderKey`(255)),
  INDEX `IX_AspNetUserLogins_UserId` (`UserId`(255) ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table AmericanTeacher.AspNetUserRoles
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `AmericanTeacher`.`AspNetUserRoles` (
  `UserId` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  `RoleId` VARCHAR(450) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`UserId`(255), `RoleId`(255)),
  INDEX `IX_AspNetUserRoles_RoleId` (`RoleId`(255) ASC) VISIBLE,
  INDEX `IX_AspNetUserRoles_UserId` (`UserId`(255) ASC) VISIBLE);
SET FOREIGN_KEY_CHECKS = 1;
