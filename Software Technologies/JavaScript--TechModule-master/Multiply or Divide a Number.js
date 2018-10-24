function multiplyOrDivide(arr) {
    let numbers = arr.map(Number);

    let num01 = numbers[0]; //n
    let num02 = numbers[1]; //x

    if(num01 <= num02){
        console.log(num02 * num01);
    }else {
        console.log(num01 / num02);
    }
}

multiplyOrDivide(['3', '2']);