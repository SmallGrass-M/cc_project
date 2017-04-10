(function(){
  define(['backbone'], function(){
    return Backbone.Model.extend({
      defaults: {
        url: '/url',
        text: 'text'
      }
    });
  });
}).call(this);
