USE CoffeeShop;
/*
CREATE DATABASE CoffeeShop;

DROP TABLE Item;

CREATE TABLE Customer(
	CustomerID INT IDENTITY(1001,1),
	CustomerName VARCHAR(255) NOT NULL,
	ContactNo VARCHAR(255),
	Address VARCHAR(255)
	CONSTRAINT PK_Customer PRIMARY KEY (CustomerId)
);

CREATE TABLE Item(
	ItemID INT IDENTITY(101,2),
	ItemName VARCHAR(255) NOT NULL UNIQUE,
	ItemPrice INT NOT NULL DEFAULT 10
	CONSTRAINT PK_Item PRIMARY KEY (ItemID)
);

DROP TABLE CustomerOrder;

CREATE TABLE CustomerOrder(
	CustomerOrderID INT IDENTITY(101,1),
	CustomerID INT,
	ItemID INT,
	Quantity INT DEFAULT 1,
	
	CONSTRAINT PK_Order PRIMARY KEY (CustomerOrderID),
	CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerID),
	CONSTRAINT FK_Order_Item FOREIGN KEY (ItemId) REFERENCES Item(ItemID)
	
);

*/


INSERT INTO Customer ( CustomerName, ContactNo, Address ) VALUES ( 'Maruf', 123, '25/A WestShewrapara' );

DELETE FROM Customer WHERE CustomerName = 'Maruf';

SELECT COUNT(CustomerID) FROM Customer WHERE CustomerName = 'MaruF';

SELECT * FROM Customer;