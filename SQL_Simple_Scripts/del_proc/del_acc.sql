DELIMITER // 

create procedure del_acc (in id int)
Begin
		delete from tab_account where account_id = id;
end//