USE assessment;
GO

-- TASK: SELECT * that pulls from main table and where is simple

-- Select all columns from users where the user's role is admin

SELECT * FROM users WHERE role = 'admin';

-- TASK: SELECT certain column on sub table and complex where, dates, null, etc.

-- Select name and description from items that were created after Sept. 20, 2019 and the description isn't null

SELECT name, description FROM items WHERE created > '2019-09-20' AND description IS NOT NULL;

-- TASK: SELECT certain columns from main table with WHERE and ORDER BY

-- Select first_name and last_name from users and order by when they were created, latest first

SELECT first_name, last_name FROM users ORDER BY created DESC;

-- TASK: SELECT counts from sub table with GROUP BY

-- Select finished and a count all the items that are finished/not finished

SELECT finished, COUNT(*) FROM items GROUP BY finished;

-- TASK: SELECT columns from main and sub using JOIN

-- Select a user's first_name and last_name and the item's name for every finished item

SELECT u.first_name, u.last_name, i.name FROM users u JOIN items i ON u.id = i.user_id WHERE i.finished = 1;
