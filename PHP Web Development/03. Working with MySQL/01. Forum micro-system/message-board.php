<?php
$title = "Message Board";
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
        <b>Message Board</b> | <a href="add-message.php">Add Message</a>
        | <a href="add-category.php">Add Category</a> |

        <?php

        $link = isset($_GET['ORDER_by_create_date']) && $_GET['ORDER_by_create_date'] == 'ASC' ? 'DESC' : 'ASC';

        echo '<a href="?ORDER_by_create_date=' . $link . '">';
        echo (isset($_GET['ORDER_by_create_date']) && $_GET['ORDER_by_create_date'] == 'ASC' ? 'DESC' : 'ASC') . '</a>';

        ?>

        | <a href="logout.php">Log Out</a>
    </div>
    <div style="float: right;">
        Hello, <?php echo $username . '!'; ?>
    </div><br><br>

<?php
$sql = NULL;
$order = NULL;

if (isset($_GET['ORDER_by_create_date']))
{
    $order = $_GET['ORDER_by_create_date'];
}
else
{
    $order = 'DESC';
}

if (isset($_GET['username']))
{
    echo '<div class="success">- All messages posted by author <strong>' . $_GET['username'] . '</strong>...</div><br>';
    $sql = 'SELECT * FROM posts WHERE author = "' . $_GET['username'] . '" ORDER BY created ' . $order;
    echo '- <a href="message-board.php">Back to Message Board</a><br><br>';
}
else if (isset($_GET['category']))
{
    echo '<div class="success">- All messages in category <strong>"' . $_GET['category'] . '"</strong>...</div><br>';
    $sql = 'SELECT * FROM posts WHERE category = "' . $_GET['category'] . '" ORDER BY created ' . $order;
    echo '- <a href="message-board.php">Back to Message Board</a><br><br>';
}
else
{
    // Премахване на съобщение -> само от администратора
    if (isset($_GET['remove_id']) && $username == ADMIN)
    {
        $sql = 'DELETE FROM posts WHERE postID = ' . $_GET['remove_id'];
        $query = mysqli_query($CONNECTION, $sql);
        if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки
        unset($_GET['remove_id']);
        header('Location: message-board.php');
    }

    //    TODO

    if (isset($_GET['ORDER_by_create_date']))
    {
        echo '<div class="success">- All messages sorted in <strong>';
        echo $_GET['ORDER_by_create_date'] . 'ENDING </strong> ORDER...</div><br>';
    }
    $sql = "SELECT * FROM posts ORDER BY created " . $order;
}

$query = mysqli_query($CONNECTION, $sql);

if (!HasErrorWithDataBase($query)) exit; // Проверка за грешки

$column = 1;

if (mysqli_num_rows($query) > 0)
{
    // Четем и визуализираме съобщенията, тяхната тема, автор, група, дата.
    while ($row = $query->fetch_assoc())
    {
        $hrefCategory = '<a href="message-board.php?category=' . $row['category'] . '">';
        $hrefUsername = '<a href="message-board.php?username=' . $row['author'] . '">';

        echo '<fieldset><legend><strong>' . $row['subject'] . '</strong></legend>';
        echo '<br>' . wordwrap($row['message'], 70, ' ', TRUE) . '<br><br><hr/>';
        echo '<span style="float: left;"><strong>Author:</strong> ' . $hrefUsername . ' '
            . $row['author'] . '</a>';
        echo ' | <strong>Category:</strong> ' . $hrefCategory . $row['category'] . '</a>';
        echo ' | <strong>Posted on:</strong> ' . $row['created'] . '</span>';

        // Добавяме иконка за изтриване, ако сме с администраторския акаунт
        if ($username == ADMIN)
            echo '<a class="centered" href="message-board.php?remove_id=' . ($row['postID']) . '">' .
                '<img src="includes/remove.png" /></a>';

        echo '</fieldset><br>';
    }
}
else
{
    echo '<div class="error">- There are no messages in the message board!</div>';
}
?>

<?php include "includes/footer.php"; ?>