select *
from tab_order1
where order_time_set > '09:00:00'
		and order_time_set < '09:02:00'
		and order_product = 3;