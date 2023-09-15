CREATE TABLE UserInfo(Email_id VARCHAR(50) NOT NULL PRIMARY KEY, UserName VARCHAR(50) NOT NULL, Password VARCHAR(50), OfficeLocation VARCHAR(50) NOT NULL, CCPoints int NOT NULL, URole VARCHAR(50) NOT NULL);
INSERT INTO UserInfo VALUES('shauryapratap44@gmail.com','Shaurya Pratap','aA1234567890','SBO BLR',1400,'Admin');

CREATE TABLE Carpooling(Activity_id SERIAL NOT NULL PRIMARY KEY,Email_id VARCHAR(50),Activity_Date DATE NOT NULL,CCAwarded INT NOT NULL,Status VARCHAR(50) NOT NULL,Start_Loc VARCHAR(50) NOT NULL,End_Loc VARCHAR(50) NOT NULL,Distance DECIMAL NOT NULL,CONSTRAINT fk_carpool
      FOREIGN KEY(Email_id) 
	  REFERENCES UserInfo(Email_id));
	  
CREATE TABLE EV_Travel(Activity_id SERIAL NOT NULL PRIMARY KEY,Email_id VARCHAR(50),Activity_Date DATE NOT NULL,CCAwarded INT NOT NULL,Status VARCHAR(50) NOT NULL,Start_Loc VARCHAR(50) NOT NULL,End_Loc VARCHAR(50) NOT NULL,Distance DECIMAL NOT NULL,CONSTRAINT fk_carpool
      FOREIGN KEY(Email_id) 
	  REFERENCES UserInfo(Email_id));

CREATE TABLE Walk_Cycle(Activity_id SERIAL NOT NULL PRIMARY KEY,Email_id VARCHAR(50),Activity_Date DATE NOT NULL,CCAwarded INT NOT NULL,Status VARCHAR(50) NOT NULL,Activity_Type VARCHAR(50) NOT NULL,Distance DECIMAL NOT NULL,CONSTRAINT fk_WalkCycle
      FOREIGN KEY(Email_id) 
	  REFERENCES UserInfo(Email_id));
	  
CREATE TABLE Afforestation(Activity_id SERIAL NOT NULL PRIMARY KEY,Email_id VARCHAR(50),Activity_Date DATE NOT NULL,CCAwarded INT NOT NULL,Status VARCHAR(50) NOT NULL,Plantaion_Loc VARCHAR(50) NOT NULL,CONSTRAINT fk_Afforestation
      FOREIGN KEY(Email_id) 
	  REFERENCES UserInfo(Email_id));
	  
ALTER TABLE Carpooling ADD Evidence BYTEA;
ALTER TABLE EV_Travel ADD Evidence BYTEA;
ALTER TABLE Walk_Cycle ADD Evidence BYTEA;
ALTER TABLE Afforestation ADD Evidence BYTEA;