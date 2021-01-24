create table tab_order1 
(
	order_id				int,
	order_account_id 	int,
	order_product		int,
	order_type			enum ('buy','sell'),
	order_quanity_in_trade float,
	order_price			float,
	order_time_set		time,
	primary key		(order_id),
	
	FOREIGN KEY (order_product ) 
	REFERENCES  tab_product (product_id)
	ON DELETE CASCADE ON UPDATE CASCADE,
	
	FOREIGN KEY (order_account_id ) 
	REFERENCES  tab_account (account_id)
	ON DELETE CASCADE ON UPDATE CASCADE
);