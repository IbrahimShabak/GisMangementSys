installed package

Microsoft.Owin.Host.SystemWeb
Microsoft.Owin.Security.OAuth
Microsoft.Owin.Cors
----------------------------------------------------------------------------------


Notes:


For all
Erorr Code will send back to client Side is

401 (Unauthorized) - 
	indicates that the request has not been applied because 
	it lacks valid authentication credentials for the target resource.
	------------------------------------------------------------------------------
403 (Forbidden) -
	when the user is authenticated but isn’t authorized to 
	perform the requested operation on the given resource.
	------------------------------------------------------------------------------




for Assad :http://www.dotnetawesome.com/2016/09/token-based-authentication-in-webapi.html
for Assad :http://www.dotnetawesome.com/2016/10/token-based-authentication-in-angularjs.html
----------------------------------------------------------------------------------

get token key
url= "http://localhost:2749/Token"
in headers
Content-Type: application/x-www-form-urlencoded
in body
grant_type=password
username=admin
password=123

http://localhost:2749/swagger/ui/index