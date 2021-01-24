create view admin_info as
Select tab_admin.admin_id,tab_admin.Password, tab_admin_fio.person_family, tab_admin_fio.person_name, tab_admin_fio.person_fname, tab_admin_fio.person_datebirth, tab_admin.admin_licence
From tab_admin, tab_admin_fio
Where tab_admin.admin_id = tab_admin_fio.admin_id