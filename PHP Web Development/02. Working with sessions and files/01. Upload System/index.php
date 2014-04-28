<?php
$title = "Login page";
include "functions.php";
include "includes" . DIR_SEPARATOR . "header.php";

$users = GetUsersData(); // Чете потребителските имена и пароли от файла
?>
    <!-- Главно меню -->

    <b>Login</b> | <a href="registration.php">New Registration</a><br><br>

    <!-- Форма за влизане в системата -->

    <form action="index.php" method="POST">
        <div>Name: <input type="text" name="username" maxlength="20" size="20"/></div>
        <div>Password: <input type="password" name="password" maxlength="20" size="20"/></div>
        <div><input type="submit" value="Login" name="login">
            <input type="reset" value="Clear"></div>
    </form>

<?php

if (isset($_SESSION['is_logged']))
{
    header('Location: files.php');
    exit;
}

// Проверка за потребителска сесия
if (isset($_POST['login']))
{
    $username = strtolower(trim($_POST['username']));

    // Проверка дали съществува потребител с въведеното име
    $isExistUser = array_key_exists($username, $users);

    // Проверка дали данните съвпадат
    if ($isExistUser && $users[$username] == $_POST['password'])
    {
        echo "logged"; // TODO
        $_SESSION['is_logged'] = TRUE;
        $_SESSION['username'] = $username;
        header('Location: files.php');
        exit;
    }
    else if (!$isExistUser) // Несъществуващо име => грешна парола
    {
        echo '<br><font color="red">' . '- Username does not exist!' . '</font>';
        echo '<br><font color="red">' . '- Wrong password!' . '</font>';
        $error = TRUE;
    }
    else // Съществува такова име, но е въведена грешна парола
    {
        echo '<br><font color="red">' . '- Wrong password!' . '</font>';
        $error = TRUE;
    }
}
?>

<?php include "includes" . DIR_SEPARATOR . "footer.php"; ?>