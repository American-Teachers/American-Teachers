- LOGIN -
API will validate if the password matches with that user account.

url: "http://www.cyberdyne-systems.tech/american-teachers/api/login.php"
type: POST
headers: { "Accept": "application/json; odata=verbose" },
body: {
	"email": <form input value>,
	"password": <form input value>
}

- SIGN UP -
API will send an email to the user to verify the account before they´re allowed to login.

url: "http://www.cyberdyne-systems.tech/american-teachers/api/sign-up.php"
type: POST
headers: { "Accept": "application/json; odata=verbose" },
body: {
	"first_name": <form input value>,
	"last_name": <form input value>,
	"phone": <form input value>,
	"password": <form input value>,
	"confirm_password": <form input value>,
	"email": <form input value>
}

- RESET PASSWORD -
API will send an email to the user to verify they own the email account account before allowing them to modify it.

url: "http://www.cyberdyne-systems.tech/american-teachers/api/reset-password.php"
type: POST
headers: { "Accept": "application/json; odata=verbose" },
body: {
	"email": <form input value>
}

- VERIFY USER REQUEST -
API will check if user had indeed access to that account´s email and clicked the link sent int the previous step.
Fetch the "user_id" and "token" params included in the URL that led user to your site and include them in your
REST query as follows.

url: "http://www.cyberdyne-systems.tech/american-teachers/api/verify-request.php"
type: POST
headers: { "Accept": "application/json; odata=verbose" },
body: {
	"user_id": <form input value>,
	"token": <form input value>	
}

- MODIFY PASSWORD -
If the response of the previous query is "Data verified", then you can enable the form and let the user change
its password. If the response is "Data could not be verified" don´t allow the user to change the password.

url: "http://cyberdyne-systems.tech/american-teachers/api/modify-password.php"
type: POST
headers: { "Accept": "application/json; odata=verbose" },
body: {
	"user_id": <URL param value>,
	"token": <URL param value>,	    
	"password": <form input value>,
	"confirm_password": <form input value>
}