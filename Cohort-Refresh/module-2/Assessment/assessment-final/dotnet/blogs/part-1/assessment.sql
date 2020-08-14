USE assessment;
GO

-- TASK: SELECT * that pulls from main table and where is simple

-- Select all columns from posts that are published

SELECT * FROM posts WHERE published = 1;

-- TASK: SELECT certain column on sub table and complex where, dates, null, etc.

-- Select posted_by and body from comments that have a body and were created after Oct. 15, 2019

SELECT posted_by, body FROM comments WHERE created > '2019-10-15' AND body IS NOT NULL;

-- TASK: SELECT certain columns from main table with WHERE and ORDER BY

-- Select the name and published states from posts ordered by when they were created, earliest first

SELECT name, published FROM posts ORDER BY created ASC;

-- TASK: SELECT counts from sub table with GROUP BY

-- Select the created date and the count of all the comments created on that date

SELECT created, COUNT(*) FROM comments GROUP BY created;

-- TASK: SELECT columns from main and sub using JOIN

-- Select the post name, comment posted_by and comment body for all posts created after Oct. 1st, 2019

SELECT p.name, c.posted_by, c.body FROM posts p JOIN comments c ON p.id = c.post_id WHERE p.created > '2019-10-01';