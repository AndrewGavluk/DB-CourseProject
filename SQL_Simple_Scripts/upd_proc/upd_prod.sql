DELIMITER // 
create procedure upd_prod (in product_id1 int,
										in product_SName1 Varchar(64),
										in product_LName1 Varchar(64))
Begin
		update tab_product set product_SName = product_SName1, product_LName = product_LName1 where product_id = product_id1;
end//