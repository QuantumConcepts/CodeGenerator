SELECT
	u.UserID,
	u.FirstName, 
	u.LastName, 
	u.EmailAddress, 
	CASE
		WHEN ISNULL(COUNT(la.LicenseActivationID), 0) = 0 THEN 'No'
		ELSE 'Yes (' + CONVERT(VARCHAR, COUNT(la.LicenseActivationID)) + ')'
	END AS 'Activated',
	la.Activated
FROM
	License l
	JOIN ApplicationVersion av ON av.ApplicationVersionID = l.ApplicationVersionID
	JOIN [Application] a ON a.ApplicationID = av.ApplicationID
	JOIN [User] u ON l.UserID = u.UserID
	LEFT JOIN LicenseActivation la ON la.LicenseID = l.LicenseID
WHERE
	a.[Key] = 'CodeGenerator'
	AND u.EmailAddress NOT LIKE '%@s-3.com'
	AND u.EmailAddress <> 'devon@synasync.com'
	AND u.EmailAddress <> 'josh@quantumconceptscorp.com'
GROUP BY 
	u.UserID,
	u.FirstName, 
	u.LastName, 
	u.EmailAddress,
	la.Activated
ORDER BY 
	u.FirstName;