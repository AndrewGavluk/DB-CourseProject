DELIMITER //
create procedure Show_prices (in instument int,
										in limit_ int)
Begin
		declare start_buy int default 0;
		declare stop_buy int default 0;
		declare start_sell int default 0;
		declare stop_sell int default 0;
		
		select count(*)
		from tab_order1
		where order_product = instument
			and order_type ='buy'
		order by order_price
		into stop_buy;
		
		if (stop_buy > limit_) then
			 select stop_buy-limit_
			 into start_buy;
		end if;
		
		select limit_+limit_
		into limit_;
		
		select tab_order1.order_id, tab_order1.order_account_id, tab_product.product_SName, tab_order1.order_type, tab_order1.order_quanity_in_trade, tab_order1.order_price, tab_order1.order_time_set
		from tab_order1, tab_product
		where order_product = instument
			and tab_order1.order_product = tab_product.product_id
		order by order_price
		limit start_buy, limit_;

				
end//