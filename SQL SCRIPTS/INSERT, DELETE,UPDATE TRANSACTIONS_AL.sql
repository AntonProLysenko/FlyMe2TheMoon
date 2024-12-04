
 
--CREATE PROCEDURE uspAddPilot
--     @intPilotID				AS INTEGER OUTPUT
--	,@strFirstName				AS VARCHAR(255)
--    ,@strLastName				AS VARCHAR(255)
--    ,@strEmployeeID				AS INTEGER 
--    ,@dtmDateofHire				AS DATETIME
--	,@dtmDateofTermination		AS DATETIME
--	,@dtmDateofLicense			AS DATETIME
--	,@intPilotRoleID			AS INTEGER
       
--AS
--SET XACT_ABORT ON --terminate and rollback if any errors
--BEGIN TRANSACTION
--    SELECT @intPilotID = MAX(intPilotID) + 1 
--    FROM TPilots (TABLOCKX) -- lock table until end of transaction
--    -- default to 1 if table is empty

--    SELECT @intPilotID = COALESCE(@intPilotID, 1)




--	INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
--				VALUES(@intPilotID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateofHire, @dtmDateofTermination,@dtmDateofLicense,@intPilotRoleID)


--COMMIT TRANSACTION
--GO






--CREATE PROCEDURE uspAddAttendant
--     @intAttendantID			AS INTEGER OUTPUT
--	,@strFirstName				AS VARCHAR(255)
--    ,@strLastName				AS VARCHAR(255)
--    ,@strEmployeeID				AS INTEGER 
--    ,@dtmDateofHire				AS DATETIME
--	,@dtmDateofTermination		AS DATETIME
	
       
--AS
--SET XACT_ABORT ON --terminate and rollback if any errors
--BEGIN TRANSACTION
--    SELECT @intAttendantID = MAX(intAttendantID) + 1 
--    FROM TAttendants (TABLOCKX) -- lock table until end of transaction
--    -- default to 1 if table is empty

--    SELECT @intAttendantID = COALESCE(@intAttendantID, 1)


--	INSERT INTO TAttendants(intAttendantID,  strFirstName,  strLastName,  strEmployeeID,  dtmDateofHire,  dtmDateofTermination)
--					VALUES(@intAttendantID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateofHire, @dtmDateofTermination)


--COMMIT TRANSACTION
--GO



--CREATE PROCEDURE uspUpdatePilot
--     @intPilotID				AS INTEGER  
--    ,@strFirstName				AS VARCHAR(255)
--    ,@strLastName				AS VARCHAR(255)
--	,@dtmDateofTermination		AS DATETIME
--	,@strEmployeeID				AS INTEGER 
--	,@intPilotRoleID			AS INTEGER
   
--AS

--SET XACT_ABORT ON --terminate and rollback if any errors

--BEGIN TRANSACTION
  
--    Update  TPilots 
--			SET strFirstName =	@strFirstName, 
--			    strLastName =	@strLastName,
--				dtmDateOfTermination = @dtmDateofTermination,
--				strEmployeeID = @strEmployeeID,
--				intPilotRoleID = @intPilotRoleID
				
--	WHERE  intPilotID = @intPilotID

--COMMIT TRANSACTION
--GO








--CREATE PROCEDURE uspUpdateAttendant
--     @intAttendantID			AS INTEGER  
--    ,@strFirstName				AS VARCHAR(255)
--    ,@strLastName				AS VARCHAR(255)
--	,@dtmDateofTermination		AS DATETIME
--	,@strEmployeeID				AS INTEGER 

   
--AS

--SET XACT_ABORT ON --terminate and rollback if any errors

--BEGIN TRANSACTION
  
--    Update  TAttendants 
--			SET strFirstName =	@strFirstName, 
--			    strLastName =	@strLastName,
--				dtmDateOfTermination = @dtmDateofTermination,
--				strEmployeeID = @strEmployeeID
				
--	WHERE  intAttendantID = @intAttendantID

--COMMIT TRANSACTION
--GO




--CREATE PROCEDURE uspDeletePilot
--     @intPilotID				AS INTEGER  
       
--AS
--SET XACT_ABORT ON --terminate and rollback if any errors
--BEGIN TRANSACTION

--	DELETE FROM TPilotFlights
--    WHERE intPilotID = @intPilotID
  
--    DELETE  FROM TPilots 
--	WHERE  intPilotID = @intPilotID

--COMMIT TRANSACTION
--GO



--CREATE PROCEDURE uspDeleteAttendant
--     @intAttendantID				AS INTEGER  
       
--AS
--SET XACT_ABORT ON --terminate and rollback if any errors
--BEGIN TRANSACTION

--	DELETE FROM TAttendantFlights
--	WHERE intAttendantID = @intAttendantID
  
--    DELETE  FROM TAttendants 
--	WHERE  intAttendantID = @intAttendantID

--COMMIT TRANSACTION
--GO

--CREATE PROCEDURE uspAddNewFlight
--  @intFlightID			AS INTEGER OUTPUT
--, @dtmFlightDate		AS DATETIME
--, @strFlightNumber		AS VARCHAR(255)  
--, @dtmTimeofDeparture	AS TIME
--, @dtmTimeOfLanding		AS TIME
--, @intFromAirportID		AS INTEGER
--, @intToAirportID		AS INTEGER
--, @intMilesFlown		AS INTEGER
--, @intPlaneID			AS INTEGER


--AS 
--SET XACT_ABORT ON --terminate and rollback if any errors
--BEGIN TRANSACTION

--	SELECT @intFlightID = MAX(intFlightID) + 1 
--		FROM TFlights (TABLOCKX) -- lock table until end of transaction
    
--		-- default to 1 if table is empty
--	SELECT @intFlightID = COALESCE(@intFlightID, 1)


--	INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,   dtmTimeofDeparture,   dtmTimeOfLanding, intFromAirportID,   intToAirportID, intMilesFlown, intPlaneID)
--				VALUES	 (@intFlightID, @dtmFlightDate, @strFlightNumber, @dtmTimeofDeparture, @dtmTimeOfLanding, @intFromAirportID, @intToAirportID, @intMilesFlown, @intPlaneID)
					
--COMMIT TRANSACTION
--GO