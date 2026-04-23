-- Created by GitHub Copilot in SSMS - review carefully before executing

INSERT INTO dbo.Members
(
    Name_FirstName,
    Name_LastName,
    PersonalInfo_Address_Street,
    PersonalInfo_Address_StreetNumber,
    PersonalInfo_Address_City,
    PersonalInfo_Address_Country,
    PersonalInfo_Contact_Email,
    PersonalInfo_Contact_PhoneNumber,
    PersonalInfo_DateOfBirth,
    PersonalInfo_ParentName_FirstName,
    PersonalInfo_ParentName_LastName,
    TraineeInfo_Rank,
    TraineeInfo_Belt,
    TraineeInfo_Role,
    TraineeInfo_DateOfJoining,
    TraineeInfo_AikidoId,
    IsActive,
    DojoId
)
VALUES
('Hiroshi', 'Tanaka', '123 Maple Street', 456, 'Tokyo', 'Japan', 'hiroshi@example.com', '555-0101', '1995-03-15', NULL, NULL, 0, 'White', 'Trainee', '2023-01-10', 'A001', 1, NULL),
('Emma', 'Johnson', '456 Oak Avenue', 789, 'London', 'United Kingdom', 'emma@example.com', '555-0102', '1998-07-22', 'Margaret', 'Johnson', 5, 'White', 'Trainee', '2022-06-15', 'A002', 1, NULL),
('Kenji', 'Yamamoto', '789 Pine Road', 234, 'Osaka', 'Japan', 'kenji@example.com', '555-0103', '2000-11-30', NULL, NULL, 2, 'White', 'Trainee', '2023-09-20', 'A003', 1, NULL),
('Sofia', 'Garcia', '321 Elm Street', 567, 'Madrid', 'Spain', 'sofia@example.com', '555-0104', '1996-05-18', 'Rosa', 'Garcia', 8, 'Black', 'Trainee', '2021-03-05', 'A004', 1, NULL),
('Lucas', 'Silva', '654 Birch Lane', 890, 'São Paulo', 'Brazil', 'lucas@example.com', '555-0105', '1999-02-14', NULL, NULL, 3, 'White', 'Trainee', '2022-11-12', 'A005', 1, NULL),
('Yuki', 'Nakamura', '987 Cedar Drive', 123, 'Kyoto', 'Japan', 'yuki@example.com', '555-0106', '2001-09-25', 'Akiko', 'Nakamura', 1, 'White', 'Trainee', '2024-01-08', 'A006', 1, NULL),
('Alejandra', 'Martinez', '147 Spruce Court', 345, 'Barcelona', 'Spain', 'alejandra@example.com', '555-0107', '1997-12-07', NULL, NULL, 6, 'Black', 'Trainee', '2020-05-20', 'A007', 1, NULL),
('Daisuke', 'Sato', '258 Ash Boulevard', 678, 'Fukuoka', 'Japan', 'daisuke@example.com', '555-0108', '1994-08-19', NULL, NULL, 10, 'Black', 'Trainee', '2019-02-10', 'A008', 1, NULL),
('Isabella', 'Rossi', '369 Walnut Street', 901, 'Rome', 'Italy', 'isabella@example.com', '555-0109', '2002-04-11', 'Francesca', 'Rossi', 0, 'White', 'Trainee', '2023-08-30', 'A009', 1, NULL),
('Marcus', 'Weber', '741 Hickory Way', 234, 'Berlin', 'Germany', 'marcus@example.com', '555-0110', '1993-10-03', NULL, NULL, 4, 'White', 'Trainee', '2022-10-25', 'A010', 1, NULL);

ALTER TABLE Members
ALTER COLUMN PersonalInfo_Address_StreetNumber nvarchar(max) NOT NULL;

INSERT INTO dbo.Organizations
(
    Name,
    PresidentId,
    Contact_Email,
    Contact_PhoneNumber,
    Address_Street,
    Address_StreetNumber,
    Address_City,
    Address_Country
)
VALUES
('Central Aikido Dojo', 9, 'contact@central-aikido.com', '555-0201', '100 Main Street', 100, 'Tokyo', 'Japan'),
('East Side Aikido Club', 6, 'info@eastside-aikido.com', '555-0202', '250 Oak Avenue', 250, 'Osaka', 'Japan');


-- Step 1: Delete existing data
DELETE FROM dbo.Organizations;

-- Step 2: Alter the column data type
ALTER TABLE dbo.Organizations
ALTER COLUMN Address_StreetNumber nvarchar(max) NOT NULL;

-- Step 3: Re-insert the data with street numbers as text
INSERT INTO dbo.Organizations
(
    Name,
    PresidentId,
    Contact_Email,
    Contact_PhoneNumber,
    Address_Street,
    Address_StreetNumber,
    Address_City,
    Address_Country
)
VALUES
('Central Aikido Dojo', 12, 'contact@central-aikido.com', '555-0201', '100 Main Street', '100', 'Tokyo', 'Japan'),
('East Side Aikido Club', 9, 'info@eastside-aikido.com', '555-0202', '250 Oak Avenue', '250', 'Osaka', 'Japan');

INSERT INTO [DojoAppDB].[dbo].[Dojos]
       ([Name],
        [Contact_Email],
        [Contact_PhoneNumber],
        [Address_Street],
        [Address_StreetNumber],
        [Address_City],
        [Address_Country],
        [DojoChoId],
        [OrganizationId])
VALUES ('Central Dojo',
        'centraldojo@example.com',
        '+381234567',
        'Main Street',
        '12',
        'Novi Sad',
        'Serbia',
        9,   -- Member Id (dojocho)
        1);   -- Organization Id

INSERT INTO [DojoAppDB].[dbo].[Dojos]
       ([Name],
        [Contact_Email],
        [Contact_PhoneNumber],
        [Address_Street],
        [Address_StreetNumber],
        [Address_City],
        [Address_Country],
        [DojoChoId],
        [OrganizationId])
VALUES ('West Dojo',
        'westdojo@example.com',
        '+381987654',
        'West Avenue',
        '9',
        'Belgrade',
        'Serbia',
        6,    -- Member Id (dojocho)
        2);   -- Organization Id
DELETE FROM [DojoAppDB].[dbo].[Dojos];

ALTER TABLE [DojoAppDB].[dbo].[Dojos]
ALTER COLUMN [Address_StreetNumber] NVARCHAR(50) NOT NULL;
