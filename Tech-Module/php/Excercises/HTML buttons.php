<form>
    Input: <input type="number" name="num">
    <input type="submit">
</form>

<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $arr = [];
    for ($i = 1; $i <= $num; $i++){
        $arr[$i - 1] = "<button>$i</button>";
    }
    echo implode(" ", $arr);
}
?>