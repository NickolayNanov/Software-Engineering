
<form>
   N: <input type="num" name="num">
    <input type="submit">
</form>

<?php

if (isset($_GET['num'])){
    $num = intval($_GET['num']);

    $arr = [];

    for ($i = $num; $i >= 1; $i--){
        $arr[$i] = $i;
    }
}
echo implode(" ", $arr);

?>