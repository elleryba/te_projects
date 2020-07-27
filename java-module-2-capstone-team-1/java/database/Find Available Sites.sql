begin transaction;

select *
        from site
        where site_id in(select site.site_id
                        from site
                        where site.site_id not in 
                                (select reservation.site_id
                                from reservation
                                where (('06-10-20', '06-15-20') overlaps (from_date, to_date)))
                         and campground_id in(select site.campground_id 
                                               from site
                                               where site.campground_id in (select campground_id
                                                                                from campground 
                                                                                where 06 >= cast(open_from_mm as Integer)
                                                                                and 06 <= cast(open_to_mm as Integer)))
                         and campground_id = 1
  ;
  rollback;     
  
  begin transaction;
  select *   
   from site   
   where site_id in (select site.site_id                    
                       from site 
                      where site.site_id not in   
                           (select reservation.site_id
                              from reservation   
                              where '06/15/2020' < to_date 
                                and '06/20/2020' > from_date))   
   and campground_id in (select site.campground_id        
                           from site 
                          where site.campground_id in (select campground_id 
                                                         from campground   
                                                        where 06 >= cast(open_from_mm as Integer)  
                                                          and 06 <= cast(open_to_mm as Integer)))  
                                                          and campground_id =   1            
   limit 5;   
   rollback;
                                                                           