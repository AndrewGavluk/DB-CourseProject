create view info_broker as
Select tab_broker.broker_id, tab_broker.Password, tab_broker.broker_admin_id, tab_broker.broker_licence_id, tab_brok_licence.brok_licence_serial , tab_brok_licence.brok_licence_number, tab_brok_licence.brok_licence_date, tab_brok_fio.person_family, tab_brok_fio.person_name, tab_brok_fio.person_fname, tab_brok_fio.person_datebirth
From tab_broker, tab_brok_fio, tab_brok_licence
Where tab_broker.broker_id = tab_brok_fio.brok_id
		and tab_broker.broker_licence_id = tab_brok_licence.brok_licence_id;