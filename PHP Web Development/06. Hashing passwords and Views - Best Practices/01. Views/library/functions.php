<?php
$CONNECTION = mysqli_connect('localhost', 'root', '', 'books');

if (HasErrorWithDataBase($CONNECTION)) exit;

mysqli_set_charset($CONNECTION, 'utf8');
mb_internal_encoding('UTF-8');

function HasErrorWithDataBase($query)
{
    if (!$query) return TRUE;

    return FALSE;
}

function GetAuthors($CONNECTION)
{
    $query = mysqli_query($CONNECTION, 'SELECT * FROM authors');

    if (HasErrorWithDataBase($CONNECTION)) return FALSE;

    $result = [];

    while ($row = mysqli_fetch_assoc($query))
        $result[] = $row;

    return $result;
}

function IsAuthorIdExists($CONNECTION, $ids)
{
    if (!is_array($ids)) return FALSE;

    $query = mysqli_query($CONNECTION, 'SELECT * FROM authors WHERE
        author_id IN(' . implode(',', $ids) . ')');

    if (HasErrorWithDataBase($CONNECTION)) return FALSE;

    if (mysqli_num_rows($query) == count($ids)) return TRUE;

    return FALSE;
}

function RenderLayoutContent($data, $content)
{
    require $content;
}