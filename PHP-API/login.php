<?php

	header('Access-Control-Allow-Origin: *');
	header('Content-Type: application/json');
	header('Access-Control-Allow-Methods: POST');
	header('Access-Control-Allow-Headers: Access-Control-Allow-Headers,Content-Type,Access-Control-Allow-Methods, Authorization, X-Requested-With');
	require 'php/conection.php';
	include 'php/functions.php';

	$data = json_decode(file_get_contents("php://input"));
	$errors = array();

	if(!empty($data)) {
		$username = $mysqli->real_escape_string($data->email);
		$password = $mysqli->real_escape_string($data->password);	
		if(isNullLogin($username, $password)) {
			$errors[] = "You must complete all the fields";
		}		
		$result = login($username, $password);
		echo json_encode($result);
		exit;
	} else {
		$errors[] = "Error: POST query is empty. Please send user´s data";
	} 

	echo json_encode($errors);

?>