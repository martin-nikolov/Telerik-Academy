<?php
# Съдържа колоните на таблицата, типовете разходи, продуктите и тяхната информация и общата сума
# Методи за четене съдържанието на файла и изчисляване на общата сума

$tableColumns = array("Name", "Price", "Type", "Date");

define("TYPE_INDEX", array_search("Type", $tableColumns));
define("PRICE_INDEX", array_search("Price", $tableColumns));

$types = array(0 => "Food", 1 => "Transport", 2 => "Clothing", 3 => "Medicament", 4 => "Other");
$products = array(); // Съдържа отделните продукти и тяхната информация (взема ги от файла)
$filterBy = -1; // Подразбиращата се стойност за показване на всички разходи
$totalSum = 0.0;
$deleteMode = FALSE;

ReadFileContent();
GetTotalSum($filterBy);

function ReadFileContent()
{
    global $products;
    $fileContent = file("list-records.txt");

    foreach ($fileContent as $value)
    {
        $products[] = explode(" ~ ", $value);
    }
}

function GetTotalSum($filter)
{
    global $totalSum, $products;
    $totalSum = 0.0;

    foreach ($products as $value)
    {
        // TODO
        if ($value[TYPE_INDEX] == (int)$filter || $filter == -1)
        {
            for ($i = 0; $i < count($value); $i++)
            {
                if ($i == PRICE_INDEX)
                {
                    $totalSum += (float)$value[$i];
                }
            }
        }
    }
}