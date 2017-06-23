
<?php

//This file must be uploaded to youe WWW Directory on a LOCAL WEB SERVER , LOCATED ON : "C:\wamp64\www\list.txt"
// C0ded by Rayka95
$file = file_get_contents("list.txt");
	preg_match_all('#[-a-zA-Z0-9@:%_\+.~\#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~\#?&//=]*)?#si', $file, $matches);
	array_unique($matches,SORT_REGULAR);
	foreach ($matches[0] as $key){
		if(strpos($key , "http") !== false || strpos($key , ".js") !== false  || strpos($key , ".png") !== false ||strpos($key , "nic") !== false ||strpos($key , ".pdf") !== false){}
	else {	echo $key . "\r\n";}}
?>

