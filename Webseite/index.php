<?php
    if(!isset($_GET['id'])){
        $_GET['id'] = "home";
    }
    if(!file_exists('data/content/'.$_GET['id'].'.html')){
        include('data/content/nocontent.html');
    }else{
        include('data/content/'.$_GET['id'].'.html');
    }    
?>