--Users {shiva.sai@citigroup.com}
select * from AspNetUsers;

select * from RegisteredOrganization;
select * from RegisteredUsers;
select * from Auctions;
select * from Bids;

select * from RegisteredUsers where UserId = 
(select Id from AspNetUsers where Email = 'shiva.sai@citigroup.com')

GUID are not good for Index. Integers will be lot more efficient.
We should use Unique Identifier.

Action Items:
Change the Primary Keys column to Bigint instead of GUID.