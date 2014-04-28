<?php
$title = "User's comments";
require "includes/config.php";
require "includes/header.php";

$USER_ID = NULL;

if (isset($_GET['user_id'])) $USER_ID = $_GET['user_id'];
else header('Location: index.php');

// Заявка за връзка потребител - коментари
$sql = 'SELECT content, date_added, comments.book_id, comments.comment_id, books.book_title, users.username FROM comments
INNER JOIN users.users ON users.user_id = comments.user_id
INNER JOIN books.books ON books.book_id = comments.book_id
WHERE users.user_id = ' . $USER_ID . ' ORDER BY date_added DESC';

$query = mysqli_query($CONNECTION_COMMENTS, $sql);

if (HasErrorWithDataBase($query)) exit; // Проверка за грешки
?>

    <!-- Главно меню -->

    <div style="float: left;"><a href="index.php">- Back to Book Catalog</a></div>
    <div style="float: right;"><?php ShowHelloScreen(); ?></div>
    <br/><br/>

<?php
if (!mysqli_affected_rows($CONNECTION_COMMENTS))
{
    echo '<span class="error">- This user do not have any comments!</span>';
}
else
{
    $user = array();
    while ($row = $query->fetch_assoc())
    {
        $hrefUsername = '<a href="user-info.php?user_id=' . $USER_ID . '">';
        $hrefBookTitle = '<a href="book-info.php?book_id=' . $row['book_id'] . '">';

        echo '<fieldset><legend><strong>' . $hrefUsername . $row['username'] . '</a></strong> commented: </legend>';
        echo '<br>' . wordwrap($row['content'], 70, ' ', TRUE) . '<br><br><hr/>';
        echo '<strong>Posted on:</strong> ' . $row['date_added'] . '</span>';
        echo '<span style="float:right"><strong>Book:</strong> ' . $hrefBookTitle . $row['book_title'] . '</a></span>';

        echo '</fieldset><br/>';
    }
}
?>

<?php include "includes/footer.php"; ?>