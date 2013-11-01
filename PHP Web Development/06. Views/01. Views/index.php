<?php

require realpath('library/functions.php');

if (isset($_GET['page']))
{
    switch ($_GET['page'])
    {
        case 'add_book': $page = 'add_book'; break;
        case 'authors': $page = 'authors';break;
        default: $page = 'book_list'; break;
    }
}
else
{
    $page = 'book_list';
}

require realpath(RESOURCE_PATH . $page . '.php');