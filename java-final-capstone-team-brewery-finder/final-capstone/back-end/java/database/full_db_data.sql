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
   image varchar(1500),
   description varchar(1500),
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

--BEGIN TRANSACTION;

INSERT INTO breweries (brewery_name,history,open_from,open_to,days_open,address) 
VALUES 
('Noble Beast Brewing Co.','Following the model of a traditional brewpub, Noble Beast Brewing Co. showcases ridiculously delicious beer alongside innovative food. Started by Shaun Yasaki in 2017 this 10BBL brewhouse puts a heavy focus pairing beer with bites.','11:30am','10:00pm','Tues-Sun','1470 Lakeside Ave E, Cleveland, OH 44114'),
('Masthead Brewing Co.','Located in the historic Bryant Building, Masthead Brewing Co. combines the history of Cleveland with historically well-brewed beer. Co-founders Frank Luther, Matt Slife, and Mike Pelechaty named their brewery after a little local lore.','12:00pm','09:00pm','Tues-Sun','1261 Superior Ave, Cleveland, OH 44114'),
('Terrestrial Brewing','For small-batch beers with a view, stop by Terrestrial Brewing Co. Situated right on the banks of Lake Erie in the Battery Park neighborhood, Terrestrial is the brainchild of co-founders Ryan Bennett and Ralph Sgro.','04:00pm','10:00pm','Mon-Sun','7524 Father Frascati, Cleveland, OH 44102'),
('Saucy Brew Works','Born and brewed in the land, Saucy Brew Works started when two beer fanatics — Brew Master Eric Anderson and Entrepreneur Brent Zimmerman — teamed up to turn the Steelman Building into a killer brewery.','11:00am','10:00pm','Mon-Sun','2885 Detroit Ave, Cleveland, OH 44113'),
('Bookhouse Brewing','If you’re going to win at trivia, you’ll probably need to brush up on your summer reading. For a brewery that combines pages and pints turn to Bookhouse Brewing, a small taproom in Cleveland’s Ohio City neighborhood (not to be confused with Denver’s Fiction Beer Company, another literary favorite!).','12:00pm','09:00pm','Thurs-Sun','1526 W 25th St, Cleveland, OH 44113');

INSERT INTO beertypes (type, description) VALUES ('IPA', 'India Pale Ale, Hoppy');              -- 1
INSERT INTO beertypes (type, description) VALUES ('Ale', 'Bitter, Higher Alcoholic Content');   -- 2
INSERT INTO beertypes (type, description) VALUES ('Pilsner', 'Pale Lager');                     -- 3
INSERT INTO beertypes (type, description) VALUES ('Lager', 'Pale, Amber, or Dark');             -- 4
INSERT INTO beertypes (type, description) VALUES ('Sour', 'Acidic, Tart, or Sour');             -- 5
INSERT INTO beertypes (type, description) VALUES ('Wheat', 'Hazy, Citrusy, and Full');          -- 6
INSERT INTO beertypes (type, description) VALUES ('Fruit', 'Refreshing');                       -- 7
INSERT INTO beertypes (type, description) VALUES ('Hefeweizen', 'Fruity & Spicy');              -- 8
INSERT INTO beertypes (type, description) VALUES ('Barleywine', 'Strong Ale');                  -- 9

INSERT INTO beers (name, image, description, abv, type) VALUES ('Union Pils Bohemian Lager', 'https://contattafiles.s3.us-west-1.amazonaws.com/tecommunity/LwozM4GyHweuMz9/Pasted%20Image%3A%20Aug%207%2C%202020%20-%2010%3A20%3A01am', 'Traditionally brewed with a double-decoction mash to enhance malt flavor and balanced with Czech Saaz hops for a delightfully floral and spicy aroma. Lagered horizontally for two months for clarity of flavor. Light yet full of character.', '4.9%', 4);
INSERT INTO beers (name, image, description, abv, type) VALUES ('Electrolier Hopfenweisse', 'https://contattafiles.s3.us-west-1.amazonaws.com/tecommunity/kwekJQV5rYttZNh/Pasted%20Image%3A%20Aug%207%2C%202020%20-%2010%3A20%3A50am', 'A Bavarian-style Hefeweizen brewed with a hoppy twist. One big addition of Mosaic hops in the whirlpool lend tropical fruit flavors that blend seamlessly with the traditional banana/clove character. A decoction mash brings out the bready character of malted wheat in this Summer refresher.', '5.4%', 8);
INSERT INTO beers (name, image, description, abv, type) VALUES ('We Don''t Rat, We Don''t Run', 'https://contattafiles.s3.us-west-1.amazonaws.com/tecommunity/zBjydZ4YLVjpP5i/Pasted%20Image%3A%20Aug%207%2C%202020%20-%2010%3A21%3A03am', '15.3% ABV. Very limited. Foeder-aged English-style barleywine. Aged 13 months in a fresh oak foeder. Rich notes of raison, toffee, oaky vanilla, fig, and winey grapes. Designed to be aged up to 25 years. This is the first release of many to come from our foeder-aged barleywine Solera project. Vintage 2021 will be a blend of 1 and 2 year aged BW, so on and so forth...', '15.3%', 9);

