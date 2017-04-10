const express = require('express');
const expressStatic = require('express-static');
const bodyParser = require('body-parser');
const multer  = require('multer');
var server = express();

/*
server.use(function(req , res , next){
  console.log(req);

  next();
});
*/
server.use(expressStatic('./www'));
server.use(bodyParser.urlencoded());
server.use(multer({dest:'./uploads'}).any());

/*
server.post('/login' , function(req , res){
  console.log(req.query);
  console.log(req.body);
  console.log(req.files);
  res.send('OK');
});
*/

// 链式路由
var testRoute = server.route("/login(/*)?");
testRoute.get(function(req , res){
    res.send('testRoute');
})

server.listen(8080);
