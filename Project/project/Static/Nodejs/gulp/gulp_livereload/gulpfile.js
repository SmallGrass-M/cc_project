  const gulp = require('gulp');
  const livereload = require('gulp-livereload');

  // 创建监听任务 （watch监听的名字|default为默认参数，gulp默认执行的任务）
  gulp.task('default', function () {
      gulp.watch('www/*.*', function (file) {
          // console.log(file.path);
          livereload.changed(file.path);
      });
  });
  livereload.listen();
