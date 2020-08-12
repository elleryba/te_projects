DROP TABLE breweries;

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



INSERT INTO breweries (brewery_name,history,open_from,open_to,days_open,address) VALUES ('First Brews','Home of the brews, first, we were first.','7:00am','2:00am','Sun-Sat','123 First St');
INSERT INTO breweries (brewery_name,history,open_from,open_to,days_open,address) VALUES ('Second Brews','House of the brews, second, we were second.','7:00am','2:00am','Sun-Sat','124 First St');

SELECT * FROM breweries;

