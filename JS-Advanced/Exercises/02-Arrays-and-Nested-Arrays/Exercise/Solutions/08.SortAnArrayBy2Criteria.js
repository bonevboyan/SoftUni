function sort(arr){
    arr.sort(function(a, b) {
      return a.length - b.length || a.localeCompare(b)
    })
    console.log(arr)
}