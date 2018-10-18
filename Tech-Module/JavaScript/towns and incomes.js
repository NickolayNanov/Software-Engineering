function sumsByTown(arr) {
    let objs = arr.map(JSON.parse);
    let towns = {};

    for (let obj of objs) {
        if (!towns[obj.town]) {
            towns[obj.town] = 0;
        }

        towns[obj.town] += obj.income;
    }
    let townsNames = Object.keys(towns).sort()

    for (let name of townsNames) {
        console.log(`${name} -> ${towns[name]}`);
    }
}


sumsByTown([
    '{"town":"Sofia","income":200}',
    '{"town":"Varna","income":120}',
    '{"town":"Pleven","income":60}',
    '{"town":"Varna","income":70}',
])
