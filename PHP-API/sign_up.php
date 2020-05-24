<?php

	header('Access-Control-Allow-Origin: *');
	header('Content-Type: application/json');
	header('Access-Control-Allow-Methods: POST');
	header('Access-Control-Allow-Headers: Access-Control-Allow-Headers,Content-Type,Access-Control-Allow-Methods, Authorization, X-Requested-With');
	require 'php/conection.php';
	include 'php/functions.php';

	$errors = array();
	$data = json_decode(file_get_contents("php://input"));

	if (!empty($data)) {
		
		$first_name = $mysqli->real_escape_string($data->first_name);
		$last_name = $mysqli->real_escape_string($data->last_name);
		$address = $mysqli->real_escape_string($data->address);
		$phone = $mysqli->real_escape_string($data->phone);
		$password = $mysqli->real_escape_string($data->password);
		$confirm_password = $mysqli->real_escape_string($data->$confirm_password);
		$email = $mysqli->real_escape_string($data->email);
		$captcha = $mysqli->real_escape_string($data->captcha);
		$active = 0;
		$user_type = 2;
		$secret = '6LcUDfgUAAAAAPfPNvQVISBbuTMSH7X4okP9b66a';
		
		if(!$captcha) {
			$errors[] = "Please verify the captcha";
		}
		
		if (isNull($first_name, $last_name, $nickname, $password, $confirm_password, $email)) {
			$errors[] = "You must complete all the fields";
		}
		
		if(!isEmail($email)) {
			$errors[] = "Invalid email address";
		}
		
		if(!validatePassword($password, $confirm_password)) {
			$errors[] = "Passwords don`t match";
		}		
		
		if(nicknameExists($nickname)) {
			$errors[] = "Nickname '$nickname' already exists";
		}
		
		if(emailExists($email)) {
			$errors[] = "Email address '$email' already exists";
		}
		
		if(count($errors) == 0) {	
			$response = file_get_contents("https://www.google.com/recaptcha/api/siteverify?secret=$secret&response=$captcha");			
			$arr = json_decode($response, TRUE);
			if($arr['success']) {	
				$pass_hash = hashPassword($password);
				$token = generateToken();				
				$user_id = registerUser($nickname, $pass_hash, $first_name, $last_name, $address, $phone, $email, $active, $token, $user_type);
				if($user_id > 0) {		
					$url = 'http://'.$_SERVER["SERVER_NAME"].'/projects/php/login/activate_account.php?user_id='.$user_id.'&token='.$token;					
					$subject = 'Activate Account - Users System';
					$body = "Hi $first_name! <br /><br />To continue with the sign up process, please click on the following link <a href='$url'>ACTIVATE ACCOUNT</a>";	
					if(sendEmail($email, $first_name, $subject, $body)){						
						echo json_encode("In order to complete the sign up process, please follow the instructions we`ve sent you to the following email address: $email");
						exit;
					} else {
						$errors[] = "Error on sending email";
					}	
				} else {
					$errors[] = "Error on register";
				}	
			} else {
				$errors[] = 'Error on reCaptcha validation';
			}
		}
	}  else {
		$errors[] = "Your POST query is empty. Please send user´s data";
	}

	echo json_encode($errors);
	
?>