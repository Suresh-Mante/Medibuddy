CREATE DATABASE MEDIBUDDY;
USE MEDIBUDDY

CREATE TABLE PATIENT(
	PID INT IDENTITY(101,1) PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	MidName VARCHAR(20) ,
	LastName VARCHAR(20) NOT NULL,
	Mobile VARCHAR(10) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	Address VARCHAR(50) NOT NULL,
	Gender CHAR(1) NOT NULL,
	DOB DATE NOT NULL
)

CREATE TABLE DEPARTMENT(
	DepID INT IDENTITY(1,1) PRIMARY KEY,
	DepName Varchar(20) NOT NULL
)

CREATE TABLE DOCTOR(
	ID INT IDENTITY(101,1) PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	Type VARCHAR(20) NOT NULL,
	Mobile VARCHAR(10) NOT NULL,
	Email VARCHAR(30),
	Gender CHAR(1) NOT NULL,
	Fees DECIMAL(6,1),
	Salary DECIMAL(7,1)
)

CREATE TABLE NURSE(
	ID INT IDENTITY(101,1) PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	Mobile VARCHAR(10) NOT NULL,
	Email VARCHAR(30),
	Gender CHAR(1) NOT NULL,
	Salary DECIMAL(7,1)
)

CREATE TABLE OPDBilling(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	PID INT FOREIGN KEY REFERENCES PATIENT(PID),
	DocID INT FOREIGN KEY REFERENCES DOCTOR(ID)
)

CREATE TABLE Test(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(20),
	Price INT,
)

CREATE TABLE Medicine(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(20),
	Price INT,
)

CREATE TABLE OPDTest(
	OPDBillingID INT FOREIGN KEY REFERENCES OPDBilling(ID),
	TestID INT FOREIGN KEY REFERENCES Test(ID)
)

CREATE TABLE OPDMedicine(
	OPDBillingID INT FOREIGN KEY REFERENCES OPDBilling(ID),
	MedicineID INT FOREIGN KEY REFERENCES Medicine(ID)
)

CREATE TABLE WARD(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	DepID INT FOREIGN KEY REFERENCES DEPARTMENT(DepID),
	RoomSpecialCapacity INT NOT NULL,
	RoomSharedCapacity INT NOT NULL,
	RoomGeneralCapacity INT NOT NULL
)

CREATE TABLE ROOM(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	WardID INT FOREIGN KEY REFERENCES WARD(ID),
	Type VARCHAR(20) NOT NULL,
	Rate DECIMAL(6,1) NOT NULL,
	CurrentBedCapacity SMALLINT NOT NULL,
	MaxBedCapacity SMALLINT NOT NULL
)

CREATE TABLE OPDPatient(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	PID INT FOREIGN KEY REFERENCES PATIENT(PID),
	DocID INT FOREIGN KEY REFERENCES DOCTOR(ID),
	VisitDate DATE NOT NULL,
	OPDBillingID INT FOREIGN KEY REFERENCES OPDBilling(ID),
	Discharged BIT NOT NULL
)

Create TABLE IPDPatient(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	PID INT FOREIGN KEY REFERENCES PATIENT(PID) NOT NULL,
	DocID INT FOREIGN KEY REFERENCES DOCTOR(ID),
	NurseID INT FOREIGN KEY REFERENCES NURSE(ID),
	EntryDate DATE NOT NULL,
	ExitDate DATE NOT NULL,
	RoomID INT FOREIGN KEY REFERENCES ROOM(ID),
	Discharged BIT NOT NULL
);

CREATE TABLE IPDTest(
	IPDPatientID INT FOREIGN KEY REFERENCES IPDPatient(ID),
	TestID INT FOREIGN KEY REFERENCES TEST(ID) NOT NULL
);

CREATE TABLE IPDMedicine(
	IPDPatientID INT FOREIGN KEY REFERENCES IPDPatient(ID),
	MedicineID INT FOREIGN KEY REFERENCES MEDICINE(ID) NOT NULL
);
