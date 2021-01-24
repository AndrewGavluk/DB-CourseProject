DELIMITER // 

create procedure ins_broker (in id int,
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
		where brok_licence_id = id
		into id2;
		
		if ((id1 = 0) and ( id2=0)) then 
			insert into tab_brok_fio 		values (id, brock_fam, brock_nam, brock_fnam, brock_DB);
			insert into tab_brok_licence  values (id_brock_lic, id_brock_lic_ser, id_brock_lic_num, id_brock_lic_date);
			insert into tab_broker 			values (id, brock_password, id_brock_lic, id_admin);
		end if;
end//