<?php

require_once 'library/functions.php';

if ($_POST)
{
    $book_name = trim($_POST['book_name']);
    if (!isset($_POST['authors']))
    {
        $_POST['authors'] = '';
    }
    $authors = $_POST['authors'];
    $er = [];
    if (mb_strlen($book_name) < 2)
    {
        $er[] = '<p>Невалидно име</p>';
    }
    if (!is_array($authors) || count($authors) == 0)
    {
        $er[] = '<p>Грешка</p>';
    }
    if (!isAuthorIdExists($CONNECTION, $authors))
    {
        $er[] = 'Невалиден автор';
    }

    if (count($er) > 0)
    {
        foreach ($er as $v)
        {
            echo '<p>' . $v . '</p>';
        }
    }
    else
    {
        mysqli_query($CONNECTION, 'INSERT INTO books (book_title) VALUES("' .
                        mysqli_real_escape_string($CONNECTION, $book_name) . '")');
        if (mysqli_error($CONNECTION))
        {
            echo 'Error';
            exit;
        }
        $id = mysqli_insert_id($CONNECTION);
        foreach ($authors as $authorId)
        {
            mysqli_query($CONNECTION, 'INSERT INTO books_authors (book_id,author_id)
                VALUES (' . $id . ',' . $authorId . ')');
            if (mysqli_error($CONNECTION))
            {
                echo 'Error';
                echo mysqli_error($CONNECTION);
                exit;
            }
        }

        echo 'Книгата е добавена';
    }
}

$authors = GetAuthors($CONNECTION);

if ($authors === FALSE)
    echo 'Грешка!';

$data = array(
    'title'   => 'Нова Книга',
    'authors' => $authors,
    'content' => 'add_book_public',
);

RenderLayoutContent($data, 'normal_layout');