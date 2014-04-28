<?php
$title = "Adding a message";
include "includes/config.php";
include "includes/header.php";

if (!isset($_SESSION['is_logged']))
{
    header('Location: index.php');
    exit;
}

$username = $_SESSION['username'];

$query = mysqli_query($CONNECTION, "SELECT * FROM categories ORDER BY category ASC");
$categories = array();

if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

while ($row = $query->fetch_assoc()) // Вземаме всички категории
{
    $categories[] = $row['category'];
}

?>
    <!-- Главно меню -->

    <div style="float: left;">
        <a href="message-board.php">Message Board</a> | <b>Add Message</b>
        | <a href="add-category.php">Add Category</a> | <a href="logout.php">Log Out</a>
    </div>
    <div style="float: right;">
        Hello, <?php echo $username . '!'; ?>
    </div><br><br>

    <!-- Форма за добавяне на ново съобщение -->

    <form action="add-message.php" method="POST">
        <div>Subject:</div>
        <div><input type="text" name="subject" maxlength="50" size="50" tabindex="1"/></div>
        <div><br>Message:</div>
        <div><textarea name="message" cols="50" rows="6" maxlength="250" tabindex="2"></textarea></div>
        <div>Select category:
            <select name="category" tabindex="3">
                <?php
                foreach ($categories as $key => $value)
                    echo '<option value="' . $key . '">' . $value . '</option>';
                ?>
            </select></div>
        <div><br><input type="submit" name="posted" value="Post" tabindex="4"/>
            <input type="reset" value="Clear"/></div>
    </form><br>

<?php

if (isset($_POST['posted']))
{
    // Нормализация на данните
    $subject = trim($_POST['subject']);
    $message = trim($_POST['message']);
    $category = $_POST['category']; // Връща индекс
    $error = FALSE;

    // Валидация на данните
    if (mb_strlen($subject, 'UTF-8') == 0 || mb_strlen($subject, 'UTF-8') > 50)
    {
        echo '<div class="error">- Subject must contains between 1 to 50 symbols!</div>';
        $error = TRUE;
    }

    if (mb_strlen($message, 'UTF-8') == 0 || mb_strlen($message, 'UTF-8') > 250)
    {
        echo '<div class="error">- Message must contains between 1 to 250 symbols!</div>';
        $error = TRUE;
    }

    // Ако няма грешки -> добавя съобщението в базата данни
    if (!$error)
    {
        $subject = mysqli_real_escape_string($CONNECTION, $_POST['subject']);
        $message = mysqli_real_escape_string($CONNECTION, $_POST['message']);

        $sql = 'INSERT INTO posts (subject, message, author, category)
        VALUES ("' . $subject . '","' . $message . '","' . $username . '","' . $categories[$category] . '")';
        $query = mysqli_query($CONNECTION, $sql);

        if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

        header('Location: message-board.php');
    }
}

?>

<?php include "includes/footer.php"; ?>