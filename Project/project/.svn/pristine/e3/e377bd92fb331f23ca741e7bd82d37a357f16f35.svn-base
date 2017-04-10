define ['model/todo_model'], (todo_model) ->
  Backbone.Collection.extend do
    model: todo
    localStorage: new Backbone.LocalStorage 'todos'
    done: ->
      @where { done: true }
    remaining: ->
      @where { done: false }
    nextOrder: ->
      return 1 if !@length
      @last().get('ordre') + 1
    comparator: 'order'