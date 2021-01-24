DELIMITER // 

create procedure del_prod (in id int)
Begin
		delete from tab_product where product_id = id;
end//