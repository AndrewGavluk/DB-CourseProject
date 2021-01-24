DELIMITER // 

create procedure upd_adm (in id1 int,
								  in adm_password1 Varchar(64),
								  in Licence1 Varchar(64),
										in person_family1 Varchar(64),
										in person_name1 Varchar(64),
										in person_fname1 Varchar(64),
										in person_datebirth1 date)
Begin
	Update tab_admin_fio set person_family = person_family1, person_name =person_name1, person_fname=person_fname1, person_datebirth = person_datebirth1 where admin_id = id1;
	update tab_admin set Password = adm_password1, admin_licence = Licence1 where admin_id = id1;
end//