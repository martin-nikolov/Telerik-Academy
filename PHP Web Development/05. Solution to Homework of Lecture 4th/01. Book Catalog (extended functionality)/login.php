<?php
$title = "Login page";

require "includes/config.php";
require "includes/header.php";

if (isset($_SESSION['is_logged']))
{
    header('Location: index.php');
    exit;
}

?>
    <!-- Главно меню -->

    <b>Login</b> | <a href="registration.php">New Registration</a><br><br>

    <!-- Форма за влизане в системата с име и парола-->
    <form action="login.php" method="POST">
        <div>Name: <input type="text" name="username" required maxlength="20" size="20"/></div>
        <div>Password: <input type="password" name="password" required maxlength="20" size="20"/></div>
        <div><input type="submit" value="Login" name="login"></div>
    </form>
    <br/>

    <!-- Форма за влизане в системата без потребителска сесия-->

    <form action="login.php" method="POST">
        <div><input type="submit" name="anonymous" value="Sign in without registration!"/></div>
    </form>

<?php
if (isset($_POST['anonymous']))
{
    header('Location: index.php');
}

// Проверка за потребителска сесия
if (isset($_POST['login']))
{
    $username = trim($_POST['username']);

    // Извличане на името
    $query = mysqli_query($CONNECTION_USERS, "SELECT user_id,username, password FROM users WHERE username = '" . $username . "'");

    if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

    $isExistUser = mysqli_num_rows($query) == 1 ? TRUE : FALSE; // Връща броя намерени потребители с това име (0 или 1)

    // Проверка дали съществува потребител с въведеното име
    if ($isExistUser)
    {
        $row = $query->fetch_assoc();
        $password = $row['password'];
        $user_id = $row['user_id'];

        if ($password != $_POST['password'])
        {
            echo '<br><div class="error">' . '- Wrong password!' . '</div>';
        }
        else
        {
            $_SESSION['is_logged'] = TRUE;
            $_SESSION['username'] = $username;
            $_SESSION['user_id'] = $user_id;
            header('Location: index.php');
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