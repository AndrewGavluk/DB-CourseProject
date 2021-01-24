DELIMITER // 

create procedure ins_acc (in id int,
										in account_password Varchar(64),
										in account_trader_id int,
										in account_type_product Varchar(64),
										in account_type_quantity float )
Begin
declare id_prod int default 0;

select product_id
from tab_product
where product_SName = account_type_product
into id_prod;
	
if (id_prod>0) then
i
end if;	

end//