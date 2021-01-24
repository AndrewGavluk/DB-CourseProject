DELIMITER // 

create procedure ins_trader (in id int,
										in trader_password Varchar(64),
										in trader_broker_id int,
										in person_family Varchar(64),
										in person_name Varchar(64),
										in person_fname Varchar(64),
										in person_datebirth date,
										in person_pasport_serial int,
										in person_pasport_number int,
										in person_pasport_code_of_num int,
										in person_bank_name Varchar(64),
										in person_bank_account_ID int)
Begin
		insert into tab_person_fio values (id, person_family, person_name, person_fname, person_datebirth);
		insert into tab_person_passport values (id, person_pasport_serial, person_pasport_number, person_pasport_code_of_num);
		insert into tab_person_bank values (id, person_bank_name, person_bank_account_ID);
		insert into tab_trader values (id, trader_password, trader_broker_id);
end//