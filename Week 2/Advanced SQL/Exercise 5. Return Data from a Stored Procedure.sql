--procedure that returns the total number of employees in a department.
CREATE PROCEDURE CountOfEmp
	@DepartmentID INT
	AS
	BEGIN
		SELECT COUNT(*) AS EmployeeCount,DepartmentName
		FROM Employees e 
		JOIN Departments d ON d.DepartmentID = e.DepartmentID --JOINING THE TABLE USING THE REFERERNCE KEYS TO GET THE NAME OF THE DEPARTMENT TO BE DISPLAYED
		WHERE e.DepartmentID = @DepartmentID 
		GROUP BY DepartmentName;
	END;

SELECT * FROM Employees;    --DISPLAYING EMPLOYEE DETAILS
SELECT * FROM Departments;  --DISPLAYING DEPARTMENT DEATILS
EXEC CountOfEmp 3; --EXECUTING THE PROCEDURE
