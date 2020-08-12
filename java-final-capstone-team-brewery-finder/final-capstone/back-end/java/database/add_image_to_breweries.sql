BEGIN TRANSACTION;

ALTER TABLE breweries ADD COLUMN image varchar(528);

INSERT INTO breweries (brewery_name, history, open_from, open_to, days_open, address, image) VALUES ('Great Lakes Brewing Company', 'Two Irish brothers with limited brewing experience. A city that shuttered its last production brewery in the early 80s. A neighborhood in serious need of a facelift. In 1986 when Patrick and Daniel Conway opened their fledgling operation in Clevelands Ohio City neighborhood, the odds were stacked against them. Fortunately, they surrounded themselves with a staff of passionate, knowledgeable people, and from the start committed themselves to bringing a sophisticated, diverse selection of craft beer to their home state. Two decades, multiple awards, and a whole lot of stories later, Pat and Dan Conway celebrate over two decades of brewing exceptional beer for their adventurous and discerning customers.',
                                                                                                        'N/A', 'N/A', 'N/A', '2516 MARKET AVE, CLEVELAND, OH 44113', 'https://res.cloudinary.com/dezxt6ibb/image/upload/v1596656099/download_lhzere.png');

SELECT * FROM breweries WHERE brewery_name = 'Great Lakes Brewing Company';

ROLLBACK;