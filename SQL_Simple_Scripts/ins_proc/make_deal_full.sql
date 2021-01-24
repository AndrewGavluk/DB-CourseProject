DELIMITER // 

create procedure make_deal_full (in id_1 int, in id_2 int)/* q1 < q2*/
Begin
	DECLARE acc1 int;
	DECLARE acc2 int;

	DECLARE q1 float;
	DECLARE q2 float;
	DECLARE q3 float;
	
	DECLARE prod int;
	DECLARE price float;
	DECLARE T	  Time;
	
	select order_quanity_in_trade
	from tab_order1 where order_id = id_1
	into q1;
	
	select order_quanity_in_trade
	from tab_order1 where order_id = id_2
	into q2;
		
	select q2-q1
	into q3;

	select order_account_id
	from tab_order1
	where order_id = id_1
	into acc1;
	
	select order_account_id
	from tab_order1
	where order_id = id_2
	into acc2;
	
	select order_quanity_in_trade
	from tab_order1 where order_id = id_2
	into q2;
	
	select order_product
	from tab_order1
	where order_id = id_1
	into prod;
	
	select order_price
	from tab_order1
	where order_id = id_1
	into price;	
	
	select order_time_set
	from tab_order1
	where order_id = id_1
	into T;
	
	call ins_deal(acc1, acc2, prod, q1, price, T);
	
	
	update tab_order1 set order_quanity_in_trade = q3 where order_id = id_2;
	if (q2=0) then
	delete from tab_order1 where order_id = id_2;
	end if;
	delete from tab_order1 where order_id = id_1;

End //