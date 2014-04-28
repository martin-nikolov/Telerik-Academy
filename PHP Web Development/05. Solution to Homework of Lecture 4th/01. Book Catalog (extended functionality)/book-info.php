<?php
$title = "Add comment to book";
require "includes/config.php";
require "includes/header.php";

$BOOK_ID = null;

if(isset($_GET['book_id'])) $BOOK_ID = str_replace('"', '', $_GET['book_id']);
else header('Location: index.php');

// Заявка за връзка книга - автор(и)
$sql = 'SELECT books.book_id, books.book_title, books.comments_count, authors.author_name
        FROM books
        LEFT JOIN books_authors ON books.book_id = books_authors.book_id
        LEFT JOIN authors ON authors.author_id = books_authors.author_id WHERE books.book_id=' . $BOOK_ID;

$query = mysqli_query($CONNECTION_BOOKS, $sql);

if (HasErrorWithDataBase($query)) exit; // Проверка за грешки
?>

    <!-- Главно меню -->

    <div style="float: left;"><a href="index.php">- Back to Book Catalog</a></div>
    <div style="float: right;"><?php ShowHelloScreen(); ?></div>
    <br/><br/>

<?php
if (!mysqli_affected_rows($CONNECTION_BOOKS))
{
    echo '<span class="error">- There are no added books containing with this ID!</span>';
    exit;
}

// Масив[][име_на_книга][авторите_на_книгата]
$book = array();
while ($row = $query->fetch_assoc())
{
    $book[$BOOK_ID]['comments_count'] = $row['comments_count'];
    $book[$BOOK_ID]['book_title'] = $row['book_title'];
    $book[$BOOK_ID]['authors'][] = $row['author_name'];
}
?>

    <!--Таблица с книгите и техните автори-->

    <table border="1" cellpadding="5" cellspacing="0">
        <tr align="center">
            <td><b>Book:</b></td>
            <td><b>Author(s):</b></td>
        </tr>
        <?php
        echo '<tr><td>' . $book[$BOOK_ID]['book_title'] . '</a>';
        echo ' [' . $book[$BOOK_ID]['comments_count'] . ']</td><td>';
        for ($i = 0; $i < count($book[$BOOK_ID]['authors']); $i++)
        {
            echo '<a href="index.php?author=' . $book[$BOOK_ID]['authors'][$i] . '">';
            echo $book[$BOOK_ID]['authors'][$i] . '</a>';
            if ($i + 1 < count($book[$BOOK_ID]['authors'])) echo ', ';
        }
        echo '</td></tr>';
        ?>
    </table>

<?php
$sql = 'SELECT * FROM comments
INNER JOIN users.users ON users.user_id = comments.user_id
WHERE book_id=' . $BOOK_ID . ' ORDER BY date_added DESC';

$query = mysqli_query($CONNECTION_COMMENTS, $sql);
if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

$column = 1;

if (mysqli_num_rows($query) > 0)
{
    // Четем и визуализираме съобщенията
    while ($row = $query->fetch_assoc())
    {
        $hrefUsername = '<a href="user-info.php?user_id=' . $row['user_id'] . '">';

        echo '<br/><fieldset><legend><strong>' . $hrefUsername . $row['username'] . '</a></strong> commented: </legend>';
        echo '<br>' . wordwrap($row['content'], 70, ' ', TRUE) . '<br><br><hr/>';
        echo '<strong>Posted on:</strong> ' . $row['date_added'] . '</span>';


        echo '</fieldset>';
    }
}
else
{
    echo '<br/><div class="error">- There are no messages in the message board!</div>';
}

if (!isset($_SESSION['username']))
{
    echo '<br/><a href="login.php">You must be logged in to comment this book!</a>';
    exit;
}
?>

    <!-- Форма за добавяне на ново съобщение -->

    <form action="book-info.php?book_id=<?php echo $BOOK_ID; ?>" method="POST">
        <div><br>Message:</div>
        <div><textarea name="message" required cols="50" rows="4" maxlength="250" tabindex="2"></textarea></div>
        <div><br><input type="submit" name="posted" value="Post" tabindex="4"/>
            <input type="reset" value="Clear"/></div>
    </form><br>

<?php

if (isset($_POST['posted']))
{
    // Нормализация на данните
    $message = trim($_POST['message']);
    $error = FALSE;

    // Валидация на данните
    if (mb_strlen($message, 'UTF-8') == 0 || mb_strlen($message, 'UTF-8') > 250)
    {
        echo '<div class="error">- Message must contains between 1 to 250 symbols!</div>';
        $error = TRUE;
    }

    // Ако няма грешки -> добавя съобщението в базата данни
    if (!$error)
    {
        $message = htmlspecialchars(mysqli_real_escape_string($CONNECTION_COMMENTS, $_POST['message']));

        // Добавяме коментара в базата данни - comments
        $sql = 'INSERT INTO comments (content, book_id, user_id)
        VALUES ("' . $message . '","' . $BOOK_ID . '","' . $_SESSION['user_id'] . '")';
        $query = mysqli_query($CONNECTION_COMMENTS, $sql);
        if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

        // Увеличаваме броя на коментарите на автора
        $sql = 'UPDATE users SET users.comments_count = users.comments_count + 1 WHERE user_id=' . $_SESSION['user_id'];
        $query = mysqli_query($CONNECTION_USERS, $sql);
        if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

        // Увеличаваме броя на коментарите на книгата
        $sql = 'UPDATE books SET books.comments_count = books.comments_count + 1 WHERE book_id=' . $BOOK_ID;
        $query = mysqli_query($CONNECTION_BOOKS, $sql);
        if (HasErrorWithDataBase($query)) exit; // Проверка за грешки

        header('Location: book-info.php?book_id="' . $BOOK_ID . '"');
    }
}
?>

<?php include "includes/footer.php"; ?>