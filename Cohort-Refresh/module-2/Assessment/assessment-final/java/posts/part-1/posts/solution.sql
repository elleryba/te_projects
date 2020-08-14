-- TASK: SELECT * that pulls from main table and where is simple

-- Select every column from users where the user's role is manager

SELECT * FROM users WHERE role = 'manager';

-- TASK: SELECT certain column on sub table and complex where, dates, null, etc.

-- Select name and created from posts where the post's body isn't null and the post was created in Aug. 2019

SELECT name, created FROM posts WHERE created >= '2019-08-01' AND created < '2019-09-01' AND body IS NOT NULL;

-- TASK: SELECT certain columns from main table with WHERE and ORDER BY

-- Select first_name and email from users, ordered by created, latest first

SELECT first_name, email FROM users ORDER BY created DESC;

-- TASK: SELECT counts from sub table with GROUP BY

-- Select published date from posts and a count of all the posts published/not published

SELECT published, COUNT(*) FROM posts GROUP BY published;

-- TASK: SELECT columns from main and sub using JOIN

-- Select the user's first_name, last_name, and email and the name of the post for all posts created after Oct. 1st 2019

SELECT u.first_name, u.last_name, u.email, p.name FROM users u JOIN posts p ON u.id = p.user_id WHERE p.created > '2019-10-01';