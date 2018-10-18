<form>
    Num1: <input type="text" name="num1">
    Num2: <input type="text" name="num2">
    Num3: <input type="text" name="num3">

    <input style="color: navy" type="submit">
</form>

<?php
if(isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])){

    $num1 = floatval($_GET['num1']);
    $num2 = floatval($_GET['num2']);
    $num3 = floatval($_GET['num3']);

    $negativeCount = 0;

    if($num1 == 0 || $num1 == 0 || $num3 == 0){
        echo "Positive";
        return;
    }else{
        if($num1 < 0) $negativeCount++;
        if($num2 < 0) $negativeCount++;
        if($num3 < 0) $negativeCount++;
    }

    echo ($negativeCount % 2 == 0) ? "Positive" : "Negative";
}

?>