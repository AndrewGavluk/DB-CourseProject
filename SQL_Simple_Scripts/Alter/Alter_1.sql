Alter Table tab_person_passport add Constraint
FOREIGN KEY (person_pasport_id) 
REFERENCES tab_trader (trader_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_person_bank add Constraint
FOREIGN KEY (person_bank_id) 
REFERENCES tab_trader (trader_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_person_fio add Constraint
FOREIGN KEY (person_pasport_id) 
REFERENCES tab_trader (trader_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_broker  add Constraint
FOREIGN KEY (broker_licence_id ) 
REFERENCES  tab_broc_licence(broc_licence_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_broker  add Constraint
FOREIGN KEY (broker_admin_id ) 
REFERENCES  tab_admin (admin_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_deal add Constraint
FOREIGN KEY (deal_prodt) 
REFERENCES tab_product (product_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_account  add Constraint
FOREIGN KEY (account_type_product) 
REFERENCES tab_product (product_id)
ON DELETE CASCADE ON UPDATE CASCADE;