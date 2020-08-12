BEGIN TRANSACTION;

UPDATE breweries SET brewery_name = 'First Brews', history = 'Jibber jabber', open_from = 'Dawn', open_to = 'Dusk', days_open = 'Monday', address = 'Earth' WHERE id = 1;

SELECT * FROM breweries WHERE id = 1;

ROLLBACK;

BEGIN TRANSACTION;

UPDATE breweries SET (brewery_name, history, open_from, open_to, days_open, address) VALUES ('First Brews', 'Jibber jabber', 'Dawn', 'Dusk', 'Monday', 'Earth')  WHERE id = 1;

SELECT * FROM breweries WHERE id = 1;

ROLLBACK;