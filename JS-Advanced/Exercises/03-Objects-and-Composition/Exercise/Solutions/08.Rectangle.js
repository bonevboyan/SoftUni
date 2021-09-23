function rectangle(width, height, color) {
    color = color[0].toUpperCase() + color.slice(1);
    let obj = {
        width: width,
        height: height,
        color: color,
        calcArea() {
            return this.width * this.height;
        }
    }
    return obj;
}