<a href="index.php">Списък</a>

<form method="post" action="">Име: <input type="text" name="book_name"/>

    <div>Автори:<select name="authors[]" multiple style="width: 200px">

            <?php
            foreach ($data['authors'] as $row)
            {
                echo '<option value="' . $row['author_id'] . '">
                ' . $row['author_name'] . '</option>';
            }
            ?>

        </select></div>
    <input type="submit" value="Добави"/>
</form>
