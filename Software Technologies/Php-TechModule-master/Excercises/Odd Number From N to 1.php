<form>
    N: <input type="number" name="num">
    <input type="submit">
</form>


<?php
if(isset($_GET['num'])){
    $num = intval($_GET['num']);
    $arr = [];
    for($i = $num; $i >= 1; $i--){
        if($i % 2 == 1){
            $arr[$i] = $i;
        }
    }
    echo implode(" ", $arr);
}

?>