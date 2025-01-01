
 --Select All Passengers
SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerFullName, strPassengerPassword 
FROM TPassengers
WHERE intPassengerLoginID = 100001

SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerFullName FROM TPassengers



SELECT intPassengerID, strFirstName, strLastName, strAddress, strCity, TStates.intStateID, strState, strZip, strPhoneNumber, strEmail
                        FROM TPassengers 
                        Join TStates
                        ON TStates.intStateID = TPassengers.intStateID
                        Where intPassengerID = 1 



--All Flights
SELECT 
	TF.intFlightID, TF.dtmFlightDate,
	FromAirport.strAirportCity + '(' + FromAirport.strAirportCode +')'+ ' - ' + ToAirport.strAirportCity+'('+ToAirport.strAirportCode +'): '  + 
		CONVERT(VARCHAR, TF.dtmFlightDate, 101) + ' at '+ CONVERT(VARCHAR, TF.dtmTimeofDeparture, 108) as strFlightName
FROM TFlights as  TF
JOIN TAirports as FromAirport 
	ON TF.intFromAirportID = FromAirport.intAirportID
JOIN TAirports as ToAirport 
	ON TF.intToAirportID = ToAirport.intAirportID
ORDER BY TF.dtmFlightDate


--Future Flights
SELECT TF.intFlightID, TF.dtmFlightDate,
		FromAirport.strAirportCity + '(' + FromAirport.strAirportCode +')'+ ' - ' + ToAirport.strAirportCity+'('+ToAirport.strAirportCode +'): '  + 
		CONVERT(VARCHAR, TF.dtmFlightDate, 101) + ' at '+ CONVERT(VARCHAR, TF.dtmTimeofDeparture, 108) as strFlightName
FROM TFlights as  TF
JOIN TAirports as FromAirport 
	ON TF.intFromAirportID = FromAirport.intAirportID
JOIN TAirports as ToAirport 
	ON TF.intToAirportID = ToAirport.intAirportID
WHERE GETDATE() <= TF.dtmFlightDate
ORDER BY TF.dtmFlightDate


--Next FlightPassenger index
SELECT max(intFlightPassengerID)+1 AS NextPrimaryKey
FROM TFlightPassengers


--Flights of Specific Passenger
SELECT *
FROM TFlightPassengers as TFP
WHERE TFP.intPassengerID = 1


--Future Flights Detailed Info of specific Passenger
SELECT TF.intFlightID,TFP.strSeat, TF.intMilesFlown,
    FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
    ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
    CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS FlightDate, 
    CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS DepartureTime,
    CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS LandingTime
	
FROM TFlights AS  TF
JOIN TAirports AS FromAirport 
	ON TF.intFromAirportID = FromAirport.intAirportID
JOIN TAirports AS ToAirport 
	ON TF.intToAirportID = ToAirport.intAirportID
JOIN TFlightPassengers as TFP
	ON tfp.intFlightID = TF.intFlightID
WHERE GETDATE() <= TF.dtmFlightDate AND TFP.intPassengerID = 1
ORDER BY TF.dtmFlightDate




--TOTAL MILES OF FUTURE FLIGHTS FOR SPECIFIC PASSENGER
SELECT SUM(intMilesFlown) as TotalMiles
FROM TFlightPassengers as TFP
JOIN TFlights as TF
	ON TF.intFlightID = TFP.intFlightID
WHERE TFP.intPassengerID = 1 AND GETDATE() <= TF.dtmFlightDate




--All Pilots
SELECT intPilotID, strFirstName + ' ' + strLastName as PilotFullName
FROM TPilots


SELECT *
FROM TPilots
JOIN TPilotRoles
ON TPilotRoles.intPilotRoleID = TPilots.intPilotRoleID



--All Attendances
SELECT intAttendantID, strFirstName + ' ' + strLastName as AttendantFullName
FROM TAttendants



-------------------------------------------------------------------------------------------------------------------------------------------------
SELECT * FROm TPASSENGERS



SELECT * FROM TEmployeeCredentials


SELECT TF.intFlightID, TF.dtmFlightDate,
		                        FromAirport.strAirportCity + '(' + FromAirport.strAirportCode +')'+ ' - ' + ToAirport.strAirportCity+'('+ToAirport.strAirportCode +'): '  + 
		                        CONVERT(VARCHAR, TF.dtmFlightDate, 101) + ' at '+ CONVERT(VARCHAR, TF.dtmTimeofDeparture, 108) as strFlightName
                        FROM TFlights as  TF
                        JOIN TAirports as FromAirport 
	                        ON TF.intFromAirportID = FromAirport.intAirportID
                        JOIN TAirports as ToAirport 
	                        ON TF.intToAirportID = ToAirport.intAirportID
                        WHERE GETDATE() <= TF.dtmFlightDate
                        ORDER BY TF.dtmFlightDate