INSERT INTO beers (name, image, description, abv, type) VALUES ('Oktoberfest', 'https://contattafiles.s3.us-west-1.amazonaws.com/tecommunity/cKVsaPcTQ8hhr48/Pasted%20Image%3A%20Aug%207%2C%202020%20-%2010%3A21%3A43am', 'A malt-forward German Lager brewed for the fall festival season. Only the finest German malt and hops are used to produce a sessionable yet flavorful lager that will make you think you are standing on a table dressed in Lederhosen (or a Dirndl) swinging a bierstein in Munich. Prost!', '5.7%', 4);
INSERT INTO beers (name, image, description, abv, type) VALUES ('Space Vibes', 'https://i.embed.ly/1/image?url=https%3A%2F%2Fcontattafiles.s3.us-west-1.amazonaws.com%2Ftecommunity%2F4MwEjOb4MFn1MUF%2FPasted%2BImage%3A%2BAug%2B7%2C%2B2020%2B-%2B10%3A22%3A07am&key=c0f258539b9c4ab5bf044cd294d74ff1', 'East and West Coasts collide, launching Ohio into the ether like a cosmic pinball. Amidst the darkness of space, a lone rider appears, carving through the cosmic debris toward alternate realities in which IPAs are anything they want to be. This West Coast Imperial IPA vibe check: far out.', '8.5%', 1);
INSERT INTO beers (name, image, description, abv, type) VALUES ('Falling Fruit', 'https://contattafiles.s3.us-west-1.amazonaws.com/tecommunity/hkdbhoZoafiL5Po/Pasted%20Image%3A%20Aug%207%2C%202020%20-%2010%3A22%3A43am', 'We set out to create a beer that showcases two of our favorite fruits: tart apples and sweet peaches. We fermented it on the fruit with one of our favorite yeasts to give it a juicy character, pleasant body, and just enough sweetness to evoke memories of biting into a fresh peach or apple.', '5.8%', 7);

INSERT INTO beers (name, image, description, abv, type) VALUES ('Rum Barrel Aged Painkiller Sour', 'https://untappd.akamaized.net/photos/2019_10_25/bbf461f633d783b703770dd9cefc7329_640x640.jpg', 'Fresh Pineapple, Orange and Coconut combined with a Sour Base Beer Aged in a Southern American Rum Barrel for 9 Months. Inspired by one of our favorite cocktails.', '9%', 5);
INSERT INTO beers (name, image, description, abv, type) VALUES ('More: Citra', 'https://pbs.twimg.com/media/Edt45-lXkAIuvp7.jpg', 'Brewed with 100% Citra hops, this beer has dank aromas of grapefruit and tropical fruits with a full-bodied, pillowy finish.', '10.5%', 1);
INSERT INTO beers (name, image, description, abv, type) VALUES ('Time Loop', 'https://untappd.akamaized.net/photos/2020_07_25/0e7428d7f5ff88612b72c03e5940e6da_640x640.jpg', 'Brewed in the traditional West Coast IPA style (member?). The spotlight in this one is shone on the resinous qualities of Nugget hops combined with the dank and fruity character of Citra hops. The finish is dry with a friendly, bitter bite.', '7.4%', 1);

INSERT INTO beers (name, image, description, abv, type) VALUES ('IPA ASAP', 'https://dttsunami.blob.core.windows.net/beer/logo/948d3ca5-3bcd-4392-b40e-64e39b16e6cb.jpeg', 'Crisp, dry and citrusy with a lingering bitterness', '6.3%', 1);
INSERT INTO beers (name, image, description, abv, type) VALUES ('That''s My Jam Strawberry', 'https://pbs.twimg.com/media/EZCSH_tXsAE2Ia7.jpg', 'Brilliant Blonde Ale meets a ludicrous amount of Red Raspberry. Bubbly, refreshing and not overly sweet', '4.9%', 2);
INSERT INTO beers (name, image, description, abv, type) VALUES ('Keller Boots, Man', 'https://untappd.akamaized.net/photos/2019_09_29/fbf3126ff589c450a69dc9310cabfd9d_640x640.jpg', 'German-style Lager is unfiltered and dry hopped. Bright yellow with a tight white head, notes of fresh citrus, crackers and honeydew with a classic, clean German finish.', '5%', 4);

