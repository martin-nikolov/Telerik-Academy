<?php
# Форма за добавяне на нов запис
# Проверка дали е въведен нов запис, ако е -> нормализира, валидира, добавя
$title = 'Adding a new expenditure';
include "includes" . DIRECTORY_SEPARATOR . "header.php";
include_once "functions.php";

// Текущата дата, която ще се показва в полето Date за добавяне на нов запис
$DateTimeNow = new DateTime('NOW');
?>

<a href="index.php">List</a> | <b>Adding a new expenditure</b>
<br><br>

<form action="new-expenditure.php" method="POST">
    <div>Date: &nbsp <input type="text" value='<?php echo $DateTimeNow->format("d-m-Y"); ?>' name="date"
                            maxlength="20" size="24"></div>
    <div>Name:&nbsp;<input type="text" name="food-name" maxlength="24" size="24"></div>
    <div>Price: &nbsp<input type="text" name="price" maxlength="10" size="24"></div>
    Type: &nbsp<select name="group">
        <?php
        foreach ($types as $key => $value)
            echo "<option value = '$key'>" . $value . "</option>";
        ?>
    </select>

    <div><input type="submit" value="Add">
        <input type="reset" value="Clear"></div>
</form>

<?php
// Ако сме направили нов запис -> добавяме го в масива и го записваме във файла (ако е валиден)
if ($_POST)
{
    // Нормализация на данните
    $trimDateTime = trim($_POST['date']);
    $dateTime = date_parse($trimDateTime);
    $foodName = \trim(\str_replace("~", "", $_POST['food-name']));
    $foodPrice = number_format((float) $_POST['price'], 2, '.', '');
    $foodGroup = (int) $_POST['group'];
    $error = FALSE;

    // Валидация на данните
    try
    {
        if (!checkdate($dateTime["month"], $dateTime["day"], $dateTime["year"])) // Проверка за валидна дата
        {
            echo '<br><font color="red">' . '- You entered an invalid date!' . '</font>';
            $error = TRUE;
        }
        else
        {
            $dateTime = new DateTime($trimDateTime); // Ако е валидна правим обект от DateTime
        }
    }
    catch (Exception $e)
    {
        echo '<br><font color="red">' . '- You entered an invalid date!' . '</font>';
        $error = TRUE;
    }

    if (mb_strlen($foodName, 'UTF-8') <= 3) // Проверка за дължината на името
    {
        echo '<br><font color="red">' . '- You entered too short food name!' . '</font>';
        $error = TRUE;
    }

    if ($foodPrice <= 0) // Проверка за стойността на цената
    {
        echo '<br><font color="red">' . '- You entered an invalid price!' . '</font>';
        $error = TRUE;
    }

    // Няма грешки - добавяме записа в масива и във файла
    if (!$error)
    {
        $newProduct = array($foodName, $foodPrice, $foodGroup, $dateTime->format("d-m-Y"));
        $products[] = $newProduct;

        file_put_contents("list-records.txt", join(" ~ ", $newProduct) . "\n", FILE_APPEND);
        echo '<br><font color="green">' . '- Expenditure was successfully added!' . '</font>';
    }
}
?>

<?php include "includes" . DIRECTORY_SEPARATOR . "footer.php"; ?>