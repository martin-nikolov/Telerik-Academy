<?php
$title = "File Storage";
include "functions.php";
include "includes" . DIR_SEPARATOR . "header.php";

if (!isset($_SESSION['is_logged']))
{
    header('Location: logout.php');
    exit;
}

$tableColumns = array("Name", "Type", "Date", "Size", "Del");
$username = $_SESSION['username'];
?>

    <!-- Главно меню -->

    <div>
        <div style="float: left;">
            <b>File Storage</b> | <a href="upload.php">Upload a file</a> | <a href="logout.php">Log Out</a>
        </div>
        <div style="float: right;">
            Hello, <?php echo $username . '!'; ?>
        </div>
    </div>
    <br><br>

<?php
$files = ReadUserFiles(); // Чете файловете на потребителя, ако съществуват такива...

if (isset($_GET['del'])) // Премахваме файла
{
    unlink(DATA_PATH . $username . DIR_SEPARATOR . $files[$_GET['del']][0]);
    header('Location: index.php');
    exit;
}

if ($files)
{
    echo '<table border="1" cellpadding="4" cellspacing="0" width="700">
        <caption><b>List of uploaded files:</b></caption><tr><td align="center" width="4%">№</td>';

    foreach ($tableColumns as $column)
        echo '<td align="center"' . ($column == 'Name' ? 'width="55%">' : '>') . $column . '</td>';

    $columnsNumber = 1;
    foreach ($files as $file)
    {
        echo '<tr><td align="center">' . $columnsNumber++ . '</td>'; // Номера на реда

        // Линк към файла за изтегляне
        $path = DATA_PATH . $username . DIR_SEPARATOR . $file[0];
        echo '<td><a href=' . str_replace(" ", "%20", $path) . '>' . $file[0] . '</a></td>';

        // Принтиране Type, Date, Size и Del
        for ($i = 1; $i < count($file); $i++)
            echo '<td align="center">' . $file[$i] . '</td>';

        echo '<td align="center"><a href="?del=' . ($columnsNumber - 2) . '">';
        echo '<img src="includes' . DIR_SEPARATOR . 'remove.png"/></a></td>';
        echo '</tr>';
    }

    echo '</tr></table>';
}
else
{
    echo '<font color="red">' . '- Your directory is empty!</font>';
}
?>

<?php include "includes" . DIR_SEPARATOR . "footer.php"; ?>