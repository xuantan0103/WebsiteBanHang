const mota = document.querySelector(".mota")
const thongtinkhac = document.querySelector(".thongtinkhac")
if(mota){
    mota.addEventListener("click",function(){
        document.querySelector(".product-content-right-bottom-content-mota").style.display = "block"
        document.querySelector(".product-content-right-bottom-content-thongtinkhac").style.display = "none"
        
    })
}
if(thongtinkhac){
    thongtinkhac.addEventListener("click",function(){
        document.querySelector(".product-content-right-bottom-content-mota").style.display = "none"
        document.querySelector(".product-content-right-bottom-content-thongtinkhac").style.display = "block"
        
    })
}
const button = document.querySelector(".product-content-right-bottom-top")
if(button){
    button.addEventListener("click",function(){
        document.querySelector(".product-content-right-bottom-content-big").classList.toggle("activeB")
    }
    )
}

const bigImg = document.querySelector(".product-content-left-big-img img")
const smalImg = document.querySelectorAll(".product-content-left-small-img img")
smalImg.forEach(function(imgItem,x){
    imgItem.addEventListener("click",function(){
        bigImg.src = imgItem.src
    })
})