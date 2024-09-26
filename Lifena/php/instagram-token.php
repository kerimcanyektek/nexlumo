<?php
/*
Name: 			Instagram Token Generator / Refresh
Written by: 	Okler Themes - (http://www.okler.net)
Theme Version:	9.7.0
*/

require "instagram/src/InstagramBasicDisplay.php";

use EspressoDev\InstagramBasicDisplay\InstagramBasicDisplay;

// Settings
$instagram = new InstagramBasicDisplay([
    'appId' => 'YOUR_INSTAGRAM_BASIC_DISPLAY_APP_ID',
    'appSecret' => 'YOUR_INSTAGRAM_BASIC_DISPLAY_APP_SECRET',
    'redirectUri' => 'https://YOUR_WEBSITE_DOMAIN/php/instagram-token.php'
]);

if( isset($_GET['code']) ) {
	
	// Get the OAuth callback code
	$code = $_GET['code'];

	// Get the short lived access token (valid for 1 hour)
	$token = $instagram->getOAuthToken($code, true);

	// Exchange this token for a long lived token (valid for 60 days)
	$token = $instagram->getLongLivedToken($token, true);

	// Create the a json file to store the token
	$fp = fopen('instagram-token.json', 'w');
	fwrite($fp, json_encode($token));
	fclose($fp);

	echo 'Your token is: ' . $token;
	die();
}

// Refresh Token
if( isset($_GET['refresh']) ) {
	
	// Get JSON file with token
	$tokenFile = file_get_contents('instagram-token.json');
	$json 	   = json_decode($tokenFile, true);

	// Refresh and generate a new token
	$refreshedToken = $instagram->refreshToken($json, true);
	
	// Save new token in the JSON file
	$fp = fopen('instagram-token.json', 'w');
	fwrite($fp, json_encode($refreshedToken));
	fclose($fp);

	echo 'Token refreshed: ' . $refreshedToken;
	die();
}

// Return json with the token
if( isset($_GET['get_token']) ) {
    header('Content-type: application/json');
    
    if( !file_exists('instagram-token.json') ) {
    	echo json_encode(array(
    		'status' => 'error',
    		'response' => 'Token file not found.'
    	));
    	die();
    }

    $str   = file_get_contents('instagram-token.json');
	$token = json_decode($str, true);
    
    echo json_encode(array(
		'status' => 'success',
		'response' => $token
	));
	die();
}

// Link for app authorization window
echo "<a href='{$instagram->getLoginUrl()}'>Login with Instagram</a>";

die();