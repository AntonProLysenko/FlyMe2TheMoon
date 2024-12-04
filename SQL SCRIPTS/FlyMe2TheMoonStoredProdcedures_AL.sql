--CREATE PROCEDURE uspListOfPassengersID
--AS
--BEGIN
--	SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerFullName FROM TPassengers
--END




--CREATE PROCEDURE uspPassengerDetails(@Passanger_id AS INTEGER)
--AS
--BEGIN
--SELECT intPassengerID, strFirstName, strLastName, strAddress, strCity, TStates.intStateID, strState, strZip, strPhoneNumber, strEmail
--                        FROM TPassengers 
--                        Join TStates
--                        ON TStates.intStateID = TPassengers.intStateID
--                        Where intPassengerID = @Passanger_id
--END



--CREATE PROCEDURE uspUsersFutureFlight(@user_id AS INTEGER)
--AS
--BEGIN
--	SELECT TF.intFlightID,TFP.strSeat, TF.intMilesFlown,
--                                FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
--                                ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
--                                CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS dtmFlightDate, 
--                                CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS dtmTimeofDeparture,
--                                CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS dtmTimeOfLanding
--    FROM TFlights AS  TF
--    JOIN TAirports AS FromAirport 
--	    ON TF.intFromAirportID = FromAirport.intAirportID
--    JOIN TAirports AS ToAirport 
--	    ON TF.intToAirportID = ToAirport.intAirportID
--    JOIN TFlightPassengers as TFP
--	    ON tfp.intFlightID = TF.intFlightID
--    WHERE  GETDATE() <= TF.dtmFlightDate  AND TFP.intPassengerID = @user_id
--    ORDER BY TF.dtmFlightDate
--END



--CREATE PROCEDURE uspUsersPastFlight(@user_id AS INTEGER)
--AS
--BEGIN
--	SELECT TF.intFlightID,TFP.strSeat, TF.intMilesFlown,
--                                FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
--                                ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
--                                CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS dtmFlightDate, 
--                                CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS dtmTimeofDeparture,
--                                CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS dtmTimeOfLanding
--    FROM TFlights AS  TF
--    JOIN TAirports AS FromAirport 
--	    ON TF.intFromAirportID = FromAirport.intAirportID
--    JOIN TAirports AS ToAirport 
--	    ON TF.intToAirportID = ToAirport.intAirportID
--    JOIN TFlightPassengers as TFP
--	    ON tfp.intFlightID = TF.intFlightID
--    WHERE  GETDATE() > TF.dtmFlightDate  AND TFP.intPassengerID = @user_id
--    ORDER BY TF.dtmFlightDate
--END



--CREATE PROCEDURE uspPilotsList
--AS
--BEGIN
--	SELECT intPilotID as intID, strFirstName + ' ' + strLastName as strFullName FROM TPilots
--END


--CREATE PROCEDURE uspAttendantsList
--AS
--BEGIN
--	SELECT intAttendantID as intID, strFirstName + ' ' + strLastName as strFullName FROM TAttendants
--END


--CREATE PROCEDURE uspStatesList
--AS
--BEGIN
--	SELECT * FROM TStates
--END




--CREATE PROCEDURE uspNextPK(@id_ColumnName VARCHAR(128), @TableName VARCHAR(128))
--AS
--BEGIN
--    DECLARE @query NVARCHAR(MAX);

--    SET @query = 'SELECT MAX(' + @id_ColumnName + ') + 1 AS intNextPrimaryKey FROM ' + @TableName;
    
--    EXEC sp_executesql @query;
--END;



--CREATE PROCEDURE uspTotalPassengers
--AS BEGIN
--	SELECT COUNT(intPassengerID) as TotalPassangers FROM TPassengers
--END




--CREATE PROCEDURE uspTotalPassengers
--AS BEGIN
--	SELECT COUNT(intPassengerID) as TotalPassangers FROM TPassengers
--END



--CREATE PROCEDURE uspTotalFlights
--AS BEGIN
--	SELECT Count(intFlightID) as TotalFlightsTaken FROM TFlightPassengers
--END



--CREATE PROCEDURE uspAverageMilesByPassengers
--AS BEGIN
--SELECT AVG(intMilesFlown) as AverageMilesFlown
--                        FROM TFlights
--                        JOIN TFlightPassengers
--                            ON TFlightPassengers.intFlightID = TFlights.intFlightID

--END


--CREATE PROCEDURE uspAverageMilesByEachPilot
--AS BEGIN
--SELECT TPilots.intPilotID, strFirstName + ' ' + strLastName as PilotFullName, ISNULL( SUM(intMilesFlown), 0)  as TotalMiles
--                        FROM TPilots
--                        LEFT JOIN TPilotFlights
--                        On TPilotFlights.intPilotID = TPilots.intPilotID
--                        LEFT JOIN TFlights
--                        ON TFlights.intFlightID = TPilotFlights.intFlightID
--                        GROUP BY TPilots.intPilotID, strFirstName, strLastName
--END



--CREATE PROCEDURE uspAverageMilesByEachAttendant
--AS BEGIN
--		SELECT TAttendants.intAttendantID, strFirstName + ' ' + strLastName as AttendantFullName, ISNULL( SUM(intMilesFlown), 0)  as TotalMiles
--        FROM TAttendants
--        LEFT JOIN TAttendantFlights
--        On TAttendantFlights.intAttendantID = TAttendants.intAttendantID
--        LEFT JOIN TFlights
--        ON TFlights.intFlightID = TAttendantFlights.intFlightID
--        GROUP BY TAttendants.intAttendantID, strFirstName, strLastName
--END



--CREATE PROCEDURE uspFindPassengerByID(@logInID as INTEGER)
--AS BEGIN
--	SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerFullName, strPassengerPassword 
--	FROM TPassengers
--	WHERE intPassengerLoginID = @logInID
--END

--CREATE PROCEDURE uspFindEmployeeByID(@loginID as INTEGER)
--AS BEGIN
--	SELECT TE.strEmployeeID, TE.strEmployeePassword, TE.strRole, TE.strEmployeeID
--	FROM TEmployeeCredentials AS TE
--	WHERE intEmployeeLoginID = @loginID
--END

--EXECUTE uspFindEmployeeByID 10002 10001 16666

--CREATE PROCEDURE uspFindPilotByEmployeeID(@employeeID as VARCHAR(255))
--AS BEGIN
--	SELECT  intPilotID as intID, strFirstName + ' ' + strLastName as strFullName
--	FROM  TPilots
--	WHERE strEmployeeID = @employeeID
--END

--EXECUTE uspFindPilotByEmployeeID 16666


--CREATE PROCEDURE uspFindAttendantByEmployeeID(@employeeID as VARCHAR(255))
--AS BEGIN
--	SELECT  intAttendantID as intID, strFirstName + ' ' + strLastName as strFullName
--	FROM  TAttendants
--	WHERE strEmployeeID = @employeeID
--END

--CREATE PROCEDURE uspFindAllAirports
--AS
--BEGIN
--	SELECT intAirportID, '('+strAirportCode+') '+strAirportCity as airportName
--	FROM TAirports
	
--END
--SELECT * FROM TPlaneTypes

CREATE PROCEDURE uspFinAllPlanes
AS 
BEGIN
	SELECT intPlaneID, strPlaneType +'('+ strPlaneNumber +')' as planeName
	FROM TPlanes
	JOIN TPlaneTypes
	ON TPlanes.intPlaneTypeID = TPlaneTypes.intPlaneTypeID
END