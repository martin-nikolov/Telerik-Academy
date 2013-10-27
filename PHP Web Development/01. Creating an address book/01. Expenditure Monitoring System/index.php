<?php
$title = 'Expenditure Monitoring System';
include "includes" . DIRECTORY_SEPARATOR . "header.php";
include_once "functions.php";
?>
<div style="width:400px;">
    <div style="float: left; width: 202px">
        <b>List</b> | <a href="new-expenditure.php">Adding a new expenditure</a> |
    </div>
    <div style="float: right; width: 192px">
        <form action="index.php" method="POST">
            <input style="overflow:visible; font-size: 10.1pt; background: white; margin:0;
                   padding:0; border:0; border-bottom:1px solid blue; color:blue; cursor:pointer;"
                   name="<?php if (!isset($_POST['delete-button'])) echo 'delete-button' ?>"
                   type="submit"
                   value="<?php
                   echo !isset($_POST['delete-button']) ? 'Mark records for deletion' : 'Cancel deletion of records';
                   ?>">
        </form>
    </div>
</div>
<br><br>

<table border="1" cellpadding="5" cellspacing="0" width="420">
    <caption>List of expenditures:</caption>
    <tr>
        <?php
        if (isset($_POST['delete-button'])) $deleteMode = TRUE;

        echo !$deleteMode ? "<td align='center'>№.</td>" : "<td align='center'></td>";

        foreach ($tableColumns as $value) // Дата, име и т.н.
        {
            echo "<td><b>" . $value . "</b></td>";
        }

        echo '<tr>';

        // Задаване на критерий, по който ще се филтрират след обновяване на страницата
        if (isset($_POST['filter']))
        {
            $filterBy = $_POST['filter'];
            GetTotalSum($filterBy);
        }

        if ($deleteMode) echo '<form action="index.php" method="post">';

        $columnNumber = 1;
        // Принтира отделните продукти като запазва филтъра (по подразбиране има стойност "default")
        foreach ($products as $value)
        {
            echo "<tr>";
            if ($filterBy == -1 || $value[TYPE_INDEX] == (int) $filterBy)
            {
                echo !$deleteMode ? "<td align='center'>" . $columnNumber++ . "</td>" 
                        : '<td><input type="checkbox" name="' . $columnNumber++ . '"/></td>';

                FillRow();
            }
            echo "</tr>";
        }

        echo "<tr>";

        // Прави нов ред в таблицата за общата сума
        // Динамична таблица - дори и да се добавят нови колони да няма проблем с изчисляването на сумата
        foreach ($tableColumns as $value)
        {
            if ($value == $tableColumns[PRICE_INDEX])
            {
                echo "<td>...</td>";
                echo "<td>" . number_format($totalSum, 2, '.', '') . "</td>";
            }
            else
            {
                echo "<td>...</td>";
            }
        }
        ?>
    </tr>
</table>

<?php
if ($deleteMode)
{
    echo '<input type="submit" name="submit-delete" value="Delete selected records"/>';
    echo '</form>';
}

// Идеята е да се маха когато сме в режим на изтриване
if (!$deleteMode)
{
    echo '<!--Бутон за филтриране-->
    <form action="index.php" method="POST">
        Filter criteria:
        <select name="filter">
            <option value="-1">All</option>';

    foreach ($types as $key => $value)
    {
        echo "<option value = '$key'>" . $value . "</option>";
    }

    echo '</select>
        <input type="submit" value="Filter">
    </form>';
}

// Проверяваме за маркирани записи за изтриване, те ще са във вида $_POST[1...броя записи]
if (isset($_POST['submit-delete']))
{
    $deletedProducts = array();
    for ($i = 1; $i <= count($products); $i++)
    {
        if (isset($_POST[$i]))
        {
            $deletedProducts[] = $i;
        }
    }

    if (count($deletedProducts) > 0)
    {
        for ($i = 0; $i < count($deletedProducts); $i++)
        {
            $products[$deletedProducts[$i] - 1] = NULL;
        }

        file_put_contents("list-records.txt", "");

        for ($i = 0; $i < count($products); $i++)
        {
            if ($products[$i] != NULL)
            {
                file_put_contents("list-records.txt", join(" ~ ", $products[$i]), FILE_APPEND);
            }
        }

        header("Location: index.php");
    }
}

function FillRow()
{
    global $value, $types;
    for ($i = 0; $i < count($value); $i++)
    {
        echo $i == TYPE_INDEX ? "<td>" . $types[(int) $value[$i]] . "</td>" : "<td>" . $value[$i] . "</td>";
    }
}
?>

<?php include "includes" . DIRECTORY_SEPARATOR . "footer.php"; ?>