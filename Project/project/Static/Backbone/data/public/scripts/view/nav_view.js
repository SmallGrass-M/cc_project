(function () {
  define(['models', 'collections', 'template', 'jquery', 'backbone'], function (models, collections, template) {
    var itemView = Backbone.View.extend({
      tagName   : 'li',
      initialize: function () {
        this.listenTo(this.model, 'change', this.render);
      },
      render    : function () {
        var html = template('navView', this.model.toJSON());
        this.$el.html(html);
        return this;
      },
      events    : {
        'click #editColor': 'editColor'
      },
      editColor : function () {
        this.$el.find('a').css('color','red');

      }
    });

    var outView = Backbone.View.extend({

    });

    var view = Backbone.View.extend({
      el        : $('#nav'),
      model     : new collections.nav(),
      initialize: function () {
        //var list = new collections.nav();
        //list.add({text: '1'});
        //list.add({text: '2'});
        //this.model = list;

        this.listenTo(this.model, 'add', this.addOne);

        this.model.url = '/data';
        this.model.fetch();
      },
      render    : function () {
        var html = template('navView', {list: this.model.toJSON()});
        this.$el.html(html);
      },

      addOne: function (item) {
        var itView = new itemView({model: item});
        this.$el.append(itView.render().el);
      }
    });
    return view;
  });
}).call(this);
