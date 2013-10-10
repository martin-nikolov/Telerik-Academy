<?php
session_start();
define('ADMIN', 'admin');
$CONNECTION = mysqli_connect('localhost', 'admin', 'qwerty', 'forum');

if (!HasErrorWithDataBase($CONNECTION)) exit; // Проверка за грешки

mysqli_query($CONNECTION, 'SET NAMES utf8');

function CheckForValidData($value, $minLength = 5)
{
    if (mb_strlen($value, 'UTF-8') < $minLength) return FALSE;

    for ($i = 0; $i < strlen($value); $i++)
        if (($value[$i] < 'a' || $value[$i] > 'z') && ($value[$i] < '0' || $value[$i] > '9'))
            return FALSE;

    return TRUE;
}

function HasErrorWithDataBase($query)
{
    if (!$query)
    {
        echo '<br><span class="error">' . '- Error in database!' . '</span>';
        return FALSE;
    }

    return TRUE;
}