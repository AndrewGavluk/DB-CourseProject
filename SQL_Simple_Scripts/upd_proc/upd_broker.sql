DELIMITER //
create procedure upd_broker (in id int,
										in brock_password Varchar(64),
										in id_admin int,
										in id_brock_lic int,
										in id_brock_lic_ser int,
										in id_brock_lic_num int,
										in id_brock_lic_date date,
										in brock_fam  Varchar(64),
										in brock_nam Varchar(64),
										in brock_fnam Varchar(64),
										in brock_DB date)
Begin
		declare id1 int default 0;
		declare id2 int default 0;
		
		select brok_id
		from tab_brok_fio
		where brok_id = id
		into id1;
		
		select brok_licence_id
		from tab_brok_licence
		where brok_licence_id = id_brock_lic
		into id2;
		
		
		
		update tab_brok_fio set person_family=brock_fam, person_name=brock_nam, person_fname=brock_fnam, person_datebirth=brock_DB where brok_id=id;
		
		if (id2=0) then
			insert into tab_brok_licence  values (id_brock_lic, id_brock_lic_ser, id_brock_lic_num, id_brock_lic_date);
		else
			update tab_brok_licence set brok_licence_serial=id_brock_lic_ser, brok_licence_number=id_brock_lic_num, brok_licence_date=id_brock_lic_date 				where brok_licence_id= id_brock_lic;
		end if;
		
		update tab_broker set Password = brock_password, broker_licence_id = id_brock_lic, broker_admin_id = id_admin where broker_id = id;
end//