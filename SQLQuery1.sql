

select * from ClaimHistory ch inner join  (
select max(ClaimStatusID) as claimstatusid ,ClaimId, EmployeeName from ClaimHistory group by ClaimId, EmployeeName) c
on ch.ClaimStatusID = c.claimstatusid 
and ch.ClaimId = c.ClaimId
and ch.EmployeeName = c.EmployeeName;


select * from (select *, row_number() over(partition by claimid order by lastupdatedate desc ,id desc) as rn from claimHistory ch ) t where t.rn = 1 and t.ClaimStatusID in (1,3,5)

select * from ClaimHistory
