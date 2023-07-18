SELECT c.ClientName, count(cc."ClientId")
FROM "Clients" c
         LEFT JOIN "ClientContacts" cc ON c.Id = cc."ClientId"
GROUP BY c.ClientName, cc."ClientId";
--
SELECT c.ClientName
FROM "Clients" c
         JOIN "ClientContacts" cc ON c.Id = cc."ClientId"
GROUP BY c.ClientName
HAVING count(*) > 2;