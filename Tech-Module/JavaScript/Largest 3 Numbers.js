function largest3Numbers(arr) {
    arr = arr.map(Number);

    let sorted = arr.sort((a, b) => b-a);

    let count = Math.min(3, arr.length);

    for (let i = 0; i < count; i++) {
        console.log(sorted[i]);
    }
}

largest3Numbers(['10', '30', '15', '20', '50', '5'])