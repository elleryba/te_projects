BEGIN TRANSACTION;

INSERT INTO BEERS
(name, image, description, abv, type)
VALUES ('Elle Beer', 'pretend image', 'It is okay', '5', 1);

INSERT INTO beerbrewery
(breweryid, beerid)
VALUES (1, (SELECT beerid FROM beers WHERE name = 'Elle Beer'));

SELECT *
FROM beers
WHERE name = 'Elle Beer';

SELECT *
FROM beerbrewery
WHERE beerid = (SELECT beerid FROM beers WHERE name = 'Elle Beer');

ROLLBACK;