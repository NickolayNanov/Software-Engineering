<form>
    N: <input type="number" name="num1">
    M: <input type="number" name="num2">
    <input type="submit">
</form>

<?php
if(isset($_GET['num1']) && isset($_GET['num2'])){
    $num1 = intval($_GET['num1']);
    $num2 = intval($_GET['num2']);
    $result = $num1 * $num2;

    echo $result;
}
?>