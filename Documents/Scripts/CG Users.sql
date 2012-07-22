SELECT DISTINCT
	u.UserID,
	u.FirstName, 
	u.LastName, 
	u.EmailAddress
FROM
	License l
	JOIN ApplicationVersion av ON av.ApplicationVersionID = l.ApplicationVersionID
	JOIN [Application] a ON a.ApplicationID = av.ApplicationID
	JOIN [User] u ON l.UserID = u.UserID
	LEFT JOIN LicenseActivation la ON la.LicenseID = l.LicenseID
WHERE a.[Key] = 'CodeGenerator'
ORDER BY 
	u.FirstName,
	u.LastName;