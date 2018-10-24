

    <ul>
        <?php

        for ($i = 1; $i <= 20; $i++) {
            $colour = "";
            if ($i % 2 == 0) {
                $colour = "green";
            }else{
                $colour = "blue";
            }
            echo "<li><span style='color: $colour'>$i</span></li>";
        }
        ?>
    </ul>






