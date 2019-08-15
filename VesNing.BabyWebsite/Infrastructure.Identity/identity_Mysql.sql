CREATE TABLE `AppUsers` (
    `Id` varchar(767) NOT NULL,
    `UserName` varchar(256) NULL,
    `NormalizedUserName` varchar(256) NULL,
    `Email` varchar(256) NULL,
    `NormalizedEmail` varchar(256) NULL,
    `EmailConfirmed` bit NOT NULL,
    `PasswordHash` text NULL,
    `SecurityStamp` text NULL,
    `ConcurrencyStamp` text NULL,
    `PhoneNumber` text NULL,
    `PhoneNumberConfirmed` bit NOT NULL,
    `TwoFactorEnabled` bit NOT NULL,
    `LockoutEnd` timestamp NULL,
    `LockoutEnabled` bit NOT NULL,
    `AccessFailedCount` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetRoles` (
    `Id` varchar(767) NOT NULL,
    `Name` varchar(256) NULL,
    `NormalizedName` varchar(256) NULL,
    `ConcurrencyStamp` text NULL,
    `Discriminator` text NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `AppUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` varchar(767) NOT NULL,
    `ClaimType` text NULL,
    `ClaimValue` text NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AppUserClaims_AppUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AppUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AppUserLogins` (
    `LoginProvider` varchar(767) NOT NULL,
    `ProviderKey` varchar(767) NOT NULL,
    `ProviderDisplayName` text NULL,
    `UserId` varchar(767) NOT NULL,
    PRIMARY KEY (`ProviderKey`, `LoginProvider`),
    CONSTRAINT `AK_AppUserLogins_LoginProvider_ProviderKey` UNIQUE (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AppUserLogins_AppUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AppUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AppUserTokens` (
    `UserId` varchar(767) NOT NULL,
    `LoginProvider` varchar(767) NOT NULL,
    `Name` varchar(767) NOT NULL,
    `Value` text NULL,
    PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AppUserTokens_AppUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AppUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AppRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` varchar(767) NOT NULL,
    `ClaimType` text NULL,
    `ClaimValue` text NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AppRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AppUserRoles` (
    `UserId` varchar(767) NOT NULL,
    `RoleId` varchar(767) NOT NULL,
    PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AppUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AppUserRoles_AppUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AppUsers` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_AppRoleClaims_RoleId` ON `AppRoleClaims` (`RoleId`);

CREATE INDEX `IX_AppUserClaims_UserId` ON `AppUserClaims` (`UserId`);

CREATE INDEX `IX_AppUserLogins_UserId` ON `AppUserLogins` (`UserId`);

CREATE INDEX `IX_AppUserRoles_RoleId` ON `AppUserRoles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `AppUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AppUsers` (`NormalizedUserName`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);


