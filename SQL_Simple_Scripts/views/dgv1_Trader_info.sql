create view info_Trader as
Select tab_trader.trader_id, tab_trader.Password, tab_trader.trader_broker_id, tab_person_fio.person_family, tab_person_fio.person_name, tab_person_fio.person_fname, tab_person_fio.person_datebirth, tab_person_passport.person_pasport_serial, tab_person_passport.person_pasport_number, tab_person_passport.person_pasport_code_of_num, tab_person_bank.person_bank_name, tab_person_bank.person_bank_account_ID
From tab_trader, tab_person_fio, tab_person_passport, tab_person_bank
Where tab_trader.trader_id = tab_person_fio.person_pasport_id
		and tab_trader.trader_id = tab_person_bank.person_bank_id
		and tab_trader.trader_id = tab_person_passport.person_pasport_id;