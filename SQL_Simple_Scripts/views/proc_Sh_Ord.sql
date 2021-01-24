DELIMITER // 

create procedure Sh_Ord (in id_prod int)
Begin
		Select tab_order1.order_id, tab_order1.order_type, tab_order1.order_quanity_in_trade, tab_order1.order_price 
		From tab_order1;
end//