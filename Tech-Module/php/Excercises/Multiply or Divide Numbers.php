
<form>
    Num01: <input type="number" name="num1">
    Num02: <input type="number" name="num2">
    <input type="submit">
</form>

<?php
if (isset($_GET['num1']) && isset($_GET['num2'])) {
    $num1 = floatval($_GET['num1']);
    $num2 = floatval($_GET['num2']);
    if ($num2 >= $num1) {
        echo $num1 * $num2;
    } else {
        echo $num1 / $num2;
    }
}

?>