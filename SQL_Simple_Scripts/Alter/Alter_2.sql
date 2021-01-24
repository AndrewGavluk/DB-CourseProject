Alter Table tab_order1 add Constraint
FOREIGN KEY (order_account_id) 
REFERENCES tab_account (account_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_trader add Constraint
FOREIGN KEY (trader_broker_id) 
REFERENCES tab_broker (broker_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_deal add Constraint
FOREIGN KEY (deal_account_buy) 
REFERENCES tab_account (account_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_deal add Constraint
FOREIGN KEY (deal_account_sell) 
REFERENCES tab_account (account_id)
ON DELETE CASCADE ON UPDATE CASCADE;

Alter Table tab_account add Constraint
FOREIGN KEY (account_trader_id) 
REFERENCES tab_trader (trader_id)
ON DELETE CASCADE ON UPDATE CASCADE;