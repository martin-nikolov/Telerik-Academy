<?php
$title = "Upload a file";
include "functions.php";
include "includes" . DIR_SEPARATOR . "header.php";

define('MAX_SIZE', 1045504); // 1MB

if (!isset($_SESSION['is_logged']))
{
    header('Location: index.php');
    exit;
}

$allowedFileTypes = array('txt', 'png', 'jpeg', 'jpg', 'gif', 'bmp', 'pdf', 'doc', 'docx', 'rtf', 'xls', 'ppt');
$username = $_SESSION['username'];

$mime_types = array(
    'txt'  => 'text/plain',
    'png'  => 'image/png',
    'jpe'  => 'image/jpeg',
    'jpeg' => 'image/jpeg',
    'jpg'  => 'image/jpeg',
    'gif'  => 'image/gif',
    'bmp'  => 'image/bmp',
    'pdf'  => 'application/pdf',
    'doc'  => 'application/msword',
    'docx' => 'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
    'rtf'  => 'application/rtf',
    'xls'  => 'application/vnd.ms-excel',
    'ppt'  => 'application/vnd.ms-powerpoint',
);

?>
    <!-- Главно меню -->
    <div>
        <div style="float: left;">
            <a href="files.php">File Storage</a> | <b>Upload a file</b> | <a href="logout.php">Log Out</a>
        </div>
        <div style="float: right;">
            Hello, <?php echo $username . '!'; ?>
        </div>
    </div><br><br>

    <!-- Форма за качване на файлове -->
    <form action="upload.php" method="post" enctype="multipart/form-data">
        <input type="file" name="file" id="file">
        <input type="submit" name="submit" value="Upload">
    </form>

<?php
if (isset($_POST['submit']) && isset($_FILES['file']))
{
    $extension = end(explode('.', $_FILES['file']['name']));

    // Прихващане на изключения + проверка дали размера на файла е по-малък от MAX_SIZE
    if ($_FILES["file"]["error"] > 0 || $_FILES['file']['size'] > MAX_SIZE)
    {
        if ($_FILES['file']['size'] > MAX_SIZE)
        {
            echo "<br><font color='red'>- Error: File size must be less than " . ceil((MAX_SIZE / (2 << 19))) . " MB!</font><br>";
        }
        else
        {
            echo "<br><font color='red'>- Error: " . ThrowErrorMessage($_FILES["file"]["error"]) . "</font><br>";
        }

        return;
    }
    else if (!(in_array($_FILES['file']['type'], $mime_types))) // Проверка за непозволено файлово разширение
    {
        echo "<br><font color='red'>" . '- Error: Unauthorized file extension.' . "</font>";
        return;
    }

    // Създава папка за потребителя, ако не съществува такава
    if (!file_exists(DATA_PATH . $username))
    {
        mkdir(DATA_PATH . $username, 0777);
    }

    // Проверка за съществуващ файл със същото име и тип
    if (file_exists(DATA_PATH . $username . DIR_SEPARATOR . $_FILES["file"]["name"]))
    {
        echo "<br><font color='red'>- Error: <b>" . $_FILES["file"]["name"] . "</b> already exists!</font>";
    }
    else
    {
        // Новият път на файла -> местим го
        $newDirPath = DATA_PATH . $username . DIR_SEPARATOR . $_FILES["file"]["name"];
        move_uploaded_file($_FILES["file"]["tmp_name"], $newDirPath);

        // Информация за качения файл
        echo "<br><b>Upload: </b>" . $_FILES["file"]["name"] . "<br>";
        echo "<b>Type: </b>" . $_FILES["file"]["type"] . "<br>";
        echo "<b>Size: </b>" . (int)($_FILES["file"]["size"] / 1024) . " kB<br>";
        echo "<b>Stored in: </b>" . $newDirPath;
        echo "<br><br><font color='green'>" . "- File was successfully uploaded!" . "</font>";
    }
}
else
{
    echo '<br><b>- Allowed file types: </b>' . join(', ', $allowedFileTypes);
}

function ThrowErrorMessage($code)
{
    switch ($code)
    {
        case UPLOAD_ERR_INI_SIZE:
            $message = "File size must be less than " . ceil((MAX_SIZE / (2 << 19))) . " MB!";
            break;
        case UPLOAD_ERR_FORM_SIZE:
            $message = "The uploaded file exceeds the MAX_FILE_SIZE directive that was specified in the HTML form!";
            break;
        case UPLOAD_ERR_PARTIAL:
            $message = "The uploaded file was only partially uploaded!";
            break;
        case UPLOAD_ERR_NO_FILE:
            $message = "No file was uploaded!";
            break;
        case UPLOAD_ERR_NO_TMP_DIR:
            $message = "Missing a temporary folder!";
            break;
        case UPLOAD_ERR_CANT_WRITE:
            $message = "Failed to write file to disk!";
            break;
        case UPLOAD_ERR_EXTENSION:
            $message = "File upload stopped by extension!";
            break;

        default:
            $message = "Unknown upload error!";
            break;
    }

    return $message;
}

?>

<?php include "includes" . DIR_SEPARATOR . "footer.php"; ?>