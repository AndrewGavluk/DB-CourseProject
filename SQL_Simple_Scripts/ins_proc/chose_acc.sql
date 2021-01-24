DELIMITER // 
create function chose_acc( id1 int, Prod int) returns int
Begin
		DECLARE aft1 int default 0;
		
		select account_id
		from tab_account
		where account_type_product = Prod
				and account_trader_id = id1
		into aft1;
		
		return aft1;
End//