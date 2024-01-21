BEGIN 
SET IDENTITY_INSERT dbo.Category ON
MERGE dbo.Category AS T 
USING	
 (
		SELECT *
		FROM (
		VALUES 
               (1, N'4dd5f372-e662-4391-acc1-50b709bbadd2', NULL, N'Music'),
               (2, N'ba7d9bd2-ba5e-4494-af80-c54bc0d2b42f', NULL, N'Movies')
		)  AS temp ([ID],[UID],[DeletedOn], [Name])
	) AS S 
ON T.[Id] = S.[Id] 
WHEN MATCHED THEN UPDATE SET 
     T.[UID] = S.[UID],
     T.[DeletedOn] = S.[DeletedOn],
     T.[Name] = S.[Name]
WHEN NOT MATCHED THEN 
INSERT 
     ([ID],[UID],[DeletedOn],[Name]) 
VALUES 
     (S.[ID],S.[UID],S.[DeletedOn],S.[Name]); 
SET IDENTITY_INSERT Category OFF 
END