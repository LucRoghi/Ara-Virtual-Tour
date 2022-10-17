USE AraVirtualTourDB;

CREATE TABLE IF NOT EXISTS useraccounts (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    UserName VARCHAR(255) NOT NULL,
    Password NVARCHAR(2550) NOT NULL
)  ENGINE=INNODB;

INSERT INTO useraccounts (ID, UserName, Password)
VALUES (
    1,
    'AraAdmin',
    'goodpassword'
  );