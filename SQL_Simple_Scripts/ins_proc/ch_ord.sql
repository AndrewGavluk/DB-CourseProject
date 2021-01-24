
/*
	id1 - inserted
	id2 - cheked
*/
DELIMITER // 
create function ch_ord( id1 int, id2 int) returns double
Begin
		DECLARE aft1 float;
		DECLARE q1 float;
		DECLARE q2 float;
		
		select order_quanity_in_trade 
		from tab_order1
		where order_id = id1
		into q1;
		
		select order_quanity_in_trade 
		from tab_order1
		where order_id = id2
		into q2;
		
		if (q2>=q1) then 
			select 0
			into aft1;
			call make_deal_full(id1,id2);
		else
			select q1-q2
			into aft1;
		call  make_deal_part(id1,id2);
		end if;
		
		return aft1;
End//