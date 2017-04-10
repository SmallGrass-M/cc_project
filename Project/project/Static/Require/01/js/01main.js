/**
 * Created by wangze1 on 2016/11/8.
 */

// 如果为模块声明了名字后，调用时必须为模块设置别名（paths）,而且名字必须与模块名一致（可以通过jquery文件测试一下）
define("main",function(){
    return {
        txt:"这是一个新建的模块"
    }
})