## Login Credentials
email = admin@example.com <br/>
password = Admin@123

# Database

Install database located in folder name Postgres_Database. This is a postgreSQL Database. Update appsettings.json to the credentials of your database.

## APIs Endpoints
1. **POST /api/auth/login**  --- Generate login JWT token <br/>
   Request body: <br/>
   {
    "email": "admin@example.com",
    "password": "Admin@123"
   }
2. **POST /api/Policies** - Create a new policy<br/>
    Request body: <br/>
    {
  "policyNumber": "string",
  "policyHolderName": "string",
  "policyType": "string",
  "premium": 0,
  "startDate": "2025-01-16T12:47:34.227Z",
  "endDate": "2025-01-16T12:47:34.227Z",
  "isActive": true,
  "createdAt": "2025-01-16T12:47:34.227Z",
  "updatedAt": "2025-01-16T12:47:34.227Z"
}<br/>

3.**GET /api/Policies** - Get all policies<br/>
    Request body: <br/>
    [
  {
    "id": 0,
    "policyNumber": "string",
    "policyHolderName": "string",
    "policyType": "string",
    "premium": 0,
    "startDate": "2025-01-16T12:50:55.215Z",
    "endDate": "2025-01-16T12:50:55.215Z",
    "isActive": true,
    "createdAt": "2025-01-16T12:50:55.215Z",
    "updatedAt": "2025-01-16T12:50:55.215Z"
  }
]<br/>

4.**GET /api/Policies/{id}** - Get policy by id<br/>
    Request body: <br/>
  {
    "id": 0,
    "policyNumber": "string",
    "policyHolderName": "string",
    "policyType": "string",
    "premium": 0,
    "startDate": "2025-01-16T12:50:55.215Z",
    "endDate": "2025-01-16T12:50:55.215Z",
    "isActive": true,
    "createdAt": "2025-01-16T12:50:55.215Z",
    "updatedAt": "2025-01-16T12:50:55.215Z"
  }
<br/>

5.**PUT /api/Policies/{id}** - Update policy by id<br/>
    Request body: <br/>
  {
    "id": 0,
    "policyNumber": "string",
    "policyHolderName": "string",
    "policyType": "string",
    "premium": 0,
    "startDate": "2025-01-16T12:50:55.215Z",
    "endDate": "2025-01-16T12:50:55.215Z",
    "isActive": true,
    "createdAt": "2025-01-16T12:50:55.215Z",
    "updatedAt": "2025-01-16T12:50:55.215Z"
  }
<br/>
6. **DELETE /api/InsurancePolicy/{id}** - Delete a policy by id


