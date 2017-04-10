/**
 * Created by wangze1 on 2016/11/8.
 */

// baseUrl 默认地址为当前js文件所在文件夹，如果设置了baseUrl属性 地址将从调用页所在文件夹
// 如未显式设置baseUrl，则默认值是加载require.js的HTML所处的位置。如果用了data-main属性，则该路径就变成baseUrl。(官方)
requirejs.config({
    baseUrl:'../lib',
    paths:{
        jquery:'jquery-3.1.0',
        main:'../01/js/01main'
    }
})

require(['jquery','main'],function($,main){
    $("div").html(main.txt);
})