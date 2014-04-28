<?php
$title = "Adding a category";
include "includes/config.php";
include "includes/header.php";

if (!isset($_SESSION['is_logged']))
{
    header('Location: index.php');
    exit;
}

$username = $_SESSION['username'];
?>

    <!-- Главно меню -->
    <div style="float: left;">
        <a href="message-board.php">Message Board</a> | <a href="add-message.php">Add Message</a>
        | <b>Add Category</b> | <a href="logout.php">Log Out</a>
    </div>
    <div style="float: right;">
        Hello, <?php echo $username . '!'; ?>
    </div><br><br>

    <!-- Поле за добавяне на нова категория -->

    <div>
        <form action="add-category.php" method="POST">
            <div>Category: <input type="text" name="category" maxlength="25" size="25" tabindex="1"/>
                <input type="submit" name="created" value="Create" tabindex="2"/></div>
        </form>
    </div>

<?php

if (isset($_POST['created']))
{
    // Нормализация на данните
    $category = trim($_POST['category']);
    $error = FALSE;

    // Валидация на данните
    if (mb_strlen($category, 'UTF-8') < 2)
    {
        echo '<br><div class="error">- You have entered an invalid Category name!</div>';
        $error = TRUE;
    }

    if (!$error)
    {
        $category = strtolower(mysqli_real_escape_string($CONNECTION, trim($_POST['category'])));
        $category = ucfirst($category); // Прави първата буква главна

        // Извличане на името
        $query = mysqli_query($CONNECTION, 'SELECT category FROM categories WHERE category = "' . $category . '"');

        if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

        $isExistCategory = mysqli_num_rows($query) >= 1 ? TRUE : FALSE; // Връща броя намерени категории с това име

        if ($isExistCategory) // Проверка дали съществува група с въведеното име
        {
            echo '<br><div class="error">- Category "' . $category . '" already exist!</div>';
        }
        else // Добавяме новата група към базата данни
        {
            $sql = 'INSERT INTO categories (category) VALUE ("' . $category . '");';
            $query = mysqli_query($CONNECTION, $sql);

            if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

            echo '<br><div class="success">- You have successfully added category "' . $category . '" !' . '</div>';
        }
    }
}

?>