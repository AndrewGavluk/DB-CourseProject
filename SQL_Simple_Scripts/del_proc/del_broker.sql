DELIMITER // 
create procedure del_broker (in id int)
Begin
		declare lid int;
		
		select broker_licence_id
		from tab_broker
		where broker_id=id
		into lid;
		
		delete from tab_brok_licence where brok_licence_id = lid;
		delete from tab_broker where broker_id=id;
		delete from tab_brok_fio where brok_id=id;
end//