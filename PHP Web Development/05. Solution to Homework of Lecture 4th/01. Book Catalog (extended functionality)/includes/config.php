<?php
session_start();
$CONNECTION_BOOKS = mysqli_connect('localhost', 'root', '', 'books');
$CONNECTION_USERS = mysqli_connect('localhost', 'root', '', 'users');
$CONNECTION_COMMENTS = mysqli_connect('localhost', 'root', '', 'comments');

if (HasErrorWithDataBase($CONNECTION_BOOKS)) exit; // Проверка за грешки

mysqli_set_charset($CONNECTION_BOOKS, 'utf8');

function HasErrorWithDataBase($query)
{
    if (!$query)
    {
        echo '<br><span class="error">- Error in database!</span>';
        return TRUE;
    }

    return FALSE;
}

function CheckForValidData($value, $minLength = 5)
{
    if (mb_strlen($value, 'UTF-8') < $minLength) return FALSE;

    for ($i = 0; $i < strlen($value); $i++)
        if (($value[$i] < 'a' || $value[$i] > 'z') && ($value[$i] < '0' || $value[$i] > '9'))
            return FALSE;

    return TRUE;
}

function ShowHelloScreen()
{
    echo 'Hello, ';
    if (isset($_SESSION['username']))
    {
        echo $_SESSION['username'];
        echo '! | <a href="logout.php">Logout</a>';
    }
    else
    {
        echo 'Anonymous';
        echo '! | <a href="login.php">Login</a>';
    }
}