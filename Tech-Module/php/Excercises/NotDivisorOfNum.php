<form>
    N: <input type="number" name="num">
    <input type="submit">
</form>


<?php
if (isset($_GET['num'])) {
    $num = floatval($_GET['num']);
    $arr = [];
    for ($i = 0, $j = $num; $j > 0; $j--, $i++) {
       if($num % $j != 0){
           $arr[$i] = $j;
       }
    }

    echo implode(" ", $arr);


}

?>