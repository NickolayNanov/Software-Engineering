<?php
if(isset($_GET['num1']) && isset($_GET['num2'])){

    $num1 = $_GET['num1'];
    $num2 = $_GET['num2'];
    $result = $_GET['num1'] + $_GET['num2'];
    echo "<div>$num1 + $num2 = $result </div>";
}?>

<form>
    <div>First Number:</div>
    <input type="number" name="num1" />
    <div>Second Number:</div>
    <input type="number" name="num2" />
    <div><input type="submit" /></div>
</form>

