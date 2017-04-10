define ['backbone', 'jquery'], ->
  Backbone.View.extend do
    initialize: ->
      @listenTo @model, 'change', @render
      @listenTo @model, 'destroy', @remove
    tagName: 'li'
    template: _.template $('#item-template').html()
    events:
      'click .toggle': 'toggleDone'
      'dblclick .view': 'edit'
      'click a.destroy': 'clear'
      'keypress .edit': 'updateOnEnter'
      'blur .edit': 'close'
    toggleDone: ->
      @model.toggle()
    edit: ->
      @$el.addClass 'editing'
      @input.focus()
    close: ->
      value = @input.val()

    updateOnEnter: ->
      if e.keyCode == 13 then @close()

    clear: ->
      @model.destory()

