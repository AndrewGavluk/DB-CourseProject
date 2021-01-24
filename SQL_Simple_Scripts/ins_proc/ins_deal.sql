DELIMITER // 

create procedure ins_deal (in deal_account_buy int, in deal_account_sell int, in deal_prodt int, in deal_quantity float, in deal_price float, in deal_time time) /*From order*/
Begin
		DECLARE id1 int default 1;
		
		select max(deal_id)+1
		from tab_deal
		into id1;
		
		insert into tab_deal values (id1, deal_account_buy, deal_account_sell, deal_prodt, deal_quantity, deal_price, deal_time);
End //