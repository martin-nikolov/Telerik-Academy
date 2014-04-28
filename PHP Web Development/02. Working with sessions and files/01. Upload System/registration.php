<?php
$title = "Registration";
include "functions.php";
include "includes" . DIR_SEPARATOR . "header.php";

if (isset($_SESSION['is_logged']))
{
    header('Location: files.php');
    exit;
}
?>

    <!-- Главно меню -->
    <a href="index.php">Login</a> | <b>New Registration</b><br><br>

    <!-- Форма за регистрация -->
    <form action="registration.php" method="POST">
        <div>Name: <input type="text" name="username" maxlength="20" size="20"/></div>
        <div>Password: <input type="password" name="password" maxlength="20" size="20"/></div>
        <div><input type="submit" value="Sign Up" name="register">
            <input type="reset" value="Clear"></div>
    </form>

<?php
if (isset($_POST['register']))
{
    // Нормализация на данните
    $username = strtolower(trim($_POST['username']));
    $password = trim($_POST['password']);
    $error = FALSE;

    // Валидация на данните
    if (!CheckForValidData($username))
    {
        echo '<br>' . '<font color="red">- You have entered invalid name!</font>';
        $error = TRUE;
    }

    if (!CheckForValidData($password))
    {
        echo '<br>' . '<font color="red">- You have entered invalid password!</font>';
        $error = TRUE;
    }

    $users = GetUsersData(); // Чете потребителските имена и пароли от файла

    if (array_key_exists($username, $users)) // Проверка дали съществува потребител с въведеното име
    {
        echo '<br>' . '<font color="red">- Username already exist!</font>';
        $error = TRUE;
    }

    // Добавяме новият потребител към базата
    if (!$error)
    {
        CreateNewUser(array($username, $password));
    }
}
?>

<?php include "includes" . DIR_SEPARATOR . "footer.php"; ?>