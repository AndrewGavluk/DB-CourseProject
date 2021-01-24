DELIMITER // 

create procedure del_ADM (in id int)
Begin
		delete from admin where admin_id = id;
		delete from admin_fio where admin_id = id;
end//