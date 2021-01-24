create user 'admin'@'localhost' identified by '5XwE-qpWh-tqy3-Tw4H';
create user 'brok'@'localhost' identified by 'Q77p-3H07-J6Oi';
create user 'trad'@'localhost' identified by 'hZR4-1XXM';

/*admin*/
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`ins_ADM` 		TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`ins_broker` 	TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`ins_prod` 		TO 'admin'@'localhost';

GRANT EXECUTE  ON PROCEDURE `trade_platform`.`del_prod` 		TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`del_ADM` 		TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`del_broker` 	TO 'admin'@'localhost';

GRANT SELECT   ON  	   	 `trade_platform`.`admin_info` 	TO 'admin'@'localhost';
GRANT SELECT   ON  	   	 `trade_platform`.`info_broker` 	TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`info_deal` 	TO 'admin'@'localhost';
GRANT SELECT   ON  	   	 `trade_platform`.`info_product` TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`Show_prices`  TO 'admin'@'localhost';

GRANT EXECUTE  ON PROCEDURE `trade_platform`.`upd_adm` 		TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`upd_broker` 	TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`upd_prod` 		TO 'admin'@'localhost';


/*brok*/
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`ins_trader` 	TO 'brok'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`ins_acc` 	TO 'brok'@'localhost';

GRANT EXECUTE  ON PROCEDURE `trade_platform`.`info_deal` 	TO 'brok'@'localhost';
GRANT SELECT   ON  	   	 `trade_platform`.`info_product` TO 'brok'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`Show_prices`  TO 'brok'@'localhost';

GRANT EXECUTE  ON PROCEDURE `trade_platform`.`del_trader` 	TO 'brok'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`del_acc` 	TO 'brok'@'localhost';

GRANT EXECUTE  ON PROCEDURE `trade_platform`.`upd_traider` 	TO 'admin'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`upd_acc` 		TO 'admin'@'localhost';

/*traider*/
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`ins_order_man` 	TO 'trad'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`info_deal` 	TO 'trad'@'localhost';
GRANT EXECUTE  ON PROCEDURE `trade_platform`.`Show_prices`  TO 'trad'@'localhost';


