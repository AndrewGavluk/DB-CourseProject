DELIMITER // 

create procedure upd_traider (in id1 int,
										in trader_password1 Varchar(64),
										in trader_broker_id1 int,
										in person_family1 Varchar(64),
										in person_name1 Varchar(64),
										in person_fname1 Varchar(64),
										in person_datebirth1 date,
										in person_pasport_serial1 int,
										in person_pasport_number1 int,
										in person_pasport_code_of_num1 int,
										in person_bank_name1 Varchar(64),
										in person_bank_account_ID1 int)
Begin
	Update tab_person_fio set person_family = person_family1, person_name =person_name1, person_fname=person_fname1, person_datebirth = person_datebirth1 where person_pasport_id = id1;
	update tab_person_bank set person_bank_name = person_bank_name1, person_bank_account_ID = person_bank_account_ID1 where person_bank_id = person_bank_account_ID1;
	update tab_person_passport set person_pasport_serial=person_pasport_serial1, person_pasport_number=person_pasport_number1, person_pasport_code_of_num = person_pasport_code_of_num1 where person_pasport_id = id1;
	update tab_trader set Password = trader_password1, trader_broker_id = trader_broker_id1 where trader_id = id1;
end//