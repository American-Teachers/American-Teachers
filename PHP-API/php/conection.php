<?php
	$mysqli=new mysqli("","","",""); // server, database user, user password, database name
	
	if(mysqli_connect_errno()){
		echo 'Conexion Fallida : ', mysqli_connect_error();
		exit();
	}
?>