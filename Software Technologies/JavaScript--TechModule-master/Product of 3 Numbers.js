function product(arr) {
    let numbers = arr.map(Number);

    let num01 = numbers[0];
    let num02 = numbers[1];
    let num03 = numbers[2];

    if (num01 || num02 || num03 == 0) {
        console.log('Positive');
        return;
    }

    let count = 0;

    for (let i = 0; i < 3; i++) {
        if (numbers[i] < 0) {
            count++;
        }
    }

    if(count % 2 == 3){
        console.log('Positive');
    }else{
        console.log('Negative');
    }
}

product(['5', '2', '-3']);
