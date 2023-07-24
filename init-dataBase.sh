sleep 10s &&
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "1q2w3e4r@#$" -d master -i /tmp/01-create-database.sql
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "1q2w3e4r@#$" -d master -i /tmp/02-create-tables.sql
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "1q2w3e4r@#$" -d master -i /tmp/03-insert-data.sql