INSERT INTO beers (name, image, description, abv, type) VALUES ('Magdalena', 'https://bookhouse-brewing-llc.square.site/uploads/1/2/6/2/126287558/s706640680989578270_p182_i1_w2560.jpeg', 'Named for the proprietor of the Baehr Brewery from 1873-1898, Magdalena, this classic pre-prohibition style pilsener is a window into the past of Cleveland''s brewing history. Though by historical standards it would be considered an "Export" pilsner, due to the slightly amplified alcohol content, flavor, and aroma, it bears similarity to what was being brewed at the time. Made with US 6-row barley (a version of barley that grows more readily in the US climate, which is warmer than most of Europe), American hops, and corn, this fine lager is balanced, refreshing, and moreish. Clean lager yeast, a hint of apple skin, floral and peppery hops, and a concise dry finish make for an eminently drinkable pint.', '5.5%', 3);
INSERT INTO beers (name, image, description, abv, type) VALUES ('Lil'' Whoopsie!', 'https://bookhouse-brewing-llc.square.site/uploads/1/2/6/2/126287558/s706640680989578270_p222_i1_w1512.jpeg', 'What happens when you take a beloved beer, mess with it a lil'' bit, and end up with something that might just be an improvement? You call it Lil'' Whoopsie! Or at least, that''s been our method. This iteration in our ongoing quest to discover new and interesting variations in method and madness to pile hop aroma and flavor into your flavor savor comes courtesy of a wheat-based (instead of oat-based) approach to malt, and a slightly more subtle hop load, to keep the lower alcohol content from being overwhelmed with intensity. Think of it as an every day blaster; armed to the gills with ripe tropical fruits, a touch of herbal citrus, and a soft, pillowy finish. Have a Lil'' Whoopsie! and cut yourself some slack.', '5.6%', 2);
INSERT INTO beers (name, image, description, abv, type) VALUES ('Jacob Bavarian Hefeweizen', 'https://bookhouse-brewing-llc.square.site/uploads/1/2/6/2/126287558/s706640680989578270_p269_i1_w1081.jpeg', 'Jacob Baehr was the proprietor of the Baehr Brewery, built in 1866, in order to serve his fellow German immigrants in Ohio City. Bookhouse now occupies a portion of his former brewery, so we thought it was only fitting to pay tribute to a style of beer that reflects brewing history. This classic Bavarian-style Hefeweizen has intense aromas of clove, pineapple, banana, and a bit of doughy bread. The complexity of flavor and aroma comes from the classic yeast strain that truly adds a unique character to this delicious wheat-driven ale.', '5.6%', 8);

INSERT INTO beerbrewery (beerid, breweryid) VALUES (1, 1);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (2, 1);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (3, 1);

INSERT INTO beerbrewery (beerid, breweryid) VALUES (4, 2);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (5, 2);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (6, 2);

INSERT INTO beerbrewery (beerid, breweryid) VALUES (7, 3);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (8, 3);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (9, 3);

INSERT INTO beerbrewery (beerid, breweryid) VALUES (10, 4);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (11, 4);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (12, 4);

INSERT INTO beerbrewery (beerid, breweryid) VALUES (13, 5);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (14, 5);
INSERT INTO beerbrewery (beerid, breweryid) VALUES (15, 5);

INSERT INTO beertyperelator (beerid, typeid) VALUES (1, 4);
INSERT INTO beertyperelator (beerid, typeid) VALUES (2, 8);
INSERT INTO beertyperelator (beerid, typeid) VALUES (3, 9);

INSERT INTO beertyperelator (beerid, typeid) VALUES (4, 4);
INSERT INTO beertyperelator (beerid, typeid) VALUES (5, 1);
INSERT INTO beertyperelator (beerid, typeid) VALUES (6, 7);

INSERT INTO beertyperelator (beerid, typeid) VALUES (7, 5);
INSERT INTO beertyperelator (beerid, typeid) VALUES (8, 1);
INSERT INTO beertyperelator (beerid, typeid) VALUES (9, 1);

