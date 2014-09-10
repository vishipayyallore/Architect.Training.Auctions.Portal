--Users {shiva.sai@citigroup.com}
select * from AspNetUsers order by Email;

select * from RegisteredOrganization;
select * from RegisteredUsers;
select * from Auctions;
select * from Bids;

--admin.buycompany1 admin.sellcompany1 admin.sellcompany2

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





Action Items:
Change the Primary Keys column to Bigint instead of GUID.