function addOrDelete(line) {
    let args = [];

    for (let i = 0; i < line.length; i++) {
       let temp = line[i].split(' ');
       let command = temp[0];

       if(command === "add"){
           let element = (Number)(temp[1]);
           args.push(element);
       }else if(command === "remove"){
           let index = (Number)(temp[1]);
           args.splice(index, 1);

       }
    }
    console.log(args.join('\n'));
}

addOrDelete(['add 3' , "add 5",'remove 1', "add 2"])