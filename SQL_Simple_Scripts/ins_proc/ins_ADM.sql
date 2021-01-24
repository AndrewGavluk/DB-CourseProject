DELIMITER // 

create procedure ins_ADM (in id int,
										in admin_password Varchar(64),
										in admin_licence int,
										in person_family Varchar(64),
										in person_name Varchar(64),
										in person_fname Varchar(64),
										in person_datebirth date )
Begin
		insert into tab_admin values (id, admin_password, admin_licence);
		insert into tab_admin_fio values (id, person_family, person_name, person_fname, person_datebirth);
end//