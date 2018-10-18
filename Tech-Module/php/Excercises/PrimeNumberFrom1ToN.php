<form>
    N: <input type="number" name="num">
    <input type="submit">
</form>

<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $primes = [];

    while ($num >= 2){
        $isPrime = true;

        for ($i = 2; $i <= $num / 2; $i++){
            if($num % $i == 0){
                $isPrime = false;
                break;
            }
        }

        if($isPrime){
            array_push($primes, $num);
        }
        $num--;
    }

    echo implode(" ", $primes);
}

?>