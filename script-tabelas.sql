DROP TABLE IF EXISTS Author;
CREATE TABLE Author (
Id INT  PRIMARY KEY AUTO_INCREMENT,
Name VARCHAR(100) NOT NULL,
DateOfBirth DATETIME NOT NULL,
Country VARCHAR(70) NOT NULL
);

INSERT INTO Author (Name, DateOfBirth, Country) VALUES ('Peter Bruce', '1990-10-30', 'United States');
INSERT INTO Author (Name, DateOfBirth, Country) VALUES ('Maria Helena', '2000-01-15', 'Brasil');
SELECT * FROM Author;

DROP TABLE IF EXISTS Genre;
CREATE TABLE Genre (
Id INT  PRIMARY KEY AUTO_INCREMENT,
Name VARCHAR(100) NOT NULL
);

INSERT INTO Genre (Name) VALUES ('Terror');
INSERT INTO Genre (Name) VALUES ('Romance');
SELECT * FROM Genre;

DROP TABLE IF EXISTS Book;
CREATE TABLE Book (
Id INT  PRIMARY KEY AUTO_INCREMENT,
Title VARCHAR(120) NOT NULL,
PublishedDate DATETIME NULL,
Price DECIMAL(10,2) NULL,
Description VARCHAR(500) NULL,
AuthorId INT NOT NULL,
GenreId INT NOT NULL,
FOREIGN KEY (AuthorId) REFERENCES Author(Id),
FOREIGN KEY (GenreId) REFERENCES Genre(Id)
);

INSERT INTO Book (Title, PublishedDate, Price, Description, AuthorId, GenreId) VALUES ('Without Fear To Love', '1980-05-17', 28.20, 'For teenage upwards', 1, 2);
INSERT INTO Book (Title, PublishedDate, Price, Description, AuthorId, GenreId) VALUES ('Like No Other Day', '1985-11-01', 35.00, 'For grownups', 1, 1);
INSERT INTO Book (Title, PublishedDate, Price, Description, AuthorId, GenreId) VALUES ('Como a Primeira Vez', '2020-03-10', 90.00, 'Para Adolecentes', 2, 1);
SELECT * FROM Book;




