<form>
    N: <input type="number" name="num">
    <input type="submit">
</form>


<?php
if(isset($_GET['num'])){
    $num = intval($_GET['num']);
$arr = [];
    for($i = 1; $i <= $num; $i++){
        if($i % 2 == 0){
            $arr[$i] = $i;
        }
    }
    echo implode(" ", $arr);
}

?>