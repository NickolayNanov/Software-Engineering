<form>
    N: <input type="number" name="num">
    <input type="submit">
</form>


<?php

if(isset($_GET['num'])){
    $number = intval($_GET['num']);
$arr = [];
    for ($i = 1; $i <= $number; $i++){
        $arr[$i] = $i;
    }

    echo implode(" ", $arr);
}
?>