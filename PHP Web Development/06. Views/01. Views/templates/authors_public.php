<a href="index.php">Списък</a>
<a href="index.php?page=add_book">Нова книга</a>

<br/><br/>

<form method="post" action="">
    Име: <input type="text" name="author_name"/>
    <input type="submit" value="Добави"/>
</form>

<table border='1'>
    <tr>
        <th>Автор</th>
    </tr>
    <br/>

    <?php
    foreach ($data['authors'] as $row)
        echo '<tr><td>' . $row['author_name'] . '</td></tr>';
    ?>

</table>
