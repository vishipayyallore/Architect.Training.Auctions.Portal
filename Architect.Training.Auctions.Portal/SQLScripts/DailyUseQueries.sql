--Users {shiva.sai@citigroup.com}
select * from AspNetUsers order by Email;

select * from RegisteredOrganization;
select * from RegisteredUsers;
select * from Auctions;
select * from Bids;
select * from LogActions;

--admin.buycompany1 admin.sellcompany1 admin.sellcompany2
-- 01-Jan-2015 09:0:00

select * from RegisteredUsers where UserId = 
(select Id from AspNetUsers where Email = 'shiva.sai@citigroup.com')

GUID are not good for Index. Integers will be lot more efficient.
We should use Unique Identifier.

buycompany1
	-admin@buycompany1.com
sellcompany1
	-admin@sellcompany1.com
	-user1@sellcompany1.com
	-user2@sellcompany1.com
sellcompany2
	-admin@sellcompany2.com
	-user1@sellcompany2.com
	-user2@sellcompany2.com


	 
	-- See more at: http://blinkenjob.com/how-to-extract-only-alphanumeric-character-from-string/#sthash.f6WtGuWY.dpuf



Action Items:
Change the Primary Keys column to Bigint instead of GUID.