define ['backbone'], ->
  Backbone.Model.extend do
    defaults: ->
      title: 'empty todo...'
      order: Todos.nextOrder()
      done: false
    toggle: ->
      @save { done: (!@get 'done') }

