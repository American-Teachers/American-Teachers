<?php

	header('Access-Control-Allow-Origin: *');
	header('Content-Type: application/json');
	header('Access-Control-Allow-Methods: POST');
	header('Access-Control-Allow-Headers: Access-Control-Allow-Headers,Content-Type,Access-Control-Allow-Methods, Authorization, X-Requested-With');
	require 'php/conection.php';
	include 'php/functions.php';
	
	$data = json_decode(file_get_contents("php://input"));
	$errors = array();
	
	if (!empty($data)) {
		$email = $mysqli->real_escape_string($data->email);		
		if(!isEmail($email)) {
			$errors[] = "You must input a valid email address";
		}
		if(emailExists($email)) {
			$user_id = getValue('id', 'email', $email);
			$first_name = getValue('first_name', 'email', $email);			
			$token = generateTokenPassword($user_id);			
			$url = 'http://'.$_SERVER["SERVER_NAME"].'/projects/php/login/change_password.php?user_id='.$user_id.'&token='.$token;			
			$subject = 'Reset Password - Users System';
			$body = "Hi $first_name! <br /><br />You requested a password reset. <br/><br/>To complete the process please click the following link: <a href='$url'>CHANGE PASSWORD</a>";			
			if (sendEmail($email, $first_name, $subject, $body)) {
				echo json_encode("We`ve sent an email to the address '$email' to reset your password.");
				exit;
			}
		} else {
			$errors[] = "Email address doesn`t exists";
		}
	} else {
		$errors[] = "Your POST query is empty. Please send user´s data";
	}

	echo json_encode($errors);
	//echo resultBlock($errors);
	
?>