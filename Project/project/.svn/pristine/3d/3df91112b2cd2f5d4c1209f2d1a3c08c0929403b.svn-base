define ['collections', 'template', 'backbone', 'jquery'], (collections, template) ->
  Backbone.View.extend do
    model: {}
    initialize: ->
      @listenTo @model, 'change', @render
      @listenTo @model, 'destroy', @remove
#      @listenTo @model, 'sync', @sync
    tagName: 'li'
    render: ->
      model =  @model.toJSON()
      @$el.html(template('user', model))
      @
    events:
      'click .edit': 'edit'
      'click .del' : 'delete'
    edit: ->
      console.log @model.toJSON()
      @model.set 'name', @$el.find('[name=name]').val()
      @model.set 'age', +@$el.find('[name=age]').val()
      @model.set 'sex', @$el.find('[name=sex]').val()
      console.log @model.toJSON()


    delete: ->
      @$el.remove()

    clear: ->
      @model.destory()
    sync: (key, val, opt) ->
      console.log key, val
      console.log opt

