DELIMITER // 

create procedure upd_acc (in id int,
										in account_password1 Varchar(64),
										in account_trader_id1 int,
										in account_type_product1 Varchar(64),
										in account_type_quantity1 float )
Begin
declare id_prod int default 0;

select product_id
from tab_product
where product_SName = account_type_product1
into id_prod;

if (id_prod>0) then
	update tab_account set account_password=account_password1, account_trader_id=account_trader_id1, account_type_product=id_prod, account_type_quantity = account_type_quantity1 where account_id = id;
end if;	

end//