function printReverse(arr) {
    let nums = arr.map(Number);

    nums = nums.reverse();

    console.log(nums.join('\n'));
}

printReverse(['12', '10', '13']);