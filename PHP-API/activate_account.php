<?php

	require 'php/conection.php';
	include 'php/functions.php';
	
	if (isset($_GET["user_id"]) AND isset($_GET['token'])) {	
		$user_id = $_GET['user_id'];
		$token = $_GET['token'];		
		$message = validateIdToken($user_id, $token);
		echo json_encode($message);
		exit;
	} else {
		$errors[] = "Your activation URL is invalid";
	}

	echo json_encode($errors[]);

?>