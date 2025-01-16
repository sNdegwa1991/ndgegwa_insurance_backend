## Login Credentials
email = admin@example.com <br/>
password = Admin@123

# Database

Install database located in folder name Postgres_Database. This is a postgreSQL Database. Update appsettings.json to the credentials of your database.

## APIs Endpoins
1. POST http://your-api/api/auth/login  --- Generate login JWT token
   payload: <br/>
   {
    "email": "admin@example.com",
    "password": "Admin@123"
   }

