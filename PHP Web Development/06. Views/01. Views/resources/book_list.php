<?php

require_once 'library/functions.php';

$author_id = isset($_GET['author_id']) ?
    (int)$_GET['author_id'] : 'ba.author_id';

$query = mysqli_query($CONNECTION,
                      'SELECT * FROM `books_authors` as ba
                      INNER JOIN books as b ON ba.book_id=b.book_id
                      INNER JOIN books_authors as bba ON bba.book_id=b.book_id
                      INNER JOIN authors as a ON bba.author_id=a.author_id
                      WHERE ba.author_id=' . $author_id);
$result = array();

while ($row = mysqli_fetch_assoc($query))
{
    $result[$row['book_id']]['book_title'] = $row['book_title'];
    $result[$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
}

$data = array(
    'title'   => 'Книги',
    'data'    => $result,
    'content' => 'book_list_public',
);

RenderLayoutContent($data, 'normal_layout');