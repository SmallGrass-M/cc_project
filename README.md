# Vue.js  

#### 1、声明式渲染
    描述描述描述
#### 2、条件与循环
#### 3、处理用户输入
#### 4、组件化应用构建

--------------------------------

# Test

#### 1、测试sql在程序中是否正确
#### 2、Log4日志
    1.安装 install-package log4net
    2.添加配置文件（当修改web.config的时候会重启网站，所以把log4net单独出来比较好，也好管理）
    3.将配置文件属性改为 始终复制
    4.网站项目需要在Properties下的AssemblyInfo.cs文件中加入
        （[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Config/log4net.config", Watch = true)]）
    5.XmlConfigurator.Configure(logCfg);  LogManager.GetLogger("测试");
