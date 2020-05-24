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

		$user_id = $mysqli->real_escape_string($data->user_id);
		$token = $mysqli->real_escape_string($data->token);
		$password = $mysqli->real_escape_string($data->password);
		$confirm_password = $mysqli->real_escape_string($data->confirm_password);

		if(validatePassword($password, $confirm_password)) {	

			$pass_hash = hashPassword($password);

			if(changePassword($pass_hash, $user_id, $token)) {

				echo json_encode("Password modified successfully");
				exit;
				
			} else {
				$errors[] = "Error changing password";
			}

		} else {
			$errors[] = 'Passwords don`t match';
		}

	}  else {
		$errors[] = "Your POST query is empty. Please send user´s data";
	}

	echo json_encode($errors);

?>