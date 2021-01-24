create view info_account as
Select tab_account.account_id, tab_account.account_password, tab_account.account_trader_id, tab_person_fio.person_family, tab_person_fio.person_name, tab_person_fio.person_fname, tab_account.account_type_product, tab_product.product_SName, tab_account.account_type_quantity
From tab_account, tab_person_fio, tab_product
where tab_account.account_trader_id = tab_person_fio.person_pasport_id
	and tab_account.account_type_product = tab_product.product_id
	
;