function validate(obj){

    if (!["GET", "POST", "DELETE", "CONNECT"].includes(obj["method"])){
        throw new Error('Invalid request header: Invalid Method');
    } 
    if(!["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"].includes(obj["version"])){
        throw new Error('Invalid request header: Invalid Version');
    }
    if(obj["message"] === undefined || obj["message"] == '' || !obj["message"].match(/([\<\>\\\&\'\"])/g) === undefined){
        throw new Error('Invalid request header: Invalid Message');
    }
    if( obj["uri"] === undefined || obj["uri"] == '' || !obj["uri"].match(/([^a-zA-Z.])/g) === undefined ){
        throw new Error('Invalid request header: Invalid URI');
    }
   return obj;
}