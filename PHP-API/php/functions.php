<?php
	
	function isNull($name, $user, $pass, $pass_con, $email) {
		if (strlen(trim($name)) < 1 || strlen(trim($user)) < 1 || strlen(trim($pass)) < 1 || strlen(trim($pass_con)) < 1 || strlen(trim($email)) < 1) {
			return true;
		} else {
			return false;
		}		
	}
	
	function isEmail($email) {
		if (filter_var($email, FILTER_VALIDATE_EMAIL)) {
			return true;
		} else {
			return false;
		}
	}
	
	function validatePassword($var1, $var2) {
		if (strcmp($var1, $var2) !== 0){
			return false;
		} else {
			return true;
		}
	}
	
	function minMax($min, $max, $valor) {
		if(strlen(trim($valor)) < $min) {
			return true;
		} else if (strlen(trim($valor)) > $max) {
			return true;
		} else {
			return false;
		}
	}
	
	function nicknameExists($nickname) {
		global $mysqli;		
		$stmt = $mysqli->prepare("SELECT id FROM users WHERE nickname = ? LIMIT 1");
		$stmt->bind_param("s", $nickname);
		$stmt->execute();
		$stmt->store_result();
		$num = $stmt->num_rows;
		$stmt->close();	
		if ($num > 0){
			return true;
		} else {
			return false;
		}
	}
	
	function emailExists($email) {
		global $mysqli;		
		$stmt = $mysqli->prepare("SELECT id FROM users WHERE email = ? LIMIT 1");
		$stmt->bind_param("s", $email);
		$stmt->execute();
		$stmt->store_result();
		$num = $stmt->num_rows;
		$stmt->close();	
		if ($num > 0) {
			return true;
		} else {
			return false;	
		}		
	}
	
	function generateToken() {
		$gen = md5(uniqid(mt_rand(), false));	
		return $gen;
	}
	
	function hashPassword($password)  {
		$hash = password_hash($password, PASSWORD_DEFAULT);
		return $hash;
	}
	
	function resultBlock($errors) {
		if (count($errors) > 0) {
			echo "<div id='error' class='alert alert-danger' role='alert'>
			<a href='#' onclick=\"showHide('error');\">[X]</a>
			<ul>";
			foreach ($errors as $error) {
				echo "<li>".$error."</li>";
			}
			echo "</ul>";
			echo "</div>";			
		}
	}
	
	function registerUser($pass_hash, $first_name, $last_name, $phone, $email, $active, $token, $user_type) {
		global $mysqli;	
		$stmt = $mysqli->prepare("INSERT INTO users (password, first_name, last_name, phone, email, active, token, user_type) VALUES(?,?,?,?,?,?,?,?)");
		$stmt->bind_param('sssssisi',$pass_hash, $first_name, $last_name, $phone, $email, $active, $token, $user_type);		
		if ($stmt->execute()){
			return $mysqli->insert_id;
		} else {
			return 0;	
		}	
	}
	
	function sendEmail($email, $first_name, $subject, $body) {		
		require_once 'PHPMailer/PHPMailerAutoload.php';		
		$mail = new PHPMailer(true);
		$mail->isSMTP();
		$mail->SMTPAuth = true;
		$mail->SMTPSecure = 'tls';
		$mail->Host = 'smtp.gmail.com';
		$mail->Port = '587';		
		$mail->Username = 'federicofigueredo87@gmail.com';
		$mail->Password = 'Ff33241675';		
		$mail->setFrom('federicofigueredo87@gmail.com', 'Digital Hospital');
		$mail->addAddress($email, $first_name);		
		$mail->Subject = $subject;
		$mail->Body = $body;
		$mail->IsHTML(true);		
		if($mail->send()){
			return true;
		} else {
			echo $mail.ErorInfo;
			return false;
		}
	}
	
	function validateIdToken($id, $token) {
		global $mysqli;		
		$stmt = $mysqli->prepare("SELECT active FROM users WHERE id = ? AND token = ? LIMIT 1");
		$stmt->bind_param("is", $id, $token);
		$stmt->execute();
		$stmt->store_result();
		$rows = $stmt->num_rows;	
		if ($rows > 0) {
			$stmt->bind_result($active);
			$stmt->fetch();			
			if ($active == 1) {
				$msg = "Account has been already activated.";
			} else {
				if (activateUser($id)) {
					$msg = 'Account activated.';
				} else {
					$msg = 'Error on account activation';
				}
			}
		} else {
			$msg = 'Activation record doesn`t exists.';
		}
		return $msg;
	}
	
	function activateUser($id) {
		global $mysqli;		
		$stmt = $mysqli->prepare("UPDATE users SET active = 1 WHERE id = ?");
		$stmt->bind_param('s', $id);
		$result = $stmt->execute();
		$stmt->close();
		return $result;
	}
	
	function isNullLogin($user, $password){
		if(strlen(trim($user)) < 1 || strlen(trim($password)) < 1) {
			return true;
		} else {
			return false;
		}		
	}
	
	function login($foo, $pass) {
		global $mysqli;		
		$stmt = $mysqli->prepare("SELECT id, user_type, password FROM users WHERE nickname = ? || email = ? LIMIT 1");
		$stmt->bind_param("ss", $foo, $foo);
		$stmt->execute();
		$stmt->store_result();
		$rows = $stmt->num_rows;		
		if($rows > 0) {		
			if(isActivated($foo)) {			
				$stmt->bind_result($id, $user_type, $password);
				$stmt->fetch();				
				$validatePassword = password_verify($pass, $password);				
				if ($validatePassword) {					
					lastSession($id);
					return "Success: User authenticated";
					exit;
				} else {					
					$errors = "Error: Incorrect Password";
				}
			} else {
				$errors = 'Error: User hasn`t been activated';
			}
		} else {
			$errors = "Error: User or email address doesn`t exist";
		}
		return $errors;
	}
	
	function lastSession($id) {
		global $mysqli;		
		$stmt = $mysqli->prepare("UPDATE users SET last_session = NOW(), token_password = '', password_request = 1 WHERE id = ?");
		$stmt->bind_param('s', $id);
		$stmt->execute();
		$stmt->close();
	}
	
	function isActivated($foo) {
		global $mysqli;		
		$stmt = $mysqli->prepare("SELECT active FROM users WHERE nickname = ? || email = ? LIMIT 1");
		$stmt->bind_param('ss', $foo, $foo);
		$stmt->execute();
		$stmt->bind_result($active);
		$stmt->fetch();		
		if ($active == 1) {
			return true;
		} else {
			return false;	
		}
	}	
	
	function generateTokenPassword($user_id) {
		global $mysqli;		
		$token = generateToken();		
		$stmt = $mysqli->prepare("UPDATE users SET token_password=?, password_request=1 WHERE id = ?");
		$stmt->bind_param('ss', $token, $user_id);
		$stmt->execute();
		$stmt->close();		
		return $token;
	}
	
	function getValue($column, $whereColumn, $value) {
		global $mysqli;	
		$stmt = $mysqli->prepare("SELECT $column FROM users WHERE $whereColumn = ? LIMIT 1");
		$stmt->bind_param('s', $value);
		$stmt->execute();
		$stmt->store_result();
		$num = $stmt->num_rows;		
		if ($num > 0) {
			$stmt->bind_result($_column);
			$stmt->fetch();
			return $_column;
		} else {
			return null;	
		}
	}
	
	function getPasswordRequest($id) {
		global $mysqli;		
		$stmt = $mysqli->prepare("SELECT password_request FROM users WHERE id = ?");
		$stmt->bind_param('i', $id);
		$stmt->execute();
		$stmt->bind_result($_id);
		$stmt->fetch();		
		if ($_id == 1) {
			return true;
		} else {
			return null;	
		}
	}
	
	function verifyTokenPassword($user_id, $token){		
		global $mysqli;		
		$stmt = $mysqli->prepare("SELECT active FROM users WHERE id = ? AND token_password = ? AND password_request = 1 LIMIT 1");
		$stmt->bind_param('is', $user_id, $token);
		$stmt->execute();
		$stmt->store_result();
		$num = $stmt->num_rows;		
		if ($num > 0) {
			$stmt->bind_result($active);
			$stmt->fetch();
			if($active == 1) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;	
		}
	}
	
	function changePassword($password, $user_id, $token){	
		global $mysqli;
		$stmt = $mysqli->prepare("UPDATE users SET password = ?, token_password = '', password_request = 0 WHERE id = ? AND token_password = ?");
		$stmt->bind_param('sis', $password, $user_id, $token);	
		if($stmt->execute()) {
			return true;
		} else {
			return false;		
		}
	}	