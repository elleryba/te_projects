
BEGIN TRANSACTION;
INSERT INTO reservation(site_id, name, from_date, to_date, create_date)
VALUES (394, 'Justine Myers', '2020-06-25', '2020-06-30', (current_date, 'yyyy-mm-dd'))
RETURNING reservation_id
;
ROLLBACK;



--to_char(current_date, 'mm/dd/yyyy')