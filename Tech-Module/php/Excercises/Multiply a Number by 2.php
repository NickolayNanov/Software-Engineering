<form>
    N: <input type="number" name="num">
    <input type="submit">
</form>

<?php
function mult($num){
    return $num * 2;
}

if(isset($_GET['num'])){
    $number = intval($_GET['num']);
    $number = mult($number);
    echo "<div>$number</div>";
}
?>