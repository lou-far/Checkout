# Checkout.com Payment Gateway Task
The various layers of the solution are clearly separated out to ensure each layer only has access to the models and functions that it should do.
1. Entry Points (Presentation) Layer
	1. Handles triggers (HTTP, timer, queue, etc.) that initiate a request on the domain
	1. Initiate dependency injection 
1. Application Layer
	1. Handle use cases
1. Domain Layer
	1. Contains domain entity and value object definitions
	1. Contains domain business rules 
	1. Contains repository interfaces
1. Infrastructure Layer - Persistence
	1. Persistence handling of aggregates (create, read, update, delete)
	1. Optimised reading of data for performance gains
1. Infrastructure Layer - Transversal
	1. Dependency resolution for all projects in the solution
	1. Exposure to external services 
	1. Solution-scoped (cross-cutting) helpers
1. Solution Assets
	1. Storage of any supporting assets required by the solution

## How to run
1. Build solution.
1. Publish Checkout.Database to your local SQL Server instance with the name, 'sqldb-checkout-local'.
1. Run Checkout.Trigger.

## How to use
Open an API platform, e.g. Postman, Fiddler.

### Create a payment

#### Request
POST http://localhost:7071/api/merchants/{merchantId}/payments/
#### Body
`
{
	"merchantId": int,
	"amount": int,
	"currency": string,
	"paymentCard": {
		"permanentAccountNumber": string,
		"cardholderName": string,
		"expiresOnMonth": string,
		"expiresOnYear": string,
		"cardVerificationValue": string
	}
}
`

#### Response
`
{
	"paymentId": int,
	"isSuccessful": bool
}
`

### Retrieve a payment's detail
GET http://localhost:7071/api/merchants/{merchantId}/payments/{paymentId}/

#### Response
`
{
	"amount": int,
	"paymentStatus": string,
	"currency": string,
	"paymentCard": {
		"maskedPermanentAccountNumber": string,
		"cardholderName": string,
		"expiresOnMonth": string,
		"expiresOnYear": string,
		"cardVerificationValue": string
	}
}
`

## Assumptions
1. This will only be run locally
1. Merchant's are already registered with the Payment Gateway.
	1. Valid Merchant Ids are 1, 2 and 3.
1. Supported currencies are EUR, GBP and USD.
1. Valid Permanent Account Numbers begin with "200", e.g. 2000111122223333.
1. Card maximum ExpiresOnYear is 5 years from current year.

## Areas for improvement
1. Utilise AAD, and introduce a database connection interceptor to manage database requests.
1. Add auth around the Azure Functions (currently anonymous).
1. Greater coverage of unit tests.
1. Return greater detail on failed payments.
1. Separate out merchant data into separate tenants to better compartmentalise data, from both a security and management perspective.
1. Not store card detail as plain text in the database.
1. Introduce IaC as part of the solution

## What cloud technologies would be used.
1. Azure Functions for Payment Gateway entry point; for a serverless, maintainless infrastructure.
1. Azure Front Door to introduce a blanket level of security with it's integrated firewall, and ability to define, manage and monitor all your web traffic
1. Azure SQL Database for storing relevant data in a secure and relational manner.
1. Azure Key Vault for ensuring no plain text configuration values are available to those who shouldn't have access.
