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
   userid int REFERENCES users(user_id),
   breweryid int REFERENCES breweries(id),
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