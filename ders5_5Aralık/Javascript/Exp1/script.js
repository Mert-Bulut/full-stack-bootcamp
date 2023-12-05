var sayi = 5;
var name = "John";
const pi = 3.14;

var meyveler = ["elma","armut","muz","çilek"];

function selamVer(isim){
    console.log("Merhaba," + isim + "!");
}

if(sayi > 3){
    console.log("Sayi 3'ten büyüktür!");
}
else{
    console.log("Sayi 3'ten küçük veya eşittir!");
}

for(var i = 0 ; i < meyveler.length; i++){
    console.log(meyveler[i])
}

selamVer("Mert");