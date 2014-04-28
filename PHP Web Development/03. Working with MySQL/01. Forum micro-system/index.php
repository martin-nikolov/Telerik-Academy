<?php
$title = "Login page";

require "includes/config.php";
require "includes/header.php";

if (isset($_SESSION['is_logged']))
{
    header('Location: message-board.php');
    exit;
}

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

// Проверка за потребителска сесия
if (isset($_POST['login']))
{
    $username = trim($_POST['username']);

    // Извличане на името
    $query = mysqli_query($CONNECTION, "SELECT username, password FROM users WHERE username = '" . $username . "'");

    if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

    $isExistUser = mysqli_num_rows($query) == 1 ? TRUE : FALSE; // Връща броя намерени потребители с това име (0 или 1)

    // Проверка дали съществува потребител с въведеното име
    if ($isExistUser)
    {
        $row = $query->fetch_assoc();
        $password = $row['password'];

        if ($password != $_POST['password'])
        {
            echo '<br><div class="error">' . '- Wrong password!' . '</div>';
        }
        else
        {
            $_SESSION['is_logged'] = TRUE;
            $_SESSION['username'] = strtolower($username);
            header('Location: message-board.php');
            exit;
        }
    }
    else
    {
        echo '<br><div class="error">' . '- Username does not exist!' . '</div>';
    }
}
?>

<?php include "includes/footer.php"; ?>