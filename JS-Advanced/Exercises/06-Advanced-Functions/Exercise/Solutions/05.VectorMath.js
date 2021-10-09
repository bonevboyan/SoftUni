let sol = (function solution() {
    return {
        add : (vector1, vector2) => {
            return [vector1[0] + vector2[0], vector1[1] + vector2[1]];
        },
        multiply : (vector, multiplier) => {
            return [vector[0] * multiplier, vector[1]*multiplier];
        },
        length : (vector)=>{
            return Math.sqrt(Math.pow(vector[0], 2) + Math.pow(vector[1], 2));
        },
        dot : (vector1, vector2)=>{
            return vector1[0]*vector2[0] + vector1[1] * vector2[1];
        },
        cross : (vector1, vector2) => {
            return vector1[0]*vector2[1] - vector1[1]*vector2[0];
        }
    }
})();