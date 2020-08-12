DROP TABLE IF EXISTS beers cascade;
DROP TABLE IF EXISTS beerbrewery cascade;
DROP TABLE IF EXISTS beertypes cascade;
DROP TABLE IF EXISTS beertyperelator cascade;
DROP TABLE IF EXISTS reviews cascade;
DROP TABLE IF EXISTS beersreviews cascade;
DROP TABLE IF EXISTS usersbreweries cascade;
DROP TABLE IF EXISTS breweries cascade;

CREATE TABLE breweries(
   id SERIAL,
   brewery_name VARCHAR(64),
   history VARCHAR(3600),
   open_from VARCHAR(16),
   open_to VARCHAR(16),
   days_open VARCHAR(16),
   address VARCHAR(64),
   PRIMARY KEY(id)
);

CREATE TABLE usersbreweries(
   id SERIAL,
   userid int,
   breweryid int,
   CONSTRAINT usersbreweries_pkey PRIMARY KEY (userid, breweryid)
   );


CREATE TABLE beertypes(
   typeid SERIAL,
   type varchar(32),
   description varchar(128),
   PRIMARY KEY(typeid)
);

CREATE TABLE beers(
   beerid SERIAL,
   name varchar(32),
   image varchar(256),
   description varchar(256),
   abv varchar(12),
   type int,
   
  CONSTRAINT pk_beerid PRIMARY KEY(beerid),
   FOREIGN KEY(type) REFERENCES beertypes(typeid)
);

CREATE TABLE reviews(
   reviewid serial,
   rating int,
   review varchar(3600),
   
   primary key(reviewid)
   );
   
CREATE TABLE beersreviews(
   beerid int REFERENCES beers(beerid),
   reviewid int REFERENCES reviews(reviewid),

   CONSTRAINT beersreviews_pkey PRIMARY KEY (beerid, reviewid)
);

CREATE TABLE beerbrewery(
   breweryid int REFERENCES breweries(id),
   beerid int REFERENCES beers(beerid),
   
   CONSTRAINT beerbrewery_pkey PRIMARY KEY(breweryid, beerid)
   
);

CREATE TABLE beertyperelator(
   typeid int REFERENCES beertypes(typeid),
   beerid int REFERENCES beers(beerid),
   
   CONSTRAINT beertyperelator_pkey PRIMARY KEY(typeid, beerid)
   
);




INSERT INTO beertypes (type, description) VALUES ('IPA', 'Imperial Pale Ale'); -- 1
INSERT INTO beertypes (type, description) VALUES ('Ale', 'Something');         -- 2
INSERT INTO beertypes (type, description) VALUES ('Pilsner', 'Pils');          -- 3
INSERT INTO beertypes (type, description) VALUES ('Lager', 'For loggers');     -- 4
INSERT INTO beertypes (type, description) VALUES ('Sour', 'Pucker up');        -- 5
INSERT INTO beertypes (type, description) VALUES ('Wheat', 'Smooth');          -- 6
INSERT INTO beertypes (type, description) VALUES ('Fruit', 'tooty');           -- 7

INSERT INTO beers (name, image, description, type) VALUES ('Stella Artois', 'www.stella.com', 'has its own special glass', 3);
INSERT INTO beers (name, image, description, type) VALUES ('Pile Driver', 'www.pdbeer.com', 'Drives it home', 1);
INSERT INTO beers (name, image, description, type) VALUES ('Warhead', 'www.supersour.com', 'Will get your lips twisted', 5);
INSERT INTO beers (name, image, description, type) VALUES ('Ale', 'www.ale.com', 'Its an ale', 2);
INSERT INTO beers (name, image, description, type) VALUES ('Coors', 'www.coors.com', 'Ride the bullet', 4);
INSERT INTO beers (name, image, description, type) VALUES ('Bud', 'www.budweiser.com', 'Standard american swill', 2);

INSERT INTO beerbrewery (beerid, breweryid) VALUES (1, 1);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (1, 2);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (1, 3);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (2, 2);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (2, 3);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (3, 1);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (3, 2);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (3, 3);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (4, 1);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (4, 3);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (5, 1);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (5, 2);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (5, 3);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (6, 1);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (6, 2);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (6, 3);

INSERT INTO beertyperelator (beerid, typeid) VALUES (1, 3);
INSERT INTO beertyperelator (beerid, typeid) VALUES (2, 1);
INSERT INTO beertyperelator (beerid, typeid) VALUES (3, 5);
INSERT INTO beertyperelator (beerid, typeid) VALUES (4, 2);
INSERT INTO beertyperelator (beerid, typeid) VALUES (5, 4);
INSERT INTO beertyperelator (beerid, typeid) VALUES (6, 2);

UPDATE beers SET abv = '5.5' WHERE beerid = 1;
UPDATE beers SET abv = '2.4' WHERE beerid = 2;
UPDATE beers SET abv = '7.9' WHERE beerid = 3;
UPDATE beers SET abv = '1.5' WHERE beerid = 4;
UPDATE beers SET abv = '3.4' WHERE beerid = 5;
UPDATE beers SET abv = '4.0' WHERE beerid = 6;

SELECT * FROM beers b
        INNER JOIN beerbrewery bb 
        ON bb.beerid = b.beerid
        INNER JOIN breweries brew
        ON bb.breweryid = brew.id
        WHERE brew.brewery_name = 'this';



        
        
SELECT * FROM beerbrewery;
SELECT * FROM beertyperelator;
SELECT * FROM beertypes;

Select id from breweries where brewery_name = 'two';

INSERT INTO reviews (rating, review) VALUES (4,'it was bitter');
INSERT INTO beersreviews(reviewid, beerid) VALUES (1, 1);

