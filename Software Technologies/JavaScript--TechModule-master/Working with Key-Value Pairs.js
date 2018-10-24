function matching(arr) {
    let obj = [{}];

    while ((arr)) 
    for (let i = 0; i < arr.length; i++) {
        let line = arr[i].split(' ');

        let key = line[0];
        let value = line[1];

        if(!obj[key]){
            obj[key] = value;
        }
    }
    console.log(obj)
}

matching(['key value', 'key eulav', 'test tset'])