<?php

	header('Access-Control-Allow-Origin: *');
	header('Content-Type: application/json');
	header('Access-Control-Allow-Methods: POST');
	header('Access-Control-Allow-Headers: Access-Control-Allow-Headers,Content-Type,Access-Control-Allow-Methods, Authorization, X-Requested-With');
	require 'php/conection.php';
	include 'php/functions.php';

	$data = json_decode(file_get_contents("php://input"));
	$errors = array();
	
	if (empty($data->user_id)) {
		$errors[] = "User ID is missing in your POST query";
	}
	
	if (empty($data->token)) {
		$errors[] = "Token is missing in your POST query";
	}
	
	$user_id = $mysqli->real_escape_string($data->user_id);
	$token = $mysqli->real_escape_string($data->token);
	
	if(!verifyTokenPassword($user_id, $token)) {
		echo json_encode("Data verified");
		exit;
	} else {
		$errors[] = "Data could not be verified";
	}

	echo json_encode($errors[]);

?>