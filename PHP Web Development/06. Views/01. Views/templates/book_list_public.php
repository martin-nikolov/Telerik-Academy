<a href="index.php?page=authors">Автори</a>
<a href="index.php?page=add_book">Нова книга</a>

<br/><br/>

<table border="1">
    <tr>
        <td>Книга</td>
        <td>Автор</td>
    </tr>

    <?php
    foreach ($data['data'] as $row)
    {
        echo '<tr><td>' . $row['book_title'] . '</td><td>';

        $authors = array();

        foreach ($row['authors'] as $id => $name)
            $authors[] = '<a href="index.php?author_id=' . $id . '">' . $name . '</a>';

        echo implode(', ', $authors) . '</td></tr>';
    }
    ?>

</table>