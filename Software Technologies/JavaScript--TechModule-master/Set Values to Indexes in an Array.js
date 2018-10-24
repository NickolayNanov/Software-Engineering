function indexAnArray(arr) {
    let count = arr.map(Number);//check
    let args = [];

    for (let i = 0; i < arr.length; i++) {
        let splitted = arr[i].split(' - ');
        let index = splitted[0];
        let value = splitted[1];

        args[index] = value;
    }

    for (let j = 0; j < count; j++) {
        if(args[j] === undefined){
            console.log(0);
        }else{
            console.log(args[j]);
        }
    } 
}

indexAnArray(['3', '0 - 5', '1 – 6', '2 – 7']);