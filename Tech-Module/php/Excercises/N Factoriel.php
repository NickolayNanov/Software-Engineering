<form>
    N: <input type="number" name="num">
    <input type="submit">
</form>


<?php
if(isset($_GET['num'])){
    $num = floatval($_GET['num']);
    if($num == 0){
        echo "1";
    }else{
        $fact = 1;

        for ($i = 1; $i <= $num; $i++){
            $fact *= $i;
        }
        echo $fact;
    }
}

?>