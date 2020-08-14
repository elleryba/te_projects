USE assessment;
GO

-- TASK: SELECT * that pulls from main table and where is simple

-- Select all the columns from communities from rows that are live

SELECT * FROM communities WHERE live = 1;

-- TASK: SELECT certain column on sub table and complex where, dates, null, etc.

-- Select the name and address from properties where the latitude is less than 0 and were created in the month of June 2019

SELECT name, address FROM properties WHERE latitude < 0 AND created >= '2019-06-01' AND created < '2019-07-01';

-- TASK: SELECT certain columns from main table with WHERE and ORDER BY

-- Select the name, latitude, and longitude from communities ordered by the created date, oldest first

SELECT name, latitude, longitude FROM communities ORDER BY created ASC;

-- TASK: SELECT counts from sub table with GROUP BY

-- Select created and a count of all the properties created on each date

SELECT created, COUNT(*) FROM properties GROUP BY created;

-- TASK: SELECT columns from main and sub using JOIN

-- Select a community's name and live status and the address of each property for every community created on or after Oct. 1st, 2019

SELECT c.name, c.live, p.address FROM communities c JOIN properties p ON c.id = p.community_id WHERE c.created >= '2019-10-01';