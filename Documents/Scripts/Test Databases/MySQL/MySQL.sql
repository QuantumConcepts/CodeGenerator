DROP DATABASE IF EXISTS CodeGeneratorTest;
CREATE DATABASE CodeGeneratorTest;

USE CodeGeneratorTest;

CREATE TABLE User
(
    ID INT NOT NULL AUTO_INCREMENT,
    Email VARCHAR(100) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NULL,
    LastName VARCHAR(50) NOT NULL,
    Age TINYINT UNSIGNED NOT NULL,
    PasswordEncrypted VARBINARY(50) NOT NULL,
    EncryptionVector VARBINARY(50) NOT NULL,
    CONSTRAINT PK_User PRIMARY KEY (ID),
    CONSTRAINT UX_User_1 UNIQUE (Email)
);

CREATE TABLE UserRole
(
    ID INT NOT NULL AUTO_INCREMENT,
    UserID INT NOT NULL,
    Role VARCHAR(25) NOT NULL,
    Sequence INT NOT NULL,
    CONSTRAINT PK_UserRole PRIMARY KEY (ID),
    CONSTRAINT FK_UserRole_User FOREIGN KEY (UserID) REFERENCES User (ID),
    CONSTRAINT UX_UserRole_1 UNIQUE (UserID, Role),
    CONSTRAINT CK_UserRole_1 CHECK (Role IN ('User', 'Manager', 'Administrator'))
);

CREATE VIEW RolesForUser AS
    SELECT
        u.ID AS UserID,
        u.Email AS UserEmail,
        ur.Role AS Role
    FROM
        User u
        JOIN UserRole ur ON ur.UserID = u.ID;