DELIMITER // 

create procedure ins_prod (in product_id int,
										in product_SName Varchar(64),
										in product_LName Varchar(64))
Begin
		insert into tab_product values (product_id, product_SName, product_LName);
end//