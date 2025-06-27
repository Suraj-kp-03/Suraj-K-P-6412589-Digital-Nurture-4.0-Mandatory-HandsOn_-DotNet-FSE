
-- This The top 3 most expensive products in each category using ROW_NUMBER() to show exactly 3 Expensive products Window Function
SELECT * FROM Products;

WITH Expensive_Product AS (
	SELECT ProductID, ProductName, Category, Price, 
	ROW_NUMBER() OVER( PARTITION BY Category ORDER BY Price DESC ) AS RowNumRank,
	RANK() OVER( PARTITION BY Category ORDER BY Price DESC ) AS NormalRank,
	DENSE_RANK() OVER( PARTITION BY Category ORDER BY Price DESC ) AS DenseRank
	FROM Products
)
SELECT  ProductID, ProductName, Category, Price, RowNumRank, NormalRank, DenseRank
FROM Expensive_Product 
WHERE RowNumRank <= 3 ORDER BY Price DESC ;

--UTLIZED CTE, AS SUB-QUERY DOES NOT SUPPORT WHERE CLAUSE
--THERE IS NOT TIES FOUND IN THIS GIVEN RELATION TABLE, SO I HAD ADDED TV, SMART TV PRODUCTS WITH PRICE 2000 EACH
--TO SHOW DIFFERENCE BETWEEN RANK() AND DENSE_RANK()
-- AFTER THE RANK() THE NORMAL RANK IS RANKED 1,1,3 IN ELECTRONICS CATEGORY AS THAT SKIPS RANK 2