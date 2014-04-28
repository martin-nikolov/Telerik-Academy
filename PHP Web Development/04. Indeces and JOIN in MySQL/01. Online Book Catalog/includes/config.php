<?php
$CONNECTION = mysqli_connect('localhost', 'root', '', 'books');

if (HasErrorWithDataBase($CONNECTION)) exit; // Проверка за грешки

mysqli_set_charset($CONNECTION, 'utf8');

function HasErrorWithDataBase($query)
{
    if (!$query)
    {
        echo '<br><span class="error">- Error in database!</span>';
        return TRUE;
    }

    return FALSE;
}