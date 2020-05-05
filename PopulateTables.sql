MERGE INTO Bouquets AS Target 
USING (VALUES 
        (1, 'I am Sorry', 'I messed up flowers', 19.99), 
        (2, 'I Love You', 'A dozen red roses', 21.99), 
        (3, 'Just Friends', 'A Mixture of flowers', 17.99)
) 
AS Source (BouquetID, BouquetName, Description, Price) 
ON Target.BouquetID = Source.BouquetID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (BouquetName, Description, Price) 
VALUES (BouquetName, Description, Price);

MERGE INTO Flowers AS Target
USING (VALUES 
        (1, 'red rose', .75),
		(2, 'yellow rose', .65), 
		(3, 'pink rose', .70), 
		(4, 'white rose', .70), 
        (5, 'baby breath', .45), 
		(6, 'yellow tulip', .50)
)
AS Source (FlowerID, FlowerName, Price)
ON Target.FlowerID = Source.FlowerID
WHEN NOT MATCHED BY TARGET THEN
INSERT (FlowerName, Price)
VALUES (FlowerName, Price);

MERGE INTO FlowerBouquets AS Target
USING (VALUES 
(1, 1, 1, 6),
(2, 1, 3, 6),
(3, 1, 5, 2),
(4, 2, 1, 12),
(5, 2, 5, 4),
(6, 3, 1, 2),
(7, 3, 2, 2),
(8, 3, 3, 2),
(9, 3, 4, 2),
(10, 3, 5, 2),
(11, 3, 6, 1)
)
AS Source (FlowerBouquetID, BouquetID, FlowerID, Quantity)
ON Target.FlowerBouquetID = Source.FlowerBouquetID
WHEN NOT MATCHED BY TARGET THEN
INSERT (BouquetID, FlowerID, Quantity)
VALUES (BouquetID, FlowerID, Quantity);