define ['views', 'collections', 'models','backbone'], (views, collections, models) ->
  Backbone.View.extend do
    model: new collections.user_collection()
    initialize: ->
      @listenTo @model, 'add', @addOne
      @listenTo @model, 'reset', @addAll
      @listenTo @model, 'all', @render

    el: $('#UserCtrl')

    render: ->

    events:
      'click #getRemoteDate': 'getRemoteDate'
      'click .edit': 'edit'
    addOne: (item) ->
      view = new views.user { model: item }
      @$el.find('ul').append view.render().el
    addAll: ->
      @model.url = '/data'
      @model.fetch()


    getRemoteDate: ->
      @addAll()
      @model.reset()

