function sumIntegers([input]) {
    let arr = input.split(' ').map(Number);

    let num1, num2, num3;
    [num1, num2, num3] = [...arr];

    let result = print(num1, num2, num3)
    || print(num1, num3, num2)
    || print(num2, num3, num1)
    || print("No");

    console.log(result);
    function print(num1, num2, sum) {

        if (num1 + num2 != sum) {
            return false
        }
        else {
            if(num1 > num2){
                [num1, num2] = [num2, num1];
            }
            return (`${num1} + ${num2} = ${num3}`)
        }
    }

}



