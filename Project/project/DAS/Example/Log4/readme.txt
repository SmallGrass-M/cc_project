从 nuget 安装 log4

layout节点的配置说明：
        %m(message):输出的日志消息；
        %n(newline):换行；
        %d(datetime/date):输出当前语句运行的时刻；
        %r(runtime):输出程序从运行到执行到当前语句时消耗的毫秒数；
        %t(threadid):当前语句所在的线程ID ；
        %p(priority/level): 日志的当前日志级别；
        %c(class/logger):当前日志对象的名称；
        %L：输出语句所在的行号；
        %F：输出语句所在的文件名； 
        %-10：表示最小长度为10，如果不够，则用空格填充；