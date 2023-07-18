WITH data AS (SELECT Id, Dt, row_number() over (PARTITION BY Id ORDER BY Dt) AS "Row" FROM "Dates")
SELECT d.Id,
       d2.Dt,
       d.Dt
FROM data d
         JOIN data d2 ON d.Id = d2.Id AND d."Row" = d2."Row" + 1
ORDER BY d.Id;