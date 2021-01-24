DELIMITER // 

create procedure ins_order (in id int, in acc1 int, in prod_id int, in ord_type enum("buy","sell"), in quantity float, in price float, in T time)
Begin
	DECLARE id_ch INT default 0;
	DECLARE Q float default 0;
   
	insert into tab_order1 values (id, acc1, prod_id, ord_type, quantity, price, T);

	select order_quanity_in_trade 
	from tab_order1
	where order_id = id
	into Q;
	
	if (ord_type= 'sell') then
		while ((Q>0.01) and (price < (Select max(order_price)
													From tab_order1
													Where order_type = 'buy'
														and order_product = prod_id))) do									
														
				Select max(order_id)
				From tab_order1
				where order_type = 'buy'
						and order_product = prod_id
						and 	order_price in 
							(Select max(order_price)
							From tab_order1
							where order_type = 'buy'
							and order_product = prod_id)
				into id_ch;
				
				select ch_ord (id, id_ch)
				into Q;
				
				
		End while;
	end if;
	
	if (ord_type= 'buy') then
		while ((Q>0.01) and (price > (Select min(order_price)
													From tab_order1
													Where order_type = 'sell'														
													and order_product = prod_id))) do
			 	
				Select max(order_id)
				From tab_order1
				where order_type = 'sell'
						and order_product = prod_id
						and 	order_price in 
							(Select min(order_price)
							From tab_order1
							where order_type = 'sell'
							and order_product = prod_id)
				into id_ch;
				
				select ch_ord (id, id_ch)
				into Q;
				
		End while;
	end if; 
	
	delete from tab_order1 where order_quanity_in_trade < 0.01;
	
End //