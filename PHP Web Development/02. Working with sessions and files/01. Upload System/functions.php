<?php
define('DIR_SEPARATOR', '/');
define('DATA_PATH', 'data' . DIR_SEPARATOR);
define('USERS_DATA_PATH', 'data' . DIR_SEPARATOR . 'users.txt');

function GetUsersData()
{
    $users = array();
    $fileContent = NULL;

    if (file_exists(USERS_DATA_PATH))
    {
        $fileContent = file(USERS_DATA_PATH);

        foreach ($fileContent as $value)
        {
            $data = explode(" ~ ", $value);

            if (count($data) == 2) $users[trim($data[0])] = trim($data[1]);
        }
    }

    return $users;
}

function CreateNewUser($data)
{
    file_put_contents(USERS_DATA_PATH, join(" ~ ", $data) . "\n", FILE_APPEND);
    echo '<br><font color="green">' . '- You have successfully registered!' . '</font>';
}

function CheckForValidData($value)
{
    if (mb_strlen($value, 'UTF-8') < 3) return FALSE;

    for ($i = 0; $i < strlen($value); $i++)
        if (($value[$i] < 'a' || $value[$i] > 'z') && ($value[$i] < '0' || $value[$i] > '9'))
            return FALSE;

    return TRUE;
}

function ReadUserFiles()
{
    $username = $_SESSION['username'];

    if (file_exists(DATA_PATH . $username) && is_dir(DATA_PATH . $username))
    {
        $files = scandir(DATA_PATH . $username);
        $allFiles = array();

        foreach ($files as $file)
        {
            if ($file == '.' || $file == '..') continue;

            $dir = DATA_PATH . $username . DIR_SEPARATOR . $file;
            $currentFile = array();

            $currentFile[] = pathinfo($dir, PATHINFO_BASENAME);
            $currentFile[] = pathinfo($dir, PATHINFO_EXTENSION);
            $currentFile[] = date("d-m-Y", filectime($dir));
            $currentFile[] = (int)ceil((filesize($dir) / 1024)) . ' KB';

            $allFiles[] = $currentFile;
        }

        return $allFiles;
    }

    return NULL;
}
