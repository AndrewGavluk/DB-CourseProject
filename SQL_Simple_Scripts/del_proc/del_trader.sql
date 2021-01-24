DELIMITER // 
create procedure del_trader (in id int)
Begin
		delete from tab_person_fio where person_pasport_id = id;
		delete from tab_person_passport where  person_pasport_id = id;
		delete from tab_person_bank where  person_bank_id = id;
		delete from tab_trader where  trader_id = id;
end//