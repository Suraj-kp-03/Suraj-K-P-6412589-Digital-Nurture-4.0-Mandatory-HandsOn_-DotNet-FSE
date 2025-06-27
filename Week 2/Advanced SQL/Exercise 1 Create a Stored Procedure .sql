--Exercise 1: Create a Stored Procedure to retrive employee details using department id

CREATE PROCEDURE EmpDetail
@DepartmentID INT
AS
BEGIN
		SELECT EmployeeId,
			  FirstName, 
			  LastName,
		      DepartmentID,
		      Salary, 
		      JoinDate
		      FROM Employees WHERE DepartmentID = @DepartmentID;
	END;
SELECT * FROM Employees;
EXEC EmpDetail @DepartmentID = 3; 
-- Enter any existing department id to retrive the employee detail of the respecctive department.



