# dotnetcorewebapi_sqlserveronawsrds
Demonstrates a simple .NET core web api that fetches data from a SQL server database hosted on AWS RDS.

The project will automatically create a table named "Beacon" in the database, and provide a Web API that provides GET, PUT, DELETE and POST methods to view and modify the data in the table.

The Beacon table will consist of the following columns:
int BeaconID
string UUID 
int Major
int Minor
string BeaconName
string Model
string Brand

To run this project

1) Set up a SQL Server AWS RDS database on http://aws.amazon.com and get its end-point. Ensure security groups are configured to allow access from where you are running the application

2) Set up a database with your preferred name, e.g. mydatabase and add a SQL server user account with password to this database, e.g. dbuser

3) Modify appsettings.json with your AWS endpoint and db user details

"AWSConnection": "Server = tcp:your.aws.rds.endpoint,1433; database = mydatabase; Persist Security Info = False; User ID = your_dbuser_name; Password = your_password; MultipleActiveResultSets = True; Encrypt = True; TrustServerCertificate = True; Connection Timeout = 30"

To test the project

If the web api is deployed successfully, you should be able to access the API as follows:

GET (to view all Beacons)
http://ipaddress/api/Beacon/

POST (for adding a Beacon)
http://ipaddress/api/Beacon
{
    "BeaconName": "Dora's Beacon",
    "Brand":"SP DMIT",
    "UUID": "B9407F30-F5F8-466E-AFF9-25556B57FE6D",
    "Major": 1234,
    "Minor": 5678,
    "Model": "A-999"
}

PUT (for updating a Beacon)
http://ipaddress/api/Beacon/{id}
e.g. http://ipaddress/api/Beacon/12
{
    "BeaconName": "Dora's Beacon",
    "Brand":"SP DMIT",
    "UUID": "B9407F30-F5F8-466E-AFF9-25556B57FE6D",
    "Major": 1234,
    "Minor": 5678,
    "Model": "A-999"
}

DELETE (for removing a Beacon)
http://ipaddress/api/Beacon/{id}
e.g. http://ipaddress/api/Beacon/12