INSERT INTO beertyperelator (beerid, typeid) VALUES (10, 1);
INSERT INTO beertyperelator (beerid, typeid) VALUES (11, 2);
INSERT INTO beertyperelator (beerid, typeid) VALUES (12, 4);

INSERT INTO beertyperelator (beerid, typeid) VALUES (13, 3);
INSERT INTO beertyperelator (beerid, typeid) VALUES (14, 2);
INSERT INTO beertyperelator (beerid, typeid) VALUES (15, 8);

INSERT INTO reviews (rating, review) VALUES (4,'Not a very complex flavor profile, but very spot on and tasty. Has a crisp, also smooth and frothy, light to medium bodied mouthfeel with moderate carbonation. Has a clean finish.');
INSERT INTO reviews (rating, review) VALUES (4,'The melon hop flavors add a nice, unique taste to the flavor profile for this style of of beer. Has a crisp, yet smooth and frothy, medium bodied mouthfeel with moderate carbonation. Has a clean, slightly sweet and spicy finish and aftertaste. Easy to drink in the way good beer beer ought to be!');
INSERT INTO reviews (rating, review) VALUES (3,'This is a challenging beer. I feel like it needs age. The nose is boozy and vinous, is that from the wine yeast? Palate is slick and sorta oily, offering lots of fruit, leathery oak, and toffee. The finish is a touch dry.');
INSERT INTO reviews (rating, review) VALUES (3,'Taste is sweet and bready, almost banana-like, with Brazil and macadamia nut and a bitter, grassy pine finish before a toasty exhale.');
INSERT INTO reviews (rating, review) VALUES (4,'Taste is sweet pineapple, melon and pine.Finishes dry and slightly bitter. Simple, clean and just plain good. Drinks like a single IPA. Recommended.');
INSERT INTO reviews (rating, review) VALUES (3,'Hints of fruit when ice cold but when it warms up even in the slightest it loses all flavor.');
INSERT INTO reviews (rating, review) VALUES (5,'Painkiller cocktail in a glass!');
INSERT INTO reviews (rating, review) VALUES (3,'Seems more like a sour than a hazy ipa, decent');
INSERT INTO reviews (rating, review) VALUES (4,'Terrestrial does not disappoint. Balanced and slightly bitter, just like I like ''em!');
INSERT INTO reviews (rating, review) VALUES (3,'Crisp, dry and citrusy with a lingering bitterness.');
INSERT INTO reviews (rating, review) VALUES (4,'Very berry yum!');
INSERT INTO reviews (rating, review) VALUES (3,'Calling this a lager seems a stretch, pretty hoppy.');
INSERT INTO reviews (rating, review) VALUES (4,'I completely avoid pilsners, unless it''s this one.');
INSERT INTO reviews (rating, review) VALUES (4,'A little on the high end of ABV for a Session IPA, but still light for a true American IPA. It has a little West Coast bitter and a little East Coast juicy. Kind of stuck in between. Interesting!');
INSERT INTO reviews (rating, review) VALUES (4,'This is a damn fine Hefeweizen, on par with the world''s greatest. Drank it recently after the Weihenstephan, and this one fresh is hard to beat. Bravo.');

INSERT INTO beersreviews(reviewid, beerid) VALUES (1, 1);
INSERT INTO beersreviews(reviewid, beerid) VALUES (2, 2);
INSERT INTO beersreviews(reviewid, beerid) VALUES (3, 3);
INSERT INTO beersreviews(reviewid, beerid) VALUES (4, 4);
INSERT INTO beersreviews(reviewid, beerid) VALUES (5, 5);
INSERT INTO beersreviews(reviewid, beerid) VALUES (6, 6);
INSERT INTO beersreviews(reviewid, beerid) VALUES (7, 7);
INSERT INTO beersreviews(reviewid, beerid) VALUES (8, 8);
INSERT INTO beersreviews(reviewid, beerid) VALUES (9, 9);
INSERT INTO beersreviews(reviewid, beerid) VALUES (10, 10);
INSERT INTO beersreviews(reviewid, beerid) VALUES (11, 11);
INSERT INTO beersreviews(reviewid, beerid) VALUES (12, 12);
INSERT INTO beersreviews(reviewid, beerid) VALUES (13, 13);
INSERT INTO beersreviews(reviewid, beerid) VALUES (14, 14);
INSERT INTO beersreviews(reviewid, beerid) VALUES (15, 15);

--ROLLBACK;
