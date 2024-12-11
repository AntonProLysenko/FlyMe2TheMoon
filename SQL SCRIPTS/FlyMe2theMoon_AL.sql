-- --------------------------------------------------------------------------------
-- Name: Anton Lysenko 
 
-- Abstract: IT-102 Project2 (FlyMe2theMoon)
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TPilotFlights')						IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')					IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')					IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')		IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID('TEmployeeCredentials')	IS NOT NULL DROP TABLE TEmployeeCredentials

IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates

-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strPhoneNumber			VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,intPassengerLoginID	INTEGER			NOT NULL
	,strPassengerPassword	VARCHAR(255)	NOT NULL
	,dtmDateOfBirth			DATETIME		NOT NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
	,CONSTRAINT Tpassengers_LoginID UNIQUE (intPassengerLoginID)
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)


--Here needs Forieng key and inserts
CREATE TABLE TEmployeeCredentials
(
	 intEmployeeCredentialsID	INTEGER			NOT NULL
	,intEmployeeLoginID			INTEGER			NOT NULL
	,strEmployeePassword		VARCHAR(255)	NOT NULL
	,strRole					VARCHAR(255)	NOT NULL
	,strEmployeeID				VARCHAR(255)	
	,CONSTRAINT TEmployeeCredentials_PK PRIMARY KEY (intEmployeeCredentialsID)
	,CONSTRAINT TEmployeeLogin_ID UNIQUE (intEmployeeLoginID)
)

-- filtered unique index if value is not null, because MSql Server treats null values as unique too
CREATE UNIQUE INDEX strEmployeeID_NotNull
ON TEmployeeCredentials (strEmployeeID)
WHERE strEmployeeID IS NOT NULL;


CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NOT NULL
	,dblTicketPrice				MONEY			NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)


CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID )

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID )

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID )

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID )

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID )

--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) 

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID )

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )  

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )  

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID ) 

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) 

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 


-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')


INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, intPassengerLoginID, strPassengerPassword, dtmDateOfBirth)
VALUES					(1, 'Knelly', 'Nervious', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com', 100001, 'Knelly123', '1990-04-15') -- Adult
					   ,(2, 'Orville', 'Waite', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com', 100002, 'Orville123', '2010-09-22') -- Kid 
					   ,(3, 'Eileen', 'Awnewe', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com', 100003, 'Eileen123', '1992-07-08') -- Adult
					   ,(4, 'Bob', 'Eninocean', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com', 100004, 'Bob123', '2008-12-11') -- Kid
					   ,(5, 'Ware', 'Hyjeked', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com', 100005, 'Ware123', '2015-03-25') -- Kid 
					   ,(6, 'Kay', 'Oss', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com', 100006, 'Kay123', '1994-11-18') -- Adult


INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909', '1/1/2012', '1/1/2099')



INSERT INTO TEmployeeCredentials (intEmployeeCredentialsID, intEmployeeLoginID, strEmployeePassword, strRole, strEmployeeID)
VALUES							 (1, 12345, 'Seenow123', 'Pilot', '12121')
								,(2, 54321, 'Soring123', 'Pilot', '13322')
								,(3, 10001, 'Encharge123', 'Pilot', '16666')
								,(4, 19876, 'Knapp123', 'Pilot', '17676')
								,(5, 10004, 'Ennair123', 'Pilot', '19909')
								,(6, 10008, 'Tyme123', 'Attendant','22121')
								,(7, 10002, 'Ujest123', 'Attendant','23322')
								,(8, 54322, 'Biy123', 'Attendant','26666')
								,(9, 21038, 'Amanie123', 'Attendant', '27676')
								,(10, 21039, 'Toexet123', 'Attendant', '29909')
								,(11, 21031, 'Anton123', 'Admin', NULL)
								,(12, 10003, 'Admin123', 'Admin', NULL)



INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				 (1, '2024-12-15', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					,(2, '2024-12-17', '222', '13:00:00', '15:00:00', 1, 3, 1000, 2)
					,(3, '2024-12-18', '333', '15:00:00', '17:00:00', 1, 5, 1200, 3)
					,(4, '2024-12-22', '444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					,(5, '2024-12-20', '555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					,(6, '2024-12-21', '666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					,(7, '2024-12-11', '777', '20:00:00', '22:00:00', 3, 6, 1400, 4)
					,(8, '2024-12-09', '888', '09:00:00', '11:00:00', 6, 4, 1100, 5)
					,(9, '2024-12-06', '999', '08:00:00', '10:00:00', 4, 2, 1000, 6)
					,(10, '2024-12-04', '091', '10:00:00', '12:00:00', 2, 1, 1200, 6);


INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 8 )
					,( 12, 1, 8 )


INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 8 )
					,( 12, 1, 8 )
					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat, dblTicketPrice)
VALUES				 (1, 1, 1, '1A', 485)
					,(2, 1, 2, '2B', 515)
					,(3, 1, 3, '1C', 465)
					,(4, 1, 4, '2C', 465)
					,(5, 1, 5, '3A', 465)
					,(6, 2, 5, '1A', 485)
					,(7, 2, 4, '1B', 515)
					,(8, 2, 3, '2A', 485)
					,(9, 3, 1, '1A', 485)
					,(10, 3, 2, '1B', 515)
					,(11, 3, 3, '2C', 465)
					,(12, 3, 4, '3B', 465)
					,(13, 3, 5, '3C', 465)
					,(14, 4, 2, '1A', 515)
					,(15, 4, 3, '2B', 465)
					,(16, 4, 4, '3A', 465)
					,(17, 4, 5, '3B', 465)
					,(18, 5, 1, '1C', 485)
					,(19, 5, 2, '2A', 515)
					,(20, 5, 3, '2B', 465)
					,(21, 5, 4, '3C', 495)
					,(22, 8, 1, '1A', 485)
					,(23, 8, 2, '2B', 515)
					,(24, 8, 3, '3A', 500)
					

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )



 





Select * FROM TEmployeeCredentials
SELECT * FROM TPassengers



----Future Detailed FlightInfo Specific Pilot
--SELECT TF.intFlightID, strPilotRole, TF.intMilesFlown,
--    FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
--    ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
--    CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS FlightDate, 
--    CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS DepartureTime,
--    CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS LandingTime
	
--FROM TFlights AS  TF
--JOIN TAirports AS FromAirport 
--	ON TF.intFromAirportID = FromAirport.intAirportID
--JOIN TAirports AS ToAirport 
--	ON TF.intToAirportID = ToAirport.intAirportID
--JOIN TPilotFlights
--	ON TPilotFlights.intFlightID = TF.intFlightID
--JOIN TPilots
--	ON TPilots.intPilotID = TPilotFlights.intPilotID
--JOIN TPilotRoles
--	ON TPilots.intPilotRoleID = TPilotRoles.intPilotRoleID
--WHERE GETDATE() <= TF.dtmFlightDate AND TPilotFlights.intPilotID = 1
--ORDER BY TF.dtmFlightDate



----Future Detailed FlightInfo Specific Attendant
--SELECT TF.intFlightID, strRole = 'Flight Attendant', TF.intMilesFlown,
--    FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
--    ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
--    CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS FlightDate, 
--    CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS DepartureTime,
--    CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS LandingTime
	
--FROM TFlights AS  TF
--JOIN TAirports AS FromAirport 
--	ON TF.intFromAirportID = FromAirport.intAirportID
--JOIN TAirports AS ToAirport 
--	ON TF.intToAirportID = ToAirport.intAirportID
--JOIN TAttendantFlights
--	ON TAttendantFlights.intFlightID = TF.intFlightID
--WHERE GETDATE() <= TF.dtmFlightDate AND TAttendantFlights.intAttendantID = 1
--ORDER BY TF.dtmFlightDate







----DELETING PILOT

--DELETE FROM TPilotFlights
--WHERE intFlightID IN( SELECT TPilotFlights.intFlightID 
--						FROM TPilotFlights
--						JOIN TFlights
--							ON TPilotFlights.intFlightID = TFlights.intFlightID
--						WHERE intPilotID = 1 
--						--AND TFlights.dtmFlightDate < GETDATE()
--)


--DELETE FROM TPilots
--WHERE intPilotID = 1


----DELETING Attendant

--DELETE FROM TAttendantFlights
--WHERE intFlightID IN( SELECT TAttendantFlights.intFlightID 
--						FROM TAttendantFlights
--						JOIN TFlights
--							ON TAttendantFlights.intFlightID = TFlights.intFlightID
--						WHERE intAttendantID = 1 
--						--AND TFlights.dtmFlightDate < GETDATE()
--)


--DELETE FROM TAttendants
--WHERE intAttendantID = 1








--SELECT max(intAttendantFlightID)+1 AS intNextPrimaryKey FROM TAttendantFlights

--SELECT max(intPilotFlightID)+1 AS intNextPrimaryKey FROM TPilotFlights




----STATISTICS
----Total Num OF Customers
--SELECT COUNT(intPassengerID) as TotalPassangers
--FROM TPassengers

----Total Flights Taken By Customers
--SELECT Count(intFlightID) as TotalFlightsTaken
--FROM TFlightPassengers

----Average miles flown for all customer
--SELECT AVG(intMilesFlown) as AverageMilesFlown
--FROM TFlights
--JOIN TFlightPassengers
--ON TFlightPassengers.intFlightID = TFlights.intFlightID

----List each Pilot and his/her total miles flown. 
--SELECT TPilots.intPilotID, strFirstName + ' ' + strLastName as PilotFullName, ISNULL( SUM(intMilesFlown), 0)  as TotalMiles
--FROM TPilots
--LEFT JOIN TPilotFlights
--On TPilotFlights.intPilotID = TPilots.intPilotID
--LEFT JOIN TFlights
--ON TFlights.intFlightID = TPilotFlights.intFlightID
--GROUP BY TPilots.intPilotID, strFirstName, strLastName

----List each attendant and his/her total miles flown. 
--SELECT * FROM TAttendants
--SELECT TAttendants.intAttendantID, strFirstName + ' ' + strLastName as PilotFullName, ISNULL( SUM(intMilesFlown), 0)  as TotalMiles
--FROM TAttendants
--LEFT JOIN TAttendantFlights
--On TAttendantFlights.intAttendantID = TAttendants.intAttendantID
--LEFT JOIN TFlights
--ON TFlights.intFlightID = TAttendantFlights.intFlightID
--GROUP BY TAttendants.intAttendantID, strFirstName, strLastName



