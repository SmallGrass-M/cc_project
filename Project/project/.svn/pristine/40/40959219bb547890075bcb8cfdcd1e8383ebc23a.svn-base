// 设置cookie
function SetCookieName(key , value){
  if(window.localStorage){
    window.localStorage.setItem(key , value);
  }else{
    var exdate = new Date()
    exdate.setDate(exdate.getTime() -1)
    document.cookie = key + "=" + escape(value) + ";expires=" + exdate.toGMTString()
  }
}

// 获取cookie
function GetCookieName(key){
  if(window.localStorage){
    var value = window.localStorage.getItem(key);
    if(!value){
      return null;
    }
    return value;
  }else{
    var arr,reg=new RegExp("(^| )" + key + "=([^;]*)(;|$)");
    if(arr = document.cookie.match(reg)){
      return unescape(arr[2]);
    }
    else{
      return null;
    }
  }
}
