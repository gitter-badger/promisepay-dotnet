#.NET SDK - PromisePay API


#1. Installation
**NuGet:** Install PromisePay via NuGet package manager. The package name is '[PromisePay](https://www.nuget.org/packages/PromisePay.API.NET/0.0.1)'.

**Source:** Download latest sources from GitHub, add project into your solution and build it.


#2. Configuration

Before interacting with PromisePay API, you need to generate an API token. See [http://docs.promisepay.com/v2.2/docs/request_token](http://docs.promisepay.com/v2.2/docs/request_token) for more information.

Once you have recorded your API token, configure the .NET package - see below.

Add the below configuration to either the **App.config** or **Web.config** file, depending if it is a Windows, or Web application.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <sectionGroup name="PromisePay">
      <section name="Settings" type="PromisePayDotNet.Settings.SettingsHandler,PromisePayDotNet" />
    </sectionGroup>
  </configSections>
  <PromisePay>
    <Settings>
      <add key="ApiUrl" value="https://test.api.promisepay.com" />
      <add key="Login" value="YOUR LOGIN" />
      <add key="Password" value="YOUR PASSWORD" />
      <add key="Key" value="YOUR API KEY" />
    </Settings>
  </PromisePay>
</configuration>
```
**Environments**

	Prelive: https://test.api.promisepay.com
	Production: https://secure.api.promisepay.com

**Final configuration**

PromisePay API package is build using Dependency Injection principle. It makes integration into your application easy and seamless.

You will need to setup your DI container to bind interfaces and implementations of the package together.

If you use **Unity** container, just invoke init method, as it's shown below:

```cs
	var container = new UnityContainer();
	PromisePayDotNet.DI.InitUnityContainer.Init(container);
```

If you use another container, just bind interfaces from PromisePayDotNet.Interfaces to PromisePayDotNet.Implementations. You may use any lifecycle; implementations are stateless.


Then, you can use repositories from package, by resolving interface with container, or passing dependencies into constructor.

For details and example, please consider the following MSDN article:
[https://msdn.microsoft.com/ru-ru/library/dn178463(v=pandp.30).aspx](http://)

#3. Examples
##Tokens
##### Example 1 - Request session token
The below example shows the request for a marketplace configured to have the Item and User IDs generated automatically for them.
```cs
var repo = container.Resolve<ITokenRepository>();
var session_token = new Token {
	current_user = "seller",
	item_name = "Test Item",
	amount = "2500",
	seller_lastname = "Seller",
	seller_firstname = "Sally",
	buyer_lastname = "Buyer",
	buyer_firstname = "Bobby",
	buyer_country = "AUS",
	seller_country = "USA",
	seller_email = "sally.seller@promisepay.com",
	buyer_email = "bobby.buyer@promisepay.com",
	fee_ids = "",
	payment_type_id = "2"		
};
```
#####Example 2 - Request session token
The below example shows the request for a marketplace that passes the Item and User IDs.

```cs
var repo = container.Resolve<ITokenRepository>();
var session_token = new Token {
	current_user_id = "seller1234",
	item_name = "Test Item",
	amount = "2500",
	seller_lastname = "Seller",
	seller_firstname = "Sally",
	buyer_lastname = "Buyer",
	buyer_firstname = "Bobby",
	buyer_country = "AUS",
	seller_country = "USA",
	seller_email = "sally.seller@promisepay.com",
	buyer_email = "bobby.buyer@promisepay.com",
	external_item_id = "TestItemId1234",
	external_seller_id = "seller1234",
	external_buyer_id = "buyer1234",
	fee_ids = "",
	payment_type_id = "2"		
};
```
##Items

#####Create an item
#####Get an item
#####Get a list of items
#####Update an item
#####Delete an item
#####Get an item status
#####Get an item's buyer
#####Get an item's seller
#####Get an item's fees
#####Get an item's transactions
#####Get an item's wire details
#####Get an item's BPAY details

##Users

#####Create a user

```cs
var repo = container.Resolve<IUserRepository>();

var id = Guid.NewGuid().ToString();
var user = new User
{
    Id = id,
    FirstName = "Test",
    LastName = "Test",
    City = "Test",
    AddressLine1 = "Line 1",
    Country = "AUS",
    State = "state",
    Zip = "123456",
    Email = id + "@google.com"
};

var createdUser = repo.CreateUser(user);	
```

#####Get a user
#####Get a list of users

```cs
	var repo = container.Resolve<IUserRepository>();
	var users = repo.ListUsers();
```

#####Delete a User
#####Get a user's card accounts
#####Get a user's PayPal accounts
#####Get a user's bank accounts
#####Get a user's items
#####Set a user's disbursement account

##Item Actions
#####Make payment
#####Request payment
#####Release payment
#####Request release
#####Cancel
#####Acknowledge wire
#####Acknowledge PayPal
#####Revert wire
#####Request refund
#####Refund

##Card Accounts
#####Create a card account
#####Get a card account
#####Delete a card account
#####Get a card account's users

##Bank Accounts
#####Create a bank account
#####Get a bank account
#####Delete a bank account
#####Get a bank account's users

##PayPal Accounts
#####Create a PayPal account
#####Get a PayPal account
#####Delete a PayPal account
#####Get a PayPal account's users

##Fees
#####Get a list of fees
#####Get a fee
#####Create a fee

##Transactions
#####Get a list of transactions
#####Get a transactions
#####Get a transaction's users
#####Get a transaction's fees


#4. Contributing
	1. Fork it ( https://github.com/PromisePay/promisepay-dotnet/fork )
	2. Create your feature branch (`git checkout -b my-new-feature`)
	3. Commit your changes (`git commit -am 'Add some feature'`)
	4. Push to the branch (`git push origin my-new-feature`)
	5. Create a new Pull Request
