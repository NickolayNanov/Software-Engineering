<?php
function celFar($celsium) {
    return $celsium * 1.8 + 32;
}
function farCel($farenheit){
    return ($farenheit - 32) / 1.8;
}

$msgAfterCelsius = "";

if(isset($_GET['cel'])){
    $cel = floatval($_GET['cel']);
    $fah = celFar($cel);
    $msgAfterCelsius = "$cel &deg;C = $fah %deg;F";
}
$msgAfterCelsius = "";
if(isset($_GET['fah'])){
    $fah = floatval($_GET['fah']);
    $cel = farCel($fah);
    $msgAfterCelsius = "$fah &deg;F = $cel %deg;C";
}

?>
<form>
    Celsius: <input type="text" name="cel" />
    <input type="submit" value="Convert">
    <?= $msgAfterCelsius ?>
</form>
<form>
    Fahrenheit: <input type="text" name="fah" />
    <input type="submit" value="Convert">
</form>

