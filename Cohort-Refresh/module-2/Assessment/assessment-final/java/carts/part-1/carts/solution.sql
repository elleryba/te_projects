-- TASK: SELECT * that pulls from main table and where is simple

-- Select all the columns in cart where the username is kmilner1j

SELECT * FROM carts WHERE username = 'kmilner1j';

-- TASK: SELECT certain column on sub table and complex where, dates, null, etc.

-- Select the id and name columns from items where the item was added on or after Jan. 15, 2019 and the weight is null

SELECT id, name FROM items WHERE added >= '2019-01-15' AND weight IS NULL;

-- TASK: SELECT certain columns from main table with WHERE and ORDER BY

-- Select username and the cookie_value from carts where the username isn't null, ordered by the created date, latest first

SELECT username, cookie_value FROM carts WHERE username IS NOT NULL ORDER BY created DESC;

-- TASK: SELECT counts from sub table with GROUP BY

-- Select the added date and the count of all the items added on that date

SELECT added, COUNT(*) FROM items GROUP BY added;

-- TASK: SELECT columns from main and sub using JOIN

-- Select the cart's username and created date and the item's name for all carts created in the month of Sept. 2019

SELECT c.username, c.created, i.name FROM carts c JOIN items i ON c.id = i.cart_id WHERE c.created >= '2019-09-01' AND c.created < '2019-10-01';