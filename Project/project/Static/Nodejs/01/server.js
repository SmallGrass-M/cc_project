const http = require("http");
const fs = require("fs");
const querystring = require("querystring");
const urlLib = require("url");

var server = http.createServer(function(request,response){
  var rObj = urlLib.parse(request.url , true);
  if(rObj.pathname.indexOf("favicon.ico") > -1){
    return;
  //接口请求
  }else if(rObj.pathname.indexOf(".do") > -1){
    var data = {};
    //get请求
    if(rObj.search){
      console.log("这是一个get请求");
      data = rObj.query;
      console.log("请求的参数为",data);
      response.end();
    }else{
      //post请求
      console.log("这是一个post请求");
      var dataArr = new Array();
      request.on("data" , function(data,error){
          dataArr.push(data);
      });
      request.on("end" , function(error,data){
        if(dataArr.length > 0){
          data = querystring.parse(dataArr.join(''));
        }
        console.log("请求的参数为",data);
        response.end();
      });
    }
  }else{
    var fileName = "../gulp/gulp_livereload/www" + rObj.pathname;
    fs.exists(fileName , (exists) => {
      if(exists){
        fs.readFile(fileName,function(error,data){
          if(error){
            console.log("出错啦");
          }else{
            response.write(data);
          }
          response.end();
        })
      }else{
          response.write("404");
          response.end();
      }
    })
  }
});
server.listen(8090);
