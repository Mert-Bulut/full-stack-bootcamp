function Ekle(){
    var alisverisEkle = document.getElementById("alisverisEkle");
    var liste = document.getElementById("liste");
    var yeniOge = document.createElement("li");
    yeniOge.innerText = alisverisEkle.value;

    if(alisverisEkle.value !== ""){
        liste.appendChild(yeniOge);
        alisverisEkle.value="";


        yeniOge.onclick = function(){
            var yeniMetin = prompt("Yeni değeri giriniz:")
            if(yeniMetin !== null && yeniMetin !== ""){
                this.firstChild.nodeValue = yeniMetin;
            }
        }

        yeniOge.addEventListener("contextmenu", function(e){
            e.preventDefault();
            this.parentNode.removeChild(yeniOge);
        });
    }
    else{
        alert("Lütfen bir öğe giriniz.")
    }
}

function listeTemizle(){
    var liste = document.getElementById("liste")
    liste.innerHTML = "";
}