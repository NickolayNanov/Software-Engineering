
<?php

if(isset($_GET['person'])){
    $name = htmlspecialchars($_GET['person']);
    echo "<div>Hello, $name</div>";
}else{
?>
<form>
    Name: <input type="text" name="person" />
    <input type="submit" />
</form>
<?php } ?>


