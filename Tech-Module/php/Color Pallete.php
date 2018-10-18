<style>
    div {
        display: inline-block;
        width: 150px;
        padding: 2px;
        margin: 5px;
    }

</style>
<?php

for ($red = 1; $red <= 255; $red += 51) {
    for ($green = 1; $green <= 255; $green += 51) {
        for ($blue = 1; $blue <= 255; $blue += 51) {
            echo "<div style='background:rgb($red, $green, $blue)'>rgb($red, $green, $blue)</div>";
        }
    }


}
?>