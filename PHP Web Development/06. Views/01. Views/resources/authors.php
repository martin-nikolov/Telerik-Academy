<?php

require_once 'library/functions.php';

if ($_POST)
{
    $author_name = trim($_POST['author_name']);

    if (mb_strlen($author_name) < 2)
    {
        echo '<p>Невалидно име</p>';
    }
    else
    {
        $author_esc = mysqli_real_escape_string($CONNECTION, $author_name);

        $query = mysqli_query($CONNECTION, 'SELECT * FROM authors WHERE
        author_name="' . $author_esc . '"');

        if (HasErrorWithDataBase($CONNECTION))
            echo 'Грешка!';

        if (mysqli_num_rows($query) > 0)
        {
            echo 'Има такъв автор';
        }
        else
        {
            mysqli_query($CONNECTION, 'INSERT INTO authors (author_name)
            VALUES("' . $author_esc . '")');

            if (mysqli_error($CONNECTION))
            {
                echo 'Грешка';
            }
            else
            {
                echo 'Успешен запис';
            }
        }
    }
}

$authors = GetAuthors($CONNECTION);

if ($authors === FALSE)
    echo 'Грешка';

$data = array(
    'title'   => 'Автор',
    'authors' => $authors,
    'content' => 'authors_public',
);

RenderLayoutContent($data, 'normal_layout');