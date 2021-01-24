DELIMITER // 
create procedure info_deal (in id_prod int, in time_start time , in time_stop time, in quantity int)
Begin
	select tab_deal.deal_account_buy, tab_deal.deal_account_sell, tab_product.product_SName ,tab_deal.deal_quantity, tab_deal.deal_price, tab_deal.deal_time
	from tab_deal, tab_product
	where tab_deal.deal_prodt = tab_product.product_id 
	and tab_deal.deal_prodt = id_prod
	and tab_deal.deal_time  > time_start
	and tab_deal.deal_time	< time_stop
	limit quantity;